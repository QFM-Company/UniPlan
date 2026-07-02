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

            TimeSlot timeSlot = reader.ToTimeSlot();

            reader.ReadInt("AdminID", out int adminID, -1);
            reader.ReadInt("SessionID", out int courseSessionID, -1);

            return new CourseSession(courseSessionID, courseOffering, hall, timeSlot, adminID);
        }
    }
}
