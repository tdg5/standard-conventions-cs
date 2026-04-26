using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopRules.nonStandardNamespace;

/// <summary>
/// Non-functional class.
/// </summary>
[FileAnalysisViolationExpected(
    "SA1300",
    "Warning",
    contains: "'nonStandardNamespace' should begin with an uppercase letter",
    disabledReason: "SA1300 is silenced")]
public class ClassInNonStandardNamespace
{
}
