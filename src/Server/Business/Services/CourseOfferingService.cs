using Business.DTOs.Requests.Create;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;
using Business.Interfaces;
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

        private CourseOffering _CreateRequestToCourseOffering(CreateCourseOfferingRequest request)
        {
            return new CourseOffering(-1, request.SectionNumber, request.CreatedByAdminID, 
                new AcademicTerm { TermID = request.TermID}, new Lecture { LectureID = request.LectureID, Course = new Course { CourseID = request.CourseID } });
        }

        private CourseOffering _UpdateRequestToCourseOffering(UpdateCourseOfferingRequest request, int offeringID = -1)
        {
            return new CourseOffering(request.OfferingID, request.SectionNumber,
                new AcademicTerm { TermID = request.TermID }, new Lecture { LectureID = request.LectureID });
        }

        private CourseOfferingResponse? _CourseOfferingToResponse(CourseOffering offering)
        {
            LectureResponse lecture = new LectureResponse();
            AcademicTermResponse academicTerm = new AcademicTermResponse();

            if (lecture != null && lecture.CourseInfo != null)
            {
                CourseResponse course = new CourseResponse(lecture.CourseInfo.CourseID, lecture.CourseInfo.CourseName, lecture.CourseInfo.CreditHours, lecture.CourseInfo.MajorID);
                lecture = new LectureResponse(lecture.LectureID, lecture.LectureType, lecture.DurationValue, course);
            }

            if (offering.Term != null)
            {
                academicTerm = new AcademicTermResponse(offering.Term.TermID, offering.Term.TermType, offering.Term.TermYear);
            }

            return new CourseOfferingResponse(offering.OfferingID, offering.SectionNumber, offering.CreatedByAdminID, academicTerm, lecture);
        }

        public async Task<bool> DeleteCourseOfferingAsync(int offeringID)
        {
            return await _offeringRepository.DeleteCourseOfferingAsync(offeringID);
        }

        public async Task<CourseOfferingResponse?> AddCourseOfferingAsync(CreateCourseOfferingRequest request)
        {
            CourseOfferingResponse? offeringResponse = null;

            if (request != null)
            {
                _offering = _CreateRequestToCourseOffering(request);
                _offering.OfferingID = await _offeringRepository.AddCourseOfferingAsync(_offering);
                offeringResponse = _CourseOfferingToResponse(_offering);
            }

            return offeringResponse;
        }

        public async Task<CourseOfferingResponse?> UpdateCourseOfferingAsync(UpdateCourseOfferingRequest request, int offeringID)
        {
            CourseOfferingResponse? offeringResponse = null;

            if (request != null)
            {
                _offering = _UpdateRequestToCourseOffering(request, offeringID);
                await _offeringRepository.UpdateCourseOfferingAsync(_offering);
                offeringResponse = await GetCourseOfferingByIDAsync(offeringID);
            }

            return offeringResponse;
        }

        public async Task<IEnumerable<CourseOfferingResponse>?> GetPagedCourseOfferingsAsync(int pageNumber = 1, int pageSize = 10)
        {
            IEnumerable<CourseOffering>? offerings = await _offeringRepository.GetPagedCourseOfferingsAsync(pageNumber, pageSize);
            return offerings?.Select(h => _CourseOfferingToResponse(h)).OfType<CourseOfferingResponse>();
        }

        public async Task<CourseOfferingResponse?> GetCourseOfferingByIDAsync(int offeringID)
        {
            _offering = await _offeringRepository.GetCourseOfferingByIDAsync(offeringID);
            return _offering != null ? _CourseOfferingToResponse(_offering) : null;
        }
    }
}
