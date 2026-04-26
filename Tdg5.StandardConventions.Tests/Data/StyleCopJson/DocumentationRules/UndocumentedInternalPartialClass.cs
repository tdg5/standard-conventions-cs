using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.DocumentationRules;

[CodeAnalysisViolationExpected(
    "SA1601", "Info", disabledReason: "SA1601 is silenced")]
internal partial class UndocumentedInternalPartialClass
{
}
