using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.DocumentationRules;

/// <summary>
/// Test that a property with a summary that references a restricted setter
/// triggers violation codes.
/// </summary>
[CodeAnalysisViolationExpected("SA1624", "Warning", contains: "should begin with 'Gets'")]
public class PropertyWithSummaryThatReferencesRestrictedSetter
{
    /// <summary>
    /// Gets or sets the property.
    /// </summary>
    public int PropertyWithRestrictedSummary { get; private set; }
}
