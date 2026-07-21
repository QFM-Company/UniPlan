using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests.Update
{
    public class UpdateAccountRequest
    {

        [Required<string>("اسم المستخدم مطلوب")]
        [Length("يجب ألا يتجاوز اسم المستخدم 50 حرفًا", 50, 3)]
        public string AccountName { get; set; } = string.Empty;

        [Required<string>("البريد الإلكتروني مطلوب")]
        [Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", "صيغة البريد الإلكتروني غير صحيحة")]
        [Length("يجب ألا يتجاوز البريد الإلكتروني 255 حرفًا", 255, 5)]
        public string Email { get; set; } = string.Empty;
    }
}