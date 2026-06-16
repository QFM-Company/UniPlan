using Core.Entities;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class StudentMapper
    {
        public static Student ToStudent(this SqlDataReader reader)
        {
            Person person = reader.ToPerson();
            Account account = reader.ToAccount();
            Major major = reader.ToMajor();

            if (!int.TryParse(reader["StudentID"]?.ToString(), out int studentID))
            {
                studentID = 0;
            }

            return new Student(studentID, person, account, major);
        }
    }
}
