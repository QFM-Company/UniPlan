using Infrastructure.ExternalServices.Validation.Attributes;


namespace Business.DTOs.Requests
{
    public class WishListItemRequest
    {
        [Required<int>("معرف قائمة الرغبات مطلوب")]
        [Range<int>("يجب ان يكون المعرف اكبر تماما من 0", 1, int.MaxValue)]
        public int WishListID { get; set; }
        [Required<int>("معرف الكورس مطلوب")]
        [Range<int>("يجب ان يكون المعرف اكبر تماما من 0", 1, int.MaxValue)]
        public int CourseID { get; set; }



        public WishListItemRequest(int wishListID, int courseID)
        {
            WishListID = wishListID;
            CourseID = courseID;
        }


    }
}
