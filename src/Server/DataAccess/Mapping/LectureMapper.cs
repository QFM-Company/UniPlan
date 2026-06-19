using Core.Entities;
using Core.Enums;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class LectureMapper
    {
        public static Lecture ToLecture(this SqlDataReader reader)
        {
            Course course = reader.ToCourse();

            int.TryParse(reader["LectureID"]?.ToString(), out int lectureID);
            int.TryParse(reader["DurationValue"]?.ToString(), out int durationValue);
            int.TryParse(reader["LectureType"]?.ToString(), out int lectureType);

            return new Lecture(lectureID, (LectureType)lectureType, durationValue, course);
        }
    }
}
