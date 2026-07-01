using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests
{
    public class WishListRequest
    {
        [Required<int>("ãÚÑİ ÇáÊÓÌíá ãØáæÈ")]
        [Range<int>("íÌÈ Ãä íßæä ÇáãÚÑİ ÃßÈÑ ãä 0", 1, int.MaxValue)]
        public int RegistrationID { get; set; }

        public WishListRequest()
        {
            RegistrationID = default;
        }

        public WishListRequest(int registrationID)
        {
            RegistrationID = registrationID;
        }
    }
}