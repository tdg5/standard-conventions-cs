using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.OrderingRules;

/// <summary>
/// A class with a variety of elements not ordered by accessibility.
/// </summary>
public class ClassWithElementsNotOrderedByAccessibility
{
    private readonly int field = 0;

    private void PrivateMethod()
    {
        NoopHelper.NoopMemberReference(field);
    }

    /// <summary>
    /// A protected method.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "SA1202",
        "Warning",
        contains: "'protected' members should come before 'private' members",
        disabledReason: "SA1202 is silenced")]
    protected void ProtectedMethod()
    {
        PrivateMethod();
        NoopHelper.NoopMemberReference(field);
    }

    /// <summary>
    /// An internal method.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "SA1202",
        "Warning",
        contains: "'internal' members should come before 'protected' members",
        disabledReason: "SA1202 is silenced")]
    internal void InternalMethod()
    {
        NoopHelper.NoopMemberReference(field);
    }

    /// <summary>
    /// A public method.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "SA1202",
        "Warning",
        contains: "'public' members should come before 'internal' members",
        disabledReason: "SA1202 is silenced")]
    public void PublicMethod()
    {
        NoopHelper.NoopMemberReference(field);
    }
}
