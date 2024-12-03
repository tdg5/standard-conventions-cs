using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.EditorConfigRules.IDE0130WithExtra;

/// <summary>
/// The namespace in this file should trigger a violation for IDE0130.
/// </summary>
[FileAnalysisViolationExpected("IDE0130", "Warning")]
public class IDE0130_NamespaceDoesNotMatchFolderStructure
{
}
