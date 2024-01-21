using TestResultsAnalyzer.Shared.DataModel;

namespace TestResultsAnalyzer.Shared.DataGenerator
{
    public class DemoGenerator
    {
        public List<TestExecution> GenerateTestExecutions(int testExecutionsCount = 1, int testSuitesCount = 1, int testCasesCount = 1)
        {
            List<TestExecution> testExecutions = new();
            for (int testExecutionId = 0; testExecutionId < testExecutionsCount; testExecutionId++)
            {
                TestExecution testExecution = new() { Id = (testExecutionId + 1), Name = $"Test Execution {(testExecutionId + 1)}", TestSuites = GenerateTestSuites(testSuitesCount, testCasesCount) };
                testExecutions.Add(testExecution);
            }

            return testExecutions;
        }

        public List<TestSuite> GenerateTestSuites(int testSuitesCount = 1, int testCasesCount = 1)
        {
            List<TestSuite> testSuites = new();
            for (int testSuiteId = 0; testSuiteId < testSuitesCount; testSuiteId++)
            {
                TestSuite testSuite = new() { Id = (testSuiteId + 1), Name = $"Test Suite {(testSuiteId + 1)}", TestCases = GenerateTestCases(testCasesCount) };
                testSuites.Add(testSuite);
            }

            return testSuites;
        }

        public List<TestCase> GenerateTestCases(int testCasesCount = 1)
        {
            List<TestCase> testCases = new();
            for (int testCaseId = 0; testCaseId < testCasesCount; testCaseId++)
            {
                Random random = new Random();
                DateTime currentDateTime = DateTime.Now;
                TestCase testCase = new() { Id = (testCaseId + 1), Name = $"Test Case {(testCaseId + 1)}", EndTime = currentDateTime.AddTicks(random.NextInt64(5000000, 50000000)), StartTime = currentDateTime };
                switch (testCaseId % 4)
                {
                    case 0:
                    {
                        testCase.Result = TestResult.Failed;
                        break;
                    }
                    case 1:
                    {
                        testCase.Result = TestResult.Passed;
                        break;
                    }
                    case 2:
                    {
                        testCase.Result = TestResult.Pending;
                        break;
                    }
                    case 3:
                    {
                        testCase.Result = TestResult.Skipped;
                        break;
                    }
                }

                testCases.Add(testCase);
            }

            return testCases;
        }
    }
}