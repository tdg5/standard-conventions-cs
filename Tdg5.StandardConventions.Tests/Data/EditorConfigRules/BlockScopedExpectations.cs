using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
    [CodeAnalysisViolationExpected(
        "IDE0053", "Info", disabledReason: "IDE0053 is silenced")]
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
    [CodeAnalysisViolationExpected("IDE0058", "Info")]
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
        "IDE0061", "Warning", disabledReason: "IDE0061 is silenced")]
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
    /// A method that uses a null forgiving operator where it is not necessary.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0080", "Warning")]
    public static void IDE0080_RemoveUnnecessarySuppressionOperator()
    {
        string thing = "thing";
        if (thing! is null)
        {
            NoopHelper.Noop();
        }
    }

    /// <summary>
    /// A method that uses the typeof operator followed by Name.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0082", "Warning")]
    public static void IDE0082_ConvertTypeofToNameof()
    {
        string name = typeof(string).Name;
        NoopHelper.Noop(name);
    }

    /// <summary>
    /// A method that doesn't use the not operator when pattern matching.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0083", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("IDE0078")]
    public static void IDE0083_UsePatternMatchingNotOperator()
    {
        object value = "value";
        if (!(value is string))
        {
            NoopHelper.Noop();
        }
    }

    /// <summary>
    /// A method containing a new expression that could be simplified.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0090", "Warning")]
    public static void IDE0090_SimplifyNewExpression()
    {
        object thing = new object();
        NoopHelper.Noop(thing);
    }

    /// <summary>
    /// A method that makes a comparison using an unnecessary equality operator.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0100", "Warning")]
    public static void IDE0100_RemoveUnnecessaryEqualitysOperator()
    {
        bool value = true;
        if (value == true)
        {
            NoopHelper.Noop();
        }
    }

    /// <summary>
    /// A method that contains an unnecessary discard.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0110", "Warning")]
    public static void IDE0110_RemoveUnnecessaryDiscard()
    {
        object obj = 5;
        switch (obj)
        {
            case int _:
                NoopHelper.Noop(obj);
                break;
        }
    }

    /// <summary>
    /// A method that calls Enumerable.Where unnecessarily.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0120", "Info")]
    public static void IDE0120_SimplifyLinqExpression()
    {
        var count = Enumerable.Range(0, 100)
            .Where(x => x % 2 == 0)
            .Count();
        NoopHelper.Noop(count);
    }

    /// <summary>
    /// A method that performs a type check where a null check is more appropriate.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0150", "Warning")]
    public static void IDE0150_PreferNullCheckOverTypeCheck()
    {
        int[]? numbers = null;
        if (numbers is not int[])
        {
            NoopHelper.Noop();
        }
    }

    /// <summary>
    /// A method that does not use extend property pattern matching.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0170", "Warning")]
    public static void IDE0170_SimplifyPropertyPattern()
    {
        static bool IsEndOnXAxis(Segment segment) =>
            segment is { Start: { Y: 0 } } or { End: { Y: 0 } };
        NoopHelper.Noop(IsEndOnXAxis(null!));
    }

    /// <summary>
    /// A method that swaps values without using a tuple.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0180", "Info")]
    public static void IDE0180_UseTupleToSwapValues()
    {
        List<int> numbers = [5, 6, 4];

        int temp = numbers[0];
        numbers[0] = numbers[1];
        numbers[1] = temp;
    }

    /// <summary>
    /// A method containing an unused lambda expression.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0200", "Warning")]
    public static void IDE0200_RemoveUnnecessaryLambdaExpression()
    {
        static bool IsEven(int x) => x % 2 == 0;
        List<int> list = [1, 2, 3, 4, 5];
        _ = list.Where(n => IsEven(n));
    }

    /// <summary>
    /// A method containing a foreach statement that doesn't use an explicit cast.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0220", "Warning")]
    public static void IDE0220_AddExplicitCastInForeachLoop()
    {
        var list = new List<object>();
        foreach (string item in list)
        {
            NoopHelper.Noop(item);
        }
    }

    /// <summary>
    /// A method that could use a UTF-8 string instead of a byte array.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0230", "Info")]
    [IncidentalCodeAnalysisViolationExpected("IDE0300")]
    public static void IDE0230_UseUtf8StringLiteral()
    {
        ReadOnlySpan<byte> span = new byte[] { 65, 66, 67 };
        NoopHelper.Noop(span[0]);
    }

    /// <summary>
    /// A method that contains an unnecessary nullable directive.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0240", "Warning")]
    public static void IDE0240_NullableDirectiveIsRedundant()
    {
#nullable enable
    }

    /// <summary>
    /// A method that contains an as expression that uses the null conditional
    /// operator for member access.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0260", "Info")]
    public static void IDE0260_PreferPatternMatchingOverAsWithNullConditionalOperator()
    {
        object? o = null;
        if ((o as string)?.Length == 0)
        {
            NoopHelper.Noop();
        }
    }

    /// <summary>
    /// A method that contains a null check that could be replaced by the null
    /// coalescing operator.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0270", "Warning")]
    public static void IDE0270_PreferNullCoalescingExpressions()
    {
        static object? FindItem() => null;
        var item = FindItem();
        if (item == null)
        {
            throw new InvalidOperationException("Value is null.");
        }
    }

    /// <summary>
    /// A method that does not use a collection expression when creating an
    /// array.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0300", "Warning")]
    public static void IDE0300_UseCollectionExpressionForArray()
    {
        int[] list = new int[] { 1, 2, 3 };
        NoopHelper.Noop(list);
    }

    /// <summary>
    /// A method that does not use a collection expression when creating an
    /// empty array.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0301", "Warning")]
    public static void IDE0301_UseCollectionExpressionForEmpty()
    {
        int[] list = Array.Empty<int>();
        NoopHelper.Noop(list);
    }

    /// <summary>
    /// A method that does not use a collection expression when creating a
    /// stackalloc array.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0302", "Warning")]
    public static void IDE0302_UseCollectionExpressionForStackalloc()
    {
        ReadOnlySpan<int> collection = stackalloc int[] { 1, 2, 3 };
        NoopHelper.Noop(collection[0]);
    }

    /// <summary>
    /// A method that does not use a collection expression when creating an
    /// immutable array.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0303", "Warning")]
    public static void IDE0303_UseCollectionExpressionForCreate()
    {
        ImmutableArray<int> collection = ImmutableArray.Create(1, 2, 3);
        NoopHelper.Noop(collection);
    }

    /// <summary>
    /// A method that does not use a collection expression and instead uses an
    /// immutable array builder.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0304", "Warning")]
    public static void IDE0304_UseCollectionExpressionForBuilder()
    {
        var builder = ImmutableArray.CreateBuilder<int>();
        builder.Add(1);
        ImmutableArray<int> collection = builder.ToImmutable();
        NoopHelper.Noop(collection);
    }

    /// <summary>
    /// A method that does not use a collection expression and instead uses a
    /// fluent expression.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0305", "Warning")]
    public static void IDE0305_UseCollectionExpressionForFluent()
    {
        int x = 0;
        List<int> list = new[] { x, 1, 2, 3 }.ToList();
        NoopHelper.Noop(list);
    }

    /// <summary>
    /// A method that includes an anonymous function that could be made static.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "IDE0320", "Info", disabledReason: "I couldn't trigger IDE0320.")]
    public static void IDE0320_MakeAnonymousFunctionStatic()
    {
        var y = 0;
        void Method(Func<int, int> function)
        {
            function(y + 1);
        }

        Method(static x => x + 1);
    }

    /// <summary>
    /// A method that uses a conditional expression to decide to execute a
    /// function or not.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE1005", "Warning")]
    public static void IDE1005_UseConditionalDelegateCall()
    {
        Func<int, int>? func = null;
        if (func != null)
        {
            func(0);
        }
    }

    /// <summary>
    /// A method that does not declare an accessibility modifier.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0040", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1400")]
    static void IDE0040_AddAccessibilityModifiers()
    {
        IDE0040_AddAccessibilityModifiers();
    }

    /// <summary>
    /// A method that contains a private method with an unused parameter.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0060", "Warning")]
    private static void IDE0060_RemoveUnusedParameter(int unusedParameter)
    {
        IDE0060_RemoveUnusedParameter(0);
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
    /// A struct that contains only readonly fields and can be made readonly.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0250", "Info")]
    public struct IDE0250_StructCanBeMadeReadonly
    {
        /// <summary>
        /// A value.
        /// </summary>
        public readonly int Value;
    }

    /// <summary>
    /// A struct that contains a member that could be made readonly.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0251", "Info")]
    public struct IDE0251_MemberCanBeMadeReadonly
    {
        /// <summary>
        /// A method that does nothing.
        /// </summary>
        public void Noop()
        {
            NoopHelper.Noop(this);
        }
    }

    private record Point(int X, int Y);

    private record Segment(Point Start, Point End);

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

    /// <summary>
    /// A class that contains a method with an attribute that uses a literal
    /// parameter name instead of the nameof operator.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0280", "Warning")]
    public class IDE0280_UseNameOf
    {
        /// <summary>
        /// A method that does nothing.
        /// </summary>
        /// <param name="input">Arbitrary input.</param>
        public static void Method([NotNullIfNotNull("input")] string? input)
        {
        }
    }
}
