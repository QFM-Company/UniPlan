using Core.Enums;

namespace Business.DTOs.Responses
{
    public class LectureResponse
    {
        public int LectureID { get; set; }
        public LectureType LectureType { get; set; }
        public int DurationValue { get; set; }
        public CourseResponse? CourseInfo { get; set; }

        public LectureResponse()
        {
            LectureID = default;
            LectureType = LectureType.Practical;
            DurationValue = default;
            CourseInfo = null;
        }

        public LectureResponse(int lectureID, LectureType lectureType, int durationValue, CourseResponse courseInfo)
        {
            LectureID = lectureID;
            LectureType = lectureType;
            DurationValue = durationValue;
            CourseInfo = courseInfo;
        }
    }
}
