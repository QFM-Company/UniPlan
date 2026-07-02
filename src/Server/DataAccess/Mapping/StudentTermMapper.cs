
using Core.Entities;
using DataAccess.Extensions;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class StudentTermMapper
    {
        public static StudentTerm ToStudentTerm(this SqlDataReader reader)
        {
            AcademicTerm academicTerm = reader.ToAcademicTerm();

            reader.ReadInt("StudentID", out int studentID, -1);
            reader.ReadInt("RegistrationID", out int registrationID, -1);

            return new StudentTerm(registrationID, studentID, academicTerm);
        }

    }
}
