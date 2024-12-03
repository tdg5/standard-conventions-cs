using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.EditorConfigRules;

/// <summary>
/// The nullable directive above should be unnecessary since there are no
/// reference types in this file.
/// </summary>
[FileAnalysisViolationExpected("IDE0241", "Warning")]
public class IDE0241_NullableDirectiveIsUnnecessary
{
#nullable disable
    private enum ViolationEnum
    {
        /// <summary>
        /// A thing.
        /// </summary>
        Thing,
    }
}
