using Tdg5.StandardConventions.Tests.TestHelpers;
using Xunit.Abstractions;

namespace Tdg5.StandardConventions.Tests;

/// <summary>
/// Tests for CodeAnalysis rules.
/// </summary>
public class CodeAnalysisRulesTest : BaseTestProjectAnalysisVerifierTest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CodeAnalysisRulesTest"/> class.
    /// </summary>
    /// <param name="testOutputHelper">The test output helper.</param>
    public CodeAnalysisRulesTest(ITestOutputHelper testOutputHelper)
        : base(testOutputHelper)
    {
    }

    /// <inheritdoc/>
    public override string ProjectPath => "Data/CodeAnalysisRules/CodeAnalysisRules.csproj";
}
