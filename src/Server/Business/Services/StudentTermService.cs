using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Requests;
using Business.DTOs.Requests.Create;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;
using Business.Interfaces;
using Business.Mapper;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace Business.Services
{
    public class StudentTermService : IStudentTermService
    {
        private IStudentTermRepository _studentTermRepository;

        public StudentTermService(IStudentTermRepository studentTermRepository)
        {
            _studentTermRepository = studentTermRepository;
        }

        public async Task<StudentTermResponse?> AddStudentTermAsync(StudentTermRequest request)
        {
            StudentTerm studentTerm = request.ToStudentTerm();

            studentTerm.RegistrationID = await _studentTermRepository.AddStudentTermAsync(studentTerm);

            if (studentTerm.RegistrationID > 0)
                return await GetStudentTermByIDAsync(studentTerm.RegistrationID);

            return null;
        }

        public async Task<IEnumerable<StudentTermResponse>?> GetStudentTermsByStudentIDAsync(int studentID)
        {
            IEnumerable<StudentTerm>? studentTerms = await _studentTermRepository.GetStudentTermsByStudentIDAsync(studentID);
            return studentTerms?.Select(m => m.ToResponse());
        }

        public async Task<StudentTermResponse?> GetStudentTermByIDAsync(int registrationID)
        {
            StudentTerm? studentTerm = await _studentTermRepository.GetStudentTermByIDAsync(registrationID);
            return studentTerm != null ? studentTerm.ToResponse() : null;
        }

    }
}
