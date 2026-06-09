using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface ILectureRepository
    {
        Task<bool> DeleteLectureAsync(int lectureID);

        Task<int> AddLectureAsync(Lecture lecture);

        Task<bool> UpdateLectureAsync(Lecture lecture);

        Task<IEnumerable<Lecture>?> GetPagedLecturesAsync(int pageNumber = 1, int pageSize = 10);

        Task<Lecture?> GetLectureByIDAsync(int lectureID);
    }
}
