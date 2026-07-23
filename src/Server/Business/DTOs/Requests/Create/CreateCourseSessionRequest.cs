using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests.Create
{
    public class CreateCourseSessionRequest
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
        [Range<int>("اليوم يجب ان يكون من 0 الى 6", 0, 6)]
        public int Day { get; set; }

        public CreateCourseSessionRequest(int courseOfferingID, int hallID, PeriodRequest periodData, int createdByAdminID, int day)
        {
            CourseOfferingID = courseOfferingID;
            HallID = hallID;
            PeriodData = periodData;
            CreatedByAdminID = createdByAdminID;
            Day = day;
        }
    }
}
