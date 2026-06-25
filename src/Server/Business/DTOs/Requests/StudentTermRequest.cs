using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Business.DTOs.Requests
{
    public class StudentTermRequest
    {
        public int StudentID { get; set; }

        public AcademicTerm? AcademicTerm { get; set; }

        public StudentTermRequest(int studentID, AcademicTerm? academicTerm)
        {
            StudentID = studentID;
            AcademicTerm = academicTerm;
        }
    }
}
