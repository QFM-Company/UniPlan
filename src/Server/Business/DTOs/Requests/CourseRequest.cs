using Core.Entities;

namespace Business.DTOs.Requests
{
    public class CourseRequest
    {
        public string? CourseName { get; set; }
        public int CreditHours { get; set; }
        public Major Major { get; set; }

        public CourseRequest(string? courseName, int creditHours, Major major)
        {
            CourseName = courseName;
            CreditHours = creditHours;
            Major = major;
        }
    }
}
