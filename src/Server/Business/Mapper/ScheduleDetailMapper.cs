using Business.DTOs.Responses;
using Core.Entities;

namespace Business.Mapper
{
    public static class ScheduleDetailMapper
    {
        public static ScheduleDetailResponse ToResponse(this ScheduleDetail detail)
        {
            GeneratedScheduleResponse scheduleResponse = detail.Schedule.ToResponse();
            CourseOfferingResponse offeringResponse = detail.Offering.ToResponse();

            return new ScheduleDetailResponse(detail.DetailID, scheduleResponse, offeringResponse);
        }
    }
}
