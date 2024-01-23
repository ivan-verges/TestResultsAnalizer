using System.Text;
using TestResultsAnalyzer.Shared.DataModel;

namespace TestResultsAnalyzer.Shared.BusinessLogic
{
    public class DataConverter
    {
        public string TestExecutionsToCsv(List<TestExecution> testExecutions, char separator = ',', bool includeHeader = true)
        {
            List<string> result = new();

            if (includeHeader)
            {
                StringBuilder sb = new();

                sb.Append("TestExecutionId");
                sb.Append(separator);
                sb.Append("TestExecutionName");
                sb.Append(separator);
                sb.Append("TestSuiteId");
                sb.Append(separator);
                sb.Append("TestSuiteName");
                sb.Append(separator);
                sb.Append("TestCaseId");
                sb.Append(separator);
                sb.Append("TestCaseName");
                sb.Append(separator);
                sb.Append("TestCaseStartTime");
                sb.Append(separator);
                sb.Append("TestCaseEndTime");
                sb.Append(separator);
                sb.Append("TestCaseDurationMS");
                sb.Append(separator);
                sb.Append("TestCaseResult");

                result.Add(sb.ToString());
            }

            foreach (TestExecution testExecution in testExecutions)
            {
                foreach (TestSuite testSuite in testExecution.TestSuites)
                {
                    foreach (TestCase testCase in testSuite.TestCases)
                    {
                        StringBuilder sb = new();

                        sb.Append(testExecution.Id);
                        sb.Append(separator);
                        sb.Append(testExecution.Name);
                        sb.Append(separator);
                        sb.Append(testSuite.Id);
                        sb.Append(separator);
                        sb.Append(testSuite.Name);
                        sb.Append(separator);
                        sb.Append(testCase.Id);
                        sb.Append(separator);
                        sb.Append(testCase.Name);
                        sb.Append(separator);
                        sb.Append(testCase.StartTime.ToString("yyyy-MM-dd hh:mm:ss.fff tt"));
                        sb.Append(separator);
                        sb.Append(testCase.EndTime.ToString("yyyy-MM-dd hh:mm:ss.fff tt"));
                        sb.Append(separator);
                        sb.Append((long)(testCase.EndTime - testCase.StartTime).TotalMilliseconds);
                        sb.Append(separator);
                        sb.Append(testCase.Result);

                        result.Add(sb.ToString());
                    }
                }
            }

            return string.Join('\n', result.ToArray());
        }
    }
}