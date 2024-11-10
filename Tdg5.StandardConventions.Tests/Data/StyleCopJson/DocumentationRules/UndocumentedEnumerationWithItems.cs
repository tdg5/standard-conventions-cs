using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.DocumentationRules;

/// <summary>
/// Test that enumeration items cause a violation code when undocumented.
/// </summary>
[CodeAnalysisViolationExpected("SA1602", "Warning")]
public enum UndocumentedEnumerationWithItems
{
    Item,
}
