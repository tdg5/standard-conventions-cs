using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.SA0002;

/// <summary>
/// This project should cause a SA0002 warning because stylecop.json is malformed.
/// </summary>
[ProjectAnalysisViolationExpected("SA0002", "Warning")]
public class ProjectScopedExpectations
{
}
