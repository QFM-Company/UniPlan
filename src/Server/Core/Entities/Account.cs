
namespace Core.Entities
{
    public class Account
    {
        public int AccountID { get; set; }

        public string AccountName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public Account(string accountName, string email)
        {
            AccountName = accountName;
            Email = email;
        }

        public Account(string accountName, string password, string email) : this(accountName, email)
        {
            Password = password;
        }
    }
}
