using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Requests.Update
{
    public class UpdateStudentCourseRequest
    {
        public bool IsPassed { get; set; }

        public UpdateStudentCourseRequest(bool isPassed)
        {
            IsPassed = isPassed;
        }

    }
}
