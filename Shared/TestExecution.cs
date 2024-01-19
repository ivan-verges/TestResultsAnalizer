using System.Text.Json.Serialization;

namespace TestResultsAnalyzer.Shared
{
    public class TestExecution
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("TestSuites")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public List<TestSuite> TestSuites { get; set; }
    }
}