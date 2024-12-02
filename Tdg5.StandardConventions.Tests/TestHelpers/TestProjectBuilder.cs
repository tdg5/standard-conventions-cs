using Microsoft.Build.Evaluation;
using Microsoft.Build.Framework;
using System.Collections;
using Xunit.Abstractions;

namespace Tdg5.StandardConventions.Tests.TestHelpers;

/// <summary>
/// Helper class for building test projects.
/// </summary>
public class TestProjectBuilder
{
    /// <summary>
    /// Gets the default global properties to use when building projects when no
    /// other global properties are specified.
    /// </summary>
    public static readonly Dictionary<string, string> DefaultGlobalProperties = new()
    {
        ["Configuration"] = "Debug",
        ["Platform"] = "AnyCPU",
    };

    private readonly MsBuildTestOutputLogger testOutputLogger;

    private readonly ITestOutputHelper testOutputHelper;

    private readonly Dictionary<string, string> globalProperties;

    /// <summary>
    /// Initializes a new instance of the <see cref="TestProjectBuilder"/> class.
    /// </summary>
    /// <param name="testOutputHelper">The <see cref="ITestOutputHelper"/> that
    /// should be used for logging build output.</param>
    /// <param name="globalProperties">The global properties to use when building
    /// projects.</param>
    public TestProjectBuilder(
        ITestOutputHelper testOutputHelper,
        Dictionary<string, string>? globalProperties = null)
    {
        this.globalProperties = globalProperties ?? DefaultGlobalProperties;
        this.testOutputHelper = testOutputHelper;
        testOutputLogger =
            new MsBuildTestOutputLogger(testOutputHelper, verbose: false);
    }

    /// <summary>
    /// Builds the specified project.
    /// </summary>
    /// <param name="projectPath">The path to the project file.</param>
    /// <returns>An instance of <see cref="TestProjectBuildResult"/> containing
    /// information about the result of the build.</returns>
    public TestProjectBuildResult BuildProject(string projectPath)
    {
        MsBuildWarningAndErrorLogger warningAndErrorLogger = new();
        List<ILogger> allLoggers = [warningAndErrorLogger, testOutputLogger];
        var projectCollection = new ProjectCollection(globalProperties);
        var project = projectCollection.LoadProject(projectPath);
        var restored = project.Build("restore", allLoggers);
        if (!restored)
        {
            LogEnvironmentAndProperties(project);
        }

        // Force the project to be reevaluated so it will notice props from
        // restored dependencies.
        project.MarkDirty();
        project.ReevaluateIfNecessary();

        var result = project.Build("build", allLoggers);
        var outputPath = project.GetPropertyValue("TargetPath");

        Assert.True(
            result,
            $"Build failed: {testOutputLogger.ErrorMessage}");

        var diagnostics =
            new TestProjectAnalyzer(globalProperties).AnalyzeProject(projectPath);

        return new(
            compileFilePaths: GetCompileFilesFullPaths(project),
            diagnostics: diagnostics,
            outputPath: outputPath,
            warningsAndErrors: warningAndErrorLogger);
    }

    private static string[] GetCompileFilesFullPaths(Project project)
    {
        var projectDirectoryPath = Path.GetDirectoryName(project.FullPath);
        return project.GetItems("Compile")
            .Select(_ =>
            {
                string compileFilePath =
                    Path.Join(projectDirectoryPath, _.EvaluatedInclude);

                if (!File.Exists(compileFilePath))
                {
                    throw new FileNotFoundException(
                        $"Referenced compile file not found: {compileFilePath}");
                }

                return compileFilePath;
            })
            .ToArray();
    }

    /// <summary>
    /// Logs the environment variables and properties of the specified project.
    /// </summary>
    /// <param name="project">The project to log the environment variables and
    /// properties of.</param>
    private void LogEnvironmentAndProperties(Project project)
    {
        var environmentVariables = Environment
            .GetEnvironmentVariables()
            .Cast<DictionaryEntry>()
            .OrderBy(_ => _.Key);

        foreach (var keyValuePair in environmentVariables)
        {
            testOutputHelper.WriteLine($"{keyValuePair.Key}:{keyValuePair.Value}");
        }

        foreach (var property in project.AllEvaluatedProperties.OrderBy(_ => _.Name))
        {
            testOutputHelper.WriteLine(
                $"{property.Name}:{property.EvaluatedValue}({property.UnevaluatedValue})");
        }
    }
}
