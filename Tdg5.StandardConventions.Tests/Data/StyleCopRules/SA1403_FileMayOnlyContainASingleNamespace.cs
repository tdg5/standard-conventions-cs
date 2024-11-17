using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopRules
{
    /// <summary>
    /// Primary class/namespace in file.
    /// </summary>
    public class SA1403_FileMayOnlyContainASingleNamespace
    {
    }
}

namespace Tdg5.StandardConventions.Tests.Data.StyleCopRules.SA1403_FileMayOnlyContainASingleNamespace_Namespace
{
    /// <summary>
    /// Class in a different namespace.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1402.
    /// </remarks>
    [FileAnalysisViolationExpected("SA1402", "Warning")]
    [FileAnalysisViolationExpected("SA1403", "Warning")]
    public class SA1403_FileMayOnlyContainASingleNamespace
    {
    }
}
