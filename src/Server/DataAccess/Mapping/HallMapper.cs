using Core.Entities;
using DataAccess.Extensions;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class HallMapper
    {
        public static Hall ToHall(this SqlDataReader reader)
        {
            reader.ReadInt("HallID", out int hallID, 0);
            reader.ReadString("HallName", out string hallName, string.Empty);
            reader.ReadInt("CreatedByAdminID", out int createdByAdminID, 0);
            reader.ReadInt("Floor", out int floor, 0);
            reader.ReadString("Building", out string building, string.Empty);

            return new Hall(hallID, hallName, building, floor, createdByAdminID);
        }
    }
}
