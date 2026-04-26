using Microsoft.Build.Framework;

namespace Tdg5.StandardConventions.Tests.TestHelpers;

/// <summary>
/// Interface describing a collection of warnings and errors emitted during a
/// build.
/// </summary>
public interface IMsBuildWarningAndErrorCollection
{
    /// <summary>
    /// Gets a list of the <see cref="BuildErrorEventArgs"/> emitted during the
    /// build.
    /// </summary>
    List<BuildErrorEventArgs> Errors { get; }

    /// <summary>
    /// Gets a list of the <see cref="BuildWarningEventArgs"/> emitted during the
    /// build.
    /// </summary>
    List<BuildWarningEventArgs> Warnings { get; }
}
