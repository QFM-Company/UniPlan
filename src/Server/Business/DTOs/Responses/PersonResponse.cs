namespace Business.DTOs.Responses
{
    public class PersonResponse
    {
        public int PersonID { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string MiddleName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string FullName => FirstName + " " + MiddleName + " " + LastName;


        public PersonResponse()
        {
            PersonID = -1;
            FirstName = string.Empty;
            MiddleName = string.Empty;
            LastName = string.Empty;
        }

        public PersonResponse(int personID, string firstName, string middleName, string lastName)
        {
            PersonID = personID;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }
    }
}
