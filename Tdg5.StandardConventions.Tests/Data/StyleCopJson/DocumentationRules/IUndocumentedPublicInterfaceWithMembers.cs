using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.DocumentationRules;

/// <summary>
/// Test that public interface members cause violation codes when undocumented.
/// </summary>
public interface IUndocumentedPublicInterfaceWithMembers
{
    [CodeAnalysisViolationExpected(
        "SA1600", "Info", disabledReason: "SA1600 is silenced")]
    bool UndocumentedPublicProperty { get; set; }

    [CodeAnalysisViolationExpected(
        "SA1600", "Info", disabledReason: "SA1600 is silenced")]
    void UndocumentedPublicMethod();
}
