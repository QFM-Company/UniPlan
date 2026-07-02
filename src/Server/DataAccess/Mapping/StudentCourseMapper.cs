using Core.Entities;
using DataAccess.Extensions;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class StudentCourseMapper
    {
        public static StudentCourse ToStudentCourse(this SqlDataReader reader)
        {
            reader.ReadInt("EnrollmentID", out int enrolmentID, -1);
            reader.ReadInt("StudentID", out int studentID, -1);

            Course course = reader.ToCourse();

            reader.ReadBool("IsPassed", out bool isPassed);

            var studentCourse = new StudentCourse(enrolmentID, isPassed, studentID, course);
            return studentCourse;
        }
    }
}
