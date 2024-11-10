using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.DocumentationRules;

/// <summary>
/// Test that a property with a summary that does not match the accessors
/// triggers violation codes.
/// </summary>
[CodeAnalysisViolationExpected("SA1623", "Warning", contains: "'Gets or sets'")]
public class PropertyWithSummaryThatDoesNotMatchAccessors
{
    /// <summary>
    /// Gets the property.
    /// </summary>
    public int PropertyWithInaccurateSummary { get; set; }
}
