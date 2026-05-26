
namespace Core.Entities
{
    public class Person
    {
        public int PersonID { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string MiddleName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string FullName => FirstName + " " + MiddleName + " " + LastName;
    }
}
