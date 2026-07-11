namespace Business.DTOs.Responses
{
    public class CourseOfferingBriefResponse
    {
        public int OfferingID { get; set; }

        public int SectionNumber { get; set; }

        public LectureBriefResponse? LectureInfo { get; set; }

        public CourseOfferingBriefResponse(int offeringID, int sectionNumber, LectureBriefResponse? lectureInfo)
        {
            OfferingID = offeringID;
            SectionNumber = sectionNumber;
            LectureInfo = lectureInfo;
        }
    }
}
