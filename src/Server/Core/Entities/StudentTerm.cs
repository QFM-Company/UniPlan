using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class StudentTerm
    {
        public int RegistrationID { get; set; }

        public int StudentID { get; set; }

        public AcademicTerm? AcademicTerm { get; set; }



        public StudentTerm() 
        {
            RegistrationID = -1;
            StudentID = -1;
            AcademicTerm = null;
        }

        public StudentTerm(int registrationID, int studentID, AcademicTerm? academicTerm)
        {
            RegistrationID = registrationID;
            StudentID = studentID;
            AcademicTerm = academicTerm;
        }
    }
}
