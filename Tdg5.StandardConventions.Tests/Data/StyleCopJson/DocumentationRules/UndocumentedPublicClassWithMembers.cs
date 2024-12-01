using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.DocumentationRules;

/// <summary>
/// Test that public class members cause violation codes when undocumented.
/// </summary>
public class UndocumentedPublicClassWithMembers
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
    public UndocumentedPublicClassWithMembers()
    {
    }

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("IDE0060")]
    internal UndocumentedPublicClassWithMembers(int ignored)
    {
    }

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    protected UndocumentedPublicClassWithMembers(long ignored)
    {
    }

    [CodeAnalysisViolationExpected(
        "SA1600",
        "Warning",
        disabledReason: "Private constructors don't require documentation.")]
    [IncidentalCodeAnalysisViolationExpected("IDE0051")]
    [IncidentalCodeAnalysisViolationExpected("IDE0060")]
    private UndocumentedPublicClassWithMembers(bool ignored)
    {
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
    [IncidentalCodeAnalysisViolationExpected("IDE0051")]
    private static bool UndocumentedPrivateStaticProperty { get; set; } = false;

    [CodeAnalysisViolationExpected(
        "SA1600",
        "Warning",
        disabledReason: "Private property don't require documentation.")]
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

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    protected static void UndocumentedProtectedStaticMethod()
    {
    }

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    protected void UndocumentedProtectedMethod()
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
