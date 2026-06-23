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
    public static class PeriodMapper
    {
        public static Period? ToPeriod(this PeriodRequest? request, int periodID = -1)
        {
            if (request != null)
            {
                return new Period(periodID, request.StartTime, request.EndTime);
            }
            return null;
        }

        public static void UpdatePeriod(this Period period, PeriodRequest? request)
        {
            if (request == null)
                return;

            period.StartTime = request.StartTime;
            period.EndTime = request.EndTime;
        }

        public static PeriodResponse? ToResponse(this Period? period)
        {
            if (period != null)
            {
                return new PeriodResponse(period.PeriodID, period.StartTime, period.EndTime);
            }
            return null;
        }

    }
}
