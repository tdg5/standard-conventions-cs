using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopRules;

/// <summary>
/// Various block scoped expectations for StyleCop rules.
/// </summary>
public class BlockScopedExpectations
{
    /// <summary>
    /// An interface that does not begin with the letter I.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1302", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("IDE1006")]
    public interface SA1302_InterfaceNamesMustBeginWithI
    {
    }

    /// <summary>
    /// A method containing a query clause that doesn't immediately follow the
    /// previous clause.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1102", "Warning")]
    public static void SA1102_QueryClauseShouldFollowPreviousClause()
    {
        List<int> numbers = [1];
        var x = from number in numbers

                select number;
    }

    /// <summary>
    /// A method containing an empty statement.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1106", "Warning")]
    public static void SA1106_CodeMustNotContainEmptyStatements()
    {
        static int Method() => 0;
        Method();
        ;
    }

    /// <summary>
    /// A method containing multiple statements on the same line.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1107", "Warning")]
    public static void SA1107_CodeMustNotContainMultipleStatementsOnOneLine()
    {
        List<int> thing = [1]; thing.Add(2);
    }

    /// <summary>
    /// A method containing a block statement with an embedded comment.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1108", "Warning")]
    public static void SA1108_BlockStatementsMustNotContainEmbeddedComments()
    {
        if (0 != 1)

        // Make sure 0 does not equal 1.
        {
        }
    }

    /// <summary>
    /// A method containing a region within a block statement.
    /// </summary>
    /// <remarks>
    /// SA1123 triggers in all the same cases as SA1109 and SA1123 is prefered.
    /// </remarks>
    [CodeAnalysisViolationExpected("SA1109", "Warning", disabledReason: "SA1109 is disabled")]
    [IncidentalCodeAnalysisViolationExpected("SA1123")]
    public static void SA1109_BlockStatementsMustNotContainEmbeddedRegions()
    {
        if (0 != 1)
        #region
        {
        }
        #endregion
    }

    /// <summary>
    /// A method containing a parenthesis that is not on the same line as the
    /// method it relates to.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1110", "Warning")]
    public static void SA1110_OpeningParenthesisMustBeOnDeclarationLine()
    {
        List<int> thing = [];
        thing.Add
            (1);
    }

    /// <summary>
    /// A method containing a parenthesis that is not on the same line as the
    /// last parameter.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1111", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1009")]
    public static void SA1111_ClosingParenthesisMustBeOnLineOfLastParameter()
    {
        List<int> thing = [];
        thing.Add(
            1
        );
    }

    /// <summary>
    /// A method containing a method call that takes no arguments where the
    /// closing parenthesis that is not on the same line as the opening
    /// parenthesis.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1112", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1009")]
    public static void SA1112_ClosingParenthesisMustBeOnLineOfOpeningParenthesis()
    {
        static int Method() => 0;
        Method(
        );
    }

    /// <summary>
    /// A method containing a method call including a comma that is
    /// not on the same line as the previous parameter.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1113", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1001")]
    public static void SA1113_CommaMustBeOnSameLineAsPreviousParameter()
    {
        static int Method(int a, int b) => a + b;
        Method(
            1
            , 2);
    }

    /// <summary>
    /// A method containing a method where the parameter list doesn't
    /// immediately follow the declaration.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1114", "Warning")]
    public static void SA1114_ParameterListMustFollowDeclaration()
    {
        static int Method(

            int a, int b) => a + b;
        Method(1, 2);
    }

    /// <summary>
    /// A method containing a method where there in a blank line between
    /// arguments.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1115", "Warning")]
    public static void SA1115_ParameterMustFollowComma()
    {
        static int Method(
            int a,

            int b) => a + b;
        Method(1, 2);
    }

    /// <summary>
    /// A method containing a method where the arguments are split across multiple
    /// lines but the first argument doesn't appear on a new line.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1116", "Warning")]
    public static void SA1116_SplitParametersMustStartOnLineAfterDeclaration()
    {
        static int Method(int a,
            int b) => a + b;
        Method(1, 2);
    }

    /// <summary>
    /// A method containing a method where the arguments are not all on the
    /// same line or each on its own line.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1117", "Warning")]
    public static void SA1117_ParametersMustBeOnSameLineOrSeparateLines()
    {
        static int Method(int a, int b,
            int c) => a + b + c;
        Method(1, 2, 3);
    }

    /// <summary>
    /// A method containing a method call where a parameter other than the first
    /// is broken across multiple lines.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1118", "Warning")]
    public static void SA1118_ParameterMustNotSpanMultipleLines()
    {
        static int Method(int a, int b) => a + b;
        Method(1, 2
            + 2);
    }

