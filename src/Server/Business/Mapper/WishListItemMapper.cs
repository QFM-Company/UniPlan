using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Requests;
using Business.DTOs.Requests.Create;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;
using Core.Entities;

namespace Business.Mapper
{
    public static class WishListItemMapper
    {
        public static WishListItem ToWishListItem(this WishListItemRequest request, int itemID = 0)
        {
            return new WishListItem(itemID , new WishList(request.WishListID) , new Course(request.CourseID));
        }

        public static WishListItemResponse ToResponse(this WishListItem wishListItem)
        {
            Course course = wishListItem.Course!;
            WishList wishList = wishListItem.WishList!;
            return new WishListItemResponse(wishListItem.ItemID , wishList.ToResponse() , course.ToResponse());
        }
    }
}
