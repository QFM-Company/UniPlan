using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class TimeSlotMapper
    {
        public static TimeSlot ToTimeSlot(this SqlDataReader reader)
        {
            Period period = reader.ToPeriod();

            if (!int.TryParse(reader["SlotID"]?.ToString(), out int slotID))
            {
                slotID = 0;
            }
            if (!int.TryParse(reader["DayNum"]?.ToString(), out int day))
            {
                day = 0;
            }

            return new TimeSlot(slotID , (DayOfWeek)day , period);
        }
    }
}
