namespace Business.DTOs.Requests
{
    public class WishListRequest
    {
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
