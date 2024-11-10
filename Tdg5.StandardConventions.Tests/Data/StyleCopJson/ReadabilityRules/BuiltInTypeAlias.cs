using Tdg5.StandardConventions.TestAnnotations;
using TypeAlias = System.Int32;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.ReadabilityRules;

/// <summary>
/// A class utilizing a type alias for a built-in type.
/// </summary>
public class BuiltInTypeAlias
{
    /// <summary>
    /// Gets or sets the counter.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1121", "Warning")]
    public TypeAlias Counter { get; set; } = 0;
}
