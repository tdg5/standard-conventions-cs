using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.OrderingRules;

/// <summary>
/// A class with a variety of elements not ordered by whether read-only or not.
/// </summary>
public class ClassWithElementsNotOrderedByReadability
{
    private string writableProperty = "writable";

    [CodeAnalysisViolationExpected(
        "SA1214",
        "Warning",
        contains: "Readonly fields should appear before non-readonly fields")]
    private readonly string readOnlyProperty = "read-only";

    private ClassWithElementsNotOrderedByReadability()
    {
        this.writableProperty =
            this.readOnlyProperty == "read-only" ? this.writableProperty : "other";
    }
}
