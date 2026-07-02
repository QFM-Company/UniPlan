namespace Core.Entities
{
    public class CoursePrerequisites
    {
        public int PreRequestID { get; set; }

        public Course? Course { get; set; }

        public Course? PreRequestCourse { get; set; }



        public CoursePrerequisites() { }

        public CoursePrerequisites(int preRequestID, Course? course, Course? preRequestCourse)
        {
            PreRequestID = preRequestID;
            Course = course;
            PreRequestCourse = preRequestCourse;
        }
    }
}
