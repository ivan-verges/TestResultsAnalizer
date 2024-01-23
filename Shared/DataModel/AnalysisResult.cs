namespace TestResultsAnalyzer.Shared.DataModel
{
    public class AnalysisResult
    {
        public long ExecutionTimeMS { get; set; }
        public Dictionary<string, long> TotalTimeByTestExecution { get; set; } = new Dictionary<string, long>();
        public Dictionary<string, long> TotalTimeByTestSuite { get; set; } = new Dictionary<string, long>();
        public Dictionary<string, long> TotalTimeByTestCase { get; set; } = new Dictionary<string, long>();
        public Dictionary<string, int> TestCasesByResult { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, float> TestRatesByResults { get; set; } = new Dictionary<string, float>();
        public int TotalExecutions { get; set; }
        public int TotalTestSuites { get; set; }
        public int TotalTestCases { get; set; }
        public int FailingTestCases { get; set; }
        public int PassingTestCases { get; set; }
        public int PendingTestCases { get; set; }
        public int SkippingTestCases { get; set; }
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