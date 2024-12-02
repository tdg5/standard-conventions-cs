using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.DocumentationRules;

/// <summary>
/// Test that internal class members cause violation codes when undocumented.
/// </summary>
internal class UndocumentedInternalClassWithMembers
{
    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    [IncidentalCodeAnalysisViolationExpected(
        "SA1401", contains: "Field should be private")]
    public static bool UndocumentedPublicStaticField = false;

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    [IncidentalCodeAnalysisViolationExpected(
        "SA1401", contains: "Field should be private")]
    public bool UndocumentedPublicField = false;

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    [IncidentalCodeAnalysisViolationExpected(
        "SA1401", contains: "Field should be private")]
    internal static bool UndocumentedInternalStaticField = false;

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    [IncidentalCodeAnalysisViolationExpected(
        "SA1401", contains: "Field should be private")]
    internal bool UndocumentedInternalField = false;

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    [IncidentalCodeAnalysisViolationExpected(
        "SA1401", contains: "Field should be private")]
    protected static bool undocumentedProtectedStaticField = false;

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    [IncidentalCodeAnalysisViolationExpected(
        "SA1401", contains: "Field should be private")]
    protected bool undocumentedProtectedField = false;

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
    public UndocumentedInternalClassWithMembers()
        : this(5)
    {
    }

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    internal UndocumentedInternalClassWithMembers(int ignored)
        : this(5L)
    {
        NoopHelper.Noop(ignored);
    }

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    protected UndocumentedInternalClassWithMembers(long ignored)
        : this(true)
    {
        NoopHelper.Noop(ignored);
    }

    [CodeAnalysisViolationExpected(
        "SA1600",
        "Warning",
        disabledReason: "Private constructors don't require documentation.")]
    private UndocumentedInternalClassWithMembers(bool ignored)
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
    protected bool UndocumentedProtectedProperty { get; set; } = false;

    [CodeAnalysisViolationExpected(
        "SA1600",
        "Warning",
        disabledReason: "Private static property don't require documentation.")]
    private static bool UndocumentedPrivateStaticProperty { get; set; } = false;

    [CodeAnalysisViolationExpected(
        "SA1600",
        "Warning",
        disabledReason: "Private property don't require documentation.")]
    private bool UndocumentedPrivateProperty { get; set; } = false;

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    public static void UndocumentedPublicStaticMethod()
    {
        NoopHelper.NoopMemberReference(UndocumentedPublicStaticField);
        UndocumentedInternalStaticMethod();
    }

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    public void UndocumentedPublicMethod()
    {
        NoopHelper.NoopMemberReference(UndocumentedPublicField);
        UndocumentedInternalMethod();
    }

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    internal static void UndocumentedInternalStaticMethod()
    {
        NoopHelper.NoopMemberReference(UndocumentedInternalStaticField);
        NoopHelper.NoopMemberReference(UndocumentedInternalStaticProperty);
    }

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    internal void UndocumentedInternalMethod()
    {
        NoopHelper.NoopMemberReference(UndocumentedInternalField);
        UndocumentedProtectedMethod();
    }

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    protected static void UndocumentedProtectedStaticMethod()
    {
        NoopHelper.NoopMemberReference(undocumentedProtectedStaticField);
        UndocumentedPrivateStaticMethod();
    }

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    protected void UndocumentedProtectedMethod()
    {
        NoopHelper.NoopMemberReference(undocumentedProtectedField);
        NoopHelper.NoopMemberReference(UndocumentedProtectedProperty);
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
    private void UndocumentedPrivateMethod()
    {
        NoopHelper.NoopMemberReference(undocumentedPrivateField);
        NoopHelper.NoopMemberReference(UndocumentedPrivateProperty);
    }
}
