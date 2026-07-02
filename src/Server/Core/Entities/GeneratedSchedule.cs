namespace Core.Entities
{
    public class GeneratedSchedule
    {
        public int ScheduleID { get; set; }

        public WishList WishList { get; set; }

        public List<CourseOffering>? Offerings { get; set; }


        public GeneratedSchedule()
        {
            ScheduleID = -1;
            WishList = new WishList();
        }

        public GeneratedSchedule(int scheduleID, WishList wishList)
        {
            ScheduleID = scheduleID;
            WishList = wishList;
        }

    }
}
