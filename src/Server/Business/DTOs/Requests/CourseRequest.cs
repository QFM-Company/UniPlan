using Business.DTOs.Responses;
using Core.Entities;
using Core.Interfaces.ExternalServices;

namespace Business.DTOs.Requests
{
    public class CourseRequest
    {
        public string? CourseName { get; set; }
        public int CreditHours { get; set; }
        public int MajorID { get; set; }

        public CourseRequest(IValidationService validationService , string? courseName, int creditHours, int majorID)
        {
            CourseName = courseName;
            CreditHours = creditHours;
            MajorID = majorID;
        }
    }
}