    /// <summary>
    /// A method containing unnecessary parenthesis.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1119", "Warning")]
    public static void SA1119_StatementMustNotUseUnnecessaryParenthesis()
    {
        static int Method() => 1 + (2);
        Method();
    }

    /// <summary>
    /// A method containing a comment with no content.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1120", "Warning")]
    public static void SA1120_CommentsMustContainText()
    {
        //
    }

    /// <summary>
    /// A method containing a built-in type that is not referenced by its
    /// built-in alias.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1121", "Warning")]
    public static void SA1121_UseBuiltInTypeAlias()
    {
        static System.Int32 Method() => 1;
        Method();
    }

    /// <summary>
    /// A method containing a an empty string that is not string.Empty.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1122", "Warning")]
    public static void SA1122_UseStringEmptyForEmptyStrings()
    {
        static string Method() => "";
        Method();
    }

    /// <summary>
    /// A method containing a region within an element.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1123", "Warning")]
    public static void SA1123_DoNotPlaceRegionsWithinElements()
    {
        #region
        #endregion
    }

    /// <summary>
    /// A method containing a nullable type that is not referenced by its
    /// short form name.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1125", "Warning")]
    public static void SA1125_UseShorthandForNullableTypes()
    {
        static Nullable<int> Method() => 1;
        Method();
    }

    /// <summary>
    /// A method with a generic constraint that is not on a new line.
    /// </summary>
    /// <typeparam name="T">A type parameter.</typeparam>
    [CodeAnalysisViolationExpected("SA1127", "Warning")]
    public static void SA1127_GenericTypeConstraintsMustBeOnOwnLine<T>() where T : class
    {
    }

    /// <summary>
    /// A method that uses a default constructor for a value type.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1129", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("IDE0028")]
    [IncidentalCodeAnalysisViolationExpected("IDE0090")]
    public static void SA1129_DoNotUseDefaultValueTypeConstructor()
    {
        static ImmutableArray<int> Method() => new ImmutableArray<int>();
        Method();
    }

    /// <summary>
    /// A method that uses a delegate instead of a lambda.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1130", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("IDE0039")]
    public static void SA1130_UseLambdaSyntax()
    {
        int x = 0;
        Action a = delegate { ++x; };
        a();
        if (x == 0)
        {
            return;
        }
    }

    /// <summary>
    /// A method containing a comparison made between a variable and a literal
    /// or constant value, and the variable appeared on the right-hand side of
    /// the expression.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1131", "Warning")]
    public static void SA1131_UseReadableConditions()
    {
        int x = 0;
        if (0 == x)
        {
        }
    }

    /// <summary>
    /// A method annotated with two attributes placed within the same set of
    /// square brackets.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1133", "Warning")]
    [
        Obsolete("Not actually obsolete."),
        CodeAnalysisViolationExpected(
            "Another attribute", "Warning", disabledReason: "Not a real attribute.")
    ]
    public static void SA1133_DoNotCombineAttributes()
    {
    }

    /// <summary>
    /// A method that uses a cast instead of literal syntax.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1139", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("IDE0004")]
    public static void SA1139_UseLiteralsSuffixNotationInsteadOfCasting()
    {
        static long Method() => (long)1;
        Method();
    }

    /// <summary>
    /// A method that uses a ValueTuple.Create instead of the preferred tuple
    /// language construct.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1141", "Warning")]
    public static void SA1141_UseTupleSyntax()
    {
        static (int, int) Method() => ValueTuple.Create(1, 1);
        Method();
    }

    /// <summary>
    /// A method that refers to a tuple element by its metadata name instead of
    /// its element name.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1142", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("IDE0033")]
    public static void SA1142_ReferToTupleElementsByName()
    {
        (int ValueA, int ValueB) Method() => (1, 1);
        int Method2() => Method().Item1;
        Method2();
    }

    /// <summary>
    /// A method that starts with a lowercase letter.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1300", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("IDE1006")]
    public static void a_SA1300_ElementMustBeginWithUpperCaseLetter()
    {
    }

    /// <summary>
    /// A method that contains a variable that starts with an uppercase letter.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1312", "Warning")]
    public static void SA1312_VariableNamesMustBeginWithLowerCaseLetter()
    {
        int Variable = 0;
        int Method() => Variable;
        Method();
    }

    /// <summary>
    /// A method that contains a parameter that starts with an uppercase letter.
    /// </summary>
    /// <param name="Variable">A parameter.</param>
    [CodeAnalysisViolationExpected("SA1313", "Warning")]
    public static void SA1313_ParameterNamesMustBeginWithLowerCaseLetter(int Variable)
    {
        int Method() => Variable;
        Method();
    }

