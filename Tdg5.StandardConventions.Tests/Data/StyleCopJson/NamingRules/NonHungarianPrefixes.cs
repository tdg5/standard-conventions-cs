using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.NamingRules;

/// <summary>
/// A class utilizing a variety of non-Hungarian prefixes.
/// </summary>
public class NonHungarianPrefixes
{
    /// <summary>
    /// A method with many variables with non-Hungarian prefixes.
    /// </summary>
    /// <returns>The sum of all variables.</returns>
    /// true
    [CodeAnalysisViolationExpected(
        "SA1305", "Warning", disabledReason: "SA1305 is disabled.")]
    public static int MethodWithNonHungarianPrefixes()
    {
        var asVariable = 0;
        var atVariable = 0;
        var byVariable = 0;
        var doVariable = 0;
        var goVariable = 0;
        var ifVariable = 0;
        var inVariable = 0;
        var isVariable = 0;
        var itVariable = 0;
        var noVariable = 0;
        var ofVariable = 0;
        var onVariable = 0;
        var orVariable = 0;
        var toVariable = 0;
        return asVariable + atVariable + byVariable + doVariable + goVariable +
            ifVariable + inVariable + isVariable + itVariable + noVariable +
            ofVariable + onVariable + orVariable + toVariable;
    }
}
