using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.EditorConfigRules;

/// <summary>
/// A class that uses an object for a lock.
/// </summary>
[CodeAnalysisViolationExpected("IDE0330", "Warning")]
public class IDE0330_UseSystemThreadingLock
{
    private static readonly object Lock = new();

    /// <summary>
    /// A method that uses an object as a lock instead of an instance of
    /// System.Threading.Lock.
    /// </summary>
    public static void MethodWithLock()
    {
        lock (Lock)
        {
            NoopHelper.Noop();
        }
    }
}
