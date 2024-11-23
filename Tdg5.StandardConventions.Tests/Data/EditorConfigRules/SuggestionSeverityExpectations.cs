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
        static int ArithmeticBinaryOperatorsMethod() => 1 + 2 * 3;
        ArithmeticBinaryOperatorsMethod();
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
        var substring = message.Substring(0, message.Length - 5);
        Console.WriteLine(substring);
    }
}
