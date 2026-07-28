namespace Core.Entities
{
    public class Course
    {
        public int CourseID { get; set; }
        public string? CourseName { get; set; }
        public int CreditHours { get; set; }
        public string? CourseCode { get; set; }
        public int NeededHours { get; set; }    


        public Course(int courseID, string? courseName, int creditHours, string? courseCode , int neededHours)
        {
            CourseID = courseID;
            CourseName = courseName;
            CreditHours = creditHours;
            CourseCode = courseCode;
            NeededHours = neededHours;
        }

        public Course(int courseID)
        {
            CourseID = courseID;
        }

        public Course() { }

        public override string ToString()
        {
            return string.Format("{0}", CourseName);
        }
    }
}
