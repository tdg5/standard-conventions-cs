using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.MaintainabilityRules;

/// <summary>
/// Primary class.
/// </summary>
public class TopLevelTypes
{
}

/// <summary>
/// A delegate.
/// </summary>
[CodeAnalysisViolationExpected(
    "SA1201",
    "Warning",
    contains: "A delegate should not follow a class")]
[CodeAnalysisViolationExpected("SA1402", "Warning")]
public delegate void PublicDelegate();

/// <summary>
/// An enumeration.
/// </summary>
[CodeAnalysisViolationExpected("SA1402", "Warning")]
public enum PublicEnumeration
{
}

/// <summary>
/// An interface.
/// </summary>
[CodeAnalysisViolationExpected("SA1402", "Warning")]
public interface IPublicInterface
{
}

/// <summary>
/// A struct.
/// </summary>
[CodeAnalysisViolationExpected("SA1402", "Warning")]
public struct PublicStruct
{
}

/// <summary>
/// A class.
/// </summary>
[CodeAnalysisViolationExpected("SA1402", "Warning")]
public class PublicClass
{
}
