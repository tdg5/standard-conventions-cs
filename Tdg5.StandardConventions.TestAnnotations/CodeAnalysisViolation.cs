namespace Tdg5.StandardConventions.TestAnnotations;

/// <summary>
/// Default implementation of the <see cref="ICodeAnalysisViolation"/>
/// interface.
/// </summary>
public class CodeAnalysisViolation : ICodeAnalysisViolation
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CodeAnalysisViolation"/>
    /// class.
    /// </summary>
    /// <param name="code">The name of the analysis code.</param>
    /// <param name="level">The level of the analysis violation.</param>
    /// <param name="projectPath">The path of the project where the violation
    /// occurred.</param>
    /// <param name="filePath">The path of the file where the violation
    /// occurred.</param>
    /// <param name="lineNumber">The line number where the violation
    /// occurred.</param>
    /// <param name="message">The message of the violation.</param>
    public CodeAnalysisViolation(
        string code,
        string level,
        string projectPath,
        string filePath,
        int lineNumber,
        string? message)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(code, nameof(code));
        ArgumentException.ThrowIfNullOrWhiteSpace(projectPath, nameof(projectPath));
        ArgumentException.ThrowIfNullOrWhiteSpace(filePath, nameof(filePath));
        ArgumentException.ThrowIfNullOrWhiteSpace(level, nameof(level));
        if (message is not null)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(message, nameof(message));
        }

        if (lineNumber < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(lineNumber),
                lineNumber,
                "The line number must be a non-negative integer.");
        }

        Code = code;
        FilePath = filePath;
        Level = level;
        LineNumber = lineNumber;
        Message = message;
        ProjectPath = projectPath;
    }

    /// <inheritdoc/>
    public string Code { get; }

    /// <inheritdoc/>
    public string FilePath { get; }

    /// <inheritdoc/>
    public string Level { get; }

    /// <inheritdoc/>
    public int LineNumber { get; }

    /// <inheritdoc/>
    public string? Message { get; }

    /// <inheritdoc/>
    public string ProjectPath { get; }
}
