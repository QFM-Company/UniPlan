using Core.Enums;

namespace UniPlan.Business.DTOs.Requests
{
    public class LectureRequest
    {
        public LectureType LectureType { get; set; }
        public int DurationValue { get; set; }
        public int CourseID { get; set; }

        public LectureRequest()
        {
            LectureType = LectureType.Practical;
            DurationValue = default;
            CourseID = default;
        }

        public LectureRequest(LectureType lectureType, int durationValue, int courseID)
        {
            LectureType = lectureType;
            DurationValue = durationValue;
            CourseID = courseID;
        }
    }
}
