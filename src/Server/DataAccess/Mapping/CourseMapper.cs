using Core.Entities;
using DataAccess.Extensions;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class CourseMapper
    {
        public static Course ToCourse(this SqlDataReader reader)
        {
            reader.ReadInt("CourseID", out int courseID, -1);
            reader.ReadString("CourseName", out string courseName, string.Empty);
            reader.ReadInt("CreditHours", out int creditHours, -1);
            reader.ReadString("CourseCode", out string courseCode, string.Empty);

            return new Course(courseID, courseName, creditHours , courseCode);
        }
    }
}
