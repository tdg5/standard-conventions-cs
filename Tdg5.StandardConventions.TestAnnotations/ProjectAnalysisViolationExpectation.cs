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
    /// <param name="disabledReason">Description indicating why the expectation is
    /// disabled.</param>
    /// <param name="projectPath">The project path where the violation is
    /// expected to occur.</param>
    public ProjectAnalysisViolationExpectation(
        string code,
        string? contains,
        string level,
        string? disabledReason,
        string projectPath)
    {
        Code = code;
        Contains = contains;
        DisabledReason = disabledReason;
        Level = level;
        ProjectPath = projectPath;
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
    /// Gets the optional text that explains why the expectation is disabled.
    /// </summary>
    public string? DisabledReason { get; }

    /// <summary>
    /// Gets a value indicating whether or not the expectation is enabled.
    /// </summary>
    public bool Enabled => DisabledReason is null;

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
        Enabled
            && violation.Code == Code
            && violation.ProjectPath == ProjectPath
            && string.Equals(
                violation.Level,
                Level,
                StringComparison.InvariantCultureIgnoreCase)
            && (Contains is null ||
                (violation.Message ?? string.Empty).Contains(Contains));

    /// <inheritdoc/>
    public string ToStringDescription()
    {
        return $"{Level}: {Code} - {ProjectPath}"
            + (Enabled ? string.Empty : $" (disabled: {DisabledReason})")
            + (Contains is not null
                ? $"{Environment.NewLine}Message containing: \"{Contains}\""
                : string.Empty);
    }
}
