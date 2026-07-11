namespace Core.Entities
{
    public class TimeSlot
    {
        public int SlotID { get; set; }

        public DayOfWeek Day { get; set; }

        public Period? Period { get; set; }

        public TimeSlot(int slotID, DayOfWeek day, Period? period)
        {
            SlotID = slotID;
            Day = day;
            Period = period;
        }

        public TimeSlot()
        {
            SlotID = -1;
            Day = DayOfWeek.Friday;
            Period = null;
        }
        public bool IsValid()
        {
            return Period != null && Period.IsValid();
        }

        public bool IsSameDay(TimeSlot other)
        {
            if (other == null)
                return false;

            return Day == other.Day;
        }


        /// <summary>
        ///  if you Need The Minuts just call this method and then .Minutes re(int) on the result 
        ///  Same for Hours and Seconds 
        /// </summary>
        /// <returns>TimeSpan The differ between 2 start and End</returns>
        /// <returns>TimeSpan.Zero if The obj is not good</returns>
        public TimeSpan GetDuration()
        {
            if (!IsValid())
                return TimeSpan.Zero;

            return Period!.GetDuration();
        }

        public override string ToString()
        {
            if (!IsValid())
                return "Invalid TimeSlot";

            return $"{Day}: {Period}";
        }

    }
}
