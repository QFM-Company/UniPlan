using Core.Entities;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class WishListMapper
    {
        public static WishList ToWishList(this SqlDataReader reader)
        {
            if (!int.TryParse(reader["WishListID"]?.ToString(), out int listID))
            {
                listID = 0;
            }

            return new WishList(listID);
        }
    }
}
