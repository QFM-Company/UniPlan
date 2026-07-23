using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests.Update
{
    public class UpdateAdministratorRequest
    {
        [Required<UpdateAccountRequest>("معلومات الحساب مطلوبة")]
        public UpdateAccountRequest? Account { get; set; }

        [Required<PersonRequest>("معلومات الشخص مطلوبة")]
        public PersonRequest Person { get; set; }

        public UpdateAdministratorRequest(UpdateAccountRequest? account , PersonRequest person)
        {
            Account = account;
            Person = person;
        }
    }
}
