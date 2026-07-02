using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests.Update
{
    public class UpdateStudentCourseRequest
    {
        [Required<bool>("هل تم ترفيع المادة")]
        public bool IsPassed { get; set; }

        public UpdateStudentCourseRequest(bool isPassed)
        {
            IsPassed = isPassed;
        }

    }
}
