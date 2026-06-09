using Business.DTOs.Requests.Create;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;
using Business.Interfaces;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace Business.Services
{
    public class StudentService : IStudentService
    {
        private IStudentRepository _studentRepository;
        private Student? _student;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            _student = null;
        }

        private Student? _CreateRequestToStudent(CreateStudentRequest request)
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

        private Student? _UpdateRequestToStudent(UpdateStudentRequest request)
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

        private StudentProfileResponse? _StudentToResponse(Student? student)
        {
            StudentProfileResponse? response = null;

            if(student != null && student.Person != null && student.Account != null && student.Major != null)
            {
                response = new StudentProfileResponse(student.Person.PersonID,student.StudentID,student.Person.FirstName,
                    student.Person.MiddleName,student.Person.LastName,student.Account.AccountName,student.Account.Email,
                    student.Major.MajorName);

            }

            return response;
        }

        public async Task<StudentProfileResponse?> AddStudentAsync(CreateStudentRequest request)
        {
            _student = _CreateRequestToStudent(request);

            if(_student != null)
            {
                if(await _studentRepository.AddStudentAsync(_student))
                {
                    return await GetStudentByIDAsync(_student.StudentID);
                }
            }

            return null;
        }

        public async Task<StudentProfileResponse?> UpdateStudentAsync(UpdateStudentRequest request)
        {
            _student = _UpdateRequestToStudent(request);

            if (_student != null)
            {
                if(await _studentRepository.UpdateStudentAsync(_student))
                {
                    return await GetStudentByIDAsync(_student.StudentID);
                }
            }

            return null;
        }

        public async Task<StudentProfileResponse?> GetStudentByIDAsync(int studentID)
        {
            StudentProfileResponse? response = null;
            
            _student = await _studentRepository.GetStudentByIDAsync(studentID);
            
            if (_student != null)
            {
                response = _StudentToResponse(_student);
            }

            return response;
        }

        public async Task<bool> DeleteStudentAsync(int studentID)
        {
            return await _studentRepository.DeleteStudentAsync(studentID);
        }

        public async Task<IEnumerable<StudentProfileResponse>?> GetPagedStudentsAsync(int pageNumber = 1, int pageSize = 10)
        {
            IEnumerable<Student>? students = await _studentRepository.GetPagedStudentsAsync(pageNumber, pageSize);
            return students?.Select(s => _StudentToResponse(s)).OfType<StudentProfileResponse>();
        }
    }
}
