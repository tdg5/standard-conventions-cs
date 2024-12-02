using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.DocumentationRules;

/// <summary>
/// Test that public partial class members cause violation codes when undocumented.
/// </summary>
internal partial class UndocumentedPublicPartialClassWithMembers
{
    private readonly bool field = true;

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    [CodeAnalysisViolationExpected("SA1601", "Warning")]
    public partial void PublicPartialMethod()
    {
        InternalPartialMethod();
    }

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    [CodeAnalysisViolationExpected("SA1601", "Warning")]
    internal partial void InternalPartialMethod()
    {
        ProtectedPartialMethod();
    }

    [CodeAnalysisViolationExpected("SA1600", "Warning")]
    [CodeAnalysisViolationExpected("SA1601", "Warning")]
    protected partial void ProtectedPartialMethod()
    {
        PrivatePartialMethod();
    }

    [CodeAnalysisViolationExpected(
        "SA1600",
        "Warning",
        disabledReason: "Private partial methods don't require documentation.")]
    [CodeAnalysisViolationExpected(
        "SA1601",
        "Warning",
        disabledReason: "Private partial methods don't require documentation.")]
    private partial void PrivatePartialMethod()
    {
        NoopHelper.Noop(field);
    }
}
