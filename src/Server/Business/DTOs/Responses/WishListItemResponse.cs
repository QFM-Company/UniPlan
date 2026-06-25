using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Business.DTOs.Responses
{
    public class WishListItemResponse
    {
        public int ItemID { get; set; }

        public WishList? WishList { get; set; }

        public Course? Course { get; set; }


        public WishListItemResponse()
        {
            ItemID = -1;
            WishList = null;
            Course = null;
        }

        public WishListItemResponse(int itemID, WishList? wishList, Course? course)
        {
            ItemID = itemID;
            WishList = wishList;
            Course = course;
        }

    }
}
