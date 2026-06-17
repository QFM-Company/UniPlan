using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class PeriodsMapper
    {
        public static Period ToPeriod(this SqlDataReader reader)
        {

            if (!int.TryParse(reader["PeriodID"]?.ToString(), out int periodID))
            {
                periodID = 0;
            }
            TimeSpan startTime = reader["StartTime"] is TimeSpan start ? start : TimeSpan.Parse(reader["StartTime"].ToString()!);
            TimeSpan endTime = reader["EndTime"] is TimeSpan end ? end : TimeSpan.Parse(reader["EndTime"].ToString()!);

            return new Period(periodID, startTime, endTime);
        }
    }
}
