using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests.Create
{
    public class CreateStudentCourseRequest
    {

        [Required<int>("معرف الكورس مطلوب")]
        [Range<int>("يجب ان يكون المعرف اكبر تماما من 0", 1, int.MaxValue)]
        public int CourseID { get; set; }

        [Required<bool>("هل تم ترفيع المادة")]
        public bool IsPassed { get; set; }

        [Required<int>("معرف الطالب مطلوب")]
        [Range<int>("يجب ان يكون المعرف اكبر تماما من 0", 1, int.MaxValue)]
        public int StudentID { get; set; }


        public CreateStudentCourseRequest(int enrolmentID, bool isPassed, int studentID)
        {
            CourseID = enrolmentID;
            IsPassed = isPassed;
            StudentID = studentID;
        }

    }
}
