using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Requests.Update
{
    public class SyncStudentPassedCoursesRequest
    {
        public List<int> PassedCourseIds { get; set; }


        public SyncStudentPassedCoursesRequest(List<int> passedCourseIds)
        {
            PassedCourseIds = passedCourseIds;
        }
        public SyncStudentPassedCoursesRequest()
        {
            PassedCourseIds = new List<int>();
        }
    }
}
