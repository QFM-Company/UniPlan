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
        public CourseOffering? CourseOffering { get; set; }

        public Hall? Hall { get; set; }

        public TimeSlot? TimeSlot { get; set; }

        public UpdateCourseSessionRequest(CourseOffering? courseOffering, Hall? hall, TimeSlot? timeSlot)
        {
            CourseOffering = courseOffering;
            Hall = hall;
            TimeSlot = timeSlot;
        }

        public UpdateCourseSessionRequest()
        {
        }

    }
}
