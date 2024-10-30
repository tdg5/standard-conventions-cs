using Microsoft.Build.Framework;
using System.Collections;
using Xunit.Abstractions;

namespace Tdg5.StandardConventions.Tests.TestHelpers;

/// <summary>
/// An implementation of <see cref="ILogger"/> that works with xUnit's <see
/// cref="ITestOutputHelper"/> to log messages.
/// </summary>
internal class MsBuildTestOutputLogger : ILogger
{
    private readonly List<string> errors = [];

    private readonly ITestOutputHelper testOutputHelper;

    private readonly bool dumpEnv;

    private readonly bool verbose;

    /// <summary>
    /// Initializes a new instance of the <see cref="MsBuildTestOutputLogger"/> class.
    /// </summary>
    /// <param name="testOutputHelper">The test output helper.</param>
    /// <param name="dumpEnv">Flag indicating whether to dump the environment.</param>
    /// <param name="verbose">Flag indicating whether to log all events.</param>
    public MsBuildTestOutputLogger(
        ITestOutputHelper testOutputHelper,
        bool dumpEnv = false,
        bool verbose = true)
    {
        this.testOutputHelper = testOutputHelper;
        this.dumpEnv = dumpEnv;
        this.verbose = verbose;
    }

    /// <inheritdoc/>
    public LoggerVerbosity Verbosity { get; set; }

    /// <inheritdoc/>
    public string? Parameters { get; set; } = null;

    /// <summary>
    /// Gets an error message composed from any accumulated errors.
    /// </summary>
    public string ErrorMessage => string.Join(Environment.NewLine, this.errors);

    /// <inheritdoc/>
    public void Initialize(IEventSource eventSource)
    {
        eventSource.AnyEventRaised += this.OnAnyEventRaised;
        eventSource.BuildStarted += this.OnBuildStarted;
        eventSource.ErrorRaised += this.OnErrorRaised;
        eventSource.MessageRaised += this.OnMessageRaised;
        eventSource.ProjectStarted += this.OnProjectStarted;
    }

    /// <inheritdoc/>
    public void Shutdown()
    {
    }

    private void OnAnyEventRaised(object sender, BuildEventArgs eventArgs)
    {
        if (this.verbose)
        {
            this.testOutputHelper.WriteLine(eventArgs.Message);
        }
    }

    private void OnBuildStarted(object sender, BuildStartedEventArgs eventArgs)
    {
        if (!this.dumpEnv || eventArgs.BuildEnvironment is null)
        {
            return;
        }

        this.testOutputHelper.WriteLine("Environment:");
        foreach (var keyValuePair in eventArgs.BuildEnvironment)
        {
            this.testOutputHelper.WriteLine($"{keyValuePair.Key}: {keyValuePair.Value}");
        }
    }

    private void OnErrorRaised(object sender, BuildErrorEventArgs eventArgs)
    {
        var message = string.Format(
            "{0} {1}({2},{3})",
            eventArgs.Message,
            eventArgs.File,
            eventArgs.LineNumber,
            eventArgs.ColumnNumber);
        this.testOutputHelper.WriteLine(message);
        this.errors.Add(message);
    }

    private void OnMessageRaised(object sender, BuildMessageEventArgs eventArgs)
    {
        if (eventArgs?.Message?.StartsWith("DEBUG:") ?? false)
        {
            this.testOutputHelper.WriteLine(eventArgs.Message);
        }
    }

    private void OnProjectStarted(object sender, ProjectStartedEventArgs eventArgs)
    {
        if (!this.dumpEnv || eventArgs.Properties is null)
        {
            return;
        }

        this.testOutputHelper.WriteLine("Initial Properties:");
        foreach (DictionaryEntry keyValuePair in eventArgs.Properties)
        {
            this.testOutputHelper
                .WriteLine("{0}: {1}", keyValuePair.Key, keyValuePair.Value);
        }
    }
}
