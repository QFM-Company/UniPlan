namespace Business.DTOs.Responses
{
    public class CourseOfferingResponse
    {
        public int OfferingID { get; set; }
        public int SectionNumber { get; set; }
        public int CreatedByAdminID { get; set; }
        public AcademicTermResponse TermInfo { get; set; }
        public LectureResponse LectureInfo { get; set; }

        public CourseOfferingResponse()
        {
            OfferingID = default;
            SectionNumber = default;
            CreatedByAdminID = default;
            TermInfo = new AcademicTermResponse();
            LectureInfo = new LectureResponse();
        }

        public CourseOfferingResponse(int offeringID, int sectionNumber, int createdByAdminID, AcademicTermResponse termInfo, LectureResponse lectureInfo)
        {
            OfferingID = offeringID;
            SectionNumber = sectionNumber;
            CreatedByAdminID = createdByAdminID;
            TermInfo = termInfo;
            LectureInfo = lectureInfo;
        }
    }
}
