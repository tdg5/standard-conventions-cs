using Microsoft.Build.Framework;

namespace Tdg5.StandardConventions.Tests.TestHelpers;

/// <summary>
/// A logger that collects warnings and errors emitted during a build.
/// </summary>
internal class MsBuildWarningAndErrorLogger : ILogger, IMsBuildWarningAndErrorCollection
{
    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="MsBuildWarningAndErrorLogger"/> class.
    /// </summary>
    public MsBuildWarningAndErrorLogger()
    {
    }

    /// <summary>
    /// Gets a list of the <see cref="BuildErrorEventArgs"/> emitted during the
    /// build.
    /// </summary>
    public List<BuildErrorEventArgs> Errors { get; } = [];

    /// <inheritdoc/>
    public string? Parameters { get; set; } = null;

    /// <inheritdoc/>
    public LoggerVerbosity Verbosity { get; set; }

    /// <summary>
    /// Gets a list of the <see cref="BuildWarningEventArgs"/> emitted during the
    /// build.
    /// </summary>
    public List<BuildWarningEventArgs> Warnings { get; } = [];

    /// <inheritdoc/>
    public void Initialize(IEventSource eventSource)
    {
        eventSource.WarningRaised += this.OnWarningRaised;
        eventSource.ErrorRaised += this.OnErrorRaised;
    }

    /// <inheritdoc/>
    public void Shutdown()
    {
    }

    private void OnErrorRaised(object sender, BuildErrorEventArgs eventArgs)
    {
        this.Errors.Add(eventArgs);
    }

    private void OnWarningRaised(object sender, BuildWarningEventArgs eventArgs)
    {
        this.Warnings.Add(eventArgs);
    }
}
