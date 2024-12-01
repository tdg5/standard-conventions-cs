using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.NamingRules;

/// <summary>
/// A class utilizing a variety of tuple element name casing styles.
/// </summary>
public class TupleElementNameCasing
{
    /// <summary>
    /// A method that returns a tuple with camel case element names.
    /// </summary>
    /// <returns>A tuple with camel case element names.</returns>
    [CodeAnalysisViolationExpected("SA1316", "Warning")]
    public static (int firstElement, int secondElement) CamelCaseTupleMethod() => (0, 0);

    /// <summary>
    /// A method that returns a tuple with pascal case element names.
    /// </summary>
    /// <returns>A tuple with pascal case element names.</returns>
    [CodeAnalysisViolationExpected("SA1316", "Warning", disabledReason: "Pascal case tuple element names are required.")]
    public static (int FirstElement, int SecondElement) PascalCaseTupleMethod() => (0, 0);
}
