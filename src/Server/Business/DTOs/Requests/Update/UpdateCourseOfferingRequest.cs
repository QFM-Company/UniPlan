namespace Business.DTOs.Requests.Update
{
    public class UpdateCourseOfferingRequest
    {
        public int OfferingID { get; set; }
        public int SectionNumber { get; set; }
        public int TermID { get; set; }
        public int LectureID { get; set; }
        public int CourseID { get; set; }

        public UpdateCourseOfferingRequest()
        {
            OfferingID = default;
            SectionNumber = default;
            TermID = default;
            LectureID = default;
            CourseID = default;
        }

        public UpdateCourseOfferingRequest(int offeringID, int sectionNumber, int termID, int lectureID, int courseID)
        {
            OfferingID = offeringID;
            SectionNumber = sectionNumber;
            TermID = termID;
            LectureID = lectureID;
            CourseID = courseID;
        }
    }
}
