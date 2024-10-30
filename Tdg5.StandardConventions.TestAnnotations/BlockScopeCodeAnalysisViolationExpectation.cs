namespace Tdg5.StandardConventions.TestAnnotations;

/// <summary>
/// Data object capturing the details of an expected code analysis violation.
/// </summary>
public class BlockScopeCodeAnalysisViolationExpectation : ICodeAnalysisViolationExpectation
{
    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="BlockScopeCodeAnalysisViolationExpectation"/> class.
    /// </summary>
    /// <param name="code">The name of the the analysis code that is
    /// expected.</param>
    /// <param name="level">The level of the analysis code that is
    /// expected.</param>
    /// <param name="filePath">The file path where the violation is expected to
    /// occur.</param>
    /// <param name="startLineNumber">The starting line number where the
    /// violation is expected to occur.</param>
    /// <param name="endLineNumber">The ending line number where the violation
    /// is expected to occur.</param>
    public BlockScopeCodeAnalysisViolationExpectation(
        string code,
        string level,
        string filePath,
        int startLineNumber,
        int endLineNumber)
    {
        this.Code = code;
        this.EndLineNumber = endLineNumber;
        this.FilePath = filePath;
        this.Level = level;
        this.StartLineNumber = startLineNumber;
    }

    /// <summary>
    /// Gets the name of the expected analysis code.
    /// </summary>
    public string Code { get; }

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
    /// Gets the starting line number where the violation is expected to occur.
    /// </summary>
    public int StartLineNumber { get; }

    /// <inheritdoc/>
    public bool IsMatch(ICodeAnalysisViolation violation) =>
        violation.Code == this.Code
            && violation.FilePath == this.FilePath
            && violation.LineNumber >= this.StartLineNumber
            && violation.LineNumber <= this.EndLineNumber
            && string.Equals(
                violation.Level,
                this.Level,
                StringComparison.InvariantCultureIgnoreCase);

    /// <inheritdoc/>
    public string ToStringDescription()
    {
        return $"{this.Level}: {this.Code} -"
            + $"  {this.FilePath}:{this.StartLineNumber}-{this.EndLineNumber}";
    }
}
