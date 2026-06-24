using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.Entities;

namespace Business.Mapper
{
    public static class GeneratedScheduleMapper
    {
        public static GeneratedSchedule ToGeneratedSchedule(this GeneratedScheduleRequest request)
        {
            return new GeneratedSchedule(-1, new WishList(request.WishListID));
        }

        public static GeneratedScheduleResponse ToResponse(this GeneratedSchedule schedule)
        {
            WishListResponse response = schedule.WishList.ToResponse();
            return new GeneratedScheduleResponse(schedule.ScheduleID, response);
        }
    }
}
