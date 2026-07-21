using Infrastructure.ExternalServices.Validation.Attributes;

namespace Client.Models.Requests
{
    public class AdministratorRequest : BaseModel
    {
        [Required<int>("معرف الشخص مطلوب")]
        [Range<int>("يجب ان يكون المعرف اكبر تماما من 0", 1, int.MaxValue)]
        public int PersonID { get; set; }

        [Required<AccountRequest>("معلومات الحساب مطلوبة")]
        public AccountRequest? Account { get; set; }

        public AdministratorRequest(int personID, AccountRequest? account)
        {
            PersonID = personID;
            Account = account;
        }
    }
}
