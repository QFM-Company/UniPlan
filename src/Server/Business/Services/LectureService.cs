using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
using Business.Mapper;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace Business.Services
{
    public class LectureService : ILectureService
    {
        private ILectureRepository _lectureRepository;
        private Lecture? _lecture;

        public LectureService(ILectureRepository lectureRepository)
        {
            _lectureRepository = lectureRepository;
            _lecture = null;
        }


        public async Task<bool> DeleteLectureAsync(int lectureID)
        {
            return await _lectureRepository.DeleteLectureAsync(lectureID);
        }

        public async Task<LectureResponse?> AddLectureAsync(LectureRequest request)
        {
            _lecture = new Lecture();
            _lecture = _lecture.RequestToLecture(request);

            if(_lecture != null)
            {
                _lecture.LectureID = await _lectureRepository.AddLectureAsync(_lecture);

                if (_lecture.LectureID != -1)
                    return await GetLectureByIDAsync(_lecture.LectureID);
            }

            return null;
        }

        public async Task<LectureResponse?> UpdateLectureAsync(LectureRequest request, int lectureID)
        {
            _lecture = new Lecture();
            _lecture = _lecture.RequestToLecture(request, lectureID);

            if (_lecture != null && await _lectureRepository.UpdateLectureAsync(_lecture))
                return await GetLectureByIDAsync(_lecture.LectureID);

            return null;
        }

        public async Task<IEnumerable<LectureResponse>?> GetPagedLecturesAsync(int pageNumber = 1, int pageSize = 10)
        {
            IEnumerable<Lecture>? lectures = await _lectureRepository.GetPagedLecturesAsync(pageNumber, pageSize);
            return lectures?.Select(m => m.LectureToResponse()).OfType<LectureResponse>();
        }

        public async Task<LectureResponse?> GetLectureByIDAsync(int lectureID)
        {
            _lecture = await _lectureRepository.GetLectureByIDAsync(lectureID);
            return _lecture != null ? _lecture.LectureToResponse() : null;
        }
    }
}
