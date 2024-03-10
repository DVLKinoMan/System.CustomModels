namespace System.CustomModels.Filters
{
    public class DatetimePattern<T>(string propPath, string? displayName = null)
        : Filter<T>(propPath, displayName) where T : class
    {
        public int? Year { get; set; }
        public int? Month { get; set; }
        public int? Day { get; set; }

        public override FilterType FilterType => FilterType.DatetimePattern;

        public override void Accept(ISelectVisitor<T> visitor) => visitor.Accept(this);

        public override bool IsValid => Day != null || Year != null || Month != null;

        public override void Reset()
        {
            Day = null;
            Year = null;
            Month = null;
        }

        public override string ToString() =>
            $"{(Year != null ? $"Year: {Year}" : "") +
            (Month != null ? $"Month: {Month}" : "") +
                (Day != null ? $"Day: {Day}" : "")}"
            + (FilterOperator == FilterOperator.None ? "" : " " + FilterOperator.ToString());

        public override Filter<T> Clone() => 
            new DatetimePattern<T>(PropertyPath, DisplayName) {
                Day = Day, 
                Year = Year, 
                Month = Month, 
                FilterOperator = FilterOperator
            };
    }
}
