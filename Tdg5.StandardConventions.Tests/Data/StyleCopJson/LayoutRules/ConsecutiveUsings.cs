using System.IO;
using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.LayoutRules;

/// <summary>
/// Inconsequential class.
/// </summary>
public class ConsecutiveUsings
{
    [CodeAnalysisViolationExpected("SA1519", "Warning", enabled: false)]
    private void Method()
    {
        using (StreamReader textReader = File.OpenText("does-not-exist.txt"))
        using (StreamReader csvReader = File.OpenText("does-not-exist.csv"))
        {
            return;
        }
    }
}
