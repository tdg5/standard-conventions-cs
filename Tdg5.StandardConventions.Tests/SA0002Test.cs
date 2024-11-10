using Tdg5.StandardConventions.Tests.TestHelpers;
using Xunit.Abstractions;

namespace Tdg5.StandardConventions.Tests;

/// <summary>
/// Tests for StyleCop rule SA0002.
/// </summary>
public class SA0002Test : BaseTestProjectAnalysisVerifierTest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SA0002Test"/> class.
    /// </summary>
    /// <param name="testOutputHelper">The test output helper.</param>
    public SA0002Test(ITestOutputHelper testOutputHelper)
        : base(testOutputHelper)
    {
    }

    /// <inheritdoc/>
    public override string ProjectPath => "Data/SA0002/SA0002.csproj";
}
