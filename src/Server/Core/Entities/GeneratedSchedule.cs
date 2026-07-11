namespace Core.Entities
{
    public class GeneratedSchedule
    {
        public int ScheduleID { get; set; }

        public WishList WishList { get; set; }


        // Stores all generated schedule permutations for database storage
        public List<List<int>>? GeneratedCombinations { get; set; }


        // Contains the single final schedule selected to display to the user
        public List<CourseSession>? SelectedSchedule { get; set; }


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
