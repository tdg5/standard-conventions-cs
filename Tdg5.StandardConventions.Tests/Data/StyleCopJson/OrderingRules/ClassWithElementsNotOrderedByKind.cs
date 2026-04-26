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
        contains: "A struct should not follow a class",
        disabledReason: "SA1201 is silenced")]
    private struct InnerStruct
    {
    }

    [CodeAnalysisViolationExpected(
        "SA1201",
        "Warning",
        contains: "A method should not follow a struct",
        disabledReason: "SA1201 is silenced")]
    private void Method()
    {
        NoopHelper.NoopMemberReference(Property);
        if (Property == -1)
        {
            Method();
        }
    }

    [CodeAnalysisViolationExpected(
        "SA1201",
        "Warning",
        contains: "A property should not follow a method",
        disabledReason: "SA1201 is silenced")]
    private int Property { get; } = 0;

    /// <summary>
    /// Private interfaces should be documented.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "SA1201",
        "Warning",
        contains: "A interface should not follow a property",
        disabledReason: "SA1201 is silenced")]
    private interface IInterface
    {
    }

    [CodeAnalysisViolationExpected(
        "SA1201",
        "Warning",
        contains: "A enum should not follow a interface",
        disabledReason: "SA1201 is silenced")]
    private enum NestedEnum
    {
    }

    [CodeAnalysisViolationExpected(
        "SA1201",
        "Warning",
        contains: "A constructor should not follow a enum",
        disabledReason: "SA1201 is silenced")]
    private ClassWithElementsNotOrderedByKind()
    {
        NoopHelper.NoopMemberReference(field);
    }

    [CodeAnalysisViolationExpected(
        "SA1201",
        "Warning",
        contains: "A field should not follow a constructor",
        disabledReason: "SA1201 is silenced")]
    private readonly int field = 0;
}
