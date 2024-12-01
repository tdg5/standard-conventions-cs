namespace Tdg5.StandardConventions.TestAnnotations;

/// <summary>
/// Attribute to specify an expected analysis code that should occur as part of
/// the analysis of a given target.
/// </summary>
[AttributeUsage(
    AttributeTargets.Class
        | AttributeTargets.Constructor
        | AttributeTargets.Delegate
        | AttributeTargets.Enum
        | AttributeTargets.Event
        | AttributeTargets.Field
        | AttributeTargets.Interface
        | AttributeTargets.Method
        | AttributeTargets.Property
        | AttributeTargets.Struct,
    AllowMultiple = true,
    Inherited = false)]
public class IncidentalCodeAnalysisViolationExpectedAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="IncidentalCodeAnalysisViolationExpectedAttribute"/> class.
    /// </summary>
    /// <param name="code">The analysis code that is expected.</param>
    /// <param name="contains">Optional text that the violation is expected to
    /// contain.</param>
    /// <param name="disabledReason">Optional description explaining why the
    /// expectation is disabled.</param>
    public IncidentalCodeAnalysisViolationExpectedAttribute(
        string code, string? contains = null, string? disabledReason = null)
    {
        Code = code;
        Contains = contains;
        DisabledReason = disabledReason;
    }

    /// <summary>
    /// Gets the name of the expected analysis code.
    /// </summary>
    public string Code { get; }

    /// <summary>
    /// Gets the optional text that the violation is expected to contain.
    /// </summary>
    public string? Contains { get; }

    /// <summary>
    /// Gets an optional description explaining why the expectation is disabled.
    /// </summary>
    public string? DisabledReason { get; }

    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="IncidentalCodeAnalysisViolationExpectation"/> class from the given attribute
    /// arguments.
    /// </summary>
    /// <param name="attributeArguments">The arguments of the attribute that
    /// specifies the expected violation.</param>
    /// <returns>A new instance of the <see
    /// cref="IncidentalCodeAnalysisViolationExpectation"/> class.</returns>
    internal static IncidentalCodeAnalysisViolationExpectation GetExpecation(
        AttributeArguments attributeArguments)
    {
        var attributeWithEffectiveRange = attributeArguments.AttributeWithEffectiveRange;
        var attribute = attributeWithEffectiveRange.Attribute;

        if (attributeWithEffectiveRange.StartLine is null)
        {
            throw new InvalidOperationException(
                $"Cannot parse {attribute} as a"
                + $" {nameof(IncidentalCodeAnalysisViolationExpectedAttribute)},"
                + " start line number is missing.");
        }

        if (attributeWithEffectiveRange.EndLine is null)
        {
            throw new InvalidOperationException(
                $"Cannot parse {attribute} as a"
                + $" {nameof(IncidentalCodeAnalysisViolationExpectedAttribute)},"
                + " end line number is missing.");
        }

        var positionalArguments = attributeArguments.PositionalArguments;
        var namedArguments = attributeArguments.NamedArguments;

        object? codeArgument = null;
        if (positionalArguments.Count > 0)
        {
            codeArgument = positionalArguments[0];
        }
        else if (namedArguments.TryGetValue("code", out codeArgument))
        {
            // Condition does the work.
        }

        if (codeArgument is not string code)
        {
            throw new InvalidOperationException(
                $"Cannot parse {attribute} as a"
                + $" {nameof(IncidentalCodeAnalysisViolationExpectedAttribute)}, {nameof(code)}"
                + " argument could not be determined.");
        }

        object? containsArgument = null;
        if (positionalArguments.Count > 1)
        {
            containsArgument = positionalArguments[1];
        }
        else if (namedArguments.TryGetValue("contains", out containsArgument))
        {
            // Condition does the work.
        }

        string? contains = containsArgument as string;

        object? disabledReasonArgument = null;
        if (positionalArguments.Count > 2)
        {
            disabledReasonArgument = positionalArguments[2];
        }
        else if (namedArguments.TryGetValue("disabledReason", out disabledReasonArgument))
        {
            // Condition does the work.
        }

        string? disabledReason = disabledReasonArgument as string;

        return new IncidentalCodeAnalysisViolationExpectation(
            code: code,
            contains: contains,
            disabledReason: disabledReason,
            endLineNumber: attributeWithEffectiveRange.EndLine.Value,
            filePath: attributeWithEffectiveRange.FilePath,
            projectPath: attributeWithEffectiveRange.ProjectPath,
            startLineNumber: attributeWithEffectiveRange.StartLine.Value);
    }
}
