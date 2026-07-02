using Core.Entities;
using DataAccess.Extensions;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class TimeSlotMapper
    {
        public static TimeSlot ToTimeSlot(this SqlDataReader reader)
        {
            Period period = reader.ToPeriod();

            reader.ReadInt("SlotID", out int slotID, -1);
            reader.ReadInt("DayNum", out int day, -1);

            return new TimeSlot(slotID, (DayOfWeek)day, period);
        }
    }
}
