using System;
using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.EditorConfigRules;

/// <summary>
/// The using directives in this file should trigger a violation for IDE0005.
/// </summary>
[FileAnalysisViolationExpected("IDE0005", "Warning")]
public class IDE0005_RemoveUnnecessaryUsings
{
}
