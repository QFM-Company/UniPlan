namespace Business.DTOs.Responses
{
    public class CoursePrerequisiteResponse
    {
        public int PreRequestID { get; set; }

        public CourseResponse? MainCourseInfo { get; set; }

        public CourseResponse? PreRequestCourseInfo { get; set; }

        public CoursePrerequisiteResponse(int preRequestID, CourseResponse? mainCourseInfo, CourseResponse? preRequestCourse)
        {
            PreRequestID = preRequestID;
            MainCourseInfo = mainCourseInfo;
            PreRequestCourseInfo = preRequestCourse;
        }
    }
}
