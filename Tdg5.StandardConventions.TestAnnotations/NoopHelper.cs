namespace Tdg5.StandardConventions.TestAnnotations;

/// <summary>
/// A class with helper methods for no-op operations.
/// </summary>
public static class NoopHelper
{
    /// <summary>
    /// A no-op method that does nothing with the given arguments.
    /// </summary>
    /// <param name="args">The arguments.</param>
    public static void Noop(params object[] args)
    {
    }

    /// <summary>
    /// A no-op method that references a member to make the member appear to be
    /// used.
    /// </summary>
    /// <param name="member">The member needing reference.</param>
    public static void NoopMemberReference(object member)
    {
    }

    /// <summary>
    /// A no-op method that references a member to make the member appear to be
    /// used.
    /// </summary>
    /// <param name="member">The member needing reference.</param>
    public static void NoopMemberReference(int member)
    {
    }
}
