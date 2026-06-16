using Core.Enums;

namespace Core.Entities
{
    public class Lecture
    {
        public int LectureID { get; set; }
        public LectureType LectureType { get; set; }
        public int DurationValue { get; set; }
        public Course? Course { get; set; }

        public Lecture()
        {
            LectureID = default;
            LectureType = LectureType.Practical;
            DurationValue = default;
            Course = null;
        }

        public Lecture(int lectureID, LectureType lectureType, int durationValue, Course course)
        {
            LectureID = lectureID;
            LectureType = lectureType;
            DurationValue = durationValue;
            Course = course;
        }

        public Lecture(int lectureID, LectureType lectureType, int durationValue)
        {
            LectureID = lectureID;
            LectureType = lectureType;
            DurationValue = durationValue;
        }
    }
}
