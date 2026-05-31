
using System;
using System.Data;
using Core.Entities;
using Core.Enums;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;
using Microsoft.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class AdminRepository : IAdminRepository
    {

        private readonly DBHelpers dBHelpers;
        private readonly ILogService _LogService;

        public AdminRepository(DBHelpers dBHelpers, ILogService logService, IExceptionService exceptionService)
        {
            this.dBHelpers = dBHelpers;
            _LogService = logService;
        }

        public async Task<int> AddAdmin(Administrator admin)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Admin_Profile_Insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var adminID = new SqlParameter("@AdministratorID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };


                    var accountID = new SqlParameter("@AccountID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };


                    command.Parameters.Add(adminID);
                    command.Parameters.Add(accountID);

                    command.Parameters.AddWithValue("@IsActive", admin.IsActive);

                    if (admin.Person == null) throw new ArgumentNullException(nameof(admin.Person), "Person is Null"); ;
                    command.Parameters.AddWithValue("@PersonID", admin.Person.PersonID);
                    if (admin.Account == null) throw new ArgumentNullException(nameof(admin.Account), "Account is Null"); ;
                    command.Parameters.AddWithValue("@AccountName", admin.Account.AccountName);
                    command.Parameters.AddWithValue("@Password", admin.Account.Password);
                    command.Parameters.AddWithValue("@Email", admin.Account.Email);


                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();


                    if (adminID.Value != DBNull.Value && int.TryParse(adminID.Value.ToString(), out int admID))
                    {
                        return admID;
                    }

                }
            }
            catch (Exception ex)
            {
                await _LogService.Log(ex);
            }

            return -1;
        }


        public async Task<bool> UpdateAdmin(Administrator admin)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Admin_Profile_Update", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var result = new SqlParameter("@Result", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(result);

                    command.Parameters.AddWithValue("@IsActive", admin.IsActive);
                    command.Parameters.AddWithValue("@AdministratorID", admin.AdminID);
                    if (admin.Account == null) throw new ArgumentNullException(nameof(admin.Account), "Account is Null"); ;
                    command.Parameters.AddWithValue("@AccountName", admin.Account.AccountName);
                    command.Parameters.AddWithValue("@Password", admin.Account.Password);
                    command.Parameters.AddWithValue("@Email", admin.Account.Email);
                    if (admin.Person == null) throw new ArgumentNullException(nameof(admin.Person), "Person is Null"); ;
                    command.Parameters.AddWithValue("@FirstName", admin.Person.FirstName);
                    command.Parameters.AddWithValue("@LastName", admin.Person.LastName);
                    command.Parameters.AddWithValue("@MiddleName", admin.Person.MiddleName ?? (object)DBNull.Value);

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
                await _LogService.Log(ex);
            }

            return false;
        }

        public async Task<bool> DeleteAdmin(int adminID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_AdminProfile_Delete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var result = new SqlParameter("@Result", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(result);
                    command.Parameters.AddWithValue("@AdministratorID", adminID);

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
                await _LogService.Log(ex);
            }
            return false;
        }

        public async Task<Administrator?> GetAdminByID(int adminID)
        {
            Administrator? admin = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_AdminProfile_GetById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AdminID", adminID);

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader != null)
                        {
                            await reader.ReadAsync();
                            
                            int personID = reader["PersonID"] != DBNull.Value ? Convert.ToInt32(reader["PersonID"]) : -1; 
                            int accountID = reader["AccountID"] != DBNull.Value ? Convert.ToInt32(reader["AccountID"]) : -1; 
                            bool isActive = reader["IsActive"] != DBNull.Value ? Convert.ToBoolean(reader["IsActive"]) : false;
                            string accoutName = reader["AccountName"].ToString() ?? string.Empty;
                            string email = reader["Email"].ToString() ?? string.Empty;
                            string firstName = reader["FirstName"].ToString() ?? string.Empty;
                            string lastName = reader["LastName"].ToString() ?? string.Empty;
                            string middelName = reader["MiddleName"].ToString() ?? string.Empty;
                            admin = new Administrator(adminID , new Person(personID , firstName , middelName , lastName) , new Account(accoutName , email) , isActive);
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                await _LogService.Log(ex);
            }

            return admin;
        }

        public async Task<IReadOnlyCollection<Administrator>?> GetPageAdmins(int pageNumber = 1, int pageSize = 10)
        {
            List<Administrator>? admins = new List<Administrator>();

            try
            {
                using (SqlConnection connection = new SqlConnection(dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Administrators_GetAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PageNumber", pageNumber);
                    command.Parameters.AddWithValue("@PageSize", pageSize);

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader != null)
                        {
                            while (await reader.ReadAsync())
                            {
                                int adminID = reader["AdminID"] != DBNull.Value ? Convert.ToInt32(reader["AdminID"]) : -1;
                                int personID = reader["PersonID"] != DBNull.Value ? Convert.ToInt32(reader["PersonID"]) : -1;
                                int accountID = reader["AccountID"] != DBNull.Value ? Convert.ToInt32(reader["AccountID"]) : -1;
                                bool isActive = reader["IsActive"] != DBNull.Value ? Convert.ToBoolean(reader["IsActive"]) : false;
                                string accoutName = reader["AccountName"].ToString() ?? string.Empty;
                                string email = reader["Email"].ToString() ?? string.Empty;
                                string firstName = reader["FirstName"].ToString() ?? string.Empty;
                                string lastName = reader["LastName"].ToString() ?? string.Empty;
                                string middelName = reader["MiddleName"].ToString() ?? string.Empty;
                       
                                Administrator admin = new Administrator(adminID, new Person(personID, firstName, middelName, lastName), new Account(accoutName, email), isActive);
                                admins.Add(admin);
                            }
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                await _LogService.Log(ex);
            }

            return admins;
        }


    }
}
