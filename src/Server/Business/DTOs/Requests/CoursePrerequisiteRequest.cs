using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Business.DTOs.Requests
{
    public class CoursePrerequisiteRequest
    {
        public int CourseID { get; set; }

        public int PreRequestCourseID { get; set; }

        public CoursePrerequisiteRequest(int courseID, int preRequestCourseID)
        {
            CourseID = courseID;
            PreRequestCourseID = preRequestCourseID;
        }
    }
}
