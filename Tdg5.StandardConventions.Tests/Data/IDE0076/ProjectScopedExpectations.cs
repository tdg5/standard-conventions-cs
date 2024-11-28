using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.IDE0076;

/// <summary>
/// This project should cause a IDE0076 warning because of an invalid reference
/// in GlobalSuppressions.cs.
/// </summary>
[ProjectAnalysisViolationExpected("IDE0076", "Warning")]
public class ProjectScopedExpectations
{
}
