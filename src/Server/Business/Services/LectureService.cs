using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
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

        private Lecture _RequestToLecture(LectureRequest request, int lectureID = -1)
        {
            return new Lecture(lectureID, request.LectureType, request.DurationValue, new Course { CourseID = request.CourseID });
        }

        private LectureResponse? _LectureToResponse(Lecture lecture)
        {
            if(lecture.Course != null && lecture.Course.Major != null)
            {
                CourseResponse course = new CourseResponse(lecture.Course.CourseID, lecture.Course.CourseName, lecture.Course.CreditHours, lecture.Course.Major.MajorID);
                return new LectureResponse(lecture.LectureID, lecture.LectureType, lecture.DurationValue, course);
            }

            return null;
        }

        public async Task<bool> DeleteLectureAsync(int lectureID)
        {
            return await _lectureRepository.DeleteLectureAsync(lectureID);
        }

        public async Task<LectureResponse?> AddLectureAsync(LectureRequest request)
        {
            LectureResponse? lectureResponse = null;

            if (request != null)
            {
                _lecture = _RequestToLecture(request);
                _lecture.LectureID = await _lectureRepository.AddLectureAsync(_lecture);
                lectureResponse = _LectureToResponse(_lecture);
            }

            return lectureResponse;
        }

        public async Task<LectureResponse?> UpdateLectureAsync(LectureRequest request, int lectureID)
        {
            LectureResponse? lectureResponse = null;

            if (request != null)
            {
                _lecture = _RequestToLecture(request, lectureID);
                await _lectureRepository.UpdateLectureAsync(_lecture);
                lectureResponse = _LectureToResponse(_lecture);
            }

            return lectureResponse;
        }

        public async Task<IEnumerable<LectureResponse>?> GetPagedLecturesAsync(int pageNumber = 1, int pageSize = 10)
        {
            IEnumerable<Lecture>? lectures = await _lectureRepository.GetPagedLecturesAsync(pageNumber, pageSize);
            return lectures?.Select(h => _LectureToResponse(h)).OfType<LectureResponse>();
        }

        public async Task<LectureResponse?> GetLectureByIDAsync(int lectureID)
        {
            _lecture = await _lectureRepository.GetLectureByIDAsync(lectureID);
            return _lecture != null ? _LectureToResponse(_lecture) : null;
        }
    }
}
