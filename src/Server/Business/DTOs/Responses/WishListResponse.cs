namespace Business.DTOs.Responses
{
    public class WishListResponse
    {
        public int WishListID { get; set; }

        public StudentTermResponse RegistrationInfo { get; set; }

        public WishListResponse()
        {
            RegistrationInfo = new StudentTermResponse();
        }

        public WishListResponse(int wishListID, StudentTermResponse registrationInfo)
        {
            WishListID = wishListID;
            RegistrationInfo = registrationInfo;
        }
    }
}
