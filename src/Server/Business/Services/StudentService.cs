using Business.DTOs.Requests;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace Business.Services
{
    public class StudentService
    {
        private IStudentRepository _studentRepository;
        private Student? _student;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            _student = null;
        }
        private Student? CreateRequestToStudent(CreateStudentRequest request)
        {
            Student? student = null;

            if(request != null)
            {
                Person person = new Person(request.FirstName, request.MiddleName, request.LastName);
                Account account = new Account(request.AccountName, request.Password, request.Email);
                student = new Student(request.StudentID, person, account, new Major { MajorID = request.MajorID });
            }

            return student;
        }

        private Student? UpdateRequestToStudent(UpdateStudentRequest request)
        {
            Student? student = null;

            if(request != null)
            {
                Person person = new Person(request.FirstName, request.MiddleName, request.LastName);
                Account account = new Account(request.AccountName, request.Email);
                student = new Student(request.StudentID, person, account, new Major { MajorID = request.MajorID });
            }

            return student;
        }

        public async Task<bool> AddStudentAsync(CreateStudentRequest request)
        {
            _student = CreateRequestToStudent(request);

            if(_student != null)
            {
                return await _studentRepository.AddStudentAsync(_student);
            }

            return false;
        }

        async Task<bool> UpdateStudentAsync(UpdateStudentRequest request)
        {
            _student = UpdateRequestToStudent(request);

            if (_student != null)
            {
                return await _studentRepository.UpdateStudentAsync(_student);
            }

            return false;
        }
    }
}
