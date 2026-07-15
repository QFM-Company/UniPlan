namespace Core.Entities
{
    public class TimeSlot
    {
        public int SlotID { get; set; }

        public DayOfWeek Day { get; set; }

        public Period? Period { get; set; }

        public TimeSlot(int slotID, DayOfWeek day, Period? period)
        {
            SlotID = slotID;
            Day = day;
            Period = period;
        }

        public TimeSlot()
        {
            SlotID = -1;
            Day = DayOfWeek.Friday;
            Period = null;
        }
    }
}
