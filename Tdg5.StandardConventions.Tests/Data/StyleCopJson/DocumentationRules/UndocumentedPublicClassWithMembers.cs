using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.DocumentationRules;

/// <summary>
/// Test that public class members cause violation codes when undocumented.
/// </summary>
public class UndocumentedPublicClassWithMembers
{
    [CodeAnalysisViolationExpected(
        "SA1401", "Warning", contains: "Field should be private")]
    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    public static bool UndocumentedPublicStaticField = false;

    [CodeAnalysisViolationExpected(
        "SA1401", "Warning", contains: "Field should be private")]
    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    public bool UndocumentedPublicField = false;

    [CodeAnalysisViolationExpected(
        "SA1401", "Warning", contains: "Field should be private")]
    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    internal static bool UndocumentedInternalStaticField = false;

    [CodeAnalysisViolationExpected(
        "SA1401", "Warning", contains: "Field should be private")]
    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    internal bool UndocumentedInternalField = false;

    [CodeAnalysisViolationExpected(
        "SA1401", "Warning", contains: "Field should be private")]
    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    protected static bool undocumentedProtectedStaticField = false;

    [CodeAnalysisViolationExpected(
        "SA1401", "Warning", contains: "Field should be private")]
    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    protected bool undocumentedProtectedField = false;

    [CodeAnalysisViolationExpected(
        "CS0414", "Warning", contains: "its value is never used")]
    [CodeAnalysisViolationExpected(
        "SA1600",
        "Warning",
        disabledReason: "Private static fields don't require documentation.")]
    private static bool undocumentedPrivateStaticField = false;

    [CodeAnalysisViolationExpected(
        "CS0414", "Warning", contains: "its value is never used")]
    [CodeAnalysisViolationExpected(
        "SA1600",
        "Warning",
        disabledReason: "Private fields don't require documentation.")]
    private bool undocumentedPrivateField = false;

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    public UndocumentedPublicClassWithMembers()
    {
    }

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
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
    private static bool UndocumentedPrivateStaticProperty { get; set; } = false;

    [CodeAnalysisViolationExpected(
        "SA1600",
        "Warning",
        disabledReason: "Private property don't require documentation.")]
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
    private static void UndocumentedPrivateStaticMethod()
    {
    }

    [CodeAnalysisViolationExpected(
        "SA1600",
        "Warning",
        disabledReason: "Private methods don't require documentation.")]
    private void UndocumentedPrivateMethod()
    {
    }
}
