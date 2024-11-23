using Tdg5.StandardConventions.Tests.TestHelpers;
using Xunit.Abstractions;

namespace Tdg5.StandardConventions.Tests;

/// <summary>
/// Tests for EditorConfig rules.
/// </summary>
public class EditorConfigRulesTest : BaseTestProjectAnalysisVerifierTest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EditorConfigRulesTest"/> class.
    /// </summary>
    /// <param name="testOutputHelper">The test output helper.</param>
    public EditorConfigRulesTest(ITestOutputHelper testOutputHelper)
        : base(testOutputHelper)
    {
    }

    /// <inheritdoc/>
    public override string ProjectPath => "Data/EditorConfigRules/EditorConfigRules.csproj";
}
