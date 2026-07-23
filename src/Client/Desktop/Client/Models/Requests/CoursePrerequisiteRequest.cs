using Infrastructure.ExternalServices.Validation.Attributes;

namespace Client.Models.Requests
{
    public class CoursePrerequisiteRequest : Person
    {
        [Required<int>("معرف الكورس مطلوب")]
        [Range<int>("يجب ان يكون المعرف اكبر تماما من 0", 1, int.MaxValue)]
        public int CourseID { get; set; }

        [Required<int>("معرف الكورس مطلوب")]
        [Range<int>("يجب ان يكون المعرف اكبر تماما من 0", 1, int.MaxValue)]
        public int PreRequestCourseID { get; set; }

        public CoursePrerequisiteRequest(int courseID, int preRequestCourseID)
        {
            CourseID = courseID;
            PreRequestCourseID = preRequestCourseID;
        }
    }
}

