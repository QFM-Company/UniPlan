namespace Business.DTOs.Responses
{
    public class AdministratorResponse
    {
        public int AdminID { get; set; }

        public PersonResponse? Person { get; set; }

        public AccountResponse? Account { get; set; }

        public bool IsActive { get; set; }

        public AdministratorResponse(int adminID, PersonResponse? person, AccountResponse? account, bool isActive)
        {
            AdminID = adminID;
            Person = person;
            Account = account;
            IsActive = isActive;
        }
    }
}
