using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Requests.Create;
using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests.Update
{
    public class UpdateAdministratorRequest
    {

        [Required<int>("معرف الشخص مطلوب")]
        [Range<int>("يجب ان يكون المعرف اكبر تماما من 0", 1, int.MaxValue)]
        public int PersonID { get; set; }
        [Required<CreateAccountRequest>("معلومات الحساب مطلوبة")]
        public UpdateAccountRequest? Account { get; set; }

        public UpdateAdministratorRequest(int personID, UpdateAccountRequest? account)
        {
            PersonID = personID;
            Account = account;
        }
    }
}
