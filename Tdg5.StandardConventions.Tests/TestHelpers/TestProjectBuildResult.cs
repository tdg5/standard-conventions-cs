namespace Tdg5.StandardConventions.Tests.TestHelpers;

/// <summary>
/// Collects various information about the result of a <see
/// cref="TestProjectBuilder.BuildProject"/>.
/// </summary>
public class TestProjectBuildResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TestProjectBuildResult"/>
    /// class.
    /// </summary>
    /// <param name="compileFilePaths">The paths to files that were compiled during
    /// the build.</param>
    /// <param name="outputPath">The path to the output of the build.</param>
    /// <param name="warningsAndErrors">The collection of warnings and
    /// errors emitted during the build.</param>
    public TestProjectBuildResult(
        string[] compileFilePaths,
        string outputPath,
        IMsBuildWarningAndErrorCollection warningsAndErrors)
    {
        this.CompileFilePaths = compileFilePaths;
        this.OutputPath = outputPath;
        this.WarningsAndErrors = warningsAndErrors;
    }

    /// <summary>
    /// Gets the paths to files that were compiled during the build.
    /// </summary>
    public string[] CompileFilePaths { get; }

    /// <summary>
    /// Gets the path to the output of the build.
    /// </summary>
    public string OutputPath { get; }

    /// <summary>
    /// Gets the collection of warnings and errors emitted during the build.
    /// </summary>
    public IMsBuildWarningAndErrorCollection WarningsAndErrors { get; }
}
