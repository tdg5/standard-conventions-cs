using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.DocumentationRules;

/// <summary>
/// Test that public partial class members cause violation codes when undocumented.
/// </summary>
internal partial class UndocumentedPublicPartialClassWithMembers
{
    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    [CodeAnalysisViolationExpected("SA1601", "Warning")]
    public partial void PublicPartialMethod()
    {
    }

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    [CodeAnalysisViolationExpected("SA1601", "Warning")]
    internal partial void InternalPartialMethod()
    {
    }

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    [CodeAnalysisViolationExpected("SA1601", "Warning")]
    protected partial void ProtectedPartialMethod()
    {
    }

    [CodeAnalysisViolationExpected("SA1600", "Warning", enabled: false)]
    [CodeAnalysisViolationExpected("SA1601", "Warning", enabled: false)]
    private partial void PrivatePartialMethod()
    {
    }
}
