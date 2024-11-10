using Tdg5.StandardConventions.Tests.TestHelpers;
using Xunit.Abstractions;

namespace Tdg5.StandardConventions.Tests;

/// <summary>
/// Tests for stylecop.json rules.
/// </summary>
public class StyleCopJsonTest : BaseTestProjectAnalysisVerifierTest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StyleCopJsonTest"/> class.
    /// </summary>
    /// <param name="testOutputHelper">The test output helper.</param>
    public StyleCopJsonTest(ITestOutputHelper testOutputHelper)
        : base(testOutputHelper)
    {
    }

    /// <inheritdoc/>
    public override string ProjectPath => "Data/StyleCopJson/StyleCopJson.csproj";
}
