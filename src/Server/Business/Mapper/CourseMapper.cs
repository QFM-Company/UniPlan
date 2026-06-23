using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Requests;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;
using Core.Entities;

namespace Business.Mapper
{
    public static class CourseMapper
    {
        public static Course _RequestToCourse(CourseRequest request, int courseID = 0)
        {
            Major major = new Major(request.MajorID, "");

            return new Course(
                courseID,
                request.CourseName,
                request.CreditHours,
                major
            );
        }

        public static void UpdateCourse(this Course course, CourseRequest? request)
        {
            if (request == null)
                return;

            course.CreditHours = request.CreditHours;
            course.CourseName = request.CourseName;
            course.Major = new Major(request.MajorID, "");
        }

        public static CourseResponse _CourseToResponse(Course course)
        {
            if (course.Major == null)
            {
                throw new ArgumentException("Course must have a Major associated with it.");
            }
            return new CourseResponse(
                course.CourseID,
                course.CourseName,
                course.CreditHours,
                course.Major!.MajorID
            );
        }

    }
}
