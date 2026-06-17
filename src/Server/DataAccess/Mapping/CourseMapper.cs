using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class CourseMapper
    {
        public static Course ToCourse(this SqlDataReader reader)
        {
            Major major = reader.ToMajor();

            string courseName = reader["CourseName"]?.ToString() ?? string.Empty;

            int.TryParse(reader["CreditHours"]?.ToString(), out int creditHours);

            if(!int.TryParse(reader["CourseID"]?.ToString(), out int courseID))
            {
                courseID = -1;
            }

            return new Course(courseID , courseName , creditHours , major);
        }
    }
}
