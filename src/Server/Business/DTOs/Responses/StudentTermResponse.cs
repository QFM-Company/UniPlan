using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Business.DTOs.Responses
{
    public class StudentTermResponse
    {
        public int RegistrationID { get; set; }

        public int StudentID { get; set; }

        public AcademicTerm? AcademicTerm { get; set; }



        public StudentTermResponse()
        {
            RegistrationID = -1;
            StudentID = -1;
            AcademicTerm = null;
        }

        public StudentTermResponse(int registrationID, int studentID, AcademicTerm? academicTerm)
        {
            RegistrationID = registrationID;
            StudentID = studentID;
            AcademicTerm = academicTerm;
        }
    }
}
