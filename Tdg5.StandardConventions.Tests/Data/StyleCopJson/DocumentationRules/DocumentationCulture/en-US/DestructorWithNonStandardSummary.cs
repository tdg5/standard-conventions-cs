using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.DocumentationRules;

/// <summary>
/// Test that a destructor with a non-standard summary triggers violation codes.
/// </summary>
[CodeAnalysisViolationExpected("SA1643", "Warning")]
public class DestructorWithNonStandardSummary
{
    /// <summary>
    /// Destructs the thing.
    /// </summary>
    ~DestructorWithNonStandardSummary()
    {
    }
}
