namespace Business.DTOs.Responses
{
    public class WishListItemResponse
    {
        public int ItemID { get; set; }

        public int WishListID { get; set; }

        public CourseResponse? Course { get; set; }


        public WishListItemResponse()
        {
            ItemID = -1;
            WishListID = -1;
            Course = null;
        }

        public WishListItemResponse(int itemID, int wishListID, CourseResponse? course)
        {
            ItemID = itemID;
            WishListID = wishListID;
            Course = course;
        }

    }
}
