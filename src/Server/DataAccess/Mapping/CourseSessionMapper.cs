using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
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

            if (!int.TryParse(reader["AdminID"]?.ToString(), out int adminID))
            {
                adminID = -1;
            }

            if (!int.TryParse(reader["@SessionID"]?.ToString(), out int courseSessionID))
            {
                courseSessionID = -1;
            }

            return new CourseSession(courseSessionID , courseOffering , hall , timeSlot , adminID);
        }
    }
}
