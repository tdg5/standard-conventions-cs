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

    /// <remarks>
    /// Also triggers IDE0051.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0051", "Warning")]
    [CodeAnalysisViolationExpected(
        "CS0414", "Warning", contains: "its value is never used")]
    [CodeAnalysisViolationExpected(
        "SA1600",
        "Warning",
        disabledReason: "Private static fields don't require documentation.")]
    private static readonly bool UndocumentedPrivateStaticField = false;

    /// <remarks>
    /// Also triggers IDE0051.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0051", "Warning")]
    [CodeAnalysisViolationExpected(
        "CS0414", "Warning", contains: "its value is never used")]
    [CodeAnalysisViolationExpected(
        "SA1600",
        "Warning",
        disabledReason: "Private fields don't require documentation.")]
    private readonly bool undocumentedPrivateField = false;

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    public UndocumentedInternalStructWithMembers()
    {
    }

    [CodeAnalysisViolationExpected("IDE0060", "Warning")]
    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    internal UndocumentedInternalStructWithMembers(long ignored)
    {
    }

    /// <remarks>
    /// Triggers IDE0051.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0051", "Warning")]
    [CodeAnalysisViolationExpected("IDE0060", "Warning")]
    [CodeAnalysisViolationExpected(
        "SA1600",
        "Warning",
        disabledReason: "Private constructors don't require documentation.")]
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

    /// <remarks>
    /// Triggers IDE0051.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0051", "Warning")]
    [CodeAnalysisViolationExpected(
        "SA1600",
        "Warning",
        disabledReason: "Private static properties don't require documentation.")]
    private static bool UndocumentedPrivateStaticProperty { get; set; } = false;

    /// <remarks>
    /// Triggers IDE0051.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0051", "Warning")]
    [CodeAnalysisViolationExpected(
        "SA1600",
        "Warning",
        disabledReason: "Private properties don't require documentation.")]
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

    /// <remarks>
    /// Triggers IDE0051.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0051", "Warning")]
    [CodeAnalysisViolationExpected(
        "SA1600",
        "Warning",
        disabledReason: "Private static methods don't require documentation.")]
    private static void UndocumentedPrivateStaticMethod()
    {
    }

    /// <remarks>
    /// Triggers IDE0051.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0051", "Warning")]
    [CodeAnalysisViolationExpected(
        "SA1600",
        "Warning",
        disabledReason: "Private methods don't require documentation.")]
    private void UndocumentedPrivateMethod()
    {
    }
}
