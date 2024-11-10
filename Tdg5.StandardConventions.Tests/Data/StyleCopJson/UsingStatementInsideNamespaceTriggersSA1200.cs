using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson
{
    // This using statement should cause the SA1200 violation.
    using System;

    /// <summary>
    /// Class to attach attribute to. The using statement above should cause the
    /// violation.
    /// </summary>
    [FileAnalysisViolationExpected("SA1200", "Warning")]
    public class UsingStatementInsideNamespaceTriggersSA1200
    {
    }
}
