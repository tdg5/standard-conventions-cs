using SystemAlias = System;
using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopRules
{
    /// <summary>
    /// Class to attach attribute to. The SystemAlias using statement above
    /// should cause the violation.
    /// </summary>
    /// <remarks>
    /// Also triggers a violation for IDE0005.
    /// </remarks>
    [FileAnalysisViolationExpected("IDE0005", "Warning")]
    [FileAnalysisViolationExpected("SA1209", "Warning")]
    public class SA1209_UsingAliasDirectivesMustBePlacedAfterOtherUsingDirectives
    {
    }
}
