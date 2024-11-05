using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.TestHelpers;

/// <summary>
/// Builds and analyzes a test project to verify that all expected analysis
/// warnings and errors are emitted and no others.
/// </summary>
public class TestProjectAnalysisVerifier
{
    private readonly TestProjectBuilder testProjectBuilder;

    /// <summary>
    /// Initializes a new instance of the <see cref="TestProjectAnalysisVerifier"/>
    /// class.
    /// </summary>
    /// <param name="testProjectBuilder">The <see cref="TestProjectBuilder"/> to use
    /// for building the test project.</param>
    public TestProjectAnalysisVerifier(TestProjectBuilder testProjectBuilder)
    {
        this.testProjectBuilder = testProjectBuilder;
    }

    /// <summary>
    /// Verifies that the project at the specified path emits the expected warnings
    /// and errors, as defined by attributes applied to the project's source files.
    /// </summary>
    /// <param name="projectPath">The path to the project file to verify.</param>
    /// <remarks>
    /// Plan of attack:
    /// 3. Interpret the files that emitted warnings and errors to determine the
    /// attributes that have been applied and the range of lines that the attributes
    /// apply to; turn that data into instances of some other class (i.e. not
    /// the attribute).
    /// 4. Combine the attribute data to make some kind of queryable thing.
    /// 5. Query the queryable thing to determine if the expected analysis codes
    /// are present and that all analysis codes are expected.
    /// 6. Hide all of that from this test so all this test needs to do is build
    /// a project file.
    /// </remarks>
    public void VerifyProject(string projectPath)
    {
        var buildResult = this.testProjectBuilder.BuildProject(projectPath);
        var warningsAndErrors = buildResult.WarningsAndErrors;
        var filesRequiringVerification =
            GetPathsOfFilesRequiringVerification(buildResult);
        var codeAnalysisViolationExpectations =
            filesRequiringVerification.SelectMany(Analyzer.Analyze).ToList();
        List<ICodeAnalysisViolation> codeAnalysisViolations = [
            ..warningsAndErrors.Warnings.Select(warning =>
                new CodeAnalysisViolation(
                    code: warning.Code,
                    level: "Warning",
                    filePath: warning.File,
                    lineNumber: warning.LineNumber,
                    message: warning.Message)),
            ..warningsAndErrors.Errors.Select(error =>
                new CodeAnalysisViolation(
                    code: error.Code,
                    level: "Error",
                    filePath: error.File,
                    lineNumber: error.LineNumber,
                    message: error.Message))];

        var unexpectedCodeViolations = codeAnalysisViolations.Where(
            violation => !codeAnalysisViolationExpectations.Any(
                expectation => expectation.IsMatch(violation)));

        var assertionFailureMessage =
            $"Unexpected code analysis violations were emitted:"
            + Environment.NewLine
            + string.Join(Environment.NewLine, unexpectedCodeViolations);
        Assert.False(unexpectedCodeViolations.Any(), assertionFailureMessage);
    }

    private static string[] GetPathsOfFilesRequiringVerification(
        TestProjectBuildResult buildResult)
    {
        var uniqueFilePaths = new HashSet<string>();
        foreach (var warning in buildResult.WarningsAndErrors.Warnings)
        {
            uniqueFilePaths.Add(warning.File);
        }

        foreach (var error in buildResult.WarningsAndErrors.Errors)
        {
            uniqueFilePaths.Add(error.File);
        }

        foreach (var filePath in buildResult.CompileFilePaths)
        {
            uniqueFilePaths.Add(filePath);
        }

        return [.. uniqueFilePaths];
    }
}
