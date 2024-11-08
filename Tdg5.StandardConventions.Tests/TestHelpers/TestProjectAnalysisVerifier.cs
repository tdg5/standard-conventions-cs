using System.Security.Cryptography;
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
        List<ICodeAnalysisViolationExpectation> codeAnalysisViolationExpectations =
            filesRequiringVerification.SelectMany(filePath =>
                ExpectationExtractor
                    .ExtractExpectations(projectPath, filePath)).ToList();
        List<ICodeAnalysisViolation> codeAnalysisViolations = [
            .. warningsAndErrors.Warnings.Select(warning =>
                new CodeAnalysisViolation(
                    code: warning.Code,
                    filePath: warning.File,
                    level: "Warning",
                    lineNumber: warning.LineNumber,
                    message: warning.Message,
                    projectPath: projectPath)),
            .. warningsAndErrors.Errors.Select(error =>
                new CodeAnalysisViolation(
                    code: error.Code,
                    filePath: error.File,
                    level: "Error",
                    lineNumber: error.LineNumber,
                    message: error.Message,
                    projectPath: projectPath)),
        ];

        List<ICodeAnalysisViolation> unexpectedCodeViolations = [];

        List<ICodeAnalysisViolationExpectation> unmatchedExpectations =
            [.. codeAnalysisViolationExpectations];

        foreach (var violation in codeAnalysisViolations)
        {
            var foundMatch = false;

            // Check the unmatched expectations first.
            foreach (var expectation in unmatchedExpectations)
            {
                if (expectation.IsMatch(violation))
                {
                    foundMatch = true;
                    unmatchedExpectations.Remove(expectation);
                    break;
                }
            }

            if (!foundMatch)
            {
                foreach (var expectation in codeAnalysisViolationExpectations)
                {
                    if (expectation.IsMatch(violation))
                    {
                        foundMatch = true;
                        break;
                    }
                }
            }

            if (!foundMatch)
            {
                unexpectedCodeViolations.Add(violation);
            }
        }

        MakeAssertion(unexpectedCodeViolations, unmatchedExpectations);
    }

    private static void MakeAssertion(
        List<ICodeAnalysisViolation> unexpectedCodeViolations,
        List<ICodeAnalysisViolationExpectation> unmatchedExpectations)
    {
        var unexpectedCodeViolationsFailureMessage =
            $"Unexpected code analysis violations were emitted:"
            + $"{Environment.NewLine}  "
            + string.Join(
                Environment.NewLine,
                unexpectedCodeViolations.Select(CodeViolationToString));

        var unresolvedExpectations = unmatchedExpectations
            .Where(expectation => expectation.Enabled)
            .ToList();

        var unresolvedExpectationsFailureMessage =
            $"Expected code analysis violations were not emitted:"
            + $"{Environment.NewLine}  "
            + string.Join(
                Environment.NewLine,
                unresolvedExpectations
                    .Select(expectation => expectation.ToStringDescription()));

        if (unexpectedCodeViolations.Count + unresolvedExpectations.Count == 0)
        {
            Assert.True(true);
            return;
        }

        if (unexpectedCodeViolations.Count > 0 && unresolvedExpectations.Count > 0)
        {
            var fullMessage = Environment.NewLine
                + unexpectedCodeViolationsFailureMessage
                + Environment.NewLine
                + unresolvedExpectationsFailureMessage;

            // This will fail, so no short-circuiting is necessary.
            Assert.True(
                unexpectedCodeViolations.Count + unresolvedExpectations.Count == 0,
                fullMessage);
            return;
        }

        if (unexpectedCodeViolations.Count > 0)
        {
            // This will fail, so no short-circuiting is necessary.
            Assert.True(
                unexpectedCodeViolations.Count == 0,
                unexpectedCodeViolationsFailureMessage);
        }

        Assert.True(
            unresolvedExpectations.Count == 0,
            unresolvedExpectationsFailureMessage);
    }

    private static string CodeViolationToString(ICodeAnalysisViolation violation)
    {
        return $"{violation.Level}: {violation.Code} - {violation.Message}"
            + Environment.NewLine
            + $"  {violation.FilePath}:{violation.LineNumber}";
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

        return uniqueFilePaths.Where(filePath => filePath.EndsWith(".cs")).ToArray();
    }
}
