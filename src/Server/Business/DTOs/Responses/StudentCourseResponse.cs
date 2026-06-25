using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Business.DTOs.Responses
{
    public class StudentCourseResponse
    {
        public int EnrolmentID { get; set; }

        public bool IsPassed { get; set; }

        public int StudentID { get; set; }

        public CourseResponse? Course { get; set; }


        public StudentCourseResponse()
        {
            EnrolmentID = -1;
            StudentID = -1;
            Course = null;
            IsPassed = false;
        }

        public StudentCourseResponse(int enrolmentID, bool isPassed, int studentID, CourseResponse course)
        {
            EnrolmentID = enrolmentID;
            IsPassed = isPassed;
            StudentID = studentID;
            Course = course;
        }
    }
}
