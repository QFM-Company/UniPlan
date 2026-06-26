using System.Data;

namespace Core.Entities
{
    public class GeneratedSchedule
    {
        public int ScheduleID { get; set; }
        
        public WishList WishList { get; set; }

        public List<CourseOffering>? Offerings { get; set; }

        public List<DayOfWeek>? Days { get; set; }

        public GeneratedSchedule()
        {
            ScheduleID = -1;
            WishList = new WishList();
        }

        public GeneratedSchedule(int scheduleID, WishList wishList, List<DayOfWeek> days)
        {
            ScheduleID = scheduleID;
            WishList = wishList;
            Days = days;
        }

        public GeneratedSchedule(int scheduleID, WishList wishList)
        {
            ScheduleID = scheduleID;
            WishList = wishList;
        }
    }
}
