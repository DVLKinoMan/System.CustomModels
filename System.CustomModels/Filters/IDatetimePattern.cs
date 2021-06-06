namespace System.CustomModels.Filters
{
    public interface IDatetimePattern
    {
        int? Year { get; set; }
        int? Month { get; set; }
        int? Day { get; set; }
    }
}
