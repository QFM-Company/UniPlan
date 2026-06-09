using Core.Entities;
using Core.Interfaces.Repositories;

namespace DataAccess.Repositories
{
    public class CourseOfferingRepository : ICourseOfferingRepository
    {
        public Task<int> AddCourseOfferingAsync(CourseOffering courseOffering)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCourseOfferingAsync(int courseOfferingID)
        {
            throw new NotImplementedException();
        }

        public Task<CourseOffering?> GetCourseOfferingByIDAsync(int courseOfferingID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseOffering>?> GetPagedCourseOfferingsAsync(int pageNumber = 1, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCourseOfferingAsync(CourseOffering courseOffering)
        {
            throw new NotImplementedException();
        }
    }
}
