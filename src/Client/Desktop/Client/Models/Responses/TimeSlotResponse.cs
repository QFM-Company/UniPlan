namespace Client.Models.Responses
{
    public class TimeSlotResponse : BaseModel
    {
        public int SlotID { get; set; }

        public DayOfWeek Day { get; set; }

        public PeriodResponse? Period { get; set; }

        public TimeSlotResponse(int slotID, DayOfWeek day, PeriodResponse? period)
        {
            SlotID = slotID;
            Day = day;
            Period = period;
        }
    }
}
