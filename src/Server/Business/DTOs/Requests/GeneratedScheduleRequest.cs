namespace Business.DTOs.Requests
{
    public class GeneratedScheduleRequest
    {
        public int WishListID { get; set; }

        public List<DayOfWeek> Days { get; set; }

        public GeneratedScheduleRequest()
        {
            WishListID = default;
            Days = new List<DayOfWeek>();
        }

        public GeneratedScheduleRequest(int wishListID, List<DayOfWeek> days)
        {
            WishListID = wishListID;
            Days = days;
        }
    }
}
