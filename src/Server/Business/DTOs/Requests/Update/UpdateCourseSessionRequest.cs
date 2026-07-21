using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests.Update
{
    public class UpdateCourseSessionRequest
    {

        [Required<int>("معرف القاعة مطلوب")]
        [Range<int>("يجب ان يكون المعرف اكبر تماما من 0", 1, int.MaxValue)]
        public int HallID { get; set; }

        [Required<PersonRequest>("بيانات الفترة الزمنية مطلوبة")]
        public PeriodRequest? PeriodData { get; set; }

        [Required<DayOfWeek>("تحديد اليوم مطلوب")]
        public DayOfWeek Day { get; set; }

    }
}
