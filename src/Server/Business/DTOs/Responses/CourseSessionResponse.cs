using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Business.DTOs.Responses
{
    public class CourseSessionResponse
    {
        public int SessionID { get; set; }

        public CourseOffering? CourseOffering { get; set; }

        public Hall? Hall { get; set; }

        public TimeSlot? TimeSlot { get; set; }

        public int? CreatedByAdminID { get; set; }

        public CourseSessionResponse(int sessionID, CourseOffering? courseOffering, Hall? hall, TimeSlot? timeSlot, int createdByAdminID)
        {
            SessionID = sessionID;
            CourseOffering = courseOffering;
            Hall = hall;
            TimeSlot = timeSlot;
            CreatedByAdminID = createdByAdminID;
        }

        public CourseSessionResponse()
        {
        }
    }
}
