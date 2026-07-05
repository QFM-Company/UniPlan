using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.Entities;

namespace Business.Mapper
{
    public static class CourseMapper
    {
        public static Course ToCourse(this CourseRequest request, int courseID = 0)
        {
            return new Course(
                courseID,
                request.CourseName,
                request.CreditHours ,
                request.CourseCode
            );
        }

        public static void UpdateCourse(this Course course, CourseRequest request)
        {
            course.CreditHours = request.CreditHours;
            course.CourseName = request.CourseName;
            course.CourseCode = request.CourseCode;
        }

        public static CourseResponse ToResponse(this Course course)
        {
            return new CourseResponse(
                course.CourseID,
                course.CourseName,
                course.CreditHours,
                course.CourseCode
            );
        }

    }
}
