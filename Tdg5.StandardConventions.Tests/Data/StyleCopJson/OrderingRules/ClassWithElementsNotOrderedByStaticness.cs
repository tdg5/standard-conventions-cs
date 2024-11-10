using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.OrderingRules;

/// <summary>
/// A class with a variety of elements not ordered by whether static or not.
/// </summary>
public class ClassWithElementsNotOrderedByStaticness
{
    /// <summary>
    /// Gets or sets a non-static property.
    /// </summary>
    public string NonStaticProperty { get; set; } = "non-static";

    /// <summary>
    /// Gets or sets a static property.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "SA1204",
        "Warning",
        contains: "Static members should appear before non-static members")]
    public static string StaticProperty { get; set; } = "static";
}
