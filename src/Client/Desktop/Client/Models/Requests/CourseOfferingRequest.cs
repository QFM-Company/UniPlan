using Infrastructure.ExternalServices.Validation.Attributes;

namespace Client.Models.Requests
{
    public class CourseOfferingRequest : BaseModel
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

        [Required<int>("معرف الأدمن المنشئ مطلوب")]
        [Range<int>("يجب أن يكون المعرف أكبر من 0", 1, int.MaxValue)]
        public int CreatedByAdminID { get; set; }

        [Required<int>("معرف الكورس مطلوب")]
        [Range<int>("يجب أن يكون المعرف أكبر من 0", 1, int.MaxValue)]
        public int CourseID { get; set; }

        public CourseOfferingRequest()
        {
            CreatedByAdminID = default;
            SectionNumber = default;
            TermID = default;
            LectureID = default;
            CourseID = default;
        }

        public CourseOfferingRequest(int sectionNumber, int termID, int lectureID, int createdByAdminID, int courseID)
        {
            SectionNumber = sectionNumber;
            TermID = termID;
            LectureID = lectureID;
            CreatedByAdminID = createdByAdminID;
            CourseID = courseID;
        }
    }
}