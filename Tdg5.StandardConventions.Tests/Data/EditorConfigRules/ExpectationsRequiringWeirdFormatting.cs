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
    /// <remarks>
    /// Also triggers SA1000.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1000", "Warning")]
    public void IDE0055_KeywordsMustBeSpacedCorrectly()
    {
        lock(new object())
        {
            return;
        }
    }

    /// <summary>
    /// Method lacking a space after a comma.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1001.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1001", "Warning")]
    public void IDE0055_CommasMustBeSpacedCorrectly()
    {
        static int[] Method() => [1,2];
        Method();
    }

    /// <summary>
    /// Method lacking a space after a semicolon.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1002.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1002", "Warning")]
    public void IDE0055_SemicolonsMustBeSpacedCorrectly()
    {
        for (int i = 0;i < 10; i++)
        {
            continue;
        }
    }

    /// <summary>
    /// Method with a space after a unary operator.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1003.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1003", "Warning")]
    public void IDE0055_SymbolsMustBeSpacedCorrectly()
    {
        static bool Method() => ! true;
        Method();
    }

    /// <summary>
    /// Method with an opening parenthesis that is followed by a space.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1008.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1008", "Warning")]
    public void IDE0055_OpeningParenthesisMustBeSpacedCorrectly()
    {
        static (int, string) Method() => ( 0, "zero");
        Method();
    }

    /// <summary>
    /// Method with a closing parenthesis that is preceded by a space.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1009.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1009", "Warning")]
    public void IDE0055_ClosingParenthesisMustBeSpacedCorrectly()
    {
        static (int, string) Method() => (0, "zero" );
        Method();
    }

    /// <summary>
    /// Method with an opening square bracket that is followed by a space.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1010.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1010", "Warning")]
    public void IDE0055_OpeningSquareBracketsMustBeSpacedCorrectly()
    {
        static bool[] Method() => [ false];
        Method();
    }

    /// <summary>
    /// Method with a closing square bracket that is preceded by a space.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1011.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1011", "Warning")]
    public void IDE0055_ClosingSquareBracketsMustBeSpacedCorrectly()
    {
        static bool[] Method() => [true ];
        Method();
    }

    /// <summary>
    /// Method with an opening brace that is not followed by a space.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1012.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1012", "Warning")]
    public void IDE0055_OpeningBracesMustBeSpacedCorrectly()
    {
        static List<int> Method() => new() {1, 2 };
        Method();
    }

    /// <summary>
    /// Method with a closing brace that is not preceded by a space.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1013.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1013", "Warning")]
    public void IDE0055_ClosingBracesMustBeSpacedCorrectly()
    {
        static List<int> Method() => new() { 1, 2};
        Method();
    }

    /// <summary>
    /// Method with an opening generic bracket that is followed by a space.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1014.
    /// </remarks>
    /// <param name="thing">The thing.</param>
    /// <typeparam name="T">The type of thing.</typeparam>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1014", "Warning")]
    public void IDE0055_OpeningGenericBracketsMustBeSpacedCorrectly< T>(T thing)
    {
    }

    /// <summary>
    /// Method with a closing generic bracket that is preceded by a space.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1015.
    /// </remarks>
    /// <param name="thing">The thing.</param>
    /// <typeparam name="T">The type of thing.</typeparam>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1015", "Warning")]
    public void IDE0055_ClosingGenericBracketsMustBeSpacedCorrectly<T >(T thing)
    {
    }

    /// <summary>
    /// Method with an attribute with an opening bracket that is followed by a
    /// space.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1016.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1016", "Warning")]
    [ Obsolete("Not actually obsolete.")]
    public void IDE0055_OpeningAttributeBracketsMustBeSpacedCorrectly()
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
    [CodeAnalysisViolationExpected("SA1009", "Warning")]
    [CodeAnalysisViolationExpected("SA1017", "Warning")]
    [Obsolete("Not actually obsolete.") ]
    public void IDE0055_ClosingAttributeBracketsMustBeSpacedCorrectly()
    {
    }

    /// <summary>
    /// Method with nullable type symbol that is preceded by a space.
    /// space.
    /// </summary>
    /// <param name="maybe">The maybe.</param>
    /// <remarks>
    /// Also triggers SA1018.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1018", "Warning")]
    public void IDE0055_NullableTypeSymbolsMustNotBePrecededBySpace(string ? maybe)
    {
    }

    /// <summary>
    /// Method with a space following the member access symbol (.).
    /// </summary>
    /// <remarks>
    /// Also triggers SA1019 and SX1101.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1019", "Warning")]
    [CodeAnalysisViolationExpected("SX1101", "Warning")]
    public void IDE0055_MemberAccessSymbolsMustBeSpacedCorrectly()
    {
        this. IDE0055_ClosingBracesMustBeSpacedCorrectly();
    }

    /// <summary>
    /// Method with a space following an increment operator.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1020.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1020", "Warning")]
    public void IDE0055_IncrementDecrementSymbolsMustBeSpacedCorrectly()
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
    /// <remarks>
    /// Also triggers SA1021.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1021", "Warning")]
    public void IDE0055_NegativeSignsMustBeSpacedCorrectly()
    {
        static int[] Method() => [- 1];
        Method();
    }

    /// <summary>
    /// Method with a space preceding a positive symbol.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1022.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1022", "Warning")]
    public void IDE0055_PositiveSignsMustBeSpacedCorrectly()
    {
        static int[] Method() => [+ 1];
        Method();
    }

    /// <summary>
    /// Method with a deference operator that is preceded by a space.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1023.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1023", "Warning")]
    public void IDE0055_DereferenceAndAccessOfMustBeSpacedCorrectly()
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
    /// <remarks>
    /// Also triggers SA1025.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1025", "Warning")]
    public void IDE0055_CodeMustNotContainMultipleWhitespaceInARow()
    {
        static int Method() =>  1;
        Method();
    }

    /// <summary>
    /// Method with a space after new keyword in implicitly typed array allocation.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1026.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1026", "Warning")]
    public void IDE0055_CodeMustNotContainSpaceAfterNewKeywordInImplicitlyTypedArrayAllocation()
    {
        static int[] Method() => new [] { 1 };
        Method();
    }

    /// <summary>
    /// Method that uses a tab where a space is normally expected.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1027.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1027", "Warning")]
    public void IDE0055_UseTabsCorrectly()
    {
    	static int Method() => 1;
    	Method();
    }

    /// <summary>
    /// Method that contains trailing whitespace.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1028.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1028", "Warning")]
    public void IDE0055_CodeMustNotContainTrailingWhitespace()
    {
        static int Method() => 1;
        Method(); 
    }

    /// <summary>
    /// A method containing a query clause incorrectly broken across multiple lines.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1103.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1103", "Warning")]
    public void IDE0055_QueryClausesShouldBeOnSeparateLinesOrAllOnOneLine()
    {
        List<int> numbers = [1];
        object x = from number in numbers
                   where number > 0 select number;
    }

    /// <summary>
    /// A method containing a query clause that doesn't begin on a new line
    /// following a clause that spans multiple lines.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1104.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1104", "Warning")]
    public void IDE0055_QueryClauseShouldBeginOnNewLineWhenPreviousClauseSpansMultipleLines()
    {
        object things = from element in new int[] { 12, 45 }
        where
        element > 20 select element;
    }

    /// <summary>
    /// A method containing a query clause that spans multiple lines but doesn't
    /// begin on its own line.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1105.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1105", "Warning")]
    public void IDE0055_QueryClausesSpanningMultipleLinesShouldBeginOnOwnLine()
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
    /// <remarks>
    /// Also triggers SA1134.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1134", "Warning")]
    [Obsolete("Not obsolete.")][CodeAnalysisViolationExpected("Ignore", "Warning", disabledReason: "Not a real attribute.")]
    public void IDE0055_AttributesMustNotShareLine()
    {
    }

    /// <summary>
    /// Method that contains elements that are not indented evenly.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1137.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1137", "Warning")]
    public void IDE0055_ElementsShouldHaveTheSameIndentation()
    {
        static int Method() => 1;
          Method();
    }

    /// <summary>
    /// A method that contains a delegate with unnecessary parentheses.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1130 and SA1410.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1130", "Warning")]
    [CodeAnalysisViolationExpected("SA1410", "Warning")]
    public void IDE0055_RemoveDelegateParenthesisWhenPossible()
    {
        static int Method(Func<int> func) => func();
        Method(delegate() { return 2; });
    }

    /// <summary>
    /// A method that contains a multi-line block statement where the opening
    /// brace is not on its own line.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1500.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1500", "Warning")]
    public void IDE0055_BracesForMultiLineStatementsMustNotShareLine()
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
        /// <remarks>
        /// Also triggers SA1007.
        /// </remarks>
        [CodeAnalysisViolationExpected("IDE0055", "Warning")]
        [CodeAnalysisViolationExpected("SA1007", "Warning")]
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
    /// <remarks>
    /// Also triggers SA1024.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0055", "Warning")]
    [CodeAnalysisViolationExpected("SA1024", "Warning")]
    public class IDE0055_ColonsMustBeSpacedCorrectly: IDE0055_OperatorKeywordMustBeFollowedBySpace_Wrapper
    {
    }
}
