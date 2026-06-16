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

        public Course? MainCourseInfo { get; set; }

        public Course? PreRequestCourseInfo { get; set; }

        public CoursePrerequisiteResponse(int preRequestID, Course? course, Course? preRequestCourse)
        {
            PreRequestID = preRequestID;
            MainCourseInfo = course;
            PreRequestCourseInfo = preRequestCourse;
        }
    }
}
