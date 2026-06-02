namespace Business.DTOs.Requests
{
    public class CreateStudentRequest : UpdateStudentRequest
    {
        public string Password { get; set; } = string.Empty;
    }
}
