using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.DocumentationRules;

/// <summary>
/// Test that a property with a non-standard summary triggers violation codes.
/// </summary>
[CodeAnalysisViolationExpected("SA1623", "Warning", contains: "'Gets or sets'")]
public class PropertyWithNonStandardSummary
{
    /// <summary>
    /// Retrieve the thing.
    /// </summary>
    public int PropertyWithSummary { get; set; }
}
