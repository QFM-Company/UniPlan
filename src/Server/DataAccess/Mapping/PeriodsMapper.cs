using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using DataAccess.Extensions;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class PeriodsMapper
    {
        public static Period ToPeriod(this SqlDataReader reader)
        {
            reader.ReadInt("PeriodID", out int periodID, -1);
            reader.ReadTimeSpan("StartTime", out TimeSpan startTime);
            reader.ReadTimeSpan("EndTime", out TimeSpan endTime);

            return new Period(periodID, startTime, endTime);
        }
    }
}
