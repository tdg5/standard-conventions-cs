// This files format is a little weird because the invalid stylecop.json file
// causes StyleCop to fallback to some defaults that disagree with the defaults
// established in the Tdg5.StandardConventions project. The structure of this file
// prevents other warnings from being emitted.
namespace Tdg5.StandardConventions.Tests.Data.SA0002
{
    using Tdg5.StandardConventions.TestAnnotations;

    /// <summary>
    /// This project should cause a SA0002 warning because stylecop.json is malformed.
    /// </summary>
    [ProjectAnalysisViolationExpected("SA0002", "Warning")]
    public class ProjectScopedExpectations
    {
    }
}
