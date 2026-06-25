using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IStudentTermRepository
    {
        Task<int> AddStudentTermAsync(StudentTerm studentTerm);

        Task<StudentTerm?> GetStudentTermByIDAsync(int registrationID);

        Task<IEnumerable<StudentTerm>?> GetStudentTermsByStudentIDAsync(int studentID);

    }
}
