using System;
using System.Collections.Generic;
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
    [CodeAnalysisViolationExpected("IDE0011", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1503")]
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
        NoopHelper.Noop(value);
    }

    /// <summary>
    /// A method that performs a null check instead of using pattern checking.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0019", "Warning")]
    public static void IDE0019_UsePatternMatchingToAvoidNullCheck()
    {
        object value = "value";
        var stringValue = value as string;
        NoopHelper.Noop(stringValue is null ? "null" : stringValue);
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
    [CodeAnalysisViolationExpected("IDE0033", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1142")]
    public static void IDE0033_UseExplicitlyProvidedTupleNames()
    {
        static (int FirstElement, int SecondElement) Method() => (0, 0);
        NoopHelper.Noop(Method().Item1);
    }

    /// <summary>
    /// A method that contains a default expression with a type.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0034", "Warning")]
    public static void IDE0034_SimplifyDefaultExpression()
    {
        static int Method(int token = default(int)) => token;
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
        NoopHelper.Noop(tuple.age, otherTuple.age);
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
        NoopHelper.Noop(anon.age, otherAnon.age);
    }

    /// <summary>
    /// A method that contains an anonymous function instead of a lambda.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0039", "Info")]
    public static void IDE0039_UseLocalFunctionInsteadOfLambda()
    {
        Func<int, bool> isEven = (int n) => n % 2 == 0;
        isEven(5);
    }

    /// <summary>
    /// A method that uses the equality operator to check for null.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0041", "Warning")]
    public static void IDE0041_UseIsNullCheck()
    {
        string? value = "not null";
        NoopHelper.Noop((object)value == null);
    }

    /// <summary>
    /// A method that does not use deconstruction for variable declaration.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0042", "Info")]
    public static void IDE0042_DeconstructVariableDeclaration()
    {
        static (int, int) Method() => (1, 2);
        (int X, int Y) result = Method();
        NoopHelper.Noop(result.X, result.Y);
    }

    /// <summary>
    /// A method that makes an assignment using an if-else statement.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0045", "Info")]
    public static void IDE0045_UseConditionalExpressionForAssignment()
    {
        static bool Method() => true;
        string value;
        if (Method())
        {
            value = "hello";
        }
        else
        {
            value = "world";
        }

        NoopHelper.Noop(value);
    }

    /// <summary>
    /// A method using an if-else statement to decide what to return.
    /// </summary>
    /// <returns>Arbitrary string.</returns>
    [CodeAnalysisViolationExpected("IDE0046", "Info")]
    public static string IDE0046_UseConditionalExpressionForReturn()
    {
        static bool Method() => true;
        if (Method())
        {
            return "hello";
        }
        else
        {
            return "world";
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
    /// A method that could use some helpful, though unnecessary parentheses.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0048", "Info")]
    [IncidentalCodeAnalysisViolationExpected("SA1407")]
    [IncidentalCodeAnalysisViolationExpected("SA1408")]
    public static void IDE0048_AddParenthesesForClarity()
    {
        static int ArithmeticBinaryOperatorsMethod() => 1 + 2 * 3;
        ArithmeticBinaryOperatorsMethod();
        static bool OtherBinaryOperatorsMethod() => false || true && true;
        OtherBinaryOperatorsMethod();
    }

    /// <summary>
    /// A method that contains a lambda with a block body.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0053", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("IDE0039")]
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
        NoopHelper.Noop(value);
    }

    /// <summary>
    /// A method that does not use the ^ operator when calculating an index from
    /// the end of a collection.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0056", "Info")]
    public static void IDE0056_UseIndexOperator()
    {
        List<string> list = [];
        var last = list[list.Count - 1];
        NoopHelper.Noop(last);
    }

    /// <summary>
    /// A method that does not use the range operator .. when extracting a
    /// slice of a collection.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0057", "Info")]
    public static void IDE0057_UseRangeOperator()
    {
        var message = "Hello, world!";
        var substring = message.Substring(0, message.Length - 5);
        NoopHelper.Noop(substring);
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
    [CodeAnalysisViolationExpected("IDE0059", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("CS0219")]
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
    /// A method that contains a local function that could be made static.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0062", "Warning")]
    public static void IDE0062_MakeLocalFunctionStatic()
    {
        int Method() => 5;
        Method();
    }

    /// <summary>
    /// A method that contains a using statement with and without a block.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "IDE0063", "Warning", disabledReason: "IDE0063 has a severity of silent.")]
    public static void IDE0063_UseSimpleUsingStatement()
    {
        IDisposable? disposable = null;
        using (disposable)
        {
            NoopHelper.Noop("Hello");
        }

        using var thing = disposable;
        NoopHelper.Noop("World");
    }

    /// <summary>
    /// A method that uses a switch statement instead of a switch expression.
    /// </summary>
    /// <returns>True if the value is 1, false otherwise.</returns>
    [CodeAnalysisViolationExpected("IDE0066", "Info")]
    public static bool IDE0066_UseSwitchExpression()
    {
        int value = 3;
        switch (value)
        {
            case 1:
                return true;
            default:
                return false;
        }
    }

    /// <summary>
    /// A method that contains an interpolated string that can be simplified.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0071", "Warning")]
    public static void IDE0071_SimplifyInterpolation()
    {
        var someValue = "some-value";
        var message = $"prefix {someValue.ToString()} suffix";
        NoopHelper.Noop(message);
    }

    /// <summary>
    /// A method that contains an assignment that doesn't use compound coalesce assignment.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0074", "Warning")]
    public static void IDE0074_UseCoalesceCompoundAssignment()
    {
        string? value = null;
        _ = value ?? (value = "default");
        string? Method() => value;
        Method();
    }

    /// <summary>
    /// A method that contains a conditional expression that can be simplified.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0075", "Warning")]
    public static void IDE0075_SimplifyConditionalExpression()
    {
        static bool TrueMethod() => true;
        static bool Method() => TrueMethod() && TrueMethod() ? true : false;
        Method();
    }

    /// <summary>
    /// A method that doesn't use pattern matching where it could.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0078", "Info")]
    public static void IDE0078_UsePatternMatching()
    {
        int number = 0;
        bool nonNegative = number == default || number > default(int);
        NoopHelper.Noop(nonNegative);
    }

    /// <summary>
    /// A method that does not declare an accessibility modifier.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0040", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("IDE0051")]
    [IncidentalCodeAnalysisViolationExpected("SA1400")]
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
    [CodeAnalysisViolationExpected("IDE0060", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("IDE0051")]
    private static void IDE0060_RemoveUnusedParameter(int unusedParameter)
    {
    }

    /// <summary>
    /// A struct that contains a method that changes the struct in such a way
    /// that readonly fields are modified.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0064", "Warning")]
    public struct IDE0064_MakeStructFieldsWritable
    {
        /// <summary>
        /// The value of the struct.
        /// </summary>
        public readonly int Value;

        /// <summary>
        /// Initializes a new instance of the <see
        /// cref="IDE0064_MakeStructFieldsWritable"/> struct.
        /// </summary>
        /// <param name="value">The integer value.</param>
        public IDE0064_MakeStructFieldsWritable(int value)
        {
            Value = value;
        }

        /// <summary>
        /// Violates the expectations by changing the struct.
        /// </summary>
        public void ViolateExpectations()
        {
            this = new IDE0064_MakeStructFieldsWritable(5);
        }
    }

    /// <summary>
    /// A class containing a constructor that uses an expression body.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0021", "Warning")]
    public class IDE0021_PreferBlockBodiesForConstructors
    {
        /// <summary>
        /// Initializes a new instance of the <see
        /// cref="IDE0021_PreferBlockBodiesForConstructors"/> class.
        /// </summary>
        /// <param name="value">The integer value.</param>
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
    public class IDE0036_EnforceModifierOrder
    {
        /// <summary>
        /// Always returns zero.
        /// </summary>
        /// <returns>Always zero.</returns>
        [CodeAnalysisViolationExpected("IDE0036", "Warning")]
        [IncidentalCodeAnalysisViolationExpected("SA1206")]
        static public int Method() => 0;
    }

    /// <summary>
    /// A class that contains a private field that can be made readonly.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0044", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("IDE0032")]
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

    /// <summary>
    /// A class containing a GetHashCode method that can be simplified.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0070", "Info")]
    public class IDE0070_UseSystemHashCodeCombine
    {
        private readonly int value;

        /// <summary>
        /// Initializes a new instance of the <see
        /// cref="IDE0070_UseSystemHashCodeCombine"/> class.
        /// </summary>
        /// <param name="value">Arbitrary integer value.</param>
        public IDE0070_UseSystemHashCodeCombine(int value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets the hash code for this instance.
        /// </summary>
        /// <returns>Integer hashode.</returns>
        public override int GetHashCode()
        {
            var hashCode = 339610899;
            hashCode = (hashCode * -1521134295) + value.GetHashCode();
            return hashCode;
        }
    }

    /// <summary>
    /// A class that includes a method that does not include all cases in a
    /// switch expression.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0072", "Info")]
    public class IDE0072_AddMissingCasesToSwitchExpression
    {
        /// <summary>
        /// An enumeration of various colors.
        /// </summary>
        public enum Color
        {
            /// <summary>
            /// Blue color.
            /// </summary>
            Blue,

            /// <summary>
            /// Green color.
            /// </summary>
            Green,
        }

        /// <summary>
        /// Gets the color as a string.
        /// </summary>
        /// <param name="color">Color to convert.</param>
        /// <returns>String representation of the color.</returns>
        public static string GetColor(Color color)
        {
            return color switch
            {
                Color.Blue => "Blue",
                _ => "Unknown",
            };
        }
    }
}
