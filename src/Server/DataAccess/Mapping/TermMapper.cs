using Core.Entities;
using Core.Enums;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class TermMapper
    {
        public static AcademicTerm ToAcademicTerm(this SqlDataReader reader)
        {
            if (!int.TryParse(reader["TermID"]?.ToString(), out int termID))
            {
                termID = 0;
            }
            if (!int.TryParse(reader["TermYear"]?.ToString(), out int termYear))
            {
                termYear = 0;
            }
            if (!int.TryParse(reader["TermType"]?.ToString(), out int termType))
            {
                termType = 0;
            }

            return new AcademicTerm(termID, (TermType)termType, termYear);
        }
    }
}
