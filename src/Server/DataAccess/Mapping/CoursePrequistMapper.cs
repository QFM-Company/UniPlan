using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class CoursePrequistMapper
    {
        public static CoursePrerequisites ToCoursePrequist(this SqlDataReader reader)
        {
            Course mainCourse = reader.ToCourse();

            string courseName2 = reader["CourseName2"]?.ToString() ?? string.Empty;

            int.TryParse(reader["CreditHours2"]?.ToString(), out int creditHours2);
            int.TryParse(reader["MajorID2"]?.ToString(), out int majorID2);
            string majorName2 = reader["MajorName2"].ToString() ?? string.Empty;
            int.TryParse(reader["CourseID2"]?.ToString(), out int PreCourseID2);

            Major major2 = new Major(majorID2, majorName2);

            Course preCourse = new Course(PreCourseID2, courseName2, creditHours2, major2);

            if(!int.TryParse(reader["PrerequisiteID"]?.ToString(), out int prerequisiteID))
            {
                prerequisiteID = -1;
            }

            return new CoursePrerequisites(
                 prerequisiteID,
                 mainCourse,
                 preCourse
                 );
        }
    }
}
