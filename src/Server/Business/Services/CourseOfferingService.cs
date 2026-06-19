using Business.DTOs.Requests.Create;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;
using Business.Interfaces;
using Business.Mapper;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace Business.Services
{
    public class CourseOfferingService : ICourseOfferingService
    {
        private ICourseOfferingRepository _offeringRepository;

        public CourseOfferingService(ICourseOfferingRepository offeringRepository)
        {
            _offeringRepository = offeringRepository;
        }

        public async Task<bool> DeleteCourseOfferingAsync(int offeringID)
        {
            return await _offeringRepository.DeleteCourseOfferingAsync(offeringID);
        }


        public async Task<CourseOfferingResponse?> AddCourseOfferingAsync(CreateCourseOfferingRequest request)
        {
            CourseOffering offering = request.ToCourseOffering();

            offering.OfferingID = await _offeringRepository.AddCourseOfferingAsync(offering);

            if (offering.OfferingID != -1)
                return await GetCourseOfferingByIDAsync(offering.OfferingID);

            return null;
        }

        public async Task<bool> UpdateCourseOfferingAsync(UpdateCourseOfferingRequest request, int offeringID)
        {
            CourseOffering? offering = await _offeringRepository.GetCourseOfferingByIDAsync(offeringID);

            offering?.UpdateOffering(request);

            if (offering != null)
                return await _offeringRepository.UpdateCourseOfferingAsync(offering);

            return false;
        }

        public async Task<IEnumerable<CourseOfferingResponse>?> GetPagedCourseOfferingsAsync(int pageNumber = 1, int pageSize = 10)
        {
            IEnumerable<CourseOffering>? offerings = await _offeringRepository.GetPagedCourseOfferingsAsync(pageNumber, pageSize);
            return offerings?.Select(m => m.ToResponse()).OfType<CourseOfferingResponse>();
        }

        public async Task<CourseOfferingResponse?> GetCourseOfferingByIDAsync(int offeringID)
        {
            CourseOffering? _offering = await _offeringRepository.GetCourseOfferingByIDAsync(offeringID);
            return _offering != null ? _offering.ToResponse() : null;
        }
    }
}
