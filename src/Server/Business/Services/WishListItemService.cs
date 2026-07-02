using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
using Business.Mapper;
using Core.Entities;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;

namespace Business.Services
{
    public class WishListItemService : IWishListItemService
    {
        private IWishListItemRepository _wishListItemRepository;
        private IValidationService _ValidationService;

        public WishListItemService(IWishListItemRepository wishListItemRepository, IValidationService validationService)
        {
            _wishListItemRepository = wishListItemRepository;
            _ValidationService = validationService;
        }

        public async Task<bool> DeleteWishListItemAsync(int itemID)
        {
            return await _wishListItemRepository.DeleteWishListItemAsync(itemID);
        }

        public async Task<WishListItemResponse?> AddWishListItemAsync(WishListItemRequest request)
        {
            _ValidationService.Validate(request);

            WishListItem wishListItem = request.ToWishListItem();

            wishListItem.ItemID = await _wishListItemRepository.AddWishListItemAsync(wishListItem);

            if (wishListItem.ItemID > 0)
                return await GetWishListItemByIDAsync(wishListItem.ItemID);

            return null;
        }

        public async Task<IEnumerable<WishListItemResponse>?> GetWishListItemsByStudentIDAsync(int wishListID)
        {
            IEnumerable<WishListItem>? wishListItems = await _wishListItemRepository.GetWishListItemsByWishListIDAsync(wishListID);
            return wishListItems?.Select(m => m.ToResponse());
        }

        public async Task<WishListItemResponse?> GetWishListItemByIDAsync(int itemID)
        {
            WishListItem? wishListItem = await _wishListItemRepository.GetWishListItemByIDAsync(itemID);
            return wishListItem != null ? wishListItem.ToResponse() : null;
        }

    }
}
