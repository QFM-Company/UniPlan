using Core.Entities;

public class Period
{
    public int PeriodID { get; set; }
    public string PeriodName { get; set; } = string.Empty;
    public Major Major { get; set; } = new Major();

    public Period(int periodID, string periodName, Major major)
    {
        PeriodID = periodID;
        PeriodName = periodName;
        Major = major;
    }

    public Period() { }
}