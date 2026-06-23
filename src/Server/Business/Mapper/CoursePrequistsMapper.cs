using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.Entities;

namespace Business.Mapper
{
    public static class CoursePrequistsMapper
    {
        public static CoursePrerequisites ToCoursePrequist(this CoursePrerequisiteRequest request, int prequistID = -1)
        {
            return new CoursePrerequisites(prequistID, new Course(request.CourseID, null, 0, null), new Course(request.PreRequestCourseID, null, 0, null));
        }

        public static void UpdateCourse(this CoursePrerequisites coursePrequist, CoursePrerequisiteRequest request)
        {
            coursePrequist.Course = new Course(request.CourseID, null, 0, null);
            coursePrequist.PreRequestCourse = new Course(request.PreRequestCourseID, null, 0, null);
        }


        public static CoursePrerequisiteResponse ToResponse(this CoursePrerequisites coursePrequist)
        {
            return new CoursePrerequisiteResponse(coursePrequist.PreRequestID, coursePrequist.Course, coursePrequist.PreRequestCourse);
        }

    }
}
