using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.OrderingRules
{
    using System;

    /// <summary>
    /// The using statement above should cause an SA1200 violation.
    /// </summary>
    /// <remarks>
    /// Also triggers a violation for IDE0005 and IDE0065.
    /// </remarks>
    [FileAnalysisViolationExpected("IDE0005", "Warning")]
    [FileAnalysisViolationExpected("IDE0065", "Warning")]
    [FileAnalysisViolationExpected(
        "SA1200",
        "Warning",
        disabledReason: "SA1200 is disabled in favor of IDE0065")]
    public class UsingStatementInsideNamespace
    {
    }
}
