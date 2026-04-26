using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.DocumentationRules;

/// <summary>
/// Test that enumeration items cause a violation code when undocumented.
/// </summary>
[CodeAnalysisViolationExpected(
    "SA1602", "Info", disabledReason: "SA1602 is silenced")]
public enum UndocumentedEnumerationWithItems
{
    Item,
}
