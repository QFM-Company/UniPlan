using Core.Entities;
using DataAccess.Extensions;
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

            reader.ReadInt("StudentID", out int studentID, 0);

            return new Student(studentID, person, account, major);
        }
    }
}
