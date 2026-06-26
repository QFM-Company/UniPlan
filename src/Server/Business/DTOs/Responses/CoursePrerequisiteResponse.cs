using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Business.DTOs.Responses
{
    public class CoursePrerequisiteResponse
    {
        public int PreRequestID { get; set; }

        public CourseResponse? MainCourseInfo { get; set; }

        public CourseResponse? PreRequestCourseInfo { get; set; }

        public CoursePrerequisiteResponse(int preRequestID, CourseResponse? course, CourseResponse? preRequestCourse)
        {
            PreRequestID = preRequestID;
            MainCourseInfo = course;
            PreRequestCourseInfo = preRequestCourse;
        }
    }
}
