using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests
{
    public class StudentTermRequest
    {
        [Required<int>("معرف الطالب مطلوب")]
        [Range<int>("يجب ان يكون المعرف اكبر تماما من 0", 1, int.MaxValue)]
        public int StudentID { get; set; }
        [Required<int>("معرف الفصل الدراسي مطلوب")]
        [Range<int>("يجب ان يكون المعرف اكبر تماما من 0", 1, int.MaxValue)]
        public int AcademicTermID { get; set; }

        public StudentTermRequest(int studentID, int academicTermID)
        {
            StudentID = studentID;
            AcademicTermID = academicTermID;
        }
    }
}
