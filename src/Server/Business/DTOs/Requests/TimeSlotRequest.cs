using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Business.DTOs.Requests
{
    public class TimeSlotRequest
    {
        public DayOfWeek Day { get; set; }

        public Period? Period { get; set; }

        public TimeSlotRequest(DayOfWeek day, Period? period)
        {
            Day = day;
            Period = period;
        }
    }
}
