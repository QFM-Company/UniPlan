using Core.Entities;
using Core.Enums;
using DataAccess.Extensions;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class LectureMapper
    {
        public static Lecture ToLecture(this SqlDataReader reader)
        {
            Course course = reader.ToCourse();

            reader.ReadInt("LectureID", out int lectureID, 0);
            reader.ReadInt("DurationValue", out int durationValue, 0);
            reader.ReadInt("LectureType", out int lectureType, 0);

            return new Lecture(lectureID, (LectureType)lectureType, durationValue, course);
        }

        public static Lecture ToLectureBasicInfo(this SqlDataReader reader)
        {
            reader.ReadInt("LectureID", out int lectureID, 0);
            reader.ReadInt("LectureType", out int lectureType, 0);

            Lecture lecture = new Lecture();

            (lecture.LectureID, lecture.LectureType) = (lectureID, (LectureType)lectureType);
            return lecture;
        }
    }
}
