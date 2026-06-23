using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Business.DTOs.Requests.Update
{
    public class UpdateCourseSessionRequest
    {
        public int CourseOfferingID { get; set; }

        public int HallID { get; set; }

        public int TimeSlotID { get; set; }

        public UpdateCourseSessionRequest(int courseOfferingID, int hallID, int timeSlotID)
        {
            CourseOfferingID = courseOfferingID;
            HallID = hallID;
            TimeSlotID = timeSlotID;
        }

        public UpdateCourseSessionRequest()
        {
        }

    }
}
