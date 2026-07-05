using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests.Update
{
    public class UpdateCourseSessionRequest
    {

        [Required<int>("معرف الكورس مطلوب")]
        [Range<int>("يجب ان يكون المعرف اكبر تماما من 0", 1, int.MaxValue)]
        public int CourseOfferingID { get; set; }

        [Required<int>("معرف القاعة مطلوب")]
        [Range<int>("يجب ان يكون المعرف اكبر تماما من 0", 1, int.MaxValue)]
        public int HallID { get; set; }

        [Required<PersonRequest>("بيانات الفترة الزمنية مطلوبة")]
        public PeriodRequest PeriodData { get; set; }

        public UpdateCourseSessionRequest(int courseOfferingID, int hallID, PeriodRequest periodData)
        {
            CourseOfferingID = courseOfferingID;
            HallID = hallID;
            PeriodData = periodData;
        }
    }
}
