namespace Client.Models.Responses
{
    public class TimeSlotResponse : Person
    {
        public int SlotID { get; set; }

        public string Day { get; set; }

        public PeriodResponse? Period { get; set; }

        public TimeSlotResponse(int slotID, string day, PeriodResponse? period)
        {
            SlotID = slotID;
            Day = day;
            Period = period;
        }
    }
}
