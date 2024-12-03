namespace Tdg5.StandardConventions.Tests.Data.EditorConfigRules
{
    using Tdg5.StandardConventions.TestAnnotations;

    /// <summary>
    /// The using statement above should cause an IDE0065 violation.
    /// </summary>
    [FileAnalysisViolationExpected("IDE0065", "Warning")]
    [FileAnalysisViolationExpected("IDE0161", "Warning")]
    public class IDE0065_UsingStatementPlacement
    {
    }
}
