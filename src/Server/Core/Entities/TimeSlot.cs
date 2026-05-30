using Core.Entities;

public class TimeSlot
{
    public int SlotID { get; set; }
    public string SlotName { get; set; } = string.Empty;
    public Period Period { get; set; } = new Period();

    public TimeSlot(int slotID, string slotName, Period period)
    {
        SlotID = slotID;
        SlotName = slotName;
        Period = period;
    }

    public TimeSlot() { }
}