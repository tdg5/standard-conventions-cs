using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.EditorConfigRules
{
    /// <summary>
    /// The block-scoped namespace should trigger an IDE0161 violation.
    /// </summary>
    [FileAnalysisViolationExpected("IDE0161", "Warning")]
    public class IDE0161_UseFileScopedNamespace
    {
    }
}
