namespace System.CustomModels.Filters
{
    public class PatternString(string value, string pattern)
    {
        public string Value { get; set; } = value;
        public string Pattern { get; set; } = pattern;
    }
}
