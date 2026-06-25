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

        public int AcademicTermID { get; set; }

        public StudentTermRequest(int studentID, int academicTermID)
        {
            StudentID = studentID;
            AcademicTermID = academicTermID;
        }
    }
}
