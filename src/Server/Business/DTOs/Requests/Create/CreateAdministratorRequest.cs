using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests.Create
{
    public class CreateAdministratorRequest
    {
        [Required<int>("معرف الشخص مطلوب")]
        [Range<int>("يجب ان يكون المعرف اكبر تماما من 0", 1, int.MaxValue)]
        public int PersonID { get; set; }

        [Required<CreateAccountRequest>("معلومات الحساب مطلوبة")]
        public CreateAccountRequest? Account { get; set; }

        public CreateAdministratorRequest(int personID, CreateAccountRequest? account)
        {
            PersonID = personID;
            Account = account;
        }
    }
}
