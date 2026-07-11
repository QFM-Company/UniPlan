namespace Business.DTOs.Responses
{
    public class GeneratedScheduleResponse
    {
        public int ScheduleID { get; set; }

        public WishListResponse WishListInfo { get; set; }

        public GeneratedScheduleResponse()
        {
            WishListInfo = new WishListResponse();
        }

        public GeneratedScheduleResponse(int scheduleID, WishListResponse wishListInfo)
        {
            ScheduleID = scheduleID;
            WishListInfo = wishListInfo;
        }
    }
}
