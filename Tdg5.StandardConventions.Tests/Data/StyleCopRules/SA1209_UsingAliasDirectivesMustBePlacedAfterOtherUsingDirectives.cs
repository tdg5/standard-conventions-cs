using SystemAlias = System;
using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopRules
{
    /// <summary>
    /// Class to attach attribute to. The SystemAlias using statement above
    /// should cause the violation.
    /// </summary>
    [FileAnalysisViolationExpected("SA1209", "Warning")]
    public class SA1209_UsingAliasDirectivesMustBePlacedAfterOtherUsingDirectives
    {
        /// <summary>
        /// Gets the reader.
        /// </summary>
        public SystemAlias.IO.BinaryReader? Reader { get; } = null;
    }
}