    /// <summary>
    /// A method with a type parameter that doesn't start with T.
    /// </summary>
    /// <param name="variable">A parameter.</param>
    /// <typeparam name="Var">A badly named type parameter.</typeparam>
    [CodeAnalysisViolationExpected("SA1314", "Warning")]
    public static void SA1314_TypeParameterNamesMustBeginWithT<Var>(Var variable)
    {
        Var Method() => variable;
        Method();
    }

    /// <summary>
    /// A method that is annotated with a suppress message without a justification.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1404", "Warning")]
    [SuppressMessage("Style", "CS0219")]
    public static void SA1404_CodeAnalysisSuppressionMustHaveJustification()
    {
    }

    /// <summary>
    /// A method that contains a Debug.Assert without a message.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1405", "Warning")]
    public static void SA1405_DebugAssertMustProvideMessageText()
    {
        Debug.Assert(true);
    }

    /// <summary>
    /// A method that contains a <see cref="Debug.Fail(string)"/> without a message.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1406", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("IDE0004")]
    public static void SA1406_DebugFailMustProvideMessageText()
    {
        Debug.Fail((string?)null);
    }

    /// <summary>
    /// A method that contains an arithmetic expression that doesn't declare
    /// precedence.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1407", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("IDE0048")]
    public static void SA1407_ArithmeticExpressionsMustDeclarePrecedence()
    {
        int x = 1 + 2 * 3;
        int Method() => x;
        Method();
    }

    /// <summary>
    /// A method that contains a conditional expression that doesn't declare
    /// precedence.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1408", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("IDE0048")]
    public static void SA1408_ConditionalExpressionsMustDeclarePrecedence()
    {
        bool x = false || true && true && false || true;
        bool Method() => x;
        Method();
    }

    /// <summary>
    /// A method that contains a multi-line initializer that doesn't use a
    /// trailing comma.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1413", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("IDE0300")]
    public static void SA1413_UseTrailingCommasInMultiLineInitializers()
    {
        static int[] Method() => new int[]
        {
            1,
            2
        };
        Method();
    }

    /// <summary>
    /// A method that contains a statement that should use braces, but does not.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "SA1503", "Warning", disabledReason: "SA1503 is silenced")]
    [IncidentalCodeAnalysisViolationExpected("IDE0011")]
    public static void SA1503_BracesMustNotBeOmitted()
    {
        if (true)
            return;
    }

    /// <summary>
    /// A method tha contains multiple blank lines in a row.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1507", "Warning")]
    public static void SA1507_CodeMustNotContainMultipleBlankLinesInARow()
    {
        static int Method() => 0;


        Method();
    }

    /// <summary>
    /// A method tha contains a closing brace that is preceded by a blank line.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1508", "Warning")]
    public static void SA1508_ClosingBracesMustNotBePrecededByBlankLine()
    {
        static int Method() => 0;
        Method();

    }

    /// <summary>
    /// A method tha contains an opening brace that is prededed by a blank line.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1509", "Warning")]
    public static void SA1509_OpeningBracesMustNotBePrecededByBlankLine()

    {
        static int Method() => 0;
        Method();
    }

    /// <summary>
    /// A method that contains a chained statment block that is preceded by a
    /// blank line.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1510", "Warning")]
    public static void SA1510_ChainedStatementBlocksMustNotBePrecededByBlankLine()
    {
        try
        {
        }

        finally
        {
        }
    }

    /// <summary>
    /// A method that contains a while do footer that is preceded by a
    /// blank line.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1511", "Warning")]
    public static void SA1511_WhileDoFooterMustNotBePrecededByBlankLine()
    {
        do
        {
        }

        while (false);
    }

    /// <summary>
    /// A method that contains a single line comment that is followed by a blank
    /// line.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1512", "Warning")]
    public static void SA1512_SingleLineCommentsMustNotBeFollowedByBlankLine()
    {
        // Single line comment

        static int Method() => 0;
        Method();
    }

    /// <summary>
    /// A method that contains a single line comment that is not preceded by a
    /// blank line.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "SA1515", "Warning", disabledReason: "SA1515 is silenced")]
    public static void SA1515_SingleLineCommentMustBePrecededByBlankLine()
    {
        static int Method() => 0;
        // Single line comment
        Method();
    }

    /// <summary>
    /// A method that contains a closing brace that is not followed by a blank
    /// line.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "SA1513", "Warning", disabledReason: "SA1513 is silenced")]
    public static void SA1513_ClosingBraceMustBeFollowedByBlankLine()
    {
        static int Method() => 0;
        if (Method() == 0)
        {
        }
        Method();
    }

    /// <summary>
    /// A method that contains a multi-line child statement without braces.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1519", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("IDE0011")]
    public static void SA1519_BracesMustNotBeOmittedFromMultiLineChildStatement()
    {
        static int Method(int value) => value;

        if (true)
            Method(
                1);
    }

    /// <summary>
    /// A method that makes inconsistent use of braces.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1520", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("IDE0011")]
    public static void SA1520_UseBracesConsistently()
    {
        static int Method(int value) => value;

        if (Method(1) == 1)
        {
            Method(2);
        }
        else
            Method(3);
    }

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    public static void SA1600_ElementsMustBeDocumented()
    {
    }

    /// <summary>
    /// A method that contains a single line comment that uses three slashes
    /// like a documentation comment.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1626", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("CS1587")]
    public static void SA1626_SingleLineCommentsMustNotUseDocumentationStyleSlashes()
    {
        static int Method() => 0;
        /// Single line comment
        Method();
    }

    /// <summary>
    /// A method that is missing an access modifier.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1400", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("IDE0040")]
    [IncidentalCodeAnalysisViolationExpected("IDE0051")]
    static void SA1400_AccessModifierMustBeDeclared()
    {
    }

    /// <summary>
    /// A class containing a method for use in testing SA1100.
    /// </summary>
    public class SA1100_BaseClass
    {
        private readonly int field = 0;

        /// <summary>
        /// A method.
        /// </summary>
        /// <returns>The value of field.</returns>
        public int Method()
        {
            return field;
        }
    }

    /// <summary>
    /// A class containing a method with a unnecessary use of base.
    /// </summary>
    public class SA1100_DoNotPrefixCallsWithBaseUnlessLocalImplementationExists_Wrapper : SA1100_BaseClass
    {
        /// <summary>
        /// A method that calls a base class method using base unnecessarily.
        /// </summary>
        [CodeAnalysisViolationExpected("SA1100", "Warning")]
        public void SA1100_DoNotPrefixCallsWithBaseUnlessLocalImplementationExists()
        {
            base.Method();
        }
    }

    /// <summary>
    /// A class containing a method that calls an instance member without this.
    /// </summary>
    public class SA1101_PrefixLocalCallsWithThis_Wrapper
    {
        private readonly int field = 0;

        /// <summary>
        /// A method that calls an instance member without using this.
        /// </summary>
        [CodeAnalysisViolationExpected("SA1101", "Warning", disabledReason: "SA1101 is disabled.")]
        public void SA1101_PrefixLocalCallsWithThis() => Method();

        private int Method() => field;
    }

    /// <summary>
    /// A class containing a region.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1124", "Warning")]
    public class SA1124_DoNotUseRegions()
    {
        #region
        #endregion
    }

    /// <summary>
    /// A class with a constructor initializer that is not on a new line.
    /// </summary>
    public class SA1128_ConstructorInitializerMustBeOnOwnLine
    {
        [CodeAnalysisViolationExpected("SA1128", "Warning")]
        private SA1128_ConstructorInitializerMustBeOnOwnLine() : this(1)
        {
        }

        private SA1128_ConstructorInitializerMustBeOnOwnLine(int a)
        {
            Value = a;
        }

        /// <summary>
        /// Gets the value of the field.
        /// </summary>
        public int Value { get; }
    }

    /// <summary>
    /// A class containing two fields declared in the same field declaration.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1132", "Warning")]
    public class SA1132_DoNotCombineFields
    {
        private readonly int field1, field2;

        private SA1132_DoNotCombineFields()
        {
            field1 = 1;
            field2 = 2;
        }

        /// <summary>
        /// A method that uses the two fields.
        /// </summary>
        /// <returns>The sum of the two fields.</returns>
        public int Method() => field1 + field2;
    }

    /// <summary>
    /// A class containing an enum with values on the same line.
    /// </summary>
    public class SA1136_EnumValuesShouldBeOnSeparateLines
    {
        [CodeAnalysisViolationExpected("SA1136", "Warning")]
        private enum SA1136_EnumValuesShouldBeOnSeparateLines_Enum
        {
            Value1, Value2,
        }
    }

    /// <summary>
    /// A class containing a method that calls an instance member using this.
    /// </summary>
    public class SX1101_DoNotPrefixLocalMembersWithThis_Wrapper
    {
        private readonly int field = 0;

        /// <summary>
        /// A method that calls an instance member using this.
        /// </summary>
        [CodeAnalysisViolationExpected("SX1101", "Warning")]
        public void SX1101_DoNotPrefixLocalMembersWithThis() => this.Method();

        private int Method() => field;
    }

    /// <summary>
    /// A class containing a declaration with incorrectly ordered keywords.
    /// </summary>
    public class SA1206_DeclarationKeywordsMustFollowOrder
    {
        /// <summary>
        /// A method that is decalred with incorrectly ordered keywords.
        /// </summary>
        /// <returns>Always zero.</returns>
        [CodeAnalysisViolationExpected("SA1206", "Warning")]
        [IncidentalCodeAnalysisViolationExpected("IDE0036")]
        static public int Method() => 0;
    }

    /// <summary>
    /// A class containing a declaration where internal comes before protected.
    /// </summary>
    public class SA1207_ProtectedMustComeBeforeInternal
    {
        private readonly int field = 0;

        /// <summary>
        /// A method that is declared with the internal keyword proceeding the
        /// protected keyword.
        /// </summary>
        /// <returns>Always zero.</returns>
        [CodeAnalysisViolationExpected("SA1207", "Warning")]
        [IncidentalCodeAnalysisViolationExpected("IDE0036")]
        internal protected int Method() => field;
    }

    /// <summary>
    /// A class a property with accessors out of order.
    /// </summary>
    public class SA1212_PropertyAccessorsMustFollowOrder
    {
        /// <summary>
        /// Gets or sets the property.
        /// </summary>
        [CodeAnalysisViolationExpected("SA1212", "Warning")]
        public int Property
        {
            set;
            get;
        }
    }

    /// <summary>
    /// A class containing an event with accessors out of order.
    /// </summary>
    public class SA1213_EventAccessorsMustFollowOrder_Wrapper
    {
        /// <summary>
        /// An event with accessors out of order.
        /// </summary>
        [CodeAnalysisViolationExpected("SA1213", "Warning")]
        public static event EventHandler SA1213_EventAccessorsMustFollowOrder
        {
            remove
            {
            }

            add
            {
            }
        }
    }

    /// <summary>
    /// A class containing a readonly field after a non-readonly field.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1214", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("IDE0044")]
    public class SA1214_ReadonlyElementsMustAppearBeforeNonReadonlyElements
    {
        private int field2 = 0;

        private readonly int field1 = 0;

        /// <summary>
        /// A method that uses the two fields.
        /// </summary>
        /// <returns>The sum of the two fields.</returns>
        public int Method() => field1 + field2;
    }

    /// <summary>
    /// A class containing a const field that doesn't begin with an uppercase
    /// letter.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1303", "Warning")]
    public class SA1303_ConstFieldNamesMustBeginWithUpperCaseLetter
    {
        /// <summary>
        /// A const field that doesn't begin with an uppercase letter.
        /// </summary>
        public const int constField = 0;
    }

    /// <summary>
    /// A class containing a public readonly field that doesn't begin with an
    /// uppercase letter.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1304", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1307")]
    [IncidentalCodeAnalysisViolationExpected("SA1401")]
    public class SA1304_NonPrivateReadonlyFieldsMustBeginWithUpperCaseLetter
    {
        /// <summary>
        /// A non-private readonly field that doesn't begin with an uppercase letter.
        /// </summary>
        protected internal readonly int field = 0;
    }

    /// <summary>
    /// A class containing a field that appears to use Hungarian notation.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "SA1305", "Warning", disabledReason: "SA1305 is disabled.")]
    public class SA1305_FieldNamesMustNotUseHungarianNotation
    {
        /// <summary>
        /// A field that appears to use Hungarian notation.
        /// </summary>
        private readonly int stVariable = 0;

        /// <summary>
        /// A method that uses the field.
        /// </summary>
        /// <returns>The value of the field.</returns>
        public int Method() => stVariable;
    }

    /// <summary>
    /// A class containing a field that does not start with a lower case letter.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1306", "Warning")]
    public class SA1306_FieldNamesMustBeginWithLowerCaseLetter
    {
        /// <summary>
        /// A field that does not start with a lower case letter.
        /// </summary>
        private readonly int Variable = 0;

        /// <summary>
        /// A method that uses the field.
        /// </summary>
        /// <returns>The value of the field.</returns>
        public int Method() => Variable;
    }

    /// <summary>
    /// A class containing a field that doesn't begin with an uppercase letter.
    /// </summary>
    [IncidentalCodeAnalysisViolationExpected("SA1307")]
    [IncidentalCodeAnalysisViolationExpected("SA1401")]
    public class SA1307_AccessibleFieldsMustBeginWithUpperCaseLetter
    {
        /// <summary>
        /// An accessible field that doesn't begin with an uppercase letter.
        /// </summary>
        protected internal int field = 0;
    }

