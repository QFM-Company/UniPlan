using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class StudentCourseMapper
    {
        public static StudentCourse ToStudentCourse(this SqlDataReader reader)
        {

            if (!int.TryParse(reader["EnrollmentID"]?.ToString(), out int enrolmentID))
            {
                enrolmentID = 0;
            }

            int.TryParse(reader["StudentID"]?.ToString(), out int studentID);

            string courseName = reader["CourseName"]?.ToString() ?? string.Empty;

            int.TryParse(reader["CreditHours"]?.ToString(), out int creditHours);

            if (!int.TryParse(reader["CourseID"]?.ToString(), out int courseID))
            {
                courseID = -1;
            }

            Course course = new Course(courseID, courseName, creditHours, null);

            bool.TryParse(reader["IsPassed"]?.ToString(), out bool isPassed);


            var studentCourse = new StudentCourse(enrolmentID , isPassed , studentID , course);
            return studentCourse;
        }
    }
}
