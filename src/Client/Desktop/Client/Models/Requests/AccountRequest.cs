using Infrastructure.ExternalServices.Validation.Attributes;

namespace Client.Models.Requests
{
    public class AccountRequest : Person
    {
        [Required<string>("اسم المستخدم مطلوب")]
        [Length("يجب ألا يتجاوز اسم المستخدم 50 حرفًا", 50, 3)]
        public string AccountName { get; set; } = string.Empty;

        [Required<string>("كلمة المرور مطلوبة")]
        [Length("يجب أن تكون كلمة المرور بين 8 و 50 حرفًا", 50, 8)]
        [Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]+$", "يجب أن تحتوي كلمة المرور على حرف كبير وحرف صغير ورقم")]
        public string Password { get; set; } = string.Empty;

        [Required<string>("البريد الإلكتروني مطلوب")]
        [Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", "صيغة البريد الإلكتروني غير صحيحة")]
        [Length("يجب ألا يتجاوز البريد الإلكتروني 255 حرفًا", 255, 5)]
        public string Email { get; set; } = string.Empty;

        public AccountRequest(string accountName, string password, string email)
        {
            AccountName = accountName;
            Email = email;
            Password = password;
        }

        public AccountRequest()
        {
            AccountName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
        }
    }
}