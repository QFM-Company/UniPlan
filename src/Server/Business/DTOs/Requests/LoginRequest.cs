namespace Business.DTOs.Requests
{
    public class LoginRequest
    {
        public string AccountName { get; set; }

        public string Password { get; set; }

        public LoginRequest()
        {
            AccountName = string.Empty;
            Password = string.Empty;
        }

        public LoginRequest(string accountName, string password)
        {
            AccountName = accountName;
            Password = password;
        }
    }
}
