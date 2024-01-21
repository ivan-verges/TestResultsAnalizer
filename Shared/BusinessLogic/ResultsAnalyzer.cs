using TestResultsAnalyzer.Shared.DataModel;

namespace TestResultsAnalyzer.Shared.BusinessLogic
{
    public class ResultsAnalyzer
    {
        public AnalysisResult AnalyzeTestExecutions(List<TestExecution> testExecutions)
        {
            AnalysisResult analysisResult = new();

            List<AnalysisResult> analysisResults = new();
            testExecutions.ForEach(x => analysisResults.Add(AnalyzeTestExecution(x)));

            analysisResult.TotalExecutions = analysisResults.Sum(x => x.TotalExecutions);
            analysisResult.TotalTestSuites = analysisResults.Sum(x => x.TotalTestSuites);
            analysisResult.TotalTestCases = analysisResults.Sum(x => x.TotalTestCases);
            
            analysisResult.FailingTestCases = analysisResults.Sum(x => x.FailingTestCases);
            analysisResult.PassingTestCases = analysisResults.Sum(x => x.PassingTestCases);
            analysisResult.PendingTestCases = analysisResults.Sum(x => x.PendingTestCases);
            analysisResult.SkippingTestCases = analysisResults.Sum(x => x.SkippingTestCases);

            analysisResult.ExecutionTimeMS = analysisResults.Sum(x => x.ExecutionTimeMS);
            analysisResult.ShortestExecutionTimeMS = analysisResults.Min(x => x.ShortestExecutionTimeMS);
            analysisResult.LongestExecutionTimeMS = analysisResults.Min(x => x.LongestExecutionTimeMS);
            analysisResult.AverageExecutionTimeMS = (long) analysisResults.Average(x => x.AverageExecutionTimeMS);

            analysisResult.FailingRate = analysisResults.Average(x => x.FailingRate);
            analysisResult.PassingRate = analysisResults.Average(x => x.PassingRate);
            analysisResult.PendingRate = analysisResults.Average(x => x.PendingRate);
            analysisResult.SkippingRate = analysisResults.Average(x => x.SkippingRate);

            analysisResult.FailedTests = new();
            analysisResults.ForEach(x => x.FailedTests.ForEach(y => analysisResult.FailedTests.Add(y)));


            return analysisResult;
        }

        public AnalysisResult AnalyzeTestExecution(TestExecution testExecution)
        {
            AnalysisResult analysisResult = new()
            {
                TotalExecutions = 1,
                TotalTestSuites = testExecution.TestSuites.Count
            };

            foreach (TestSuite testSuite in testExecution.TestSuites)
            {
                analysisResult.TotalTestCases += testSuite.TestCases.Count;

                analysisResult.FailingTestCases += testSuite.TestCases.Where(x => x.Result == TestResult.Failed).Count();
                analysisResult.PassingTestCases += testSuite.TestCases.Where(x => x.Result == TestResult.Passed).Count();
                analysisResult.PendingTestCases += testSuite.TestCases.Where(x => x.Result == TestResult.Pending).Count();
                analysisResult.SkippingTestCases += testSuite.TestCases.Where(x => x.Result == TestResult.Skipped).Count();

                long shortestExecutionTime = testSuite.TestCases.Min(x => x.DurationMS);
                long longestExecutionTime = testSuite.TestCases.Max(x => x.DurationMS);
                double averageExecutionTime = testSuite.TestCases.Average(x => x.DurationMS);

                analysisResult.ExecutionTimeMS += testSuite.TestCases.Select(x => x.DurationMS).Sum();
                analysisResult.ShortestExecutionTimeMS = (analysisResult.ShortestExecutionTimeMS > 0) ? Math.Min(analysisResult.ShortestExecutionTimeMS, shortestExecutionTime) : shortestExecutionTime;
                analysisResult.LongestExecutionTimeMS = (analysisResult.LongestExecutionTimeMS > 0) ? Math.Max(analysisResult.LongestExecutionTimeMS, longestExecutionTime) : longestExecutionTime;

                foreach (TestCase testCase in testSuite.TestCases)
                {
                    if (testCase.Result == TestResult.Failed)
                    {
                        analysisResult.FailedTests.Add(string.Format("Test Execution: ({0} - {1}), Test Suite: ({2} - {3}), Test Case: ({4} - {5})", testExecution.Id, testExecution.Name, testSuite.Id, testSuite.Name, testCase.Id, testCase.Name));
                    }
                }
            }

            analysisResult.FailingRate = (analysisResult.FailingTestCases / analysisResult.TotalTestCases);
            analysisResult.PassingRate = (analysisResult.PassingTestCases / analysisResult.TotalTestCases);
            analysisResult.PendingRate = (analysisResult.PendingTestCases / analysisResult.TotalTestCases);
            analysisResult.SkippingRate = (analysisResult.SkippingTestCases / analysisResult.TotalTestCases);

            analysisResult.AverageExecutionTimeMS = (analysisResult.ExecutionTimeMS / analysisResult.TotalTestCases);

            return analysisResult;
        }
    }
}
