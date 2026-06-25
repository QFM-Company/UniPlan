using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IStudentCourseRepository
    {
        Task<int> AddStudentCourseAsync(StudentCourse studentCourse);

        Task<bool> UpdateStudentCourseAsync(StudentCourse studentCourse);

        Task<bool> DeleteStudentCourseAsync(int enrolmentID);

        Task<StudentCourse?> GetStudentCourseByIDAsync(int enrolmentID);

        Task<IEnumerable<StudentCourse>?> GetStudentCoursesByStudentIDAsync(int studentID);
    }
}
}
