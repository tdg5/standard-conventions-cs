using System;
using System.Collections.Generic;
using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.EditorConfigRules;

/// <summary>
/// Diagnostics that are limited to suggestions that only show up in Visual
/// Studio and can't be tested in the build.
/// </summary>
public class SuggestionSeverityExpectations
{
    /// <summary>
    /// A method that contains an anonymous function instead of a lambda.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "IDE0039", "Warning", disabledReason: "IDE0039 has a severity of suggestion")]
    public static void IDE0039_UseLocalFunctionInsteadOfLambda()
    {
        /* -------------↓↓↓↓↓↓---- IDE0039 */
        Func<int, bool> isEven = (int n) => n % 2 == 0;
        isEven(5);
    }

    /// <summary>
    /// A method that does not use deconstruction for variable declaration.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "IDE0042", "Warning", disabledReason: "IDE0042 has a severity of suggestion.")]
    public static void IDE0042_DeconstructVariableDeclaration()
    {
        static (int, int) Method() => (1, 2);
        /* ------------↓↓↓↓↓↓---- IDE0042 */
        (int X, int Y) result = Method();
        Console.WriteLine($"{result.X}, {result.Y}");
    }

    /// <summary>
    /// A method that makes an assignment using an if-else statement.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "IDE0045", "Warning", disabledReason: "IDE0045 has a severity of suggestion.")]
    public static void IDE0045_UseConditionalExpressionForAssignment()
    {
        static bool Method() => true;
        string value;
        /*
        ↓↓---- IDE0045 */
        if (Method())
        {
            value = "hello";
        }
        else
        {
            value = "world";
        }

        Console.WriteLine(value);
    }

    /// <summary>
    /// A method using an if-else statement to decide what to return.
    /// </summary>
    /// <returns>Arbitrary string.</returns>
    [CodeAnalysisViolationExpected(
        "IDE0046", "Warning", disabledReason: "IDE0046 has a severity of suggestion.")]
    public static string IDE0046_UseConditionalExpressionForReturn()
    {
        static bool Method() => true;
        /*
        ↓↓---- IDE0046 */
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
    /// A method that could use some helpful, though unnecessary parentheses.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1407 and SA1408.
    /// </remarks>
    [CodeAnalysisViolationExpected(
        "IDE0048", "Warning", disabledReason: "IDE0048 has a severity of suggestion.")]
    [CodeAnalysisViolationExpected("SA1407", "Warning")]
    [CodeAnalysisViolationExpected("SA1408", "Warning")]
    public static void IDE0048_AddParenthesesForClarity()
    {
        /* -------------------------------------------------↓↓↓↓↓↓---- IDE0048 */
        static int ArithmeticBinaryOperatorsMethod() => 1 + 2 * 3;
        ArithmeticBinaryOperatorsMethod();
        /* --------------------------------------------------↓↓↓↓↓↓↓↓↓↓↓↓---- IDE0048 */
        static bool OtherBinaryOperatorsMethod() => false || true && true;
        OtherBinaryOperatorsMethod();
    }

    /// <summary>
    /// A method that does not use the ^ operator when calculating an index from
    /// the end of a collection.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "IDE0056", "Warning", disabledReason: "IDE0056 has a severity of suggestion.")]
    public static void IDE0056_UseIndexOperator()
    {
        List<string> list = [];
        /* -------------↓↓↓↓---------- IDE0056 */
        var last = list[list.Count - 1];
        Console.WriteLine(last);
    }

    /// <summary>
    /// A method that does not use the range operator .. when extracting a
    /// slice of a collection.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "IDE0057", "Warning", disabledReason: "IDE0057 has a severity of suggestion.")]
    public static void IDE0057_UseRangeOperator()
    {
        var message = "Hello, world!";
        /* -------------------------------↓---- IDE0057 */
        var substring = message.Substring(0, message.Length - 5);
        Console.WriteLine(substring);
    }

    /// <summary>
    /// A method that uses a switch statement instead of a switch expression.
    /// </summary>
    /// <returns>True if the value is 1, false otherwise.</returns>
    [CodeAnalysisViolationExpected(
        "IDE0066", "Warning", disabledReason: "IDE0066 has a severity of suggestion.")]
    public static bool IDE0066_UseSwitchExpression()
    {
        int value = 3;
        /*
        ↓↓↓↓↓↓---- IDE0066 */
        switch (value)
        {
            case 1:
                return true;
            default:
                return false;
        }
    }

    /// <summary>
    /// A method that doesn't use pattern matching where it could.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "IDE0078", "Warning", disabledReason: "IDE0078 has a severity of suggestion.")]
    public static void IDE0078_UsePatternMatching()
    {
        int number = 0;
        /* ----------------↓↓↓↓↓↓---- IDE0078 */
        bool nonNegative = number == default || number > default(int);
        Console.WriteLine(nonNegative);
    }

    /// <summary>
    /// A class containing a GetHashCode method that can be simplified.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "IDE0070", "Warning", disabledReason: "IDE0070 has a severity of suggestion.")]
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
        /* -----------------↓↓↓↓↓↓↓↓↓↓↓---- IDE0070 */
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
    [CodeAnalysisViolationExpected(
        "IDE0072", "Warning", disabledReason: "IDE0072 has a severity of suggestion.")]
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
            /* ----------↓↓↓↓↓↓---- IDE0072 */
            return color switch
            {
                Color.Blue => "Blue",
                _ => "Unknown",
            };
        }
    }
}
