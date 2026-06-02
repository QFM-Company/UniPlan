using Business.DTOs.Requests;
using Business.DTOs.Responses;

namespace Business.Interfaces
{
    public interface IStudentService
    {
        Task<bool> DeleteStudentAsync(int studentID);

        Task<StudentProfileResponse?> AddStudentAsync(CreateStudentRequest request);

        Task<StudentProfileResponse?> UpdateStudentAsync(UpdateStudentRequest request);

        Task<IEnumerable<StudentProfileResponse>?> GetPagedStudentsAsync(int pageNumber = 1, int pageSize = 10);

        Task<StudentProfileResponse?> GetStudentByIDAsync(int studentID);
    }
}
