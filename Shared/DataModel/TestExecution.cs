using System.Text.Json.Serialization;

namespace TestResultsAnalyzer.Shared.DataModel
{
    public class TestExecution
    {
        [JsonPropertyName("Id")]
        public required int Id { get; set; }
        [JsonPropertyName("Name")]
        public required string Name { get; set; }
        [JsonPropertyName("TestSuites")]
        public List<TestSuite> TestSuites { get; set; } = new List<TestSuite>();
    }
}