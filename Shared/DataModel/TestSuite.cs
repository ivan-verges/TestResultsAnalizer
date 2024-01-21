using System.Text.Json.Serialization;

namespace TestResultsAnalyzer.Shared.DataModel
{
    public class TestSuite
    {
        [JsonPropertyName("Id")]
        public required int Id { get; set; }
        [JsonPropertyName("Name")]
        public required string Name { get; set; }
        [JsonPropertyName("TestCases")]
        public List<TestCase> TestCases { get; set; } = new List<TestCase>();
    }
}