using Tdg5.StandardConventions.TestAnnotations;
using static System.Math;
using static System.Console;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopRules
{
    /// <summary>
    /// Class to attach attribute to. The out-of-order static using statements
    /// above should cause the violation.
    /// </summary>
    /// <remarks>
    /// Also triggers a violation for IDE0005.
    /// </remarks>
    [FileAnalysisViolationExpected("IDE0005", "Warning")]
    [FileAnalysisViolationExpected("SA1217", "Warning")]
    public class SA1217_UsingStaticDirectivesMustBeOrderedAlphabetically
    {
    }
}
