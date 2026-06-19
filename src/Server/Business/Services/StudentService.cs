using Business.DTOs.Requests.Create;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;
using Business.Interfaces;
using Business.Mapper;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace Business.Services
{
    public class StudentService : IStudentService
    {
        private IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<bool> DeleteStudentAsync(int studentID)
        {
            return await _studentRepository.DeleteStudentAsync(studentID);
        }

        public async Task<StudentResponse?> AddStudentAsync(CreateStudentRequest request)
        {
            Student student = request.ToStudent();

            if (await _studentRepository.AddStudentAsync(student))
                return await GetStudentByIDAsync(student.StudentID);

            return null;
        }

        public async Task<bool> UpdateStudentAsync(UpdateStudentRequest request, int studentID)
        {
            Student? student = await _studentRepository.GetStudentByIDAsync(studentID);

            student?.UpdateStudent(request);

            if (student != null)
                return await _studentRepository.UpdateStudentAsync(student);

            return false;
        }

        public async Task<IEnumerable<StudentResponse>?> GetPagedStudentsAsync(int pageNumber = 1, int pageSize = 10)
        {
            IEnumerable<Student>? students = await _studentRepository.GetPagedStudentsAsync(pageNumber, pageSize);
            return students?.Select(m => m.ToResponse()).OfType<StudentResponse>();
        }

        public async Task<StudentResponse?> GetStudentByIDAsync(int studentID)
        {
            Student? student = await _studentRepository.GetStudentByIDAsync(studentID);
            return student != null ? student.ToResponse() : null;
        }
    }
}
