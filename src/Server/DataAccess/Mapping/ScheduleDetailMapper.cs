using Core.Entities;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class ScheduleDetailMapper
    {
        public static ScheduleDetail ToScheduleDetail(this SqlDataReader reader)
        {
            if (!int.TryParse(reader["DetailID"]?.ToString(), out int detailID))
            {
                detailID = 0;
            }
            
            GeneratedSchedule schedule = reader.ToGeneratedSchedule();
            CourseOffering offering = reader.ToCourseOffering();

            return new ScheduleDetail(detailID, schedule, offering);
        }
    }
}
