using Tdg5.StandardConventions.TestAnnotations;
using SystemAlias = System;
using AardvarkAlias = System.IO;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopRules;

/// <summary>
/// Class to attach attribute to. The out of order using statement aliases
/// above should cause the violation.
/// </summary>
/// <remarks>
/// Also triggers a violation for IDE0005.
/// </remarks>
[FileAnalysisViolationExpected("IDE0005", "Warning")]
[FileAnalysisViolationExpected("SA1211", "Warning")]
public class SA1211_UsingAliasDirectivesMustBeOrderedAlphabeticallyByAliasName
{
}
