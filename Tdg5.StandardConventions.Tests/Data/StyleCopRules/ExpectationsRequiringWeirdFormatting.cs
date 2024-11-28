using System;
using System.Collections.Generic;
using System.Linq;
using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopRules;

/// <summary>
/// Various expectations that require weird formatting.
/// </summary>
/// <remarks>
/// Lots of arrays are used because they don't trigger CS0219 for some reason.
/// </remarks>
[CodeAnalysisViolationExpected("IDE0055", "Warning")]
public class ExpectationsRequiringWeirdFormatting
{
    /// <summary>
    /// Method lacking a space after the lock keyword.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1000", "Warning")]
    public void SA1000_KeywordsMustBeSpacedCorrectly()
    {
        lock(new object())
        {
            return;
        }
    }

    /// <summary>
    /// Method lacking a space after a comma.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1001", "Warning")]
    public void SA1001_CommasMustBeSpacedCorrectly()
    {
        static bool[] Method() => [true,false];
        Method();
    }

    /// <summary>
    /// Method lacking a space after a semicolon.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1002", "Warning")]
    public void SA1002_SemicolonsMustBeSpacedCorrectly()
    {
        for (int i = 0;i < 10; i++)
        {
            continue;
        }
    }

    /// <summary>
    /// Method with a space after a unary operator.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1003", "Warning")]
    public void SA1003_SymbolsMustBeSpacedCorrectly()
    {
        static bool Method() => ! true;
        Method();
    }

    /// <summary>
    /// Method with an inline comment missing a space after the forward slashes.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1005", "Warning")]
    public void SA1005_SingleLineCommentsMustBeginWithSingleSpace()
    {
        //Comment missing a space after the forward slashes.
    }

    /// <summary>
    /// Method with a preprocessor keyword that is preceded by a space.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1006", "Warning")]
    public void SA1006_PreprocessorKeywordsMustNotBePrecededBySpace()
    {
# if true
#endif
    }

    /// <summary>
    /// Method with an opening parenthesis that is followed by a space.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1008", "Warning")]
    public void SA1008_OpeningParenthesisMustBeSpacedCorrectly()
    {
        static (int, string) Method() => ( 0, "zero");
        Method();
    }

    /// <summary>
    /// Method with a closing parenthesis that is preceded by a space.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1009", "Warning")]
    public void SA1009_ClosingParenthesisMustBeSpacedCorrectly()
    {
        static (int, string) Method() => (0, "zero" );
        Method();
    }

    /// <summary>
    /// Method with an opening square bracket that is followed by a space.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1010", "Warning")]
    public void SA1010_OpeningSquareBracketsMustBeSpacedCorrectly()
    {
        static bool[] Method() => [ false];
        Method();
    }

    /// <summary>
    /// Method with a closing square bracket that is preceded by a space.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1011", "Warning")]
    public void SA1011_ClosingSquareBracketsMustBeSpacedCorrectly()
    {
        static bool[] Method() => [false ];
        Method();
    }

    /// <summary>
    /// Method with an opening brace that is not followed by a space.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1012", "Warning")]
    public void SA1012_OpeningBracesMustBeSpacedCorrectly()
    {
        static List<int> Method() => new() {1, 2 };
        Method();
    }

    /// <summary>
    /// Method with a closing brace that is not preceded by a space.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1013", "Warning")]
    public void SA1013_ClosingBracesMustBeSpacedCorrectly()
    {
        static List<int> Method() => new() { 1, 2};
        Method();
    }

    /// <summary>
    /// Method with an opening generic bracket that is followed by a space.
    /// </summary>
    /// <param name="thing">The thing.</param>
    /// <typeparam name="T">The type of thing.</typeparam>
    [CodeAnalysisViolationExpected("SA1014", "Warning")]
    public void SA1014_OpeningGenericBracketsMustBeSpacedCorrectly< T>(T thing)
    {
    }

