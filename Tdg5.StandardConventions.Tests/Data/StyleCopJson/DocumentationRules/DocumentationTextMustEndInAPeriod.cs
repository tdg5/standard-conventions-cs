using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopJson.DocumentationRules;

/// <summary>
/// Wrapper class for testing documentation text that must end in a period.
/// </summary>
public class DocumentationTextMustEndInAPeriod
{
    [CodeAnalysisViolationExpected("SA1629", "Warning")]
    private class SummaryWithoutPeriod
    {
        /// <summary>
        /// This is a summary without a period
        /// </summary>
        public void Method()
        {
        }
    }

    [CodeAnalysisViolationExpected("SA1629", "Warning")]
    private class ParamWithoutPeriod
    {
        /// <summary>
        /// This is a summary.
        /// </summary>
        /// <param name="ignored">This is a param without a period</param>
        public void Method(bool ignored)
        {
        }
    }

    [CodeAnalysisViolationExpected("SA1629", "Warning")]
    private class ReturnsWithoutPeriod
    {
        /// <summary>
        /// This is a summary.
        /// </summary>
        /// <returns>This is a returns without a period</returns>
        public bool Method() => true;
    }

    [CodeAnalysisViolationExpected("SA1629", "Warning", enabled: false)]
    private class SeeAlsoWithoutPeriod
    {
        /// <summary>
        /// This is a summary.
        /// </summary>
        /// <seealso cref="SeeAlsoWithoutPeriod">This is a seealso without a period</seealso>
        public void Method()
        {
        }
    }
}