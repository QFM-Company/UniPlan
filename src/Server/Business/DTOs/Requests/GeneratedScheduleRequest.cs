using Infrastructure.ExternalServices.Validation.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Business.DTOs.Requests
{
    public class GeneratedScheduleRequest
    {
        [Required<int>("معرف قائمة الرغبات مطلوب")]
        [Range<int>("يجب أن يكون المعرف أكبر من 0", 1, int.MaxValue)]
        public int WishListID { get; set; }

        [Required<object>("يجب تحديد أيام الأسبوع")]
        [Range<int>("يجب أن تكون قيمة اليوم بين 0 للأحد و 6 للسبت", 0, 6)]
        public List<int> Days { get; set; }


        public GeneratedScheduleRequest(int wishListID, List<int> days)
        {
            WishListID = wishListID;
            Days = days;
        }
    }
}