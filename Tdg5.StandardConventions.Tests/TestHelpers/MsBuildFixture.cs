using Microsoft.Build.Locator;

namespace Tdg5.StandardConventions.Tests.TestHelpers;

/// <summary>
/// Registers MSBuildLocator before the first test in the collection is run.
/// </summary>
public class MsBuildFixture : IDisposable
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MsBuildFixture"/> class.
    /// </summary>
    public MsBuildFixture()
    {
        MSBuildLocator.RegisterDefaults();
    }

    /// <summary>
    /// Unregisters MSBuildLocator after the last test in the collection is run.
    /// </summary>
    public void Dispose()
    {
        MSBuildLocator.Unregister();
        GC.SuppressFinalize(this);
    }
}
