using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.Entities;

namespace Business.Mapper
{
    public static class WishListMapper
    {
        public static WishList ToWishList(this WishListRequest request)
        {
            return new WishList(-1, new StudentTerm { RegistrationID = request.RegistrationID });
        }

        public static WishListResponse ToResponse(this WishList wishList)
        {
            StudentTermResponse studentTerm = wishList.StudentTerm.ToResponse();
            return new WishListResponse(wishList.WishListID, studentTerm);
        }
    }
}
