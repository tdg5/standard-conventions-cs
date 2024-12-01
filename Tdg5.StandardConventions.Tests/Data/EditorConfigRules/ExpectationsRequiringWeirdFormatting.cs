using System;
using System.Collections.Generic;
using System.Linq;
using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.EditorConfigRules;

/// <summary>
/// Various expectations that require weird formatting.
/// </summary>
public class ExpectationsRequiringWeirdFormatting
{
    /// <summary>
    /// Method lacking a space after the lock keyword.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1000")]
    public static void IDE0055_KeywordsMustBeSpacedCorrectly()
    {
        lock(new object())
        {
            return;
        }
    }

    /// <summary>
    /// Method lacking a space after a comma.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1001")]
    public static void IDE0055_CommasMustBeSpacedCorrectly()
    {
        static int[] Method() => [1,2];
        Method();
    }

    /// <summary>
    /// Method lacking a space after a semicolon.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1002")]
    public static void IDE0055_SemicolonsMustBeSpacedCorrectly()
    {
        for (int i = 0;i < 10; i++)
        {
            continue;
        }
    }

    /// <summary>
    /// Method with a space after a unary operator.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1003")]
    public static void IDE0055_SymbolsMustBeSpacedCorrectly()
    {
        static bool Method() => ! true;
        Method();
    }

    /// <summary>
    /// Method with an opening parenthesis that is followed by a space.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1008")]
    public static void IDE0055_OpeningParenthesisMustBeSpacedCorrectly()
    {
        static (int, string) Method() => ( 0, "zero");
        Method();
    }

    /// <summary>
    /// Method with a closing parenthesis that is preceded by a space.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1009")]
    public static void IDE0055_ClosingParenthesisMustBeSpacedCorrectly()
    {
        static (int, string) Method() => (0, "zero" );
        Method();
    }

    /// <summary>
    /// Method with an opening square bracket that is followed by a space.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1010")]
    public static void IDE0055_OpeningSquareBracketsMustBeSpacedCorrectly()
    {
        static bool[] Method() => [ false];
        Method();
    }

    /// <summary>
    /// Method with a closing square bracket that is preceded by a space.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1011")]
    public static void IDE0055_ClosingSquareBracketsMustBeSpacedCorrectly()
    {
        static bool[] Method() => [true ];
        Method();
    }

    /// <summary>
    /// Method with an opening brace that is not followed by a space.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1012")]
    public static void IDE0055_OpeningBracesMustBeSpacedCorrectly()
    {
        static List<int> Method() => new() {1, 2 };
        Method();
    }

    /// <summary>
    /// Method with a closing brace that is not preceded by a space.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1013")]
    public static void IDE0055_ClosingBracesMustBeSpacedCorrectly()
    {
        static List<int> Method() => new() { 1, 2};
        Method();
    }

    /// <summary>
    /// Method with an opening generic bracket that is followed by a space.
    /// </summary>
    /// <param name="thing">The thing.</param>
    /// <typeparam name="T">The type of thing.</typeparam>
    /// <returns>The thing that was given.</returns>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1014")]
    public static T IDE0055_OpeningGenericBracketsMustBeSpacedCorrectly< T>(T thing)
    {
        return thing;
    }

    /// <summary>
    /// Method with a closing generic bracket that is preceded by a space.
    /// </summary>
    /// <param name="thing">The thing.</param>
    /// <typeparam name="T">The type of thing.</typeparam>
    /// <returns>The given thing.</returns>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1015")]
    public static T IDE0055_ClosingGenericBracketsMustBeSpacedCorrectly<T >(T thing)
    {
        return thing;
    }

    /// <summary>
    /// Method with an attribute with an opening bracket that is followed by a
    /// space.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1016")]
    [ Obsolete("Not actually obsolete.")]
    public static void IDE0055_OpeningAttributeBracketsMustBeSpacedCorrectly()
    {
    }

    /// <summary>
    /// Method with an attribute with an closing bracket that is followed by a
    /// space.
    /// </summary>
    /// <remarks>
    /// This happens to trigger SA1009 and SA1017 also.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1009")]
    [IncidentalCodeAnalysisViolationExpected("SA1017")]
    [Obsolete("Not actually obsolete.") ]
    public static void IDE0055_ClosingAttributeBracketsMustBeSpacedCorrectly()
    {
    }

    /// <summary>
    /// Method with nullable type symbol that is preceded by a space.
    /// space.
    /// </summary>
    /// <param name="maybe">The maybe.</param>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1018")]
    public static void IDE0055_NullableTypeSymbolsMustNotBePrecededBySpace(string ? maybe)
    {
    }

    /// <summary>
    /// Method with a space following the member access symbol (.).
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1019")]
    public static void IDE0055_MemberAccessSymbolsMustBeSpacedCorrectly()
    {
        ExpectationsRequiringWeirdFormatting. IDE0055_ClosingBracesMustBeSpacedCorrectly();
    }

    /// <summary>
    /// Method with a space following an increment operator.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1020")]
    public static void IDE0055_IncrementDecrementSymbolsMustBeSpacedCorrectly()
    {
        int i = 0;
        int[] thing = [++ i];
        if (thing[0] == 0)
        {
            throw new InvalidOperationException("i is 0.");
        }
    }

