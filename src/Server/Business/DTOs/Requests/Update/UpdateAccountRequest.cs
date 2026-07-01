using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests.Update
{
    public class UpdateAccountRequest
    {
        [Required<int>("معرف الحساب مطلوب")]
        [Range<int>("يجب أن يكون المعرف أكبر من 0", 1, int.MaxValue)]
        public int AccountID { get; set; }

        [Required<string>("اسم المستخدم مطلوب")]
        [Length("يجب ألا يتجاوز اسم المستخدم 50 حرفًا", 50, 3)]
        public string AccountName { get; set; } = string.Empty;

        [Required<string>("البريد الإلكتروني مطلوب")]
        [Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", "صيغة البريد الإلكتروني غير صحيحة")]
        [Length("يجب ألا يتجاوز البريد الإلكتروني 255 حرفًا", 255, 5)]
        public string Email { get; set; } = string.Empty;

        public UpdateAccountRequest(int accountID, string accountName, string email)
        {
            AccountID = accountID;
            AccountName = accountName;
            Email = email;
        }

        public UpdateAccountRequest()
        {
            AccountID = -1;
            AccountName = string.Empty;
            Email = string.Empty;
        }
    }
}