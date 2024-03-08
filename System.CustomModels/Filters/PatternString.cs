﻿namespace System.CustomModels.Filters
{
    public class PatternString<T>(string? value = null, string? pattern = null) : Filter<T> where T : class
    {
        public string? Value { get; set; } = value;
        public string? Pattern { get; set; } = pattern;

        public override void Accept(ISelectVisitor<T> visitor) => visitor.Accept(this);
    }
}
