using static System.Math;
using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopRules
{
    /// <summary>
    /// Class to attach attribute to. The static using statement before other
    /// using statements above should cause the violation.
    /// </summary>
    [FileAnalysisViolationExpected("SA1216", "Warning")]
    public class SA1216_UsingStaticDirectivesMustBePlacedAtTheCorrectLocation
    {
    }
}
