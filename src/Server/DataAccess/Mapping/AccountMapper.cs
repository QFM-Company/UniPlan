using Core.Entities;
using Microsoft.Data.SqlClient;

namespace DataAccess.Mapping
{
    public static class AccountMapper
    {
        public static Account ToAccount(this SqlDataReader reader)
        {
            if (!int.TryParse(reader["AccountID"]?.ToString(), out int accountID))
            {
                accountID = 0;
            }
            string accountName = reader["AccountName"].ToString() ?? string.Empty;
            string email = reader["Email"].ToString() ?? string.Empty;

            return new Account(accountID, accountName, email);
        }
    }
}
