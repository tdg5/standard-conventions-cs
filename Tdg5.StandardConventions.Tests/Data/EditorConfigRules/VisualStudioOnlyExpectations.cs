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

    private bool PropertyForIde0003 => true;

    /// <summary>
    /// A method that contains a member reference using this that can be simplified.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "IDE0001", "Warning", disabledReason: "Only shows up in Visual Studio")]
    public static void IDE0001_SimplifyName()
    {
        static System.AppContext? Method() => null;
        /* ----^^^^^^----- IDE0001 */

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
        VisualStudioOnlyExpectations.IDE0001_SimplifyName();
        /*^^^^^^^^^^^^^^^^^^^^^^^^^^---- IDE0002 */
    }

    /// <summary>
    /// A method that contains unreachable code.
    /// </summary>
    /// <remarks>
    /// Also triggers CS0162.
    /// </remarks>
    [CodeAnalysisViolationExpected(
        "IDE0035", "Warning", disabledReason: "Only shows up in Visual Studio")]
    [CodeAnalysisViolationExpected("CS0162", "Warning")]
    public static void IDE0035_RemoveUnreachableCode()
    {
        return;
        return;
        /* ^^^---- IDE0035 */
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
        Method(value is string ? (string)value : string.Empty);
        /* ----^^^^^^^^^^^^^^^--- IDE0038 */
    }

    /// <summary>
    /// A method that doesn't use a built-in type alias.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1121.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0049", "Warning", disabledReason: "Only shows up in Visual Studio")]
    [CodeAnalysisViolationExpected("SA1121", "Warning")]
    public static void IDE0049_UseBuiltInTypeAliases()
    {
        static Int32 Method() => 0;
        /* ----^^^^^--- IDE0049 */
        Method();
    }

    /// <summary>
    /// A method that contains a member reference using this that can be simplified.
    /// </summary>
    /// <remarks>
    /// Also triggers SX1101.
    /// </remarks>
    [CodeAnalysisViolationExpected(
        "IDE0003", "Warning", disabledReason: "Only shows up in Visual Studio")]
    [CodeAnalysisViolationExpected("SX1101", "Warning")]
    public void IDE0003_RemoveThisQualificationWhereUnnecessary()
    {
        bool Method() => this.fieldForIde0003;
        /* --------------^^^^---- IDE0003 for field */

        bool result = false;
        var propertyIsTrue = this.PropertyForIde0003;
        /* ------------------^^^^---- IDE0003 for property */
        if (propertyIsTrue)
        {
            result = this.MethodForIde0003();
            /* ------^^^^---- IDE0003 for property */
        }

        var clone = this.EventForIde0003?.Clone();
        /* ---------^^^^---- IDE0003 for event */

        // Extra logic to silence some unused variable warnings.
        if (result && clone is null)
        {
            Method();
        }
    }

    private bool MethodForIde0003() => true;
}
