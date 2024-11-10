using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.DocumentationRules;

/// <summary>
/// Test that a constructor with a non-standard summary triggers violation codes.
/// </summary>
[CodeAnalysisViolationExpected("SA1642", "Warning")]
public class ConstructorWithNonStandardSummary
{
    /// <summary>
    /// Initializes a new <see cref="ConstructorWithNonStandardSummary"/> instance.
    /// </summary>
    public ConstructorWithNonStandardSummary()
    {
    }
}
