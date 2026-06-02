using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Business.DTOs.Responses
{
    public class TimeSlotResponse
    {
        public int SlotID { get; set; }

        public DayOfWeek Day { get; set; }

        public Period? Period { get; set; }

        public TimeSlotResponse(int slotID, DayOfWeek day, Period? period)
        {
            SlotID = slotID;
            Day = day;
            Period = period;
        }
    }
}
