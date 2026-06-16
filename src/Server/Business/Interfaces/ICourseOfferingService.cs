using Business.DTOs.Requests.Create;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;

namespace Business.Interfaces
{
    public interface ICourseOfferingService
    {
        Task<bool> DeleteCourseOfferingAsync(int offeringID);

        Task<CourseOfferingResponse?> AddCourseOfferingAsync(CreateCourseOfferingRequest request);

        Task<bool> UpdateCourseOfferingAsync(UpdateCourseOfferingRequest request, int offeringID);

        Task<IEnumerable<CourseOfferingResponse>?> GetPagedCourseOfferingsAsync(int pageNumber = 1, int pageSize = 10);

        Task<CourseOfferingResponse?> GetCourseOfferingByIDAsync(int offeringID);
    }
}
