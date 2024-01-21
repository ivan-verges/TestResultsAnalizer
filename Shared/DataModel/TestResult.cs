using System.ComponentModel;
using System.Runtime.Serialization;

namespace TestResultsAnalyzer.Shared.DataModel
{
    [DefaultValue(Pending)]
    public enum TestResult
    {
        [Description("Failed")]
        [EnumMember(Value = "Failed")]
        Failed = 0,
        [Description("Passed")]
        [EnumMember(Value = "Passed")]
        Passed = 1,
        [Description("Pending")]
        [EnumMember(Value = "Pending")]
        Pending = 2,
        [Description("Skipped")]
        [EnumMember(Value = "Skipped")]
        Skipped = 3
    }
}