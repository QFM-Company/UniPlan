using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Requests.Create;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;
using Core.Entities;

namespace Business.Mapper
{
    public static class StudentCourseMapper
    {
        public static StudentCourse ToStudentCourse(this CreateStudentCourseRequest request , int enrolledID = 0)
        {
            return new StudentCourse(enrolledID , request.IsPassed , request.StudentID , new Course(request.CourseID));
        }

        public static void UpdateStudentCourse(this StudentCourse studentCourse, UpdateStudentCourseRequest request)
        {
            studentCourse.IsPassed = request.IsPassed;
        }

        public static StudentCourseResponse ToResponse(this StudentCourse studentCourse)
        {
            Course course = studentCourse.Course!;
            return new StudentCourseResponse(studentCourse.EnrolmentID , studentCourse.IsPassed , studentCourse.StudentID , course.ToResponse());
        }
    }
}
