using Tdg5.StandardConventions.Tests.TestHelpers;
using Xunit.Abstractions;

namespace Tdg5.StandardConventions.Tests;

/// <summary>
/// Tests for StyleCop rules.
/// </summary>
public class StyleCopRulesTest : BaseTestProjectAnalysisVerifierTest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StyleCopRulesTest"/> class.
    /// </summary>
    /// <param name="testOutputHelper">The test output helper.</param>
    public StyleCopRulesTest(ITestOutputHelper testOutputHelper)
        : base(testOutputHelper)
    {
    }

    /// <inheritdoc/>
    public override string ProjectPath => "Data/StyleCopRules/StyleCopRules.csproj";
}
