using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class CourseSession
    {
        public int SessionID { get; set; }

        public CourseOffering? CourseOffering { get; set; }

        public Hall? Hall { get; set; }

        public TimeSlot? TimeSlot { get; set; }

        public Administrator? CreatedByAdmin { get; set; }

        public CourseSession(int sessionID, CourseOffering? courseOffering, Hall? hall, TimeSlot? timeSlot, Administrator? createdByAdmin)
        {
            SessionID = sessionID;
            CourseOffering = courseOffering;
            Hall = hall;
            TimeSlot = timeSlot;
            CreatedByAdmin = createdByAdmin;
        }

        public CourseSession()
        {
        }
    }
}
