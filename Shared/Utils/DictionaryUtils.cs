namespace TestResultsAnalyzer.Shared.Utils
{
    public class DictionaryUtils
    {
        public void AddOrUpdateDictionary(Dictionary<string, float> dictionary, string key, float newValue, bool replace = false)
        {
            if (dictionary.TryGetValue(key, out float val))
            {
                dictionary[key] = newValue + ((replace) ? 0 : val);
            }
            else
            {
                dictionary.Add(key, newValue);
            }
        }

        public void AddOrUpdateDictionary(Dictionary<string, int> dictionary, string key, int newValue, bool replace = false)
        {
            if (dictionary.TryGetValue(key, out int val))
            {
                dictionary[key] = newValue + ((replace) ? 0 : val);
            }
            else
            {
                dictionary.Add(key, newValue);
            }
        }

        public void AddOrUpdateDictionary(Dictionary<string, long> dictionary, string key, long newValue, bool replace = false)
        {
            if (dictionary.TryGetValue(key, out long val))
            {
                dictionary[key] = newValue + ((replace) ? 0 : val);
            }
            else
            {
                dictionary.Add(key, newValue);
            }
        }
    }
}