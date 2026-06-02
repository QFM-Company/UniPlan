
namespace Core.Entities
{
    public class Person
    {

        public int PersonID { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string MiddleName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string FullName => FirstName + " " + MiddleName + " " + LastName;

        public Person(int personID, string firstName, string middleName, string lastName)
        {
            PersonID = personID;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        public Person(string firstName, string middleName, string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }
    }
}
