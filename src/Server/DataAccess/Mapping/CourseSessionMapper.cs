using Core.Entities;
using DataAccess.Extensions;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class CourseSessionMapper
    {
        public static CourseSession ToCourseSession(this SqlDataReader reader)
        {
            Hall hall = reader.ToHall();

            CourseOffering courseOffering = reader.ToCourseOffering();

            reader.ReadTimeSpan("StartTime", out TimeSpan startTime);
            reader.ReadTimeSpan("EndTime", out TimeSpan endTime);
            reader.ReadInt("AdminID", out int adminID, -1);
            reader.ReadInt("SessionID", out int courseSessionID, -1);
            reader.ReadInt("DayNum", out int day, -1);

            return new CourseSession(courseSessionID, courseOffering, hall, startTime, endTime, adminID, (DayOfWeek)day);
        }
    }
}
