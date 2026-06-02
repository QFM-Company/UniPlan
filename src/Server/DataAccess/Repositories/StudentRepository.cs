using Core.Entities;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;


namespace DataAccess.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public readonly DBHelpers _dBHelpers;
        private readonly ILogService _logService;

        public StudentRepository(DBHelpers dBHelpers, ILogService logService)
        {
            _dBHelpers = dBHelpers;
            _logService = logService;
        }

        public async Task<bool> AddStudentAsync(Student student)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_StudentProfile_Insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var accountID = new SqlParameter("@AccountID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    var personID = new SqlParameter("@PersonID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    var result = new SqlParameter("@Result", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(personID);
                    command.Parameters.Add(accountID);
                    command.Parameters.Add(result);

                    command.Parameters.AddWithValue("@AccountName", student.Account?.AccountName);
                    command.Parameters.AddWithValue("@Password", student.Account?.Password);
                    command.Parameters.AddWithValue("@Email", student.Account?.Email);
                    command.Parameters.AddWithValue("@StudentID", student.StudentID);
                    command.Parameters.AddWithValue("@MajorID", student.Major?.MajorID);
                    command.Parameters.AddWithValue("@FirstName", student.Person?.FirstName);
                    command.Parameters.AddWithValue("@MiddleName", student.Person?.MiddleName != null ? student.Person?.MiddleName : DBNull.Value);
                    command.Parameters.AddWithValue("@LastName", student.Person?.LastName);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    if (personID.Value != DBNull.Value && int.TryParse(personID.Value.ToString(), out int pID) && student.Person != null)
                    {
                        student.Person.PersonID = pID;
                    }

                    if (accountID.Value != DBNull.Value && int.TryParse(accountID.Value.ToString(), out int aID) && student.Account != null)
                    {
                        student.Account.AccountID = aID;
                    }

                    if (result.Value != DBNull.Value && bool.TryParse(result.Value.ToString(), out bool res))
                    {
                        return res;
                    }
                }
            }
            catch (Exception ex)
            {
                await _logService.Log(ex);
            }

            return false;
        }

        public async Task<bool> UpdateStudentAsync(Student student)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_StudentProfile_Update", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var result = new SqlParameter("@Result", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(result);

                    command.Parameters.AddWithValue("@AccountName", student.Account?.AccountName);
                    command.Parameters.AddWithValue("@Password", student.Account?.Password);
                    command.Parameters.AddWithValue("@Email", student.Account?.Email);
                    command.Parameters.AddWithValue("@StudentID", student.StudentID);
                    command.Parameters.AddWithValue("@MajorID", student.Major?.MajorID);
                    command.Parameters.AddWithValue("@FirstName", student.Person?.FirstName);
                    command.Parameters.AddWithValue("@MiddleName", student.Person?.MiddleName != null ? student.Person?.MiddleName : DBNull.Value);
                    command.Parameters.AddWithValue("@LastName", student.Person?.LastName);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    if (result.Value != DBNull.Value && bool.TryParse(result.Value.ToString(), out bool res))
                    {
                        return res;
                    }
                }
            }
            catch (Exception ex)
            {
                await _logService.Log(ex);
            }

            return false;
        }

        public async Task<bool> DeleteStudentAsync(int studentID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_StudentProfile_Delete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var result = new SqlParameter("@Result", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(result);
                    command.Parameters.AddWithValue("@StudentID", studentID);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    if (result.Value != DBNull.Value && bool.TryParse(result.Value.ToString(), out bool res))
                    {
                        return res;
                    }
                }
            }
            catch (Exception ex)
            {
                await _logService.Log(ex);
            }

            return false;
        }

        public async Task<Student?> GetStudentByIDAsync(int studentID)
        {
            Student? student = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_StudentProfile_GetById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StudentID", studentID);

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if(reader != null)
                        {
                            await reader.ReadAsync();
                            if (!int.TryParse(reader["PersonID"]?.ToString(), out int personID))
                            {
                                personID = 0;
                            }
                            string firstName = reader["FirstName"].ToString() ?? string.Empty;
                            string middleName = reader["MiddleName"].ToString() ?? string.Empty;
                            string lastName = reader["LastName"].ToString() ?? string.Empty;
                            string accountName = reader["AccountName"].ToString() ?? string.Empty;
                            string email = reader["Email"].ToString() ?? string.Empty;
                            string majorName = reader["MajorName"].ToString() ?? string.Empty;

                            student = new Student(studentID, new Person(personID, firstName, middleName, lastName), new Account(accountName, email), new Major { MajorName = majorName});
                        }
                    }

          
                }
            }
            catch (Exception ex)
            {
                await _logService.Log(ex);
            }

            return student;
        }

        public async Task<IEnumerable<Student>?> GetPagedStudentsAsync(int pageNumber = 1 , int pageSize = 10)
        {
            List<Student>? students = new List<Student>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_StudentProfile_GetAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PageNumber", pageNumber);
                    command.Parameters.AddWithValue("@PageSize", pageSize);

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if(reader != null)
                        {
                           while(await reader.ReadAsync())
                           {
                                if (!int.TryParse(reader["PersonID"]?.ToString(), out int personID))
                                {
                                    personID = 0;
                                }
                                if (!int.TryParse(reader["StudentID"]?.ToString(), out int studentID))
                                {
                                    studentID = 0;
                                }
                                string firstName = reader["FirstName"].ToString() ?? string.Empty;
                                string middleName = reader["MiddleName"].ToString() ?? string.Empty;
                                string lastName = reader["LastName"].ToString() ?? string.Empty;
                                string accountName = reader["AccountName"].ToString() ?? string.Empty;
                                string email = reader["Email"].ToString() ?? string.Empty;
                                string majorName = reader["MajorName"].ToString() ?? string.Empty;

                                Student? student = new Student(studentID, new Person(personID, firstName, middleName, lastName), new Account(accountName, email), new Major { MajorName = majorName });
                                students.Add(student);
                            }
                        }
                    }

          
                }
            }
            catch (Exception ex)
            {
                await _logService.Log(ex);
            }

            return students;
        }

    }
}
