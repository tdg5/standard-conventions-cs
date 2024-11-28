using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.EditorConfigRules
{
    using System;

    /// <summary>
    /// The using statement above should cause an IDE0065 violation.
    /// </summary>
    /// <remarks>
    /// Also triggers a violation for IDE0005.
    /// </remarks>
    [FileAnalysisViolationExpected("IDE0005", "Warning")]
    [FileAnalysisViolationExpected("IDE0065", "Warning")]
    public class IDE0065_UsingStatementPlacement
    {
    }
}
