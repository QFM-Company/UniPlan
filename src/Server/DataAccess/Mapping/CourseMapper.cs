using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using DataAccess.Extensions;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class CourseMapper
    {
        public static Course ToCourse(this SqlDataReader reader)
        {
            Major major = reader.ToMajor();

            reader.ReadInt("CourseID", out int courseID, -1);
            reader.ReadString("CourseName", out string courseName, string.Empty);
            reader.ReadInt("CreditHours", out int creditHours, -1);

            return new Course(courseID , courseName , creditHours , major);
        }
    }
}
