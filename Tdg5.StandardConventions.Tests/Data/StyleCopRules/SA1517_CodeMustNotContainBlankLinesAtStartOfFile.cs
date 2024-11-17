
using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopRules;

/// <summary>
/// A file that contains a blank line at the start.
/// </summary>
[FileAnalysisViolationExpected("SA1517", "Warning")]
public class SA1517_CodeMustNotContainBlankLinesAtStartOfFile
{
}
