using Tdg5.StandardConventions.TestAnnotations;
using System;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopRules
{
    /// <summary>
    /// Class to attach attribute to. The out of order using statements above
    /// should cause the violation.
    /// </summary>
    [FileAnalysisViolationExpected("SA1210", "Warning")]
    public class SA1210_UsingDirectivesMustBeOrderedAlphabeticallyByNamespace
    {
    }
}