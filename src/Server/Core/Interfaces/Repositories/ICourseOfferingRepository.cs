using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface ICourseOfferingRepository
    {
        Task<bool> DeleteCourseOfferingAsync(int courseOfferingID);

        Task<int> AddCourseOfferingAsync(CourseOffering courseOffering);

        Task<bool> UpdateCourseOfferingAsync(CourseOffering courseOffering);

        Task<IEnumerable<CourseOffering>?> GetPagedCourseOfferingsAsync(int pageNumber = 1, int pageSize = 10);

        Task<CourseOffering?> GetCourseOfferingByIDAsync(int courseOfferingID);
    }
}
