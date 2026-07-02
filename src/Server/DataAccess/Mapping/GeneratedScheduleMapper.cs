using Core.Entities;
using DataAccess.Extensions;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class GeneratedScheduleMapper
    {
        public static GeneratedSchedule ToGeneratedSchedule(this SqlDataReader reader)
        {
            reader.ReadInt("ScheduleID", out int scheduleID, 0);

            WishList list = reader.ToWishList();

            return new GeneratedSchedule(scheduleID, list);
        }
    }
}
