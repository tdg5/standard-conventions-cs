using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.NamingRules;

/// <summary>
/// The name of this file is in metadata format and should cause a code
/// violation warning.
/// </summary>
/// <typeparam name="T">The type of the generic class.</typeparam>
[FileAnalysisViolationExpected("SA1649", "Warning")]
public class GenericClassWithMetadataStyleFileName<T>
{
}
