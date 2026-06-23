using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.Entities;

namespace Business.Mapper
{
    public static class TimeSlotMapper
    {
        public static TimeSlot? ToTimeSlot(this TimeSlotRequest? request, int timeSlotID = -1)
        {
            if (request != null)
            {
                return new TimeSlot(timeSlotID, request.Day, request.Period);
            }
            return null;
        }

        public static void UpdatePeriod(this TimeSlot timeSlot, TimeSlotRequest? request)
        {
            if (request == null)
                return;

//            timeSlot.Period. = request.StartTime;
  //          period.EndTime = request.EndTime;
        }

        public static TimeSlotResponse? ToResponse(this TimeSlot? timeSlot)
        {
            if (timeSlot != null)
            {
                return new TimeSlotResponse(timeSlot.SlotID, timeSlot.Day, timeSlot.Period);
            }
            return null;
        }

    }
}
