namespace TestResultsAnalyzer.Shared.DataModel
{
    public class AnalysisResult
    {
        public long ExecutionTimeMS { get; set; }
        public int TotalExecutions { get; set; }
        public int TotalTestSuites { get; set; }
        public int TotalTestCases { get; set; }
        public float FailingTestCases { get; set; }
        public float PassingTestCases { get; set; }
        public float PendingTestCases { get; set; }
        public float SkippingTestCases { get; set; }
        public float FailingRate { get; set; }
        public float PassingRate { get; set; }
        public float PendingRate { get; set; }
        public float SkippingRate { get; set; }
        public long ShortestExecutionTimeMS { get; set; }
        public long LongestExecutionTimeMS { get; set; }
        public long AverageExecutionTimeMS { get; set; }
        public List<string> FailedTests { get; set; } = new List<string>();
    }
}