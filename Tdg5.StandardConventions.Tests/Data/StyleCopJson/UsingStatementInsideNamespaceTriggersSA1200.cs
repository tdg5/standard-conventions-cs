using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson
{
    using System;

    /// <summary>
    /// The using statement above should cause an SA1200 violation.
    /// </summary>
    [FileAnalysisViolationExpected("SA1200", "Warning")]
    public class UsingStatementInsideNamespaceTriggersSA1200
    {
    }
}
