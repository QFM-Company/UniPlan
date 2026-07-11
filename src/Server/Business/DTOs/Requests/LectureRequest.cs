using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests
{
    public class LectureRequest
    {
        [Required<int>("نوع المحاضرة مطلوبة")]
        [AllowedValues("يجب أن تكون قيمة نوع المحاضرة 1 (النظري) أو 2 (العملي) أو 3 (TD) فقط", new object[] { 1, 2, 3 })]
        public int LectureType { get; set; }

        [Required<int>("مدة المحاضرة مطلوبة")]
        [Range<int>("يجب أن تكون المدة أكبر من 0", 1, int.MaxValue)]
        public int DurationValue { get; set; }

        [Required<int>("معرف الكورس مطلوب")]
        [Range<int>("يجب أن يكون المعرف أكبر من 0", 1, int.MaxValue)]
        public int CourseID { get; set; }

        public LectureRequest(int lectureType, int durationValue, int courseID)
        {
            LectureType = lectureType;
            DurationValue = durationValue;
            CourseID = courseID;
        }
    }
}