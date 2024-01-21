using System.Text.Json.Serialization;

namespace TestResultsAnalyzer.Shared.DataModel
{
    public class TestCase
    {
        [JsonPropertyName("Id")]
        public required int Id { get; set; }
        [JsonPropertyName("Name")]
        public required string Name { get; set; }
        [JsonPropertyName("StartTime")]
        public DateTime StartTime { get; set; }
        [JsonPropertyName("EndTime")]
        public DateTime EndTime { get; set; }
        [JsonIgnore]
        public long DurationMS
        {
            get
            {
                return (EndTime - StartTime).Milliseconds;
            }
        }
        [JsonPropertyName("Result")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TestResult Result { get; set; }
    }
}