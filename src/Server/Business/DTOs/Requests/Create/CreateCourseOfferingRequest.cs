namespace Business.DTOs.Requests.Create
{
    public class CreateCourseOfferingRequest
    {
        public int SectionNumber { get; set; }
        public int TermID { get; set; }
        public int LectureID { get; set; }
        public int CreatedByAdminID { get; set; }
        public int CourseID { get; set; }

        public CreateCourseOfferingRequest()
        {
            CreatedByAdminID = default;
            SectionNumber = default;
            TermID = default;
            LectureID = default;
            CourseID = default;
        }

        public CreateCourseOfferingRequest(int sectionNumber, int termID, int lectureID, int createdByAdminID, int courseID)
        {
            SectionNumber = sectionNumber;
            TermID = termID;
            LectureID = lectureID;
            CreatedByAdminID = createdByAdminID;
            CourseID = courseID;
        }
    }
}