    /// <summary>
    /// Method with a closing generic bracket that is preceded by a space.
    /// </summary>
    /// <param name="thing">The thing.</param>
    /// <typeparam name="T">The type of thing.</typeparam>
    [CodeAnalysisViolationExpected("SA1015", "Warning")]
    public void SA1015_ClosingGenericBracketsMustBeSpacedCorrectly<T >(T thing)
    {
    }

    /// <summary>
    /// Method with an attribute with an opening bracket that is followed by a
    /// space.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1016", "Warning")]
    [ Obsolete("Not actually obsolete.")]
    public void SA1016_OpeningAttributeBracketsMustBeSpacedCorrectly()
    {
    }

    /// <summary>
    /// Method with an attribute with an closing bracket that is followed by a
    /// space.
    /// </summary>
    /// <remarks>
    /// This happens to trigger SA1009 also.
    /// </remarks>
    [CodeAnalysisViolationExpected("SA1009", "Warning")]
    [CodeAnalysisViolationExpected("SA1017", "Warning")]
    [Obsolete("Not actually obsolete.") ]
    public void SA1017_ClosingAttributeBracketsMustBeSpacedCorrectly()
    {
    }

    /// <summary>
    /// Method with nullable type symbol that is preceded by a space.
    /// space.
    /// </summary>
    /// <param name="maybe">The maybe.</param>
    [CodeAnalysisViolationExpected("SA1018", "Warning")]
    public void SA1018_NullableTypeSymbolsMustNotBePrecededBySpace(string ? maybe)
    {
    }

    /// <summary>
    /// Method with a space following the member access symbol (.).
    /// </summary>
    /// <remarks>
    /// Also triggers SX1101.
    /// </remarks>
    [CodeAnalysisViolationExpected("SA1019", "Warning")]
    [CodeAnalysisViolationExpected("SX1101", "Warning")]
    public void SA1019_MemberAccessSymbolsMustBeSpacedCorrectly()
    {
        this. SA1013_ClosingBracesMustBeSpacedCorrectly();
    }

    /// <summary>
    /// Method with a space following an increment operator.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1020", "Warning")]
    public void SA1020_IncrementDecrementSymbolsMustBeSpacedCorrectly()
    {
        static int Method(int value) => ++ value;
        Method(0);
    }

    /// <summary>
    /// Method with a space preceding a negative symbol.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1021", "Warning")]
    public void SA1021_NegativeSignsMustBeSpacedCorrectly()
    {
        static int Method() => - 1;
        Method();
    }

    /// <summary>
    /// Method with a space preceding a positive symbol.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1022", "Warning")]
    public void SA1022_PositiveSignsMustBeSpacedCorrectly()
    {
        static int Method() => + 1;
        Method();
    }

    /// <summary>
    /// Method with a deference operator that is preceded by a space.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1023", "Warning")]
    public void SA1023_DereferenceAndAccessOfMustBeSpacedCorrectly()
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
    [CodeAnalysisViolationExpected("SA1025", "Warning")]
    public void SA1025_CodeMustNotContainMultipleWhitespaceInARow()
    {
        static int Method() =>  1;
        Method();
    }

    /// <summary>
    /// Method with a space after new keyword in implicitly typed array allocation.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1026", "Warning")]
    public void SA1026_CodeMustNotContainSpaceAfterNewKeywordInImplicitlyTypedArrayAllocation()
    {
        static int[] Method() => new [] { 1 };
        Method();
    }

    /// <summary>
    /// Method that uses a tab where a space is normally expected.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1027", "Warning")]
    public void SA1027_UseTabsCorrectly()
    {
    	static int Method() => 1;
    	Method();
    }

    /// <summary>
    /// Method that contains trailing whitespace.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1028", "Warning")]
    public void SA1028_CodeMustNotContainTrailingWhitespace()
    {
        static int Method() => 1;
        Method(); 
    }

    /// <summary>
    /// A method containing a query clause incorrectly broken across multiple lines.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1103", "Warning")]
    public void SA1103_QueryClausesShouldBeOnSeparateLinesOrAllOnOneLine()
    {
        List<int> numbers = [1];
        object Method()
        {
            return from number in numbers
            where number > 0 select number;
        }

        Method();
    }

