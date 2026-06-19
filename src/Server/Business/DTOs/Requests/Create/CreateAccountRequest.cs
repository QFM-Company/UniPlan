namespace Business.DTOs.Requests.Create
{
    public class CreateAccountRequest
    {
        public string AccountName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public CreateAccountRequest(string accountName, string password, string email) 
        {
            AccountName = accountName;
            Email = email;
            Password = password;
        }

        public CreateAccountRequest() 
        {
            AccountName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
        }
    }
}
