using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests.Update
{
    public class UpdateCourseSessionRequest
    {

        [Required<int>("معرف القاعة مطلوب")]
        [Range<int>("يجب ان يكون المعرف اكبر تماما من 0", 1, int.MaxValue)]
        public int HallID { get; set; }

        [Required<PeriodRequest>("بيانات الفترة الزمنية مطلوبة")]
        public PeriodRequest? PeriodData { get; set; }

        [Required<int>("تحديد اليوم مطلوب")]
        [Range<int>("اليوم يجب ان يكون من 0 الى 6", 0, 6)]
        public int Day { get; set; }

    }
}
