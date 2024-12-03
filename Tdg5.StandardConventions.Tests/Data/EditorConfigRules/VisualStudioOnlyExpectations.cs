using System;
using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.EditorConfigRules;

/// <summary>
/// Expecations that only show up in Visual Studio and can't be tested in the
/// build.
/// </summary>
public class VisualStudioOnlyExpectations
{
    private readonly bool fieldForIde0003 = true;

    private event EventHandler? EventForIde0003;

    private bool PropertyForIde0003 => !fieldForIde0003;

    /// <summary>
    /// A method that contains a member reference using this that can be simplified.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "IDE0001", "Warning", disabledReason: "Only shows up in Visual Studio")]
    public static void IDE0001_SimplifyName()
    {
        /* ----↓↓↓↓↓↓----- IDE0001 */
        static System.AppContext? Method() => null;

        // Method2 is used to avoid IDE0005 for 'using System' import.
        static AppContext? Method2() => Method();
        Method2();
    }

    /// <summary>
    /// A method that contains a member reference using the full class name that
    /// can be simplified.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "IDE0002", "Warning", disabledReason: "Only shows up in Visual Studio")]
    public static void IDE0002_SimplifyMemberAccess()
    {
        /*
        ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓---- IDE0002 */
        VisualStudioOnlyExpectations.IDE0001_SimplifyName();
    }

    /// <summary>
    /// A method that contains unreachable code.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "IDE0035", "Warning", disabledReason: "Only shows up in Visual Studio")]
    [IncidentalCodeAnalysisViolationExpected("CS0162")]
    public static void IDE0035_RemoveUnreachableCode()
    {
        return;
        /*
        ↓↓↓↓↓↓---- IDE0035 */
        return;
    }

    /// <summary>
    /// A method that performs a cast instead of using pattern matching (without
    /// a variable).
    /// </summary>
    [CodeAnalysisViolationExpected(
        "IDE0038", "Warning", disabledReason: "Only shows up in Visual Studio")]
    public static void IDE0038_UsePatternMatchingToCastWithoutVariable()
    {
        static string Method(string value) => value;
        object value = "value";
        /* ----↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓--- IDE0038 */
        Method(value is string ? (string)value : string.Empty);
    }

    /// <summary>
    /// A method that doesn't use a built-in type alias.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0049", "Warning", disabledReason: "Only shows up in Visual Studio")]
    [IncidentalCodeAnalysisViolationExpected("SA1121")]
    public static void IDE0049_UseBuiltInTypeAliases()
    {
        /* ----↓↓↓↓↓--- IDE0049 */
        static Int32 Method() => 0;
        Method();
    }

    /// <summary>
    /// A method that contains an unnecessary suppression.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0079", "Warning", disabledReason: "Only shows up in Visual Studio")]
    public static void IDE0079_RemoveUnnecessarySuppression()
    {
        /* ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓---- IDE0079 */
#pragma warning disable IDE0051
        NoopHelper.Noop("foo");
        /* ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓---- IDE0079 */
#pragma warning restore IDE0051
    }

    /// <summary>
    /// A method that contains a member reference using this that can be simplified.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "IDE0003", "Warning", disabledReason: "Only shows up in Visual Studio")]
    [IncidentalCodeAnalysisViolationExpected("SX1101")]
    public void IDE0003_RemoveThisQualificationWhereUnnecessary()
    {
        /* --------------↓↓↓↓---- IDE0003 for field */
        bool Method() => this.fieldForIde0003;

        bool result = false;
        /* ------------------↓↓↓↓---- IDE0003 for property */
        var propertyIsTrue = this.PropertyForIde0003;
        if (propertyIsTrue)
        {
            /* ------↓↓↓↓---- IDE0003 for property */
            result = this.MethodForIde0003();
        }

        /* ---------↓↓↓↓---- IDE0003 for event */
        var clone = this.EventForIde0003?.Clone();

        // Extra logic to silence some unused variable warnings.
        if (result && clone is null)
        {
            Method();
        }
    }

    private bool MethodForIde0003() => fieldForIde0003;
}
