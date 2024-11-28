using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.IDE0077;

/// <summary>
/// This project should cause a IDE0077 warning because of a legacy target
/// in GlobalSuppressions.cs.
/// </summary>
[ProjectAnalysisViolationExpected("IDE0077", "Warning")]
public class ProjectScopedExpectations
{
    public static void Method()
    {
    }
}
