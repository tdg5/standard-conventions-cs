using Tdg5.StandardConventions.Tests.TestHelpers;
using Xunit.Abstractions;

namespace Tdg5.StandardConventions.Tests;

/// <summary>
/// Tests for StyleCop rule SA0001.
/// </summary>
public class SA0001Test : BaseTestProjectAnalysisVerifierTest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SA0001Test"/> class.
    /// </summary>
    /// <param name="testOutputHelper">The test output helper.</param>
    public SA0001Test(ITestOutputHelper testOutputHelper)
        : base(testOutputHelper)
    {
    }

    /// <inheritdoc/>
    public override string ProjectPath => "Data/SA0001/SA0001.csproj";
}
