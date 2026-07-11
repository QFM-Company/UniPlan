using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
using Business.Mapper;
using Core.Entities;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;

namespace Business.Services
{
    public class LectureService : ILectureService
    {
        private readonly ILectureRepository _lectureRepository;
        private readonly IValidationService _validationService;

        public LectureService(ILectureRepository lectureRepository, IValidationService validationService)
        {
            _validationService = validationService;
            _lectureRepository = lectureRepository;
        }


        public async Task<bool> DeleteLectureAsync(int lectureID)
        {
            return lectureID > 0 && await _lectureRepository.DeleteLectureAsync(lectureID);
        }

        public async Task<LectureResponse?> AddLectureAsync(LectureRequest request)
        {
            _validationService.Validate(request);

            Lecture lecture = request.ToLecture();

            lecture.LectureID = await _lectureRepository.AddLectureAsync(lecture);

            if (lecture.LectureID != -1)
                return await GetLectureByIDAsync(lecture.LectureID);

            return null;
        }

        public async Task<bool> UpdateLectureAsync(LectureRequest request, int lectureID)
        {
            _validationService.Validate(request);

            Lecture? lecture = await _lectureRepository.GetLectureByIDAsync(lectureID);

            lecture?.UpdateLecture(request);

            if (lecture != null)
                return await _lectureRepository.UpdateLectureAsync(lecture);

            return false;
        }

        public async Task<IEnumerable<LectureResponse>?> GetPagedLecturesAsync(int pageNumber = 1, int pageSize = 10)
        {
            IEnumerable<Lecture>? lectures = await _lectureRepository.GetPagedLecturesAsync(pageNumber, pageSize);
            return lectures?.Select(m => m.ToResponse()).OfType<LectureResponse>();
        }

        public async Task<LectureResponse?> GetLectureByIDAsync(int lectureID)
        {
            if (lectureID <= 0)
                return null;

            Lecture? lecture = await _lectureRepository.GetLectureByIDAsync(lectureID);
            return lecture != null ? lecture.ToResponse() : null;
        }
    }
}
