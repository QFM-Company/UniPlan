namespace Client.Models.Responses
{
    public class CoursePrerequisiteResponse : Person
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

        public CoursePrerequisiteResponse()
        {

        }
    }
}
