using System.Text.Json;

namespace TestResultsAnalyzer.Shared.Utils
{
    public class FileUtils
    {
        public string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }

        public bool IsPathValid(string path, bool fileShouldExists = false)
        {
            return Path.Exists(path) && (fileShouldExists)? File.Exists(path) : true;
        }

        public bool IsJsonValid(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return false;
            }

            try
            {
                JsonDocument.Parse(json);
                return true;
            }
            catch (JsonException)
            {
                return false;
            }
        }

        public void WriteFile(string path, string content)
        {
            using StreamWriter streamWriter = new(path);
            streamWriter.Write(content);
        }
    }
}