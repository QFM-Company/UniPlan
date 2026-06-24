using Core.Entities;

namespace Business.Interfaces
{
    public interface IWishListRepository
    {
        Task<bool> DeleteWishListAsync(int listID);

        Task<int> AddWishListAsync(WishList list);

        Task<IEnumerable<WishList>?> GetWishListsByRegistrationIDAsync(int registrationID);

        Task<WishList?> GetWishListByIDAsync(int listID);
    }
}
