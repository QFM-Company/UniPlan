namespace Core.Entities
{
    public class WishList
    {
        public int WishListID { get; set; }

        public StudentTerm StudentTerm { get; set; }

        public WishList(int wishListID, StudentTerm studentTerm)
        {
            WishListID = wishListID;
            StudentTerm = studentTerm;
        }

        public WishList(int wishListID)
        {
            WishListID = wishListID;
            StudentTerm = new StudentTerm();
        }

        public WishList()
        {
            WishListID = -1;
            StudentTerm = new StudentTerm();
        }
    }
}
