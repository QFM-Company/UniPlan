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
            WishListResponse listResponse = schedule.WishList.ToResponse();

            return new GeneratedScheduleResponse(schedule.ScheduleID, listResponse);
        }

        public static ScheduleDetailResponse ToScheduleDetailResponse(this GeneratedSchedule schedule)
        {
            WishListResponse listResponse = schedule.WishList.ToResponse();
            List<SessionBriefResponse>? sessions = schedule.SelectedSchedule?.Select(s => s.ToBriefResponse()).ToList();

            return new ScheduleDetailResponse(schedule.ScheduleID, sessions);
        }
    }
}
