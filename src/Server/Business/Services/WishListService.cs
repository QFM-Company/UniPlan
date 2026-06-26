using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
using Business.Mapper;
using Core.Entities;

namespace Business.Services
{
    public class WishListService : IWishListService
    {
        private IWishListRepository _listRepository;

        public WishListService(IWishListRepository listRepository)
        {
            _listRepository = listRepository;
        }

        public async Task<bool> DeleteWishListAsync(int WishListID)
        {
            return await _listRepository.DeleteWishListAsync(WishListID);
        }

        public async Task<WishListResponse?> AddWishListAsync(WishListRequest request)
        {
            WishList list = request.ToWishList();

            list.WishListID = await _listRepository.AddWishListAsync(list);

            if (list.WishListID != -1)
                return await GetWishListByIDAsync(list.WishListID);

            return null;
        }

        public async Task<IEnumerable<WishListResponse>?> GetWishListsByRegistrationIDAsync(int registrationID)
        {
            IEnumerable<WishList>? lists = await _listRepository.GetWishListsByRegistrationIDAsync(registrationID);
            return lists?.Select(m => m.ToResponse()).OfType<WishListResponse>();
        }

        public async Task<WishListResponse?> GetWishListByIDAsync(int listID)
        {
            WishList? list = await _listRepository.GetWishListByIDAsync(listID);
            return list != null ? list.ToResponse() : null;
        }
    }
}
