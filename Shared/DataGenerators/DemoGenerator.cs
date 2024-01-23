using System;
using TestResultsAnalyzer.Shared.DataModel;

namespace TestResultsAnalyzer.Shared.DataGenerators
{
    public class DemoGenerator
    {
        public List<TestExecution> GenerateTestExecutions(int testExecutionsCount = 1, int testSuitesCount = 1, int testCasesCount = 1)
        {
            List<TestExecution> testExecutions = new();
            for (int testExecutionId = 0; testExecutionId < testExecutionsCount; testExecutionId++)
            {
                TestExecution testExecution = new()
                {
                    Id = (testExecutionId + 1),
                    Name = $"Test Execution {Guid.NewGuid()}",
                    TestSuites = GenerateTestSuites(testSuitesCount, testCasesCount)
                };

                testExecutions.Add(testExecution);
            }

            return testExecutions;
        }

        public List<TestSuite> GenerateTestSuites(int testSuitesCount = 1, int testCasesCount = 1)
        {
            List<TestSuite> testSuites = new();
            for (int testSuiteId = 0; testSuiteId < testSuitesCount; testSuiteId++)
            {
                TestSuite testSuite = new()
                {
                    Id = (testSuiteId + 1),
                    Name = $"Test Suite {Guid.NewGuid()}",
                    TestCases = GenerateTestCases(testCasesCount)
                };

                testSuites.Add(testSuite);
            }

            return testSuites;
        }

        public List<TestCase> GenerateTestCases(int testCasesCount = 1)
        {
            List<TestCase> testCases = new();
            for (int testCaseId = 0; testCaseId < testCasesCount; testCaseId++)
            {
                Random random = new();
                DateTime currentDateTime = DateTime.Now;
                TestCase testCase = new()
                {
                    Id = (testCaseId + 1),
                    Name = $"Test Case {Guid.NewGuid()}",
                    EndTime = currentDateTime.AddTicks(random.NextInt64(5000000, 50000000)),
                    Result = GetRandomTestResult(),
                    StartTime = currentDateTime
                };

                testCases.Add(testCase);
            }

            return testCases;
        }

        public TestResult GetRandomTestResult()
        {
            Random random = new();
            Array statuses = Enum.GetValues(typeof(TestResult));
            
            return (TestResult) statuses.GetValue(random.Next(statuses.Length));
        }
    }
}