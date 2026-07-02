using Business.DTOs.Requests;
using Business.DTOs.Responses;

namespace Business.Interfaces
{
    public interface IWishListItemService
    {
        Task<WishListItemResponse?> AddWishListItemAsync(WishListItemRequest request);

        Task<bool> DeleteWishListItemAsync(int itemID);

        Task<WishListItemResponse?> GetWishListItemByIDAsync(int itemID);

        Task<IEnumerable<WishListItemResponse>?> GetWishListItemsByStudentIDAsync(int wishListID);
    }
}
