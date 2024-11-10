using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.NamingRules;

/// <summary>
/// A class utilizing a variety of Hungarian prefixes.
/// </summary>
public class HungarianPrefixes
{
    /// <summary>
    /// A method with a variable with a Hungarian prefix.
    /// </summary>
    /// <returns>The value of the variable.</returns>
    [CodeAnalysisViolationExpected("SA1305", "Warning", enabled: false)]
    public int MethodWithHungarianPrefix()
    {
        int stVariable = 0;
        return stVariable;
    }
}
