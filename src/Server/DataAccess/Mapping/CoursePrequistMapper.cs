using Core.Entities;
using DataAccess.Extensions;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class CoursePrequistMapper
    {
        public static CoursePrerequisites ToCoursePrequist(this SqlDataReader reader)
        {
            Course mainCourse = reader.ToCourse();

            reader.ReadInt("CourseID2", out int PreCourseID2, -1);
            reader.ReadString("CourseName2", out string courseName2, string.Empty);
            reader.ReadInt("CreditHours2", out int creditHours2, -1);

            reader.ReadInt("PrerequisiteID", out int prerequisiteID, -1);

            Course preCourse = new Course(PreCourseID2, courseName2, creditHours2);

            return new CoursePrerequisites(
                 prerequisiteID,
                 mainCourse,
                 preCourse
                 );
        }
    }
}
