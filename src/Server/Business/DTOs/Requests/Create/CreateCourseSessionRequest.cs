using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Responses;
using Core.Entities;

namespace Business.DTOs.Requests.Create
{
    public class CreateCourseSessionRequest
    {

        public int CourseOfferingID { get; set; }

        public int HallID { get; set; }

        public int TimeSlotID { get; set; }

        public int CreatedByAdminID { get; set; }

        public CreateCourseSessionRequest(int courseOfferingID, int hallID, int timeSlotID, int createdByAdminID)
        {
            CourseOfferingID = courseOfferingID;
            HallID = hallID;
            TimeSlotID = timeSlotID;
            CreatedByAdminID = createdByAdminID;
        }

        public CreateCourseSessionRequest()
        {
        }
    }
}
