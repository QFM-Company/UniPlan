using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests.Create
{
    public class CreateAccountRequest
    {
        [Required<string>("Account name is required")]
        [Length("Account name cannot exceed 50 characters.", 50, 3)]
        public string AccountName { get; set; } = string.Empty;

        [Required<string>("password is required")]
        [Length("Password must be between 8 and 50 characters long.", 50, 8)]
        [Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$", 
            "Password must include an uppercase letter, a lowercase letter, a number, and a special character.")]
        public string Password { get; set; } = string.Empty;


        [Required<string>("Email is required")]
        [Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", "Invalid email format.")]
        [Length("Email cannot exceed 255 characters.", 255, 5)]
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
