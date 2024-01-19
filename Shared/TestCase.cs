using System.Text.Json.Serialization;

namespace TestResultsAnalyzer.Shared
{
    public class TestCase
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("StartTime")]
        public DateTime StartTime { get; set; }
        [JsonPropertyName("EndTime")]
        public DateTime EndTime { get; set; }
        [JsonPropertyName("Result")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TestResult Result { get; set; }
    }
}