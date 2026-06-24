using Business.Interfaces;
using Core.Entities;

namespace DataAccess.Repositories
{
    public class WishListRepository : IWishListRepository
    {
        public Task<int> AddWishListAsync(WishList list)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteWishListAsync(int listID)
        {
            throw new NotImplementedException();
        }

        public Task<WishList?> GetWishListByIDAsync(int listID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WishList>?> GetWishListsByRegistrationIDAsync(int registrationID)
        {
            throw new NotImplementedException();
        }
    }
}
