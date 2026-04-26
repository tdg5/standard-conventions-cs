using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.DocumentationRules;

[CodeAnalysisViolationExpected(
    "SA1600", "Info", disabledReason: "SA1600 is silenced")]
public enum UndocumentedEnumeration
{
}
