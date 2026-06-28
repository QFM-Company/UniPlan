using Core.Entities;
using DataAccess.Extensions;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class WishListMapper
    {
        public static WishList ToWishList(this SqlDataReader reader)
        {
            reader.ReadInt("WishListID", out int listID, 0);

            StudentTerm studentTerm = reader.ToStudentTerm();

            return new WishList(listID, studentTerm);
        }
    }
}
