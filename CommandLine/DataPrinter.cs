using System.Text;
using TestResultsAnalyzer.Shared.DataModel;

namespace TestResultsAnalyzer.CommandLine
{
    public class DataPrinter
    {
        public void PrintCsvContent(string content, char separator = ',')
        {
            string[] lines = content.Split(Environment.NewLine);

            foreach (string line in lines)
            {
                string[] columns = line.Split(separator);

                foreach (string column in columns)
                {
                    Console.Write($"| {column} ");
                }
                Console.Write("|" + Environment.NewLine);
            }
        }

        public void PrintResultsAnalysis(AnalysisResult analysisResult)
        {
            Console.WriteLine("Counters");
            Console.WriteLine(GetSeparator());
            Console.WriteLine($"Total Executions: {analysisResult.TotalExecutions}");
            Console.WriteLine($"Total Test Suites: {analysisResult.TotalTestSuites}");
            Console.WriteLine($"Total Test Cases: {analysisResult.TotalTestCases}");
            Console.WriteLine(GetSeparator(2));

            Console.WriteLine("Execution Time");
            Console.WriteLine(GetSeparator());
            Console.WriteLine($"Total Execution Time (MS): {analysisResult.ExecutionTimeMS}");
            Console.WriteLine($"Shortest Execution Time (MS): {analysisResult.ShortestExecutionTimeMS}");
            Console.WriteLine($"Longest Execution Time (MS): {analysisResult.LongestExecutionTimeMS}");
            Console.WriteLine($"Average Execution Time (MS): {analysisResult.AverageExecutionTimeMS}");
            Console.WriteLine(GetSeparator(2));

            Console.WriteLine("Test Cases by Status");
            Console.WriteLine(GetSeparator());
            foreach (KeyValuePair<string, int> entry in analysisResult.TestCasesByResult)
            {
                Console.WriteLine($"\tTest Status: {entry.Key}, Test Cases: {entry.Value}");
            }
            Console.WriteLine(GetSeparator(2));

            Console.WriteLine("Test Rates by Status");
            Console.WriteLine(GetSeparator());
            foreach (KeyValuePair<string, float> entry in analysisResult.TestRatesByResults)
            {
                Console.WriteLine($"\tTest Status: {entry.Key}, Test Cases: {entry.Value}");
            }
            Console.WriteLine(GetSeparator(2));

            Console.WriteLine("Execution Time by Test Execution");
            Console.WriteLine(GetSeparator());
            foreach (KeyValuePair<string, long> entry in analysisResult.TotalTimeByTestExecution)
            {
                Console.WriteLine($"\tExecution: {entry.Key}, Time (MS): {entry.Value}");
            }
            Console.WriteLine(GetSeparator(2));

            Console.WriteLine("Execution Time by Test Suite");
            Console.WriteLine(GetSeparator());
            foreach (KeyValuePair<string, long> entry in analysisResult.TotalTimeByTestSuite)
            {
                Console.WriteLine($"\tExecution: {entry.Key}, Time (MS): {entry.Value}");
            }
            Console.WriteLine(GetSeparator(2));

            Console.WriteLine("Execution Time by Test Case");
            Console.WriteLine(GetSeparator());
            foreach (KeyValuePair<string, long> entry in analysisResult.TotalTimeByTestCase)
            {
                Console.WriteLine($"\tExecution: {entry.Key}, Time (MS): {entry.Value}");
            }
            Console.WriteLine(GetSeparator(2));

            Console.WriteLine("Failed Test Cases");
            Console.WriteLine(GetSeparator());
            foreach (string failedTest in analysisResult.FailedTests)
            {
                Console.WriteLine($"\t{failedTest}");
            }
            Console.WriteLine(GetSeparator());
        }

        private string GetSeparator(int newLines = 0)
        {
            StringBuilder sb = new();
            sb.Append("--------------------------------------------------------------------------------------------------------------");

            for (int i = 0; i < newLines; i++)
            {
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
