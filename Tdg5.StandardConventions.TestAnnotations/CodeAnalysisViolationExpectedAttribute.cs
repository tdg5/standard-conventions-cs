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
public class CodeAnalysisViolationExpectedAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="CodeAnalysisViolationExpectedAttribute"/> class.
    /// </summary>
    /// <param name="code">The analysis code that is expected.</param>
    /// <param name="level">The level of the analysis code that is expected.</param>
    /// <param name="enabled">Flag indicating whether or not the expectation is
    /// enabled.</param>
    public CodeAnalysisViolationExpectedAttribute(
        string code, string level, bool enabled = true)
    {
        this.Code = code;
        this.Enabled = enabled;
        this.Level = level;
    }

    /// <summary>
    /// Gets the name of the expected analysis code.
    /// </summary>
    public string Code { get; }

    /// <summary>
    /// Gets a value indicating whether or not the expectation is enabled.
    /// </summary>
    public bool Enabled { get; }

    /// <summary>
    /// Gets the expected level of the analysis code.
    /// </summary>
    public string Level { get; }

    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="CodeAnalysisViolationExpectation"/> class from the given attribute
    /// arguments.
    /// </summary>
    /// <param name="attributeArguments">The arguments of the attribute that
    /// specifies the expected violation.</param>
    /// <returns>A new instance of the <see
    /// cref="CodeAnalysisViolationExpectation"/> class.</returns>
    internal static CodeAnalysisViolationExpectation GetExpecation(
        AttributeArguments attributeArguments)
    {
        var attributeWithEffectiveRange = attributeArguments.AttributeWithEffectiveRange;
        var attribute = attributeWithEffectiveRange.Attribute;

        if (attributeWithEffectiveRange.StartLine is null)
        {
            throw new InvalidOperationException(
                $"Cannot parse {attribute} as a"
                + $" {nameof(CodeAnalysisViolationExpectedAttribute)},"
                + " start line number is missing.");
        }

        if (attributeWithEffectiveRange.EndLine is null)
        {
            throw new InvalidOperationException(
                $"Cannot parse {attribute} as a"
                + $" {nameof(CodeAnalysisViolationExpectedAttribute)},"
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
                + $" {nameof(CodeAnalysisViolationExpectedAttribute)}, {nameof(code)}"
                + " argument could not be determined.");
        }

        object? levelArgument = null;
        if (positionalArguments.Count > 1)
        {
            levelArgument = positionalArguments[1];
        }
        else if (namedArguments.TryGetValue("level", out levelArgument))
        {
            // Condition does the work.
        }

        if (levelArgument is not string level)
        {
            throw new InvalidOperationException(
                $"Cannot parse {attribute} as a"
                + $" {nameof(CodeAnalysisViolationExpectedAttribute)}, {nameof(level)}"
                + " argument could not be determined.");
        }

        object? enabledArgument = null;
        if (positionalArguments.Count > 2)
        {
            enabledArgument = positionalArguments[2];
        }
        else if (namedArguments.TryGetValue("enabled", out enabledArgument))
        {
            // Condition does the work.
        }

        bool enabled = enabledArgument is not bool enabledValue || enabledValue;

        return new CodeAnalysisViolationExpectation(
            code: code,
            enabled: enabled,
            endLineNumber: attributeWithEffectiveRange.EndLine.Value,
            filePath: attributeWithEffectiveRange.FilePath,
            level: level,
            projectPath: attributeWithEffectiveRange.ProjectPath,
            startLineNumber: attributeWithEffectiveRange.StartLine.Value);
    }
}
