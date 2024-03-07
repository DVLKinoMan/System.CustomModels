namespace System.CustomModels.Filters
{
    public class DatetimePattern : Filter
    {
        public int? Year { get; set; }
        public int? Month { get; set; }
        public int? Day { get; set; }

        public override void Accept(ISelectVisitor visitor) => visitor.Accept(this);
    }
}
