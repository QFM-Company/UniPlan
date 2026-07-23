using Infrastructure.ExternalServices.Validation.Attributes;

namespace Client.Models.Requests
{
    public class CourseSessionRequest : Person
    {


        [Required<int>("معرف الكورس مطلوب")]
        [Range<int>("يجب ان يكون المعرف اكبر تماما من 0", 1, int.MaxValue)]
        public int CourseOfferingID { get; set; }


        [Required<int>("معرف القاعة مطلوب")]
        [Range<int>("يجب ان يكون المعرف اكبر تماما من 0", 1, int.MaxValue)]
        public int HallID { get; set; }

        [Required<PeriodRequest>("بيانات الفترة الزمنية مطلوبة")]
        public PeriodRequest PeriodData { get; set; }

        [Required<int>("معرف الادمن مطلوب")]
        [Range<int>("يجب ان يكون المعرف اكبر تماما من 0", 1, int.MaxValue)]
        public int CreatedByAdminID { get; set; }

        [Required<int>("تحديد اليوم مطلوب")]
        public int Day { get; set; }

        public CourseSessionRequest(int courseOfferingID, int hallID, PeriodRequest periodData, int createdByAdminID, int day)
        {
            CourseOfferingID = courseOfferingID;
            HallID = hallID;
            PeriodData = periodData;
            CreatedByAdminID = createdByAdminID;
            Day = day;
        }
    }
}
