using Core.Entities;
using Core.Interfaces.Repositories;

namespace DataAccess.Repositories
{
    public class LectureRepository : ILectureRepository
    {
        public Task<int> AddLectureAsync(Lecture lecture)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteLectureAsync(int lectureID)
        {
            throw new NotImplementedException();
        }

        public Task<Lecture?> GetLectureByIDAsync(int lectureID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Lecture>?> GetPagedLecturesAsync(int pageNumber = 1, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateLectureAsync(Lecture lecture)
        {
            throw new NotImplementedException();
        }
    }
}
