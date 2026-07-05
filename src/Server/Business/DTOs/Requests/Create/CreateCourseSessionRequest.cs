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

        [Required<PersonRequest>("بيانات الفترة الزمنية مطلوبة")]
        public PeriodRequest PeriodData { get; set; }

        [Required<int>("معرف الادمن مطلوب")]
        [Range<int>("يجب ان يكون المعرف اكبر تماما من 0", 1, int.MaxValue)]
        public int CreatedByAdminID { get; set; }

        [Required<DayOfWeek>("تحديد اليوم مطلوب")]
        public DayOfWeek Day { get; set; }

        public CreateCourseSessionRequest(int courseOfferingID, int hallID, PeriodRequest periodData, int createdByAdminID, DayOfWeek day)
        {
            CourseOfferingID = courseOfferingID;
            HallID = hallID;
            PeriodData = periodData;
            CreatedByAdminID = createdByAdminID;
            Day = day;
        }
    }
}
