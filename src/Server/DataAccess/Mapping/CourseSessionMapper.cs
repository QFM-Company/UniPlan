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
            reader.ReadInt("SCreatedByAdminID", out int sadminID, -1);
            reader.ReadInt("SessionID", out int courseSessionID, -1);
            reader.ReadInt("DayNum", out int day, -1);


            reader.ReadInt("CCreatedByAdminID", out int cadminID, -1);

            courseOffering.CreatedByAdminID = cadminID;

            reader.ReadInt("HCreatedByAdminID", out int hadminID, -1);

            hall.CreatedByAdminID = hadminID;


            return new CourseSession(courseSessionID, courseOffering, hall, startTime, endTime, sadminID, (DayOfWeek)day);
        }
    }
}
