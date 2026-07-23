using Infrastructure.ExternalServices.Validation.Attributes;

namespace Client.Models.Requests
{
    public class LoginRequest : Person
    {
        [Required<string>("اسم المستخدم مطلوب")]
        [Length("يجب ألا يتجاوز الاسم 50 حرفًا", 50, 1)]
        public string AccountName { get; set; }

        [Required<string>("كلمة المرور مطلوبة")]
        [Length("يجب ألا تتجاوز كلمة المرور 255 حرفًا", 255, 1)]
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