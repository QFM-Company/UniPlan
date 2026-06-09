namespace Business.DTOs.Requests.Update
{
    public class UpdateStudentRequest
    {
        public string FirstName { get; set; } = string.Empty;

        public string MiddleName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string AccountName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int StudentID { get; set; }

        public int MajorID { get; set; }
    }
}
