using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.OrderingRules;

/// <summary>
/// A class with a variety of elements not ordered by their constance.
/// </summary>
public class ClassWithElementsNotOrderedByConstance
{
    private string nonConstantField = "public";

    [CodeAnalysisViolationExpected(
        "SA1203",
        "Warning",
        contains: "Constant fields should appear before non-constant fields")]
    private const string ConstantField = "public const";

    private ClassWithElementsNotOrderedByConstance()
    {
        this.nonConstantField =
            ConstantField == "public const" ? this.nonConstantField : "other";
    }
}