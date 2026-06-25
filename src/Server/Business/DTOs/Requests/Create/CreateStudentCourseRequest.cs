using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Business.DTOs.Requests.Create
{
    public class CreateStudentCourseRequest
    {
        public int CourseID { get; set; }

        public bool IsPassed { get; set; }

        public int StudentID { get; set; }


        public CreateStudentCourseRequest(int enrolmentID, bool isPassed, int studentID)
        {
            CourseID = enrolmentID;
            IsPassed = isPassed;
            StudentID = studentID;
        }

    }
}
