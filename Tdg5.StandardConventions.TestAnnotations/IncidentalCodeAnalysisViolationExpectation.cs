namespace Tdg5.StandardConventions.TestAnnotations;

/// <summary>
/// A block scoped implementation of <see cref="ICodeAnalysisViolationExpectation"/>
/// that is intended to identify violations that occur incidentally and are not
/// the subject of a given test scenario.
/// </summary>
internal class IncidentalCodeAnalysisViolationExpectation
    : ICodeAnalysisViolationExpectation
{
    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="IncidentalCodeAnalysisViolationExpectation"/> class.
    /// </summary>
    /// <param name="code">The name of the the analysis code that is
    /// expected.</param>
    /// <param name="contains">Optional text that the violation is expected to
    /// contain.</param>
    /// <param name="disabledReason">Description indicating why the expectation is
    /// disabled.</param>
    /// <param name="projectPath">The project path where the violation is
    /// expected to occur.</param>
    /// <param name="filePath">The file path where the violation is expected to
    /// occur.</param>
    /// <param name="startLineNumber">The starting line number where the
    /// violation is expected to occur.</param>
    /// <param name="endLineNumber">The ending line number where the violation
    /// is expected to occur.</param>
    public IncidentalCodeAnalysisViolationExpectation(
        string code,
        string? contains,
        string? disabledReason,
        string projectPath,
        string filePath,
        int startLineNumber,
        int endLineNumber)
    {
        Code = code;
        Contains = contains;
        DisabledReason = disabledReason;
        EndLineNumber = endLineNumber;
        FilePath = filePath;
        ProjectPath = projectPath;
        StartLineNumber = startLineNumber;
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
    /// Gets the ending line number where the violation is expected to occur.
    /// </summary>
    public int EndLineNumber { get; }

    /// <summary>
    /// Gets the file path where the violation is expected to occur.
    /// </summary>
    public string FilePath { get; }

    /// <summary>
    /// Gets the project path where the violation is expected to occur.
    /// </summary>
    public string ProjectPath { get; }

    /// <summary>
    /// Gets the starting line number where the violation is expected to occur.
    /// </summary>
    public int StartLineNumber { get; }

    /// <inheritdoc/>
    public bool IsMatch(ICodeAnalysisViolation violation) =>
        Enabled
            && violation.Code == Code
            && violation.ProjectPath == ProjectPath
            && violation.FilePath == FilePath
            && violation.LineNumber >= StartLineNumber
            && violation.LineNumber <= EndLineNumber
            && (Contains is null ||
                (violation.Message ?? string.Empty).Contains(Contains));

    /// <inheritdoc/>
    public string ToStringDescription()
    {
        return $"Any: {Code} -"
            + $" {FilePath}:{StartLineNumber}-{EndLineNumber}"
            + (Enabled ? string.Empty : $" (disabled: {DisabledReason})")
            + (Contains is not null
                ? $"{Environment.NewLine}Message containing: \"{Contains}\""
                : string.Empty);
    }
}