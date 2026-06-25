using Core.Entities;

namespace Business.DTOs.Responses
{
    public class GeneratedScheduleResponse
    {
        public int ScheduleID { get; set; }

        public WishListResponse WishListInfo { get; set; }

        public List<CourseOfferingResponse>? Offerings { get; set; }

        public GeneratedScheduleResponse()
        {
            WishListInfo = new WishListResponse();
        }

        public GeneratedScheduleResponse(int scheduleID, WishListResponse wishListInfo)
        {
            ScheduleID = scheduleID;
            WishListInfo = wishListInfo;
        }

        public GeneratedScheduleResponse(int scheduleID, WishListResponse wishListInfo, List<CourseOfferingResponse>? offerings)
        {
            ScheduleID = scheduleID;
            WishListInfo = wishListInfo;
            Offerings = offerings;
        }
    }
}
