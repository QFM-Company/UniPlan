namespace Business.DTOs.Responses
{
    public class CourseBriefResponse
    {
        public int CourseID { get; set; }

        public string? CourseName { get; set; }

        public string? CourseCode { get; set; }

        public CourseBriefResponse(int courseID, string? courseName, string? courseCode)
        {
            CourseID = courseID;
            CourseName = courseName;
            CourseCode = courseCode;
        }
    }
}
