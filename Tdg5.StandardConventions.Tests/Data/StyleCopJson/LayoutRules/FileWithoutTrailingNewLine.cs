using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.LayoutRules;

/// <summary>
/// Inconsequential class.
/// </summary>
[FileAnalysisViolationExpected("SA1518", "Warning", disabledReason: "Not needed with csharpier")]
public class FileWithoutTrailingNewLine
{
}