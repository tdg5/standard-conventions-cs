namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.OrderingRules
{
    using Tdg5.StandardConventions.TestAnnotations;

    /// <summary>
    /// The using statement above should cause an SA1200 violation.
    /// </summary>
    [FileAnalysisViolationExpected("IDE0065", "Warning")]
    [FileAnalysisViolationExpected("IDE0161", "Warning")]
    [FileAnalysisViolationExpected(
        "SA1200",
        "Warning",
        disabledReason: "SA1200 is disabled in favor of IDE0065")]
    public class UsingStatementInsideNamespace
    {
    }
}
