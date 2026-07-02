using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IWishListItemRepository
    {
        Task<int> AddWishListItemAsync(WishListItem wishListItem);

        Task<bool> DeleteWishListItemAsync(int wishListItemID);

        Task<WishListItem?> GetWishListItemByIDAsync(int wishListItemID);

        Task<IEnumerable<WishListItem>?> GetWishListItemsByWishListIDAsync(int wishListID);

    }
}
