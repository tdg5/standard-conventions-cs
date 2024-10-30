namespace Tdg5.StandardConventions.TestAnnotations;

/// <summary>
/// Attribute to specify an expected analysis code that should occur as part of
/// the analysis of a given target.
/// </summary>
[AttributeUsage(
    AttributeTargets.Class
        | AttributeTargets.Constructor
        | AttributeTargets.Delegate
        | AttributeTargets.Enum
        | AttributeTargets.Event
        | AttributeTargets.Field
        | AttributeTargets.Interface
        | AttributeTargets.Method
        | AttributeTargets.Property
        | AttributeTargets.Struct,
    AllowMultiple = true,
    Inherited = false)]
public class CodeAnalysisViolationExpectedAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="CodeAnalysisViolationExpectedAttribute"/> class.
    /// </summary>
    /// <param name="code">The analysis code that is expected.</param>
    /// <param name="level">The level of the analysis code that is expected.</param>
    public CodeAnalysisViolationExpectedAttribute(string code, string level)
    {
        this.Code = code;
        this.Level = level;
    }

    /// <summary>
    /// Gets the name of the expected analysis code.
    /// </summary>
    public string Code { get; }

    /// <summary>
    /// Gets the expected level of the analysis code.
    /// </summary>
    public string Level { get; }
}
