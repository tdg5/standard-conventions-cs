using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.DocumentationRules;

/// <summary>
/// Test that public struct members cause violation codes when undocumented.
/// </summary>
public struct UndocumentedPublicStructWithMembers
{
    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    public static readonly bool UndocumentedPublicStaticField = false;

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    public readonly bool UndocumentedPublicField = false;

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    internal static readonly bool UndocumentedInternalStaticField = false;

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    internal readonly bool UndocumentedInternalField = false;

    [CodeAnalysisViolationExpected(
        "SA1600",
        "Warning",
        disabledReason: "Private static fields don't require documentation.")]
    private static readonly bool UndocumentedPrivateStaticField = false;

    [CodeAnalysisViolationExpected(
        "SA1600",
        "Warning",
        disabledReason: "Private fields don't require documentation.")]
    private readonly bool undocumentedPrivateField = false;

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    public UndocumentedPublicStructWithMembers()
        : this(5L)
    {
    }

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    internal UndocumentedPublicStructWithMembers(long ignored)
        : this(true)
    {
        NoopHelper.Noop(ignored);
    }

    [CodeAnalysisViolationExpected(
        "SA1600",
        "Warning",
        disabledReason: "Private constructors don't require documentation.")]
    private UndocumentedPublicStructWithMembers(bool ignored)
    {
        NoopHelper.Noop(ignored);
    }

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    public static bool UndocumentedPublicStaticProperty { get; set; } = false;

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    public bool UndocumentedPublicProperty { get; set; } = false;

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    internal static bool UndocumentedInternalStaticProperty { get; set; } = false;

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    internal bool UndocumentedInternalProperty { get; set; } = false;

    [CodeAnalysisViolationExpected(
        "SA1600",
        "Warning",
        disabledReason: "Private static properties don't require documentation.")]
    private static bool UndocumentedPrivateStaticProperty { get; set; } = false;

    [CodeAnalysisViolationExpected(
        "SA1600",
        "Warning",
        disabledReason: "Private properties don't require documentation.")]
    private bool UndocumentedPrivateProperty { get; set; } = false;

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    public static void UndocumentedPublicStaticMethod()
    {
        UndocumentedInternalStaticMethod();
    }

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    public readonly void UndocumentedPublicMethod()
    {
        UndocumentedInternalMethod();
    }

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    internal static void UndocumentedInternalStaticMethod()
    {
        NoopHelper.NoopMemberReference(UndocumentedInternalStaticField);
        NoopHelper.NoopMemberReference(UndocumentedInternalStaticProperty);
        UndocumentedPrivateStaticMethod();
    }

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    internal readonly void UndocumentedInternalMethod()
    {
        NoopHelper.NoopMemberReference(UndocumentedInternalField);
        NoopHelper.NoopMemberReference(UndocumentedInternalProperty);
        UndocumentedPrivateMethod();
    }

    [CodeAnalysisViolationExpected(
        "SA1600",
        "Warning",
        disabledReason: "Private static methods don't require documentation.")]
    private static void UndocumentedPrivateStaticMethod()
    {
        NoopHelper.NoopMemberReference(UndocumentedPrivateStaticField);
        NoopHelper.NoopMemberReference(UndocumentedPrivateStaticProperty);
    }

    [CodeAnalysisViolationExpected(
        "SA1600",
        "Warning",
        disabledReason: "Private methods don't require documentation.")]
    private readonly void UndocumentedPrivateMethod()
    {
        NoopHelper.NoopMemberReference(undocumentedPrivateField);
        NoopHelper.NoopMemberReference(UndocumentedPrivateProperty);
    }
}
