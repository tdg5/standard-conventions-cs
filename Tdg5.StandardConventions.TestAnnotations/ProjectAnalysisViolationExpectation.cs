namespace Tdg5.StandardConventions.TestAnnotations;

/// <summary>
/// Default, block scoped implementation of <see
/// cref="ICodeAnalysisViolationExpectation"/>.
/// </summary>
internal class ProjectAnalysisViolationExpectation
    : ICodeAnalysisViolationExpectation
{
    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="ProjectAnalysisViolationExpectation"/> class.
    /// </summary>
    /// <param name="code">The name of the the analysis code that is
    /// expected.</param>
    /// <param name="contains">Optional text that the violation is expected to
    /// contain.</param>
    /// <param name="level">The level of the analysis code that is
    /// expected.</param>
    /// <param name="enabled">Flag indicating whether or not the expectation is
    /// enabled.</param>
    /// <param name="projectPath">The project path where the violation is
    /// expected to occur.</param>
    public ProjectAnalysisViolationExpectation(
        string code,
        string? contains,
        string level,
        bool enabled,
        string projectPath)
    {
        this.Code = code;
        this.Contains = contains;
        this.Enabled = enabled;
        this.Level = level;
        this.ProjectPath = projectPath;
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
    /// Gets the project path where the violation is expected to occur.
    /// </summary>
    public string ProjectPath { get; }

    /// <inheritdoc/>
    public bool IsMatch(ICodeAnalysisViolation violation) =>
        this.Enabled
            && violation.Code == this.Code
            && violation.ProjectPath == this.ProjectPath
            && string.Equals(
                violation.Level,
                this.Level,
                StringComparison.InvariantCultureIgnoreCase)
            && (this.Contains is null ||
                (violation.Message ?? string.Empty).Contains(this.Contains));

    /// <inheritdoc/>
    public string ToStringDescription()
    {
        return $"{this.Level}: {this.Code} - {this.ProjectPath}"
            + (this.Enabled ? string.Empty : " (disabled)")
            + (this.Contains is not null
                ? $"{Environment.NewLine}Message containing: \"{this.Contains}\""
                : string.Empty);
    }
}
