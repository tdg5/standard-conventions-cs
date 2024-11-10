using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.LayoutRules;

/// <summary>
/// Putting the while on the same line as the closing brace is not allowed.
/// </summary>
public class DoWhileOnClosingBrace
{
    [CodeAnalysisViolationExpected("SA1500", "Warning")]
    private void Method()
    {
        do
        {
            return;
        } while (false);
    }
}
