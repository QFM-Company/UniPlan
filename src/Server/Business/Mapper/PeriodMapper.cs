using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.Entities;

namespace Business.Mapper
{
    public static class PeriodMapper
    {
        public static Period ToPeriod(this PeriodRequest request, int periodID = -1)
        {
            return new Period(periodID, request.StartTime, request.EndTime);
        }

        public static PeriodResponse ToResponse(this Period period)
        {
            return new PeriodResponse(period.PeriodID, period.StartTime, period.EndTime);
        }

    }
}
