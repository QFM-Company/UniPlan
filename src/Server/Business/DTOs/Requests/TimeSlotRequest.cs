using Infrastructure.ExternalServices.Validation.Attributes;


namespace Business.DTOs.Requests
{
    public class TimeSlotRequest
    {
        [Required<int>("تحديد اليوم مطلوب")]
        [Range<int>("اليوم يجب ان يكون من 0 الى 6" ,0, 6)]
        public int Day { get; set; }

        [Required<int>("معرف الفترة مطلوب")]
        [Range<int>("يجب ان يكون المعرف اكبر تماما من 0", 1, int.MaxValue)]
        public int PeriodID { get; set; }

        public TimeSlotRequest(int day, int periodID)
        {
            Day = day;
            PeriodID = periodID;
        }
    }
}
