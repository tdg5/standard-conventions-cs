using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.LayoutRules;

/// <summary>
/// Putting the while on the same line as the closing brace is not allowed.
/// </summary>
public class DoWhileOnClosingBrace
{
    /// <summary>
    /// A method that contains a do-while loop with the while on the same line
    /// as the closing brace.
    /// </summary>
    [CodeAnalysisViolationExpected("SA1500", "Warning")]
    public static void Method()
    {
        do
        {
            return;
        } while (false);
    }
}
