namespace Tdg5.StandardConventions.TestAnnotations;

/// <summary>
/// Default, block scoped implementation of <see
/// cref="ICodeAnalysisViolationExpectation"/>.
/// </summary>
internal class FileAnalysisViolationExpectation
    : ICodeAnalysisViolationExpectation
{
    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="FileAnalysisViolationExpectation"/> class.
    /// </summary>
    /// <param name="code">The name of the the analysis code that is
    /// expected.</param>
    /// <param name="level">The level of the analysis code that is
    /// expected.</param>
    /// <param name="enabled">Flag indicating whether or not the expectation is
    /// enabled.</param>
    /// <param name="projectPath">The project path where the violation is
    /// expected to occur.</param>
    /// <param name="filePath">The file path where the violation is expected to
    /// occur.</param>
    public FileAnalysisViolationExpectation(
        string code,
        string level,
        bool enabled,
        string projectPath,
        string filePath)
    {
        this.Code = code;
        this.Enabled = enabled;
        this.FilePath = filePath;
        this.Level = level;
        this.ProjectPath = projectPath;
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

    /// <inheritdoc/>
    public bool IsMatch(ICodeAnalysisViolation violation) =>
        this.Enabled
            && violation.Code == this.Code
            && violation.ProjectPath == this.ProjectPath
            && violation.FilePath == this.FilePath
            && string.Equals(
                violation.Level,
                this.Level,
                StringComparison.InvariantCultureIgnoreCase);

    /// <inheritdoc/>
    public string ToStringDescription()
    {
        return $"{this.Level}: {this.Code} - {this.FilePath}"
            + (this.Enabled ? string.Empty : " (disabled)");
    }
}
