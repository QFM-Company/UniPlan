using Core.Entities;
using DataAccess.Extensions;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class MajorMapper
    {
        public static Major ToMajor(this SqlDataReader reader)
        {
            reader.ReadInt("MajorID", out int majorID, 0);
            reader.ReadString("MajorName", out string majorName, string.Empty);

            return new Major(majorID, majorName);
        }
    }
}
