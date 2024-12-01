using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.DocumentationRules;

/// <summary>
/// Test that internal struct members cause violation codes when undocumented.
/// </summary>
internal struct UndocumentedInternalStructWithMembers
{
    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    public static bool UndocumentedPublicStaticField = false;

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    public bool UndocumentedPublicField = false;

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    internal static bool UndocumentedInternalStaticField = false;

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    internal bool UndocumentedInternalField = false;

    [CodeAnalysisViolationExpected(
        "SA1600",
        "Warning",
        disabledReason: "Private static fields don't require documentation.")]
    [IncidentalCodeAnalysisViolationExpected(
        "CS0414", contains: "its value is never used")]
    [IncidentalCodeAnalysisViolationExpected("IDE0051")]
    private static readonly bool UndocumentedPrivateStaticField = false;

    [CodeAnalysisViolationExpected(
        "SA1600",
        "Warning",
        disabledReason: "Private fields don't require documentation.")]
    [IncidentalCodeAnalysisViolationExpected(
        "CS0414", contains: "its value is never used")]
    [IncidentalCodeAnalysisViolationExpected("IDE0051")]
    private readonly bool undocumentedPrivateField = false;

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    public UndocumentedInternalStructWithMembers()
    {
    }

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("IDE0060")]
    internal UndocumentedInternalStructWithMembers(long ignored)
    {
    }

    [CodeAnalysisViolationExpected(
        "SA1600",
        "Warning",
        disabledReason: "Private constructors don't require documentation.")]
    [IncidentalCodeAnalysisViolationExpected("IDE0051")]
    [IncidentalCodeAnalysisViolationExpected("IDE0060")]
    private UndocumentedInternalStructWithMembers(bool ignored)
    {
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
    [IncidentalCodeAnalysisViolationExpected("IDE0051")]
    private static bool UndocumentedPrivateStaticProperty { get; set; } = false;

    [CodeAnalysisViolationExpected(
        "SA1600",
        "Warning",
        disabledReason: "Private properties don't require documentation.")]
    [IncidentalCodeAnalysisViolationExpected("IDE0051")]
    private bool UndocumentedPrivateProperty { get; set; } = false;

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    public static void UndocumentedPublicStaticMethod()
    {
    }

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    public void UndocumentedPublicMethod()
    {
    }

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    internal static void UndocumentedInternalStaticMethod()
    {
    }

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    internal void UndocumentedInternalMethod()
    {
    }

    [CodeAnalysisViolationExpected(
        "SA1600",
        "Warning",
        disabledReason: "Private static methods don't require documentation.")]
    [IncidentalCodeAnalysisViolationExpected("IDE0051")]
    private static void UndocumentedPrivateStaticMethod()
    {
    }

    [CodeAnalysisViolationExpected(
        "SA1600",
        "Warning",
        disabledReason: "Private methods don't require documentation.")]
    [IncidentalCodeAnalysisViolationExpected("IDE0051")]
    private void UndocumentedPrivateMethod()
    {
    }
}
