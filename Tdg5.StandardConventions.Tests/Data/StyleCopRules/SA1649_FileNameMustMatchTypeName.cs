using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopRules;

/// <summary>
/// A class that does not have the same name as the file.
/// </summary>
[FileAnalysisViolationExpected("SA1649", "Warning")]
public class SA1649_IncorrectClassName
{
}
