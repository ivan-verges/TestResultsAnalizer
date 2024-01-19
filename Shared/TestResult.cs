using System.ComponentModel;

namespace TestResultsAnalyzer.Shared
{
    [DefaultValue(Pending)]
    public enum TestResult
    {
        Fail,
        Pending,
        Skipped,
        Success
    }
}