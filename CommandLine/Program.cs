using System.IO;
using System.Text;
using TestResultsAnalyzer.Shared.BusinessLogic;
using TestResultsAnalyzer.Shared.DataConverters;
using TestResultsAnalyzer.Shared.DataGenerators;
using TestResultsAnalyzer.Shared.DataModel;
using TestResultsAnalyzer.Shared.Utils;

namespace TestResultsAnalyzer.CommandLine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Test Results Analyzer");

                int option = GetUserSelection();

                if (option == 0)
                {
                    WaitForUserAndClearConsole();
                    continue;
                }

                switch ((MenuOptions)option)
                {
                    case MenuOptions.GenerateJsonDemo:
                    {
                        string outputPath = GetFilePathFromUser(false);
                        if (outputPath == null)
                        {
                            WaitForUserAndClearConsole();
                            continue;
                        }

                        GenerateDemoToJsonFile(outputPath, 2, 2, 2);

                        break;
                    }
                    case MenuOptions.GenerateCsvDemo:
                    {
                        string outputPath = GetFilePathFromUser(false);
                        if (outputPath == null)
                        {
                            WaitForUserAndClearConsole();
                            continue;
                        }

                        GenerateDemoToCsvFile(outputPath, 3, 5, 7);

                        break;
                    }
                    case MenuOptions.AnalyzeJsonFromConsole:
                    {
                        string jsonData = GetJsonFromUserInput();
                        if (jsonData == null)
                        {
                            WaitForUserAndClearConsole();
                            continue;
                        }

                        List<TestExecution> testExecutions = GetTestExecutionsFromJson(jsonData);
                        AnalysisResult analysisResult = AnalyzeTestExecutions(testExecutions);
                        PrintAnalysisResults(analysisResult);

                        break;
                    }
                    case MenuOptions.AnalyzeJsonFromFile:
                    {
                        string inputPath = GetFilePathFromUser(true);
                        if (inputPath == null)
                        {
                            WaitForUserAndClearConsole();
                            continue;
                        }

                        string jsonData = GetJsonFromFile(inputPath);
                        if (jsonData == null)
                        {
                            WaitForUserAndClearConsole();
                            continue;
                        }

                        List<TestExecution> testExecutions = GetTestExecutionsFromJson(jsonData);
                        AnalysisResult analysisResult = AnalyzeTestExecutions(testExecutions);
                        PrintAnalysisResults(analysisResult);

                        break;
                    }
                    case MenuOptions.ExportJsonFromConsoleToCsvFile:
                    {
                            string jsonData = GetJsonFromUserInput();
                            if (jsonData == null)
                            {
                                WaitForUserAndClearConsole();
                                continue;
                            }

                            string outputPath = GetFilePathFromUser(false);
                            if (outputPath == null)
                            {
                                WaitForUserAndClearConsole();
                                continue;
                            }

                            List<TestExecution> testExecutions = GetTestExecutionsFromJson(jsonData);
                            string csvContent = TestExecutionsToCsv(testExecutions);
                            WriteCsvFile(outputPath, csvContent);

                            break;
                    }
                    case MenuOptions.ExportJsonFromFileToCsvFile:
                    {
                            string inputPath = GetFilePathFromUser(true);
                            string outputPath = GetFilePathFromUser(false);

                            if (inputPath == null || outputPath == null)
                            {
                                WaitForUserAndClearConsole();
                                continue;
                            }

                            string jsonData = GetJsonFromFile(inputPath);
                            if (jsonData == null)
                            {
                                WaitForUserAndClearConsole();
                                continue;
                            }

                            List<TestExecution> testExecutions = GetTestExecutionsFromJson(jsonData);
                            string csvContent = TestExecutionsToCsv(testExecutions);
                            WriteCsvFile(outputPath, csvContent);

                            break;
                    }
                    default:
                    {
                        WaitForUserAndClearConsole();
                        continue;
                    }
                }
            }
        }

        private static string TestExecutionsToCsv(List<TestExecution> testExecutions)
        {
            DataConverter dataConverter = new();

            return dataConverter.TestExecutionsToCsv(testExecutions);
        }

        private static void WriteCsvFile(string filePath, string content)
        {
            FileUtils fileUtils = new();

            fileUtils.WriteFile(filePath, content);
        }

        private static string GetJsonFromFile(string path)
        {
            FileUtils fileUtils = new();

            return fileUtils.ReadFile(path);
        }

        private static void PrintAnalysisResults(AnalysisResult analysisResult)
        {
            DataPrinter dataPrinter = new();

            dataPrinter.PrintResultsAnalysis(analysisResult);
        }

        private static List<TestExecution> GetTestExecutionsFromJson(string jsonData)
        {
            DataConverter converter = new();

            return converter.JsonToObject<List<TestExecution>>(jsonData);
        }

        static string GetJsonFromUserInput()
        {
            Console.WriteLine("Enter the json data");
            StringBuilder sb = new();

            string line;
            while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
            {
                sb.AppendLine(line);
            }

            return sb.ToString();
        }

        static string GetFilePathFromUser(bool fileShouldExist = false)
        {
            Console.WriteLine($"Enter the full path for file to {(fileShouldExist ? "read" : "write")} (with extension):");
            var path = Console.ReadLine();

            FileUtils fileUtils = new();
            if (!fileUtils.IsPathValid(path, fileShouldExist))
            {
                Console.WriteLine($"The specified path is not valid or file doesn't exists, press any key and try again");
                return null;
            }

            return path;
        }

        static void WaitForUserAndClearConsole()
        {
            Console.ReadKey();
            Console.Clear();
        }

        static int GetUserSelection()
        {
            Console.WriteLine("Type the number of the option you want to execute, then press enter");

            PrintMenuOptions();

            string input = Console.ReadLine();
            int parsedOption = ParseUserSelection(input);

            return parsedOption;
        }

        static int ParseUserSelection(string option)
        {
            bool optionIsNumber = int.TryParse(option, out int numericOption);
            if (!optionIsNumber)
            {
                Console.WriteLine("Only numeric values are allowed, press any key and try again");
                return 0;
            }

            if (!Enum.IsDefined(typeof(MenuOptions), numericOption))
            {
                Console.WriteLine("The option you selected is not available, press any key and try again");
                return 0;
            }

            return numericOption;
        }

        static void PrintMenuOptions()
        {
            var array = (MenuOptions[]) Enum.GetValues(typeof(MenuOptions));
            var options = string.Join(Environment.NewLine, array.Select(x => $"{(int) x} => { DivideCapitalWords(x.ToString()) }"));
            Console.WriteLine(options);
        }

        static string DivideCapitalWords(string text)
        {
            return string.Join("", text.Select((x, i) => char.IsUpper(x) && i != 0 ? $" {x}" : x.ToString()));
        }

        private static List<TestExecution> GenerateDemoData(int testExecutions = 1, int testSuites = 1, int testCases = 1)
        {
            DemoGenerator demoGenerator = new();

            return demoGenerator.GenerateTestExecutions(testExecutions, testSuites, testCases);
        }

        private static void GenerateDemoToJsonFile(string filePath, int testExecutions = 1, int testSuites = 1, int testCases = 1)
        {
            DataConverter dataConverter = new();
            List<TestExecution> results = GenerateDemoData(testExecutions, testSuites, testCases);
            string jsonData = dataConverter.ObjectToJson(results);

            using StreamWriter streamWriter = new(filePath);
            streamWriter.Write(jsonData);
        }

        private static void GenerateDemoToCsvFile(string filePath, int testExecutions = 1, int testSuites = 1, int testCases = 1)
        {
            DataConverter dataConverter = new();
            List<TestExecution> results = GenerateDemoData(testExecutions, testSuites, testCases);
            string csvData = dataConverter.TestExecutionsToCsv(results);

            using StreamWriter streamWriter = new(filePath);
            streamWriter.Write(csvData);
        }

        private static AnalysisResult AnalyzeTestExecutions(List<TestExecution> testExecutions)
        {
            ResultsAnalyzer resultsAnalyzer = new();
            AnalysisResult analysisResult = new();

            if (testExecutions != null)
            {
                analysisResult = resultsAnalyzer.AnalyzeTestExecutions(testExecutions);
            }

            return analysisResult;
        }
    }
}