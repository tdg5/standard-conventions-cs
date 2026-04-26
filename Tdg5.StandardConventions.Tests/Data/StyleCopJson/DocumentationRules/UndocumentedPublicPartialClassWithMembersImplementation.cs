using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.DocumentationRules;

/// <summary>
/// Test that public partial class members cause violation codes when undocumented.
/// </summary>
internal partial class UndocumentedPublicPartialClassWithMembers
{
    private readonly bool field = true;

    [CodeAnalysisViolationExpected(
        "SA1600", "Info", disabledReason: "SA1600 is silenced")]
    [CodeAnalysisViolationExpected(
        "SA1601", "Info", disabledReason: "SA1601 is silenced")]
    public partial void PublicPartialMethod()
    {
        InternalPartialMethod();
    }

    [CodeAnalysisViolationExpected(
        "SA1600", "Info", disabledReason: "SA1600 is silenced")]
    [CodeAnalysisViolationExpected(
        "SA1601", "Info", disabledReason: "SA1601 is silenced")]
    internal partial void InternalPartialMethod()
    {
        ProtectedPartialMethod();
    }

    [CodeAnalysisViolationExpected(
        "SA1600", "Info", disabledReason: "SA1600 is silenced")]
    [CodeAnalysisViolationExpected(
        "SA1601", "Info", disabledReason: "SA1601 is silenced")]
    protected partial void ProtectedPartialMethod()
    {
        PrivatePartialMethod();
    }

    [CodeAnalysisViolationExpected(
        "SA1600",
        "Info",
        disabledReason: "Private partial methods don't require documentation.")]
    [CodeAnalysisViolationExpected(
        "SA1601",
        "Info",
        disabledReason: "Private partial methods don't require documentation.")]
    private partial void PrivatePartialMethod()
    {
        NoopHelper.Noop(field);
    }
}
