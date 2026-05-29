
using System.Data;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class AdminRepository //: IAdminRepository
    {

        public readonly DBHelpers dBHelpers;

        public AdminRepository(DBHelpers dBHelpers)
        {
            this.dBHelpers = dBHelpers;
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

                    if (admin.Person == null) throw new ArgumentNullException(nameof(admin.Person), "Person is Not choosed to Add Admin"); ;
                    command.Parameters.AddWithValue("@PersonID", admin.Person.PersonID);
                    if (admin.Account == null) throw new ArgumentNullException(nameof(admin.Account), "Account is Not choosed to Add Admin"); ;
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
                // log(ex);
            }

            return -1;
        }

    }
}
