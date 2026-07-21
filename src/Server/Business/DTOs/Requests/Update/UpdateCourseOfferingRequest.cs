using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests.Update
{
    public class UpdateCourseOfferingRequest
    {

        [Required<int>("رقم القسم مطلوب")]
        [Range<int>("يجب أن يكون رقم القسم أكبر من 0", 1, int.MaxValue)]
        public int SectionNumber { get; set; }

        [Required<int>("معرف الفصل الأكاديمي مطلوب")]
        [Range<int>("يجب أن يكون المعرف أكبر من 0", 1, int.MaxValue)]
        public int TermID { get; set; }

        [Required<int>("معرف المحاضرة مطلوب")]
        [Range<int>("يجب أن يكون المعرف أكبر من 0", 1, int.MaxValue)]
        public int LectureID { get; set; }

        [Required<int>("معرف الكورس مطلوب")]
        [Range<int>("يجب أن يكون المعرف أكبر من 0", 1, int.MaxValue)]
        public int CourseID { get; set; }

    }
}