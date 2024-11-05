namespace Tdg5.StandardConventions.TestAnnotations;

/// <summary>
/// Abstraction for reported code analysis violations.
/// </summary>
public interface ICodeAnalysisViolation
{
    /// <summary>
    /// Gets the name of the analysis code.
    /// </summary>
    string Code { get; }

    /// <summary>
    /// Gets the path of the file where the violation occurred.
    /// </summary>
    string FilePath { get; }

    /// <summary>
    /// Gets the level of the analysis violation.
    /// </summary>
    string Level { get; }

    /// <summary>
    /// Gets the line number where the violation occurred.
    /// </summary>
    int LineNumber { get; }

    /// <summary>
    /// Gets the message of the violation.
    /// </summary>
    string? Message { get; }
}
