using Business.DTOs.Requests;
using Business.DTOs.Responses;

namespace Business.Interfaces
{
    public interface IWishListService
    {
        Task<bool> DeleteWishListAsync(int listID);

        Task<WishListResponse?> AddWishListAsync(WishListRequest list);

        Task<IEnumerable<WishListResponse>?> GetWishListsByRegistrationIDAsync(int registrationID);

        Task<WishListResponse?> GetWishListByIDAsync(int listID);
    }
}
