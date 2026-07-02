using Business.DTOs.Requests;

namespace Business.DTOs.Responses
{
    public class AdministratorResponse
    {
        public int AdminID { get; set; }

        public PersonRequest? Person { get; set; }

        public AccountResponse? Account { get; set; }

        public bool IsActive { get; set; }

        public AdministratorResponse(int adminID, PersonRequest? person, AccountResponse? account, bool isActive)
        {
            AdminID = adminID;
            Person = person;
            Account = account;
            IsActive = isActive;
        }
    }
}
