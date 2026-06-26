using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Requests;
using Business.DTOs.Requests.Create;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;
using Business.Mapper;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace Business.Services
{
    public class WishListItemService
    {
        private IWishListItemRepository _wishListItemRepository;

        public WishListItemService(IWishListItemRepository wishListItemRepository)
        {
            _wishListItemRepository = wishListItemRepository;
        }

        public async Task<bool> DeleteWishListItemAsync(int itemID)
        {
            return await _wishListItemRepository.DeleteWishListItemAsync(itemID);
        }

        public async Task<WishListItemResponse?> AddWishListItemAsync(WishListItemRequest request)
        {
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
