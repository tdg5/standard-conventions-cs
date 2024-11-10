using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.DocumentationRules;

/// <summary>
/// Test that internal interface members cause violation codes when undocumented.
/// </summary>
internal interface IUndocumentedInternalInterfaceWithMembers
{
    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    public bool UndocumentedPublicProperty { get; set; }

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    public void UndocumentedPublicMethod();
}
