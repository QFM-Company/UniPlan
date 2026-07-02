using Core.Entities;
using DataAccess.Extensions;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class WishListItemMapper
    {
        public static WishListItem ToWishListItem(this SqlDataReader reader)
        {

            WishList wishList = reader.ToWishList();

            Course course = reader.ToCourse();

            reader.ReadInt("ItemID", out int itemID, -1);

            return new WishListItem(itemID, wishList, course);
        }
    }
}
