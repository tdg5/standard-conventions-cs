namespace Tdg5.StandardConventions.TestAnnotations;

/// <summary>
/// Abstraction for expected code analysis violations.
/// </summary>
public interface ICodeAnalysisViolationExpectation
{
    /// <summary>
    /// Gets a value indicating whether or not the expectation is enabled.
    /// </summary>
    public bool Enabled { get; }

    /// <summary>
    /// Checks if the given violation matches the expectation.
    /// </summary>
    /// <param name="violation">The violation to check.</param>
    /// <returns>True if the violation matches the expectation, false
    /// otherwise.</returns>
    public bool IsMatch(ICodeAnalysisViolation violation);

    /// <summary>
    /// Returns a string representation of the expectation.
    /// </summary>
    /// <returns>A string description of the expectation.</returns>
    public string ToStringDescription();
}
