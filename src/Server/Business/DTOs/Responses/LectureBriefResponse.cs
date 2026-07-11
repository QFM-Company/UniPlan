namespace Business.DTOs.Responses
{
    public class LectureBriefResponse
    {
        public int LectureID { get; set; }

        public string? LectureType { get; set; }

        public CourseBriefResponse? CourseInfo { get; set; }

        public LectureBriefResponse(int lectureID, string? lectureType, CourseBriefResponse? courseInfo)
        {
            LectureID = lectureID;
            LectureType = lectureType;
            CourseInfo = courseInfo;
        }
    }
}
