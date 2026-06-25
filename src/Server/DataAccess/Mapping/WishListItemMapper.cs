using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class WishListItemMapper
    {
        public static WishListItem ToWishListItem(this SqlDataReader reader)
        {

            WishList wishList = reader.ToWishList();

            string courseName = reader["CourseName"]?.ToString() ?? string.Empty;

            int.TryParse(reader["CreditHours"]?.ToString(), out int creditHours);

            if (!int.TryParse(reader["CourseID"]?.ToString(), out int courseID))
            {
                courseID = -1;
            }

            Course course = new Course(courseID, courseName, creditHours, null);

            if (!int.TryParse(reader["ItemID"]?.ToString(), out int itemID))
            {
                itemID = -1;
            }

            int.TryParse(reader["MajorID"]?.ToString(), out int studentID);

            return new WishListItem(itemID, wishList, course);
        }
    }
}
