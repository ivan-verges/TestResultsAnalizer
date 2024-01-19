using System.Text.Json.Serialization;

namespace TestResultsAnalyzer.Shared
{
    public class TestSuite
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("TestCases")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public List<TestCase> TestCases { get; set; }
    }
}