namespace Core.Entities
{
    public class TimeSlot
    {
        public int SlotID { get; set; }

        public DayOfWeek Day { get; set; } = DayOfWeek.Tuesday;

        public Period? Period { get; set; }

        public TimeSlot(int slotID, DayOfWeek day, Period? period)
        {
            SlotID = slotID;
            Day = day;
            Period = period;
        }
    }
}
