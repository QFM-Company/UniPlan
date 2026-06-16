using Core.Entities;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class HallMapper
    {
        public static Hall ToHall(this SqlDataReader reader)
        {
            if (!int.TryParse(reader["HallID"]?.ToString(), out int hallID))
            {
                hallID = 0;
            }
            if (!int.TryParse(reader["CreatedByAdminID"]?.ToString(), out int createdByAdminID))
            {
                createdByAdminID = 0;
            }
            if (!int.TryParse(reader["Floor"]?.ToString(), out int floor))
            {
                floor = 0;
            }
            string hallName = reader["HallName"].ToString() ?? string.Empty;
            string building = reader["Building"].ToString() ?? string.Empty;

            return new Hall(hallID, hallName, building, floor, createdByAdminID);
        }
    }
}
