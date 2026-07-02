namespace Core.Entities
{
    public class StudentCourse
    {
        public int EnrolmentID { get; set; }

        public bool IsPassed { get; set; }

        public int StudentID { get; set; }

        public Course? Course { get; set; }


        public StudentCourse()
        {
            EnrolmentID = -1;
            StudentID = -1;
            Course = null;
            IsPassed = false;
        }

        public StudentCourse(int enrolmentID, bool isPassed, int studentID, Course course)
        {
            EnrolmentID = enrolmentID;
            IsPassed = isPassed;
            StudentID = studentID;
            Course = course;
        }
    }
}
