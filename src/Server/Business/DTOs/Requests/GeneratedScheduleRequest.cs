namespace Business.DTOs.Requests
{
    public class GeneratedScheduleRequest
    {
        public int WishListID { get; set; }

        public GeneratedScheduleRequest()
        {
            WishListID = default;
        }

        public GeneratedScheduleRequest(int wishListID)
        {
            WishListID = wishListID;
        }
    }
}
