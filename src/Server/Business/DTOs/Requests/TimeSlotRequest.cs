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

        public int PeriodID { get; set; }

        public TimeSlotRequest(DayOfWeek day, int periodID)
        {
            Day = day;
            PeriodID = periodID;
        }
    }
}
