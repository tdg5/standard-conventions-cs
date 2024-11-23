using Tdg5.StandardConventions.TestAnnotations;

namespace System.Mxyzptlk
{
    using IO;

    /// <summary>
    /// Class to attach attribute to. The using statement above should cause the
    /// violation because it is not a fully qualified reference to <see
    /// cref="System.IO"/>.
    /// </summary>
    /// <remarks>
    /// Also triggers IDE00005 and SA1200.
    /// </remarks>
    [FileAnalysisViolationExpected("IDE0005", "Warning")]
    [FileAnalysisViolationExpected("SA1135", "Warning")]
    [FileAnalysisViolationExpected("SA1200", "Warning")]
    public class SA1135_UsingDirectivesMustBeQualified
    {
    }
}
