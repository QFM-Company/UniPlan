using Infrastructure.ExternalServices.Validation.Attributes;


namespace Business.DTOs.Requests
{
    public class TimeSlotRequest
    {
        [Required<DayOfWeek>("تحديد اليوم مطلوب")]
        public DayOfWeek Day { get; set; }
        [Required<int>("معرف الفترة مطلوب")]
        [Range<int>("يجب ان يكون المعرف اكبر تماما من 0", 1, int.MaxValue)]
        public int PeriodID { get; set; }

        public TimeSlotRequest(DayOfWeek day, int periodID)
        {
            Day = day;
            PeriodID = periodID;
        }
    }
}
