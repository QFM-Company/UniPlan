using Business.DTOs.Requests;
using Business.DTOs.Responses;

namespace Business.Interfaces
{
    public interface IStudentTermService
    {
        Task<StudentTermResponse?> AddStudentTermAsync(StudentTermRequest request);

        Task<IEnumerable<StudentTermResponse>?> GetStudentTermsByStudentIDAsync(int studentID);

        Task<StudentTermResponse?> GetStudentTermByIDAsync(int registrationID);
    }
}
