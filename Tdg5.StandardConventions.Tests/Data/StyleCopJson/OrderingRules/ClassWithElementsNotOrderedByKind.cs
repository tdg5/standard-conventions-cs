using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.OrderingRules;

/// <summary>
/// A class with a variety of elements not ordered by kind.
/// </summary>
public class ClassWithElementsNotOrderedByKind
{
    private class InnerClass
    {
    }

    [CodeAnalysisViolationExpected(
        "SA1201",
        "Warning",
        contains: "A struct should not follow a class")]
    private struct InnerStruct
    {
    }

    /// <remarks>
    /// Also triggers IDE0051.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0051", "Warning")]
    [CodeAnalysisViolationExpected(
        "SA1201",
        "Warning",
        contains: "A method should not follow a struct")]
    private void Method()
    {
    }

    /// <remarks>
    /// Also triggers IDE0051.
    /// </remarks>
    [CodeAnalysisViolationExpected("IDE0051", "Warning")]
    [CodeAnalysisViolationExpected(
        "SA1201",
        "Warning",
        contains: "A property should not follow a method")]
    private int Property { get; } = 0;

    /// <summary>
    /// An interface.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "SA1201",
        "Warning",
        contains: "A interface should not follow a property")]
    private interface IInterface
    {
    }

    [CodeAnalysisViolationExpected(
        "SA1201",
        "Warning",
        contains: "A enum should not follow a interface")]
    private enum NestedEnum
    {
    }

    [CodeAnalysisViolationExpected(
        "SA1201",
        "Warning",
        contains: "A constructor should not follow a enum")]
    private ClassWithElementsNotOrderedByKind()
    {
        // Prevent CS0169 warning.
        field = field == 1 ? 0 : 1;
    }

    [CodeAnalysisViolationExpected(
        "SA1201",
        "Warning",
        contains: "A field should not follow a constructor")]
    private readonly int field;
}
