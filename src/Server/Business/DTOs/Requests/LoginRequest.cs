using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests
{
    public class LoginRequest
    {
        [Required<string>("«”„ «·„” Œœ„ „ÿ·Ê»")]
        [Length("ÌÃ» √·« Ì Ã«Ê“ «·«”„ 50 Õ—›«", 50, 1)] 
        public string AccountName { get; set; }

        [Required<string>("ﬂ·„… «·„—Ê— „ÿ·Ê»…")]
        [Length("ÌÃ» √·«   Ã«Ê“ ﬂ·„… «·„—Ê— 255 Õ—›«", 255, 1)]
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