using Tdg5.StandardConventions.TestAnnotations;

using TypeAlias = Tdg5.StandardConventions.Tests.Data.StyleCopJson.OrderingRules.UsingStatementInsideNamespace;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.OrderingRules;

/// <summary>
/// The empty line before the "using TypeAlias = ..." statement above should cause an
/// SA1516 violation because "blankLinesBetweenUsingGroups" is set to "omit".
/// </summary>
[FileAnalysisViolationExpected(
    "SA1516",
    "Warning",
    contains: "Using directives should not be separated by blank line")]
public class BlankLineBetweenUsingGroups
{
}
