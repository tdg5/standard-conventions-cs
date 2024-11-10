namespace Tdg5.StandardConventions.TestAnnotations;

/// <summary>
/// Attribute to specify an expected analysis code that should occur as part of
/// the analysis of a given target.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class ProjectAnalysisViolationExpectedAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="ProjectAnalysisViolationExpectedAttribute"/> class.
    /// </summary>
    /// <param name="code">The analysis code that is expected.</param>
    /// <param name="contains">Optional text that the violation is expected to
    /// contain.</param>
    /// <param name="level">The level of the analysis code that is expected.</param>
    /// <param name="enabled">Flag indicating whether or not the expectation is
    /// enabled.</param>
    public ProjectAnalysisViolationExpectedAttribute(
        string code, string level, string? contains = null, bool enabled = true)
    {
        this.Code = code;
        this.Contains = contains;
        this.Enabled = enabled;
        this.Level = level;
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
    /// Gets a value indicating whether or not the expectation is enabled.
    /// </summary>
    public bool Enabled { get; }

    /// <summary>
    /// Gets the expected level of the analysis code.
    /// </summary>
    public string Level { get; }

    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="ProjectAnalysisViolationExpectation"/> class from the given attribute
    /// arguments.
    /// </summary>
    /// <param name="attributeArguments">The arguments of the attribute that
    /// specifies the expected violation.</param>
    /// <returns>A new instance of the <see
    /// cref="ProjectAnalysisViolationExpectation"/> class.</returns>
    internal static ProjectAnalysisViolationExpectation GetExpecation(
        AttributeArguments attributeArguments)
    {
        var attributeWithEffectiveRange = attributeArguments.AttributeWithEffectiveRange;
        var attribute = attributeWithEffectiveRange.Attribute;
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
                + $" {nameof(ProjectAnalysisViolationExpectedAttribute)}, {nameof(code)}"
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
                + $" {nameof(ProjectAnalysisViolationExpectedAttribute)}, {nameof(level)}"
                + " argument could not be determined.");
        }

        object? containsArgument = null;
        if (positionalArguments.Count > 2)
        {
            containsArgument = positionalArguments[2];
        }
        else if (namedArguments.TryGetValue("contains", out containsArgument))
        {
            // Condition does the work.
        }

        string? contains = containsArgument as string;

        object? enabledArgument = null;
        if (positionalArguments.Count > 3)
        {
            enabledArgument = positionalArguments[2];
        }
        else if (namedArguments.TryGetValue("enabled", out enabledArgument))
        {
            // Condition does the work.
        }

        bool enabled = enabledArgument is not bool enabledValue || enabledValue;

        return new ProjectAnalysisViolationExpectation(
            code: code,
            contains: contains,
            enabled: enabled,
            level: level,
            projectPath: attributeWithEffectiveRange.ProjectPath);
    }
}
