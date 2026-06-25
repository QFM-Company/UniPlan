
using Core.Entities;
using Core.Enums;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class StudentTermMapper
    {
        public static StudentTerm ToStudentTerm(this SqlDataReader reader)
        {
            AcademicTerm academicTerm = reader.ToAcademicTerm();

            int.TryParse(reader["StudentID"]?.ToString(), out int studentID);

            if (!int.TryParse(reader["RegistrationID"]?.ToString(), out int registrationID))
            {
                registrationID = 0;
            }

            return new StudentTerm(registrationID , studentID , academicTerm);
        }

    }
}
