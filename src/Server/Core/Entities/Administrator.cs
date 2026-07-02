namespace Core.Entities
{
    public class Administrator
    {
        public int AdminID { get; set; }

        public Person? Person { get; set; }

        public Account? Account { get; set; }

        public bool IsActive { get; set; }



        public Administrator(int adminID, Person? person, Account? account, bool isActive)
        {
            AdminID = adminID;
            Person = person;
            Account = account;
            IsActive = isActive;
        }
        public Administrator()
        {
        }
    }
}
