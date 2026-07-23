namespace Client.Models.Responses
{
    public class LectureResponse : Person
    {
        public int LectureID { get; set; }

        public string LectureType { get; set; }

        public int DurationValue { get; set; }

        public CourseResponse? CourseInfo { get; set; }

        public LectureResponse()
        {
            LectureID = default;
            LectureType = string.Empty;
            DurationValue = default;
            CourseInfo = null;
        }

        public LectureResponse(int lectureID, string lectureType, int durationValue, CourseResponse? courseInfo)
        {
            LectureID = lectureID;
            LectureType = lectureType;
            DurationValue = durationValue;
            CourseInfo = courseInfo;
        }
    }
}
