namespace Tdg5.StandardConventions.TestAnnotations;

/// <summary>
/// Default, block scoped implementation of <see
/// cref="ICodeAnalysisViolationExpectation"/>.
/// </summary>
internal class CodeAnalysisViolationExpectation
    : ICodeAnalysisViolationExpectation
{
    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="CodeAnalysisViolationExpectation"/> class.
    /// </summary>
    /// <param name="code">The name of the the analysis code that is
    /// expected.</param>
    /// <param name="level">The level of the analysis code that is
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
    public CodeAnalysisViolationExpectation(
        string code,
        string level,
        string? contains,
        string? disabledReason,
        string projectPath,
        string filePath,
        int startLineNumber,
        int endLineNumber)
    {
        this.Code = code;
        this.Contains = contains;
        this.DisabledReason = disabledReason;
        this.EndLineNumber = endLineNumber;
        this.FilePath = filePath;
        this.Level = level;
        this.ProjectPath = projectPath;
        this.StartLineNumber = startLineNumber;
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
    public bool Enabled => this.DisabledReason is null;

    /// <summary>
    /// Gets the ending line number where the violation is expected to occur.
    /// </summary>
    public int EndLineNumber { get; }

    /// <summary>
    /// Gets the file path where the violation is expected to occur.
    /// </summary>
    public string FilePath { get; }

    /// <summary>
    /// Gets the expected level of the analysis code.
    /// </summary>
    public string Level { get; }

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
        this.Enabled
            && violation.Code == this.Code
            && violation.ProjectPath == this.ProjectPath
            && violation.FilePath == this.FilePath
            && violation.LineNumber >= this.StartLineNumber
            && violation.LineNumber <= this.EndLineNumber
            && string.Equals(
                violation.Level,
                this.Level,
                StringComparison.InvariantCultureIgnoreCase)
            && (this.Contains is null ||
                (violation.Message ?? string.Empty).Contains(this.Contains));

    /// <inheritdoc/>
    public string ToStringDescription()
    {
        return $"{this.Level}: {this.Code} -"
            + $" {this.FilePath}:{this.StartLineNumber}-{this.EndLineNumber}"
            + (this.Enabled ? string.Empty : $" (disabled: {this.DisabledReason})")
            + (this.Contains is not null
                ? $"{Environment.NewLine}Message containing: \"{this.Contains}\""
                : string.Empty);
    }
}
