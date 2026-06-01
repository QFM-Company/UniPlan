using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Requests
{
    public class PeriodRequest
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public PeriodRequest(TimeSpan startTime, TimeSpan endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