    /// <summary>
    /// Method with a space preceding a negative symbol.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1021")]
    public static void IDE0055_NegativeSignsMustBeSpacedCorrectly()
    {
        static int[] Method() => [- 1];
        Method();
    }

    /// <summary>
    /// Method with a space preceding a positive symbol.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1022")]
    public static void IDE0055_PositiveSignsMustBeSpacedCorrectly()
    {
        static int[] Method() => [+ 1];
        Method();
    }

    /// <summary>
    /// Method with a deference operator that is preceded by a space.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1023")]
    public static void IDE0055_DereferenceAndAccessOfMustBeSpacedCorrectly()
    {
        unsafe
        {
            static int * Method() => null;
            Method();
        }
    }

    /// <summary>
    /// Method with multiple whitespace in a row.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1025")]
    public static void IDE0055_CodeMustNotContainMultipleWhitespaceInARow()
    {
        static int Method() =>  1;
        Method();
    }

    /// <summary>
    /// Method with a space after new keyword in implicitly typed array allocation.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1026")]
    public static void IDE0055_CodeMustNotContainSpaceAfterNewKeywordInImplicitlyTypedArrayAllocation()
    {
        static int[] Method() => new [] { 1 };
        Method();
    }

    /// <summary>
    /// Method that uses a tab where a space is normally expected.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1027")]
    public static void IDE0055_UseTabsCorrectly()
    {
    	static int Method() => 1;
    	Method();
    }

    /// <summary>
    /// Method that contains trailing whitespace.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1028")]
    public static void IDE0055_CodeMustNotContainTrailingWhitespace()
    {
        static int Method() => 1;
        Method(); 
    }

    /// <summary>
    /// A method containing a query clause incorrectly broken across multiple lines.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1103")]
    public static void IDE0055_QueryClausesShouldBeOnSeparateLinesOrAllOnOneLine()
    {
        List<int> numbers = [1];
        object x = from number in numbers
                   where number > 0 select number;
    }

    /// <summary>
    /// A method containing a query clause that doesn't begin on a new line
    /// following a clause that spans multiple lines.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1104")]
    public static void IDE0055_QueryClauseShouldBeginOnNewLineWhenPreviousClauseSpansMultipleLines()
    {
        object things = from element in Enumerable.Range(0, 100)
        where
        element > 20 select element;
    }

    /// <summary>
    /// A method containing a query clause that spans multiple lines but doesn't
    /// begin on its own line.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1105")]
    public static void IDE0055_QueryClausesSpanningMultipleLinesShouldBeginOnOwnLine()
    {
        static int GenerateItem(int element) => element;

        List<int> elements = [1];
        var items =
            from element in elements select
                GenerateItem(element);
    }

    /// <summary>
    /// A method annotated with two attributes placed on the same line.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1134")]
    [Obsolete("Not obsolete.")][CodeAnalysisViolationExpected("Ignore", "Warning", disabledReason: "Not a real attribute.")]
    public static void IDE0055_AttributesMustNotShareLine()
    {
    }

    /// <summary>
    /// Method that contains elements that are not indented evenly.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1137")]
    public static void IDE0055_ElementsShouldHaveTheSameIndentation()
    {
        static int Method() => 1;
          Method();
    }

    /// <summary>
    /// A method that contains a delegate with unnecessary parentheses.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1130")]
    [IncidentalCodeAnalysisViolationExpected("SA1410")]
    public static void IDE0055_RemoveDelegateParenthesisWhenPossible()
    {
        static int Method(Func<int> func) => func();
        Method(delegate() { return 2; });
    }

    /// <summary>
    /// A method that contains a multi-line block statement where the opening
    /// brace is not on its own line.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1500")]
    public static void IDE0055_BracesForMultiLineStatementsMustNotShareLine()
    {
        lock (new object()) {
        }
    }

    /// <summary>
    /// Class wrapping an operator method that is missing a space after the
    /// operator keyword.
    /// </summary>
    public class IDE0055_OperatorKeywordMustBeFollowedBySpace_Wrapper
    {
        /// <summary>
        /// Operator method that is missing a space after the operator keyword.
        /// </summary>
        /// <param name="a">The first thing.</param>
        /// <param name="b">The other thing.</param>
        /// <returns>Thing a.</returns>
        [CodeAnalysisViolationExpected("IDE0055", "Warning")]
        [IncidentalCodeAnalysisViolationExpected("SA1007")]
        public static IDE0055_OperatorKeywordMustBeFollowedBySpace_Wrapper operator+(
            IDE0055_OperatorKeywordMustBeFollowedBySpace_Wrapper a,
            IDE0055_OperatorKeywordMustBeFollowedBySpace_Wrapper b)
        {
            return a;
        }
    }

    /// <summary>
    /// Class with a colon that is not preceded by a space.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1024")]
    public class IDE0055_ColonsMustBeSpacedCorrectly: IDE0055_OperatorKeywordMustBeFollowedBySpace_Wrapper
    {
    }
}
