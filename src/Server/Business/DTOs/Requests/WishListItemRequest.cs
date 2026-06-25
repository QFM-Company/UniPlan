using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Business.DTOs.Requests
{
    public class WishListItemRequest
    {
        public int WishListID { get; set; }

        public int CourseID { get; set; }



        public WishListItemRequest(int wishListID, int courseID)
        {
            WishListID = wishListID;
            CourseID = courseID;
        }


    }
}
