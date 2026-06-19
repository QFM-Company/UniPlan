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

        public CourseOffering? CourseOffering { get; set; }

        public Hall? Hall { get; set; }

        public TimeSlot? TimeSlot { get; set; }

        public int? CreatedByAdminID { get; set; }

        public CreateCourseSessionRequest(CourseOffering? courseOffering, Hall? hall, TimeSlot? timeSlot, int createdByAdminID)
        {
            CourseOffering = courseOffering;
            Hall = hall;
            TimeSlot = timeSlot;
            CreatedByAdminID = createdByAdminID;
        }

        public CreateCourseSessionRequest()
        {
        }
    }
}
