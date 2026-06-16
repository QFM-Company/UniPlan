using Core.Entities;
using Core.Enums;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class LectureMapper
    {
        public static Lecture ToLecture(this SqlDataReader reader)
        {
            int.TryParse(reader["CourseID"]?.ToString(), out int courseID);
            int.TryParse(reader["CreditHours"]?.ToString(), out int creditHours);
            int.TryParse(reader["MajorID"]?.ToString(), out int majorID);
            string courseName = reader["CourseName"]?.ToString() ?? string.Empty;

            Course course = new Course(courseID, courseName, creditHours, new Major { MajorID = majorID });

            int.TryParse(reader["LectureID"]?.ToString(), out int lectureID);
            int.TryParse(reader["DurationValue"]?.ToString(), out int durationValue);
            int.TryParse(reader["LectureType"]?.ToString(), out int lectureType);

            return new Lecture(lectureID, (LectureType)lectureType, durationValue, course);
        }
    }
}
