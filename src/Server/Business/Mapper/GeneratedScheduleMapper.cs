using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.Entities;

namespace Business.Mapper
{
    public static class GeneratedScheduleMapper
    {
        public static GeneratedSchedule ToGeneratedSchedule(this GeneratedScheduleRequest request)
        {
            return new GeneratedSchedule(-1, new WishList(request.WishListID), request.Days);
        }

        public static GeneratedScheduleResponse ToResponse(this GeneratedSchedule schedule)
        {
            WishListResponse listResponse = schedule.WishList.ToResponse();
            List<CourseOfferingResponse>? offeringsResponse = schedule.Offerings?.Select(o => o.ToResponse()).ToList();

            return new GeneratedScheduleResponse(schedule.ScheduleID, listResponse, offeringsResponse);
        }
    }
}
