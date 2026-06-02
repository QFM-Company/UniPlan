namespace Business.DTOs.Responses
{
    public class StudentProfileResponse
    {
        public int PersonID { get; set; }

        public int StudentID { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string MiddleName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string AccountName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        
        public string MajorName { get; set; } = string.Empty;
    }
}
