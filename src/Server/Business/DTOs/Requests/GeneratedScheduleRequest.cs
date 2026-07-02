using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests
{
    public class GeneratedScheduleRequest
    {
        [Required<int>("معرف قائمة الرغبات مطلوب")]
        [Range<int>("يجب أن يكون المعرف أكبر من 0", 1, int.MaxValue)]
        public int WishListID { get; set; }

        [Required<object>("يجب تحديد أيام الأسبوع")]
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