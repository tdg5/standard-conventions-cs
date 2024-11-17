using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.NamingRules;

/// <summary>
/// A class utilizing a variety of tuple element name casing styles.
/// </summary>
public class TupleElementNameCasing
{
    [CodeAnalysisViolationExpected("SA1316", "Warning")]
    [CodeAnalysisViolationExpected("SA1316", "Warning")]
    private (int firstElement, int secondElement) CamelCaseTupleMethod() => (0, 0);

    [CodeAnalysisViolationExpected("SA1316", "Warning", enabled: false)]
    [CodeAnalysisViolationExpected("SA1316", "Warning", enabled: false)]
    private (int FirstElement, int SecondElement) PascalCaseTupleMethod() => (0, 0);
}