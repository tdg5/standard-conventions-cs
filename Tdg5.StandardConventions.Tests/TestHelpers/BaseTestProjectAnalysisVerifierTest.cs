using Xunit.Abstractions;

namespace Tdg5.StandardConventions.Tests.TestHelpers;

/// <summary>
/// Base class for tests that build a test project to verify that all expected
/// analysis warnings and errors are emitted and no others.
/// </summary>
[Collection("RequiresMsBuild")]
public abstract class BaseTestProjectAnalysisVerifierTest
{
    private readonly TestProjectAnalysisVerifier analysisVerifier;

    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="BaseTestProjectAnalysisVerifierTest"/> class.
    /// </summary>
    /// <param name="testOutputHelper">The test output helper.</param>
    public BaseTestProjectAnalysisVerifierTest(ITestOutputHelper testOutputHelper)
    {
        analysisVerifier = new TestProjectAnalysisVerifier(
            testProjectBuilder: new TestProjectBuilder(testOutputHelper));
    }

    /// <summary>
    /// Gets the path to the project file to verify.
    /// </summary>
    public abstract string ProjectPath { get; }

    /// <summary>
    /// Experimenal test.
    /// </summary>
    [Fact]
    public void ExpectedCodeAnalysisViolationsAreEmittedDuringBuild()
    {
        analysisVerifier.VerifyProject(ProjectPath);
    }
}
