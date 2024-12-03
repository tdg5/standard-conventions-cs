using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.EditorConfigRules;

/// <summary>
/// Class for testing IDE0051.
/// </summary>
/// <remarks>
/// This is separate from other assertions because IDE0051 behaves weirdly in
/// some scenarios: https://github.com/dotnet/roslyn/issues/54972.
/// </remarks>
public class IDE0051_RemoveUnusedPrivateMember
{
    /// <summary>
    /// A method that is not used elsewhere in the code.
    /// </summary>
    [CodeAnalysisViolationExpected("IDE0051", "Warning")]
    private static void UnusedMethod()
    {
    }
}
