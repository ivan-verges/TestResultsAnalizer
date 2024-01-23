using TestResultsAnalyzer.Shared.DataModel;
using TestResultsAnalyzer.Shared.Utils;

namespace TestResultsAnalyzer.Shared.BusinessLogic
{
    public class ResultsAnalyzer
    {
        public AnalysisResult AnalyzeTestExecutions(List<TestExecution> testExecutions)
        {
            DictionaryUtils dictionaryUtils = new();

            AnalysisResult analysisResult = new();

            List<AnalysisResult> analysisResults = new();
            testExecutions.ForEach(x => analysisResults.Add(AnalyzeTestExecution(x)));

            analysisResults.ForEach(x =>
            {
                foreach (KeyValuePair<string, long> entry in x.TotalTimeByTestExecution)
                {
                    dictionaryUtils.AddOrUpdateDictionary(analysisResult.TotalTimeByTestExecution, entry.Key, entry.Value);
                }

                foreach (KeyValuePair<string, long> entry in x.TotalTimeByTestSuite)
                {
                    dictionaryUtils.AddOrUpdateDictionary(analysisResult.TotalTimeByTestSuite, entry.Key, entry.Value);
                }

                foreach (KeyValuePair<string, long> entry in x.TotalTimeByTestCase)
                {
                    dictionaryUtils.AddOrUpdateDictionary(analysisResult.TotalTimeByTestCase, entry.Key, entry.Value);
                }

                foreach (KeyValuePair<string, float> entry in x.TestRatesByResults)
                {
                    dictionaryUtils.AddOrUpdateDictionary(analysisResult.TestRatesByResults, entry.Key, (float) Decimal.Divide((decimal) entry.Value, testExecutions.Count));
                }

                foreach (KeyValuePair<string, int> entry in x.TestCasesByResult)
                {
                    dictionaryUtils.AddOrUpdateDictionary(analysisResult.TestCasesByResult, entry.Key, entry.Value);
                }
            });

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
            DictionaryUtils dictionaryUtils = new();

            AnalysisResult analysisResult = new()
            {
                TotalExecutions = 1,
                TotalTestSuites = testExecution.TestSuites.Count
            };
            
            dictionaryUtils.AddOrUpdateDictionary(analysisResult.TotalTimeByTestExecution, $"{testExecution.Id} - {testExecution.Name}", testExecution.TestSuites.Select(x => x.TestCases.Sum(y => (long)(y.EndTime - y.StartTime).TotalMilliseconds)).Sum());

            foreach (TestSuite testSuite in testExecution.TestSuites)
            {
                dictionaryUtils.AddOrUpdateDictionary(analysisResult.TotalTimeByTestSuite, $"{testSuite.Id} - {testSuite.Name}", testSuite.TestCases.Sum(y => (long)(y.EndTime - y.StartTime).TotalMilliseconds));

                analysisResult.TotalTestCases += testSuite.TestCases.Count;

                analysisResult.FailingTestCases += testSuite.TestCases.Where(x => x.Result == TestResult.Failed).Count();
                analysisResult.PassingTestCases += testSuite.TestCases.Where(x => x.Result == TestResult.Passed).Count();
                analysisResult.PendingTestCases += testSuite.TestCases.Where(x => x.Result == TestResult.Pending).Count();
                analysisResult.SkippingTestCases += testSuite.TestCases.Where(x => x.Result == TestResult.Skipped).Count();

                long shortestExecutionTime = testSuite.TestCases.Min(x => (long)(x.EndTime - x.StartTime).TotalMilliseconds);
                long longestExecutionTime = testSuite.TestCases.Max(x => (long)(x.EndTime - x.StartTime).TotalMilliseconds);
                double averageExecutionTime = testSuite.TestCases.Average(x => (long)(x.EndTime - x.StartTime).TotalMilliseconds);

                analysisResult.ExecutionTimeMS += testSuite.TestCases.Select(x => (long)(x.EndTime - x.StartTime).TotalMilliseconds).Sum();
                analysisResult.ShortestExecutionTimeMS = (analysisResult.ShortestExecutionTimeMS > 0) ? Math.Min(analysisResult.ShortestExecutionTimeMS, shortestExecutionTime) : shortestExecutionTime;
                analysisResult.LongestExecutionTimeMS = (analysisResult.LongestExecutionTimeMS > 0) ? Math.Max(analysisResult.LongestExecutionTimeMS, longestExecutionTime) : longestExecutionTime;

                foreach (TestCase testCase in testSuite.TestCases)
                {
                    dictionaryUtils.AddOrUpdateDictionary(analysisResult.TotalTimeByTestCase, $"{testCase.Id} - {testCase.Name}", (long)(testCase.EndTime - testCase.StartTime).TotalMilliseconds);

                    dictionaryUtils.AddOrUpdateDictionary(analysisResult.TestCasesByResult, testCase.Result.ToString(), 1);
                    dictionaryUtils.AddOrUpdateDictionary(analysisResult.TestRatesByResults, testCase.Result.ToString(), (float) Decimal.Divide(1, testExecution.TestSuites.Sum(x => x.TestCases.Count)));

                    if (testCase.Result == TestResult.Failed)
                    {
                        analysisResult.FailedTests.Add(string.Format("Test Execution: ({0} - {1}), Test Suite: ({2} - {3}), Test Case: ({4} - {5})", testExecution.Id, testExecution.Name, testSuite.Id, testSuite.Name, testCase.Id, testCase.Name));
                    }
                }
            }

            analysisResult.FailingRate = (float) Decimal.Divide(analysisResult.FailingTestCases, analysisResult.TotalTestCases);
            analysisResult.PassingRate = (float) Decimal.Divide(analysisResult.PassingTestCases, analysisResult.TotalTestCases);
            analysisResult.PendingRate = (float) Decimal.Divide(analysisResult.PendingTestCases, analysisResult.TotalTestCases);
            analysisResult.SkippingRate = (float) Decimal.Divide(analysisResult.SkippingTestCases, analysisResult.TotalTestCases);

            analysisResult.AverageExecutionTimeMS = (analysisResult.ExecutionTimeMS / analysisResult.TotalTestCases);

            return analysisResult;
        }
    }
}
