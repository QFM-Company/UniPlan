namespace Business.DTOs.Responses
{
    public class CourseResponse
    {
        public int CourseID { get; set; }
        public string? CourseName { get; set; }
        public int CreditHours { get; set; }
        public string? CourseCode { get; set; }
        public int NeededHours { get; set; }


        public CourseResponse(int courseID, string? courseName, int creditHours, string? courseCode , int neededHours)
        {
            CourseID = courseID;
            CourseName = courseName;
            CreditHours = creditHours;
            CourseCode = courseCode;
            NeededHours = neededHours;
        }
    }
}
