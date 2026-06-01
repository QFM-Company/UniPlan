namespace Business.DTOs.Requests
{
    public class PersonRequest
    {
        public int PersonID { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string MiddleName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
    }
}
