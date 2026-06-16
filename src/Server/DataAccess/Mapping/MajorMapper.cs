using Core.Entities;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class MajorMapper
    {
        public static Major ToMajor(this SqlDataReader reader)
        {
            if (!int.TryParse(reader["MajorID"]?.ToString(), out int majorID))
            {
                majorID = 0;
            }

            string majorName = reader["MajorName"].ToString() ?? string.Empty;

            return new Major(majorID, majorName);
        }
    }
}
