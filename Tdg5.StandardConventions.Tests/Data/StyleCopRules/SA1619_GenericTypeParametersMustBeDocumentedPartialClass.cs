using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopRules;

/// <summary>
/// A partial class that is missing documentation for a type parameter.
/// </summary>
[FileAnalysisViolationExpected("SA1619", "Warning")]
public partial class SA1619_GenericTypeParametersMustBeDocumentedPartialClass<T>
{
}