    /// <summary>
    /// A class that contains a field that starts with a prefix suggesting that
    /// it's a member field.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1308", "Warning")]
    public class SA1308_VariableNamesMustNotBePrefixed
    {
        private readonly int m_int = 0;

        /// <summary>
        /// A method that uses the field.
        /// </summary>
        /// <returns>The value of the field.</returns>
        public int Method() => m_int;
    }

    /// <summary>
    /// A class that contains a field that starts with an underscore.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "SA1309", "Warning", disabledReason: "SA1309 is disabled.")]
    public class SA1309_FieldNamesMustNotBeginWithUnderscore
    {
        private readonly int _int = 0;

        /// <summary>
        /// A method that uses the field.
        /// </summary>
        /// <returns>The value of the field.</returns>
        public int Method() => _int;
    }

    /// <summary>
    /// A class that contains a field that contains an underscore.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1310", "Warning")]
    public class SA1310_FieldNamesMustNotContainUnderscore
    {
        private readonly int my_int = 0;

        /// <summary>
        /// A method that uses the field.
        /// </summary>
        /// <returns>The value of the field.</returns>
        public int Method() => my_int;
    }

    /// <summary>
    /// A class that contains a static readonly field that does not begin with
    /// an upper case letter.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1311", "Warning")]
    public class SA1311_StaticReadonlyFieldsMustBeginWithUpperCaseLetter
    {
        private static readonly int field = 0;

        /// <summary>
        /// A method that uses the field.
        /// </summary>
        /// <returns>The value of the field.</returns>
        public static int Method() => field;
    }

    /// <summary>
    /// A class with a field that is not private.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1401", "Warning")]
    public class SA1401_FieldsMustBePrivate()
    {
        /// <summary>
        /// A field that is not private.
        /// </summary>
        public int Field = 0;
    }

    /// <summary>
    /// A class that is annotated with an attribute that uses unnecessary
    /// parentheses.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1411", "Warning")]
    [Serializable()]
    public class SA1411_AttributeConstructorMustNotUseUnnecessaryParenthesis
    {
    }

    /// <summary>
    /// A class that contains a member that returns a tuple without element names.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1414", "Warning")]
    public class SA1414_UseTrailingCommasInMultiLineInitializers()
    {
        /// <summary>
        /// A method that returns a tuple without element names.
        /// </summary>
        /// <returns>A tuple with 1 and 2.</returns>
        public static (int, int) Method() => (1, 2);
    }

    /// <summary>
    /// A method that contains a property with a single-line getter and multi-line
    /// setter.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1504", "Warning")]
    public class SA1504_AllAccessorsMustBeSingleLineOrMultiLine
    {
        /// <summary>
        /// Gets or sets a value indicating whether the property is enabled.
        /// </summary>
        public static bool Enabled
        {
            get { return true; }

            set
            {
                return;
            }
        }
    }

    /// <summary>
    /// A method that contains a property with a getter with a blank line after
    /// the opening brace.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1505", "Warning")]
    public class SA1505_OpeningBracesMustNotBeFollowedByBlankLine
    {
        /// <summary>
        /// Gets a value indicating whether the property is enabled.
        /// </summary>
        public static bool Enabled
        {
            get
            {

                return true;
            }
        }
    }

    /// <summary>
    /// A class that contains a method with documentation that contains a blank
    /// line after the summary tag.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1506", "Warning")]
    public class SA1506_ElementDocumentationHeadersMustNotBeFollowedByBlankLine()
    {
        /// <summary>
        /// A method that contains a blank line after the summary tag.
        /// </summary>

        public static void Method()
        {
        }
    }

    /// <summary>
    /// A class that contains a two methods that aren't separated by a blank line.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1516", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("IDE0051")]
    public class SA1516_ElementsMustBeSeparatedByBlankLine()
    {
        private static int Method() => 0;
        private static int OtherMethod() => 1;
    }

    /// <summary>
    /// A class that contains a method with documentation that is not preceded by
    /// a blank line.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1514", "Warning")]
    public class SA1514_ElementDocumentationHeaderMustBePrecededByBlankLine()
    {
        /// <summary>
        /// Dummy method.
        /// </summary>
        /// <returns>Always zero.</returns>
        public static int Method() => 0;
        /// <summary>
        /// There should be a blank line before this documentation.
        /// </summary>
        public static void OtherMethod()
        {
        }
    }

