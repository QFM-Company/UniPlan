namespace Client.Models.Responses
{
    public class CoursePrerequisiteResponse : BaseModel
    {
        public int PreRequestID { get; set; }

        public CourseResponse? MainCourseInfo { get; set; }

        public CourseResponse? PreRequestCourseInfo { get; set; }

        public CoursePrerequisiteResponse(int preRequestID, CourseResponse? course, CourseResponse? preRequestCourse)
        {
            PreRequestID = preRequestID;
            MainCourseInfo = course;
            PreRequestCourseInfo = preRequestCourse;
        }
    }
}
