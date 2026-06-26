using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.Interfaces.Repositories;

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
