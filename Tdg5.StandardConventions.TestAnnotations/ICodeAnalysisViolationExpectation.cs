namespace Tdg5.StandardConventions.TestAnnotations;

/// <summary>
/// Abstraction for expected code analysis violations.
/// </summary>
public interface ICodeAnalysisViolationExpectation
{
    /// <summary>
    /// Checks if the given violation matches the expectation.
    /// </summary>
    /// <param name="violation">The violation to check.</param>
    /// <returns>True if the violation matches the expectation, false
    /// otherwise.</returns>
    public bool IsMatch(ICodeAnalysisViolation violation);
}