    /// <summary>
    /// A method containing a query clause that doesn't begin on a new line
    /// following a clause that spans multiple lines.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1104", "Warning")]
    public void SA1104_QueryClauseShouldBeginOnNewLineWhenPreviousClauseSpansMultipleLines()
    {
        object things = from element in new int[] { 12, 45 }
        where
        element > 20 select element;
    }

    /// <summary>
    /// A method containing a query clause that spans multiple lines but doesn't
    /// begin on its own line.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1105", "Warning")]
    public void SA1105_QueryClausesSpanningMultipleLinesShouldBeginOnOwnLine()
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
    [CodeAnalysisViolationExpected("SA1134", "Warning")]
    [Obsolete("Not obsolete.")][CodeAnalysisViolationExpected("Ignore", "Warning", disabledReason: "Not a real attribute.")]
    public void SA1134_AttributesMustNotShareLine()
    {
    }

    /// <summary>
    /// Method that contains elements that are not indented evenly.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1137", "Warning")]
    public void SA1137_ElementsShouldHaveTheSameIndentation()
    {
        static int Method() => 1;
          Method();
    }

    /// <summary>
    /// A method that contains a delegate with unnecessary parentheses.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1130.
    /// </remarks>
    [CodeAnalysisViolationExpected("SA1130", "Warning")]
    [CodeAnalysisViolationExpected("SA1410", "Warning")]
    public void SA1410_RemoveDelegateParenthesisWhenPossible()
    {
        static int Method(Func<int> func) => func();
        Method(delegate() { return 2; });
    }

    /// <summary>
    /// A method that contains a multi-line block statement where the opening
    /// brace is not on its own line.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1500", "Warning")]
    public void SA1500_BracesForMultiLineStatementsMustNotShareLine()
    {
        lock (new object()) {
        }
    }

    /// <summary>
    /// A method that contains a statement that is on a single line.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1501", "Warning")]
    public void SA1501_StatementMustNotBeOnSingleLine()
    {
        lock (new object()) { }
    }

    /// <summary>
    /// A method that contains an element that is wrapped in opening and closing
    /// braces, written on a single line.
    /// </summary>
    /// <remarks>
    /// Also triggers SA1501.
    /// </remarks>
    [CodeAnalysisViolationExpected("SA1501", "Warning")]
    [CodeAnalysisViolationExpected("SA1502", "Warning")]
    public void SA1502_ElementMustNotBeOnSingleLine()
    {
        static int Method() { return 1; }
        Method();
    }

    /// <summary>
    /// Class wraping a method that has a documentation comment that is missing
    /// a space after the forward slashes.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1004", "Warning")]
    public class SA1004_DocumentationLinesMustBeginWithSingleSpace_Wrapper
    {
        /// <summary>
        ///Comment missing a space after the forward slashes.
        /// </summary>
        public void SA1004_DocumentationLinesMustBeginWithSingleSpace()
        {
        }
    }

    /// <summary>
    /// Class wrapping an operator method that is missing a space after the
    /// operator keyword.
    /// </summary>
    public class SA1007_OperatorKeywordMustBeFollowedBySpace_Wrapper
    {
        /// <summary>
        /// Operator method that is missing a space after the operator keyword.
        /// </summary>
        /// <param name="a">The first thing.</param>
        /// <param name="b">The other thing.</param>
        /// <returns>Thing a.</returns>
        [CodeAnalysisViolationExpected("SA1007", "Warning")]
        public static SA1007_OperatorKeywordMustBeFollowedBySpace_Wrapper operator+(
            SA1007_OperatorKeywordMustBeFollowedBySpace_Wrapper a,
            SA1007_OperatorKeywordMustBeFollowedBySpace_Wrapper b)
        {
            return a;
        }
    }

    /// <summary>
    /// Class with a colon that is not preceded by a space.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1024", "Warning")]
    public class SA1024_ColonsMustBeSpacedCorrectly: SA1004_DocumentationLinesMustBeginWithSingleSpace_Wrapper
    {
    }
}
