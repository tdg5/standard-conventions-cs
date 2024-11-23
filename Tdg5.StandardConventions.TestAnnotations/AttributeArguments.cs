namespace Tdg5.StandardConventions.TestAnnotations;

/// <summary>
/// Collection of arguments for a code analysis violation expectation.
/// </summary>
internal class AttributeArguments
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AttributeArguments"/>
    /// class.
    /// </summary>
    /// <param name="attributeWithEffectiveRange">The attribute with effective
    /// range.</param>
    /// <param name="positionalArguments">The positional arguments.</param>
    /// <param name="namedArguments">The named arguments.</param>
    public AttributeArguments(
        AttributeWithEffectiveRange attributeWithEffectiveRange,
        List<object> positionalArguments,
        Dictionary<string, object> namedArguments)
    {
        AttributeWithEffectiveRange = attributeWithEffectiveRange;
        NamedArguments = namedArguments;
        PositionalArguments = positionalArguments;
    }

    /// <summary>
    /// Gets the attribute with effective range.
    /// </summary>
    public AttributeWithEffectiveRange AttributeWithEffectiveRange { get; }

    /// <summary>
    /// Gets the named arguments.
    /// </summary>
    public Dictionary<string, object> NamedArguments { get; }

    /// <summary>
    /// Gets the positional arguments.
    /// </summary>
    public List<object> PositionalArguments { get; }
}