    /// <summary>
    /// A class that contains a method with documentation that is missing a
    /// summary section.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1604", "Warning")]
    public class SA1604_ElementDocumentationMustHaveSummary()
    {
        /// <param name="value">The value to return.</param>
        /// <returns>The given value.</returns>
        public static int Method(int value) => value;
    }

    /// <summary>
    /// A class that contains a method with documentation that has an blank
    /// summary section.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1606", "Warning")]
    public class SA1606_ElementDocumentationMustHaveSummaryText()
    {
        /// <summary> </summary>
        /// <param name="value">The value to return.</param>
        /// <returns>The given value.</returns>
        public static int Method(int value) => value;
    }

    /// <summary>
    /// A class that contains a method with default summary documentation.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1608", "Warning")]
    public class SA1608_ElementDocumentationMustNotHaveDefaultSummary()
    {
        /// <summary>
        /// Summary description for the Method method.
        /// </summary>
        /// <returns>Always returns one.</returns>
        public static int Method() => 1;
    }

    /// <summary>
    /// A class that contains a property that doesn't have value documentation.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "SA1609", "Warning", disabledReason: "SA1609 is disabled.")]
    public class SA1609_PropertyDocumentationMustHaveValue()
    {
        /// <summary>
        /// Gets the value of the property.
        /// </summary>
        public int Property { get; } = 1;
    }

    /// <summary>
    /// A class that contains a property that has blank value documentation.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1610", "Warning")]
    public class SA1610_PropertyDocumentationMustHaveValueText()
    {
        /// <summary>
        /// Gets the value of the property.
        /// </summary>
        /// <value> </value>
        public int Property { get; } = 1;
    }

    /// <summary>
    /// A class that contains a method with undocumented parameters.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1611", "Warning")]
    public class SA1611_ElementParametersMustBeDocumented()
    {
        /// <summary>
        /// Returns the given value.
        /// </summary>
        /// <returns>The given value.</returns>
        public static int Method(int value) => value;
    }

    /// <summary>
    /// A class that contains a method with incorrectly documented parameters.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1612", "Warning")]
    public class SA1612_ElementParameterDocumentationMustMatchElementParameters()
    {
        /// <summary>
        /// Returns the sum of value and other.
        /// </summary>
        /// <param name="other">No such parameter.</param>
        /// <param name="value">The value to return.</param>
        /// <returns>The sum of value and other.</returns>
        public static int Method(int value, int other) => value + other;
    }

    /// <summary>
    /// A class that contains a method with documentation for a parameter
    /// without a name.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1613", "Warning")]
    public class SA1613_ElementParameterDocumentationMustDeclareParameterName()
    {
        /// <summary>
        /// Returns the given value.
        /// </summary>
        /// <param name="value">The value to return.</param>
        /// <param>The unnamed parameter.</param>
        /// <returns>The given value.</returns>
        public static int Method(int value) => value;
    }

    /// <summary>
    /// A class that contains a method with documentation for a parameter
    /// without any text.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1614", "Warning")]
    public class SA1614_ElementParameterDocumentationMustHaveText()
    {
        /// <summary>
        /// Returns the given value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The given value.</returns>
        public static int Method(int value) => value;
    }

    /// <summary>
    /// A class that contains a method with documentation that doesn't document
    /// the return value.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1615", "Warning")]
    public class SA1615_ElementReturnValueMustBeDocumented()
    {
        /// <summary>
        /// Returns the given value.
        /// </summary>
        /// <param name="value">The value to return.</param>
        public static int Method(int value) => value;
    }

    /// <summary>
    /// A class that contains a method with documentation that contains a blank
    /// return value.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1616", "Warning")]
    public class SA1616_ElementReturnValueDocumentationMustHaveText()
    {
        /// <summary>
        /// Returns the given value.
        /// </summary>
        /// <param name="value">The value to return.</param>
        /// <returns></returns>
        public static int Method(int value) => value;
    }

    /// <summary>
    /// A class that contains a method with a void return value that is
    /// documented.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1617", "Warning")]
    public class SA1617_VoidReturnValueMustNotBeDocumented()
    {
        /// <summary>
        /// Do nothing.
        /// </summary>
        /// <returns>/dev/null.</returns>
        public static void Method()
        {
        }
    }

    /// <summary>
    /// A class that contains a method with an undocumented type parameter.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1618", "Warning")]
    public class SA1618_GenericTypeParametersMustBeDocumented()
    {
        /// <summary>
        /// Returns the given value.
        /// </summary>
        /// <param name="value">The value to return.</param>
        /// <returns>The given value.</returns>
        public static T Method<T>(T value) => value;
    }

    /// <summary>
    /// A class containing a method that has incorrect type parameter documentation.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1620", "Warning")]
    public class SA1620_GenericTypeParameterDocumentationMustMatchTypeParameters
    {
        /// <summary>
        /// A method that does nothing.
        /// </summary>
        /// <typeparam name="TSecond">The other type parameter.</typeparam>
        /// <typeparam name="TFirst">The type parameter.</typeparam>
        public static void Method<TFirst, TSecond>()
        {
        }
    }

    /// <summary>
    /// A class that contains a method that has incorrect type parameter
    /// documentation.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1621", "Warning")]
    public class SA1621_GenericTypeParameterDocumentationMustDeclareParameterName
    {
        /// <summary>
        /// A method that does nothing.
        /// </summary>
        /// <typeparam name="TFirst">The type parameter.</typeparam>
        /// <typeparam>The other type parameter.</typeparam>
        public static void Method<TFirst>()
        {
        }
    }

    /// <summary>
    /// A class that contains a method that has type parameter documentation
    /// that doesn't have any text.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1622", "Warning")]
    public class SA1622_GenericTypeParameterDocumentationMustHaveText
    {
        /// <summary>
        /// A method that does nothing.
        /// </summary>
        /// <typeparam name="TFirst"></typeparam>
        public static void Method<TFirst>()
        {
        }
    }

    /// <summary>
    /// A class that has a method with documentation that has been copied.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1625", "Warning")]
    public class SA1625_ElementDocumentationMustNotBeCopiedAndPasted
    {
        /// <summary>
        /// A method that does nothing.
        /// </summary>
        /// <param name="firstName">Part of the name.</param>
        /// <param name="lastName">Part of the name.</param>
        /// <returns>The full name.</returns>
        public static string Method(string firstName, string lastName)
        {
            return $"{firstName} {lastName}";
        }
    }

    /// <summary>
    /// A class that has a method with documentation that contains an empty
    /// element.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1627", "Warning")]
    public class SA1627_DocumentationTextMustNotBeEmpty
    {
        /// <summary>
        /// A method that does nothing.
        /// </summary>
        /// <remarks></remarks>
        public static void Method()
        {
        }
    }

    /// <summary>
    /// A class that has a constructor that doesn't begin with the standard text.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1642", "Warning")]
    public class SA1642_ConstructorSummaryDocumentationMustBeginWithStandardText
    {
        /// <summary>
        /// Other text.
        /// </summary>
        public SA1642_ConstructorSummaryDocumentationMustBeginWithStandardText()
        {
        }
    }

    /// <summary>
    /// A class that has a destructor that doesn't begin with the standard text.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1643", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("CA1821")]
    public class SA1643_DestructorSummaryDocumentationMustBeginWithStandardText
    {
        /// <summary>
        /// Other text.
        /// </summary>
        ~SA1643_DestructorSummaryDocumentationMustBeginWithStandardText()
        {
        }
    }

    /// <summary>
    /// A class that has a method that is documented with a placeholder element.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1651", "Warning")]
    public class SA1651_DoNotUsePlaceholderElements
    {
        /// <summary>
        /// This method <placeholder>performs some operation</placeholder>.
        /// </summary>
        /// <returns>Always zero.</returns>
        public static int Method() => 0;
    }

    /// <summary>
    /// A class that has a method that uses inheritdoc where it's not
    /// appropriate.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1648", "Warning")]
    public class SA1648_InheritDocMustBeUsedWithInheritingClass
    {
        /// <inheritdoc/>
        public static int Method() => 0;
    }

    /// <summary>
    /// A class that contains a field that starts with an underscore.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "SX1309", "Warning", disabledReason: "SX1309 is disabled.")]
    public class SX1309_FieldNamesMustBeginWithUnderscore
    {
        private readonly int field = 0;

        /// <summary>
        /// A method that uses the field.
        /// </summary>
        /// <returns>The value of the field.</returns>
        public int Method() => field;
    }

    /// <summary>
    /// A class that contains a field that starts with an underscore.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "SX1309S", "Warning", disabledReason: "SX1309S is disabled.")]
    public class SX1309S_StaticFieldNamesMustBeginWithUnderscore
    {
        private static readonly int Field = 0;

        /// <summary>
        /// A method that uses the field.
        /// </summary>
        /// <returns>The value of the field.</returns>
        public static int Method() => Field;
    }

    /// <summary>
    /// A partial class that doesn't declare access.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1205", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("IDE0040")]
    partial class SA1205_PartialElementsMustDeclareAccess
    {
    }
}
