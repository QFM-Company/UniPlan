using Business.DTOs.Requests.Update;

namespace Business.DTOs.Requests.Create
{
    public class CreateStudentRequest : UpdateStudentRequest
    {
        public string Password { get; set; } = string.Empty;
    }
}
