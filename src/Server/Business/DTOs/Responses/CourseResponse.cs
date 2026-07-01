
using Core.Entities;

namespace Business.DTOs.Responses
{
    public class CourseResponse
    {

        public int CourseID { get; set; }
        public string? CourseName { get; set; }
        public int CreditHours {  get; set; }

        public CourseResponse(int courseID, string? courseName, int creditHours)
        {
            CourseID = courseID;
            CourseName = courseName;
            CreditHours = creditHours;
        }
    }
}
