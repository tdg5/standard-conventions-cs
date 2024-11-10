using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.SA0001;

/// <summary>
/// The project should trigger a warning for SA0001 because the project file
/// sets GenerateDocumentationFile to false.
/// </summary>
[ProjectAnalysisViolationExpected("SA0001", "Warning")]
public class ProjectScopedExpectations
{
}
