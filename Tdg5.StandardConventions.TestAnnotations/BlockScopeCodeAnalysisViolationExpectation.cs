namespace Tdg5.StandardConventions.TestAnnotations;

/// <summary>
/// Data object capturing the details of an expected code analysis violation.
/// </summary>
public class BlockScopeCodeAnalysisViolationExpectation : ICodeAnalysisViolationExpectation
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BlockScopeCodeAnalysisViolationExpectation"/>
    /// class.
    /// </summary>
    /// <param name="code">The name of the the analysis code that is expected.</param>
    /// <param name="level">The level of the analysis code that is expected.</param>
    /// <param name="filePath">The file path where the violation is expected to
    /// occur.</param>
    /// <param name="startLine">The starting line number where the violation is
    /// expected to occur.</param>
    /// <param name="endLine">The ending line number where the violation is expected
    /// to occur.</param>
    public BlockScopeCodeAnalysisViolationExpectation(
        string code,
        string level,
        string filePath,
        int startLine,
        int endLine)
    {
        this.Code = code;
        this.EndLine = endLine;
        this.FilePath = filePath;
        this.Level = level;
        this.StartLine = startLine;
    }

    /// <summary>
    /// Gets the name of the expected analysis code.
    /// </summary>
    public string Code { get; }

    /// <summary>
    /// Gets the ending line number where the violation is expected to occur.
    /// </summary>
    public int EndLine { get; }

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
    public int StartLine { get; }

    /// <inheritdoc/>
    public bool IsMatch(ICodeAnalysisViolation violation) =>
        violation.Code == this.Code
            && violation.FilePath == this.FilePath
            && violation.LineNumber >= this.StartLine
            && violation.LineNumber <= this.EndLine
            && string.Equals(
                violation.Level,
                this.Level,
                StringComparison.InvariantCultureIgnoreCase);
}
