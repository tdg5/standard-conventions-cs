using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.LayoutRules;

/// <summary>
/// Inconsequential class.
/// </summary>
[FileAnalysisViolationExpected("SA1518", "Warning")]
public class FileWithoutTrailingNewLine
{
}