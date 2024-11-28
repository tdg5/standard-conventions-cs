using Tdg5.StandardConventions.Tests.TestHelpers;
using Xunit.Abstractions;

namespace Tdg5.StandardConventions.Tests;

/// <summary>
/// Tests for EditorConfig rule IDE0077.
/// </summary>
public class IDE0077Test : BaseTestProjectAnalysisVerifierTest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IDE0077Test"/> class.
    /// </summary>
    /// <param name="testOutputHelper">The test output helper.</param>
    public IDE0077Test(ITestOutputHelper testOutputHelper)
        : base(testOutputHelper)
    {
    }

    /// <inheritdoc/>
    public override string ProjectPath => "Data/IDE0077/IDE0077.csproj";
}
