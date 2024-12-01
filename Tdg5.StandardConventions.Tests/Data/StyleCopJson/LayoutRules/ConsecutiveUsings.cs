using System.IO;
using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.LayoutRules;

/// <summary>
/// A class with consecutive using statements.
/// </summary>
public class ConsecutiveUsings
{
    /// <summary>
    /// A method with consecutive using statements.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "SA1519",
        "Warning",
        disabledReason: "Multiple using statements don't require brackets.")]
    public static void Method()
    {
        using (StreamReader textReader = File.OpenText("does-not-exist.txt"))
        using (StreamReader csvReader = File.OpenText("does-not-exist.csv"))
        {
            return;
        }
    }
}
