namespace Core.Entities
{
    public class WishListItem
    {
        public int ItemID { get; set; }

        public WishList? WishList { get; set; }

        public Course? Course { get; set; }


        public WishListItem()
        {
            ItemID = -1;
            WishList = null;
            Course = null;
        }

        public WishListItem(int itemID, WishList? wishList, Course? course)
        {
            ItemID = itemID;
            WishList = wishList;
            Course = course;
        }
    }
}
