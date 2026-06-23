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
        public static CoursePrerequisites? _RequestToCoursePrequist(CoursePrerequisiteRequest request, int prequistID = -1)
        {
            if (request == null || request.CourseID <= 0 || request.PreRequestCourseID <= 0) return null;
            return new CoursePrerequisites(prequistID, new Course(request.CourseID, null, 0, null), new Course(request.PreRequestCourseID, null, 0, null));
        }

        public static void UpdateCourse(this CoursePrerequisites coursePrequist, CoursePrerequisiteRequest? request)
        {
            if (request == null)
                return;

            coursePrequist.Course = new Course(request.CourseID, null, 0, null);
            coursePrequist.PreRequestCourse = new Course(request.PreRequestCourseID, null, 0, null);
        }


        public static CoursePrerequisiteResponse? _CoursePrequistToResponse(CoursePrerequisites? coursePrequist)
        {
            if (coursePrequist == null) return null;
            return new CoursePrerequisiteResponse(coursePrequist.PreRequestID, coursePrequist.Course, coursePrequist.PreRequestCourse);
        }

    }
}
