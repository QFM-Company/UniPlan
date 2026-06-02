using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Responses
{
    public class PeriodResponse
    {
        public int PeriodID { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public PeriodResponse(int periodID, TimeSpan startTime, TimeSpan endTime)
        {
            PeriodID = periodID;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
