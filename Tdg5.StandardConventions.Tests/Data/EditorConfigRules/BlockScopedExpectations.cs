using System;
using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.EditorConfigRules;

/// <summary>
/// Various block scoped expectations for EditorConfig rules.
/// </summary>
public class BlockScopedExpectations
{
    /// <summary>
    /// An interface that includes a method without an accessibility modifier,
    /// which is allowed by
    /// dotnet_style_require_accessibility_modifiers=for_non_interface_members.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "IDE0040",
        "Warning",
        disabledReason: "This is allowed by configuration.")]
    public interface IIDE0040_AddAccessibilityModifiers
    {
        /// <summary>
        /// A method that does not declare an accessibility modifier.
        /// </summary>
        void Method();
    }

    /// <summary>
    /// A method that contains an unnecessary cast.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0004", "Warning")]
    public static void IDE0004_RemoveUnnecessaryCast()
    {
        static int Method() => (int)5;
        Method();
    }

    /// <summary>
    /// A method that contains a statement that should use braces, but does not.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1503.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0011", "Warning")]
    [CodeAnalysisViolationExpected("SA1503", "Warning")]
    public static void IDE0011_SurroundBlocksOfCodeWithCurlyBraces()
    {
        if (true)
            return;
    }

    /// <summary>
    /// A method that contains an out variable that is not declared inline.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0018", "Warning")]
    public static void IDE0018_DeclareOutVariablesInline()
    {
        static void Method(out int number) => number = 0;
        int value;
        Method(out value);
        if (value == 0)
        {
            throw new InvalidOperationException("Value is 0.");
        }
    }

    /// <summary>
    /// A method that performs a null check instead of using pattern checking.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0019", "Warning")]
    public static void IDE0019_UsePatternMatchingToAvoidNullCheck()
    {
        object value = "value";
        var stringValue = value as string;
        if (stringValue == null)
        {
            throw new InvalidOperationException("Value is not a string.");
        }
    }

    /// <summary>
    /// A method that performs a cast instead of using pattern matching (with a
    /// variable).
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0020", "Warning")]
    public static void IDE0020_UsePatternMatchingToCastWithVariable()
    {
        static string Method(string value) => value;
        object value = "value";
        if (value is string)
        {
            var stringValue = (string)value;
            Method(stringValue);
        }
    }

    /// <summary>
    /// A method that uses a ternary expression instead of null propagation.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0031", "Warning")]
    public static void IDE0031_UseNullPropagation()
    {
        static string? Method(string? value) =>
            value is null ? null : value.ToString();
        Method(null);
    }

    /// <summary>
    /// A method that uses implicit ItemX names for tuple elements.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1142.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0033", "Warning")]
    [CodeAnalysisViolationExpected("SA1142", "Warning")]
    public static void IDE0033_UseExplicitlyProvidedTupleNames()
    {
        static (int FirstElement, int SecondElement) Method() => (0, 0);
        if (Method().Item1 == 1)
        {
            throw new InvalidOperationException("First element is 1.");
        }
    }

    /// <summary>
    /// A method that contains a default expression with a type.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0034", "Warning")]
    public static void IDE0034_SimplifyDefaultExpression()
    {
        static int Method(int token = default(int)) => 0;
        Method();
    }

    /// <summary>
    /// A method that contains implicit tuple member names.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "IDE0037", "Warning", disabledReason: "IDE0037 has a severity of none.")]
    public static void IDE0037_UseExplicitMemberNamesWithTuples()
    {
        var age = 30;
        var name = "John";

        // This style is preferred, but IDE0037 can't be used to enforce it.
        var tuple = (age: age, name: name);
        var otherTuple = (age, name);
        if (tuple.age == 31 || otherTuple.age == 31)
        {
            throw new InvalidOperationException("Age is 31.");
        }
    }

    /// <summary>
    /// A method that contains implicit anonymous type member names.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "IDE0037", "Warning", disabledReason: "IDE0037 has a severity of none.")]
    public static void IDE0037_UseExplicitMemberNamesWithAnonymousTypes()
    {
        var age = 30;
        var name = "John";

        // This style is preferred, but IDE0037 can't be used to enforce it.
        var anon = new { age = age, name = name };
        var otherAnon = new { age, name };
        if (anon.age == 31 || otherAnon.age == 31)
        {
            throw new InvalidOperationException("Age is 31.");
        }
    }

    /// <summary>
    /// A method that uses the equality operator to check for null.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0041", "Warning")]
    public static void IDE0041_UseIsNullCheck()
    {
        string? value = "not null";
        if ((object)value == null)
        {
            throw new InvalidOperationException("Value is null.");
        }
    }

    /// <summary>
    /// A method that uses some helpful, though unnecessary parentheses.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "IDE0047", "Warning", disabledReason: "IDE0047 has a severity of silent.")]
    public static void IDE0047_RemoveUnnecessaryParentheses()
    {
        static int ArithmeticBinaryOperatorsMethod() => 1 + (2 * 3);
        ArithmeticBinaryOperatorsMethod();
        static bool RelationalBinaryOperatorsMethod() => (1 < 2) || (4 > 3);
        RelationalBinaryOperatorsMethod();
        static bool OtherBinaryOperatorsMethod() => false || (true && true);
        OtherBinaryOperatorsMethod();
    }

    /// <summary>
    /// A method that contains a lambda with a block body.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0053", "Warning")]
    public static void IDE0053_UseExpressionBodyForLambdas()
    {
        Func<int, int> square = x =>
        {
            return x * x;
        };
        square(5);
    }

    /// <summary>
    /// A method that contains a non-compound assignment.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0054", "Warning")]
    public static void IDE0054_UseCompoundAssignment()
    {
        int value = 5;
        value = value + 1;
        Console.WriteLine(value);
    }

    /// <summary>
    /// A method that ignores a computed value.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "IDE0058", "Warning", disabledReason: "IDE0058 has a severity of silent.")]
    public static void IDE0058_RemoveUnnecessaryExpressionValue()
    {
        static int Method() => 5;
        Method();
    }

    /// <summary>
    /// A method that assigns a value to a variable that is never used.
    /// </summary>
    /// <remarks>
    /// Also triggers CS0219.
    /// </remarks>
    [CodeAnalysisViolationExpected("CS0219", "Warning")]
    [CodeAnalysisViolationExpected("IDE0059", "Warning")]
    public static void IDE0059_UnnecessaryAssignmentToAValue()
    {
        int value = 5;
    }

    /// <summary>
    /// A method that contains a local function with a block body.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "IDE0061", "Warning", disabledReason: "IDE0061 has a severity of silent.")]
    public static void IDE0061_UseExpressionBodyForLocalFunctions()
    {
        static int Method()
        {
            return 5;
        }

        Method();
    }

    /// <summary>
    /// A method that does not declare an accessibility modifier.
    /// </summary>
    /// <remarks>
    /// Also triggers IDE0051 and SA1400.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0040", "Warning")]
    [CodeAnalysisViolationExpected("IDE0051", "Warning")]
    [CodeAnalysisViolationExpected("SA1400", "Warning")]
    static void IDE0040_AddAccessibilityModifiers()
    {
    }

    /// <summary>
    /// A method that is not used elsewhere in the code.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0051", "Warning")]
    private static void IDE0051_RemoveUnusedPrivateMember()
    {
    }

    /// <summary>
    /// A method that contains a private method with an unused parameter.
    /// </summary>
    /// <remarks>
    /// Also triggers IDE0051 and SA1400.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0051", "Warning")]
    [CodeAnalysisViolationExpected("IDE0060", "Warning")]
    private static void IDE0060_RemoveUnusedParameter(int unusedParameter)
    {
    }

    /// <summary>
    /// A class containing a constructor that uses an expression body.
    /// </summary>
    public class IDE0021_PreferBlockBodiesForConstructors
    {
        /// <summary>
        /// Initializes a new instance of the <see
        /// cref="IDE0021_PreferBlockBodiesForConstructors"/> class.
        /// </summary>
        /// <param name="value">The integer value.</param>
        [CodeAnalysisViolationExpected("IDE0021", "Warning")]
        public IDE0021_PreferBlockBodiesForConstructors(int value) => Value = value;

        /// <summary>
        /// Gets the value.
        /// </summary>
        public int Value { get; }
    }

    /// <summary>
    /// A class containing a property that uses a private backing field.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0032", "Warning")]
    public class IDE0032_UseAutoImplementedProperty
    {
        private int value;

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public int Value
        {
            get => value;
            set => this.value = value;
        }
    }

    /// <summary>
    /// A class containing a declaration with incorrectly ordered modifiers.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1206.
    /// </remarks>
    public class IDE0036_EnforceModifierOrder
    {
        /// <summary>
        /// Always returns zero.
        /// </summary>
        /// <returns>Always zero.</returns>
        [CodeAnalysisViolationExpected("SA1206", "Warning")]
        [CodeAnalysisViolationExpected("IDE0036", "Warning")]
        static public int Method() => 0;
    }

    /// <summary>
    /// A class that contains a private field that can be made readonly.
    /// </summary>
    /// <remarks>
    /// Also triggers IDE0032.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0032", "Warning")]
    [CodeAnalysisViolationExpected("IDE0044", "Warning")]
    public class IDE0044_AddReadonlyModifier
    {
        private int value;

        /// <summary>
        /// Initializes a new instance of the <see
        /// cref="IDE0044_AddReadonlyModifier"/> class.
        /// </summary>
        /// <param name="value">Arbitrary integer value.</param>
        public IDE0044_AddReadonlyModifier(int value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public int Value => value;
    }

    /// <summary>
    /// A class containing an unread private member.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0052", "Warning")]
    public class IDE0052_RemoveUnreadPrivateMember
    {
        private readonly int value;

        /// <summary>
        /// Initializes a new instance of the <see
        /// cref="IDE0052_RemoveUnreadPrivateMember"/> class.
        /// </summary>
        /// <param name="value">Arbitrary integer value.</param>
        public IDE0052_RemoveUnreadPrivateMember(int value)
        {
            this.value = value;
        }
    }
}
