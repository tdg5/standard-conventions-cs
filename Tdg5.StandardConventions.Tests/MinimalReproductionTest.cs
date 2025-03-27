using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using System.Collections.Immutable;
using Tdg5.StandardConventions.Tests.TestHelpers;
using Xunit.Abstractions;

namespace Tdg5.StandardConventions.Tests;

/// <summary>
/// Test case demonstrating a minimal reproduction of a diagnostic issue that
/// arose in .NET 9.0.200.
/// </summary>
public class MinimalReproductionTest : BaseTestProjectAnalysisVerifierTest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MinimalReproductionTest"/> class.
    /// </summary>
    /// <param name="testOutputHelper">The test output helper.</param>
    public MinimalReproductionTest(ITestOutputHelper testOutputHelper)
        : base(testOutputHelper)
    {
    }

    /// <summary>
    /// Gets a version of the project path that can be used as member data.
    /// </summary>
    public static List<object[]> TheProjectPaths { get; } = [
        ["Data/StyleCopRules/StyleCopRules.csproj"],
        [Environment.GetEnvironmentVariable("ROOT_PROJECT_PATH")!]
    ];

    /// <inheritdoc/>
    public override string ProjectPath => (TheProjectPaths[0][0] as string)!;

    /// <summary>
    /// The minimum reproduction.
    /// </summary>
    /// <param name="projectPath">The project to run diagnostics on.</param>
    /// <returns>A task representing the completion of the test.</returns>
    [Theory]
    [MemberData(nameof(TheProjectPaths))]
    public async Task MinimumReproduction(string projectPath)
    {
        var workspace = MSBuildWorkspace.Create();
        var project = await workspace.OpenProjectAsync(projectPath);
        var analyzers = project
            .AnalyzerReferences
            .SelectMany(r => r.GetAnalyzers(project.Language))
            .ToImmutableArray();
        Dictionary<string, List<string>> diagnosticIdsByAnalyzer = [];
        foreach (var analyzerReference in project.AnalyzerReferences)
        {
            var analyzerId = analyzerReference.Id.ToString() ?? "NO_ANALYZER_ID";
            var analyzerName = analyzerId[..analyzerId.IndexOf(',')];
            List<string> ids;
            if (!diagnosticIdsByAnalyzer.TryGetValue(analyzerName, out ids!))
            {
                ids = [];
                diagnosticIdsByAnalyzer[analyzerName] = ids;
            }

            foreach (var analyzer in analyzerReference.GetAnalyzers(project.Language))
            {
                foreach (var diagnostic in analyzer.SupportedDiagnostics)
                {
                    ids.Add(diagnostic.Id);
                }
            }
        }

        var cSharpCodeStyleDiagnosticIds =
            Assert.Contains("Microsoft.CodeAnalysis.CSharp.CodeStyle", diagnosticIdsByAnalyzer);
        var codeStyleDiagnosticIds =
            Assert.Contains("Microsoft.CodeAnalysis.CodeStyle", diagnosticIdsByAnalyzer);

        Assert.Contains("IDE0040", cSharpCodeStyleDiagnosticIds);
        Assert.Contains("IDE0055", cSharpCodeStyleDiagnosticIds);
        Assert.Contains("IDE0033", codeStyleDiagnosticIds);
        Assert.Contains("IDE0070", codeStyleDiagnosticIds);
    }
}
