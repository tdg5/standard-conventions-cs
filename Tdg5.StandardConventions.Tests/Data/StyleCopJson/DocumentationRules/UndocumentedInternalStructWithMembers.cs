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
        "CS0414", "Warning", contains: "its value is never used")]
    [CodeAnalysisViolationExpected("SA1600", "Warning", enabled: false)]
    private static bool undocumentedPrivateStaticField = false;

    [CodeAnalysisViolationExpected(
        "CS0414", "Warning", contains: "its value is never used")]
    [CodeAnalysisViolationExpected("SA1600", "Warning", enabled: false)]
    private bool undocumentedPrivateField = false;

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    public UndocumentedInternalStructWithMembers()
    {
    }

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    internal UndocumentedInternalStructWithMembers(long ignored)
    {
    }

    [CodeAnalysisViolationExpected("SA1600", "Warning", enabled: false)]
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

    [CodeAnalysisViolationExpected("SA1600", "Warning", enabled: false)]
    private static bool UndocumentedPrivateStaticProperty { get; set; } = false;

    [CodeAnalysisViolationExpected("SA1600", "Warning", enabled: false)]
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

    [CodeAnalysisViolationExpected("SA1600", "Warning", enabled: false)]
    private static void UndocumentedPrivateStaticMethod()
    {
    }

    [CodeAnalysisViolationExpected("SA1600", "Warning", enabled: false)]
    private void UndocumentedPrivateMethod()
    {
    }
}
