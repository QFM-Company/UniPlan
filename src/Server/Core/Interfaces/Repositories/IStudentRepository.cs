using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        Task<bool> DeleteStudent(int studentID);

        Task<bool> AddStudent(Student student);

        Task<bool> UpdateStudent(Student student);

        Task<IEnumerable<Student>?> GetPagedStudents(int pageNumber = 1, int pageSize = 10);

        Task<Student?> GetStudentByID(int studentID);
    }
}
