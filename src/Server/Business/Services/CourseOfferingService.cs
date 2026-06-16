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
        private CourseOffering? _offering;

        public CourseOfferingService(ICourseOfferingRepository offeringRepository)
        {
            _offeringRepository = offeringRepository;
            _offering = null;
        }

        public async Task<bool> DeleteCourseOfferingAsync(int offeringID)
        {
            return await _offeringRepository.DeleteCourseOfferingAsync(offeringID);
        }


        public async Task<CourseOfferingResponse?> AddCourseOfferingAsync(CreateCourseOfferingRequest request)
        {
            _offering = new CourseOffering();
            _offering = _offering.CreateRequestToCourseOffering(request);

            if (_offering != null)
            {
                _offering.OfferingID = await _offeringRepository.AddCourseOfferingAsync(_offering);

                if (_offering.OfferingID != -1)
                    return await GetCourseOfferingByIDAsync(_offering.OfferingID);
            }

            return null;
        }

        public async Task<CourseOfferingResponse?> UpdateCourseOfferingAsync(UpdateCourseOfferingRequest request, int offeringID)
        {
            _offering = new CourseOffering();
            _offering = _offering.UpdateRequestToCourseOffering(request, offeringID);

            if (_offering != null && await _offeringRepository.UpdateCourseOfferingAsync(_offering))
                return await GetCourseOfferingByIDAsync(_offering.OfferingID);

            return null;
        }

        public async Task<IEnumerable<CourseOfferingResponse>?> GetPagedCourseOfferingsAsync(int pageNumber = 1, int pageSize = 10)
        {
            IEnumerable<CourseOffering>? offerings = await _offeringRepository.GetPagedCourseOfferingsAsync(pageNumber, pageSize);
            return offerings?.Select(m => m.CourseOfferingToResponse()).OfType<CourseOfferingResponse>();
        }

        public async Task<CourseOfferingResponse?> GetCourseOfferingByIDAsync(int offeringID)
        {
            _offering = await _offeringRepository.GetCourseOfferingByIDAsync(offeringID);
            return _offering != null ? _offering.CourseOfferingToResponse() : null;
        }
    }
}
