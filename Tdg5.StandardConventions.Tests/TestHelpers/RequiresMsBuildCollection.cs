namespace Tdg5.StandardConventions.Tests.TestHelpers;

/// <summary>
/// Collection definition for tests that require the MSBuildLocator to be
/// registered.
/// </summary>
[CollectionDefinition("RequiresMsBuild")]
public class RequiresMsBuildCollection : ICollectionFixture<MsBuildFixture>
{
}
