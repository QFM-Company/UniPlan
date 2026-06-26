using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
