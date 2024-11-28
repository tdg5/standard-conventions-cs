using Tdg5.StandardConventions.Tests.TestHelpers;
using Xunit.Abstractions;

namespace Tdg5.StandardConventions.Tests;

/// <summary>
/// Tests for EditorConfig rule IDE0076.
/// </summary>
public class IDE0076Test : BaseTestProjectAnalysisVerifierTest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IDE0076Test"/> class.
    /// </summary>
    /// <param name="testOutputHelper">The test output helper.</param>
    public IDE0076Test(ITestOutputHelper testOutputHelper)
        : base(testOutputHelper)
    {
    }

    /// <inheritdoc/>
    public override string ProjectPath => "Data/IDE0076/IDE0076.csproj";
}
