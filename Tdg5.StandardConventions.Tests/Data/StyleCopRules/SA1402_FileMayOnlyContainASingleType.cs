using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopRules;

/// <summary>
/// Primary class in the file.
/// </summary>
public class SA1402_FileMayOnlyContainASingleType
{
}

/// <summary>
/// Other class in the file.
/// </summary>
[CodeAnalysisViolationExpected("SA1402", "Warning")]
public class OtherClass
{
}
