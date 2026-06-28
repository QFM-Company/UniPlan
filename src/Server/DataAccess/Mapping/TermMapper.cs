using Core.Entities;
using Core.Enums;
using DataAccess.Extensions;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class TermMapper
    {
        public static AcademicTerm ToAcademicTerm(this SqlDataReader reader)
        {
            reader.ReadInt("TermID", out int termID, 0);
            reader.ReadInt("TermYear", out int termYear, 0);
            reader.ReadInt("TermType", out int termType, 0);

            return new AcademicTerm(termID, (TermType)termType, termYear);
        }
    }
}
