using Business.DTOs.Requests;
using Business.DTOs.Requests.Update;
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

        public LectureService(ILectureRepository lectureRepository)
        {
            _lectureRepository = lectureRepository;
        }


        public async Task<bool> DeleteLectureAsync(int lectureID)
        {
            return await _lectureRepository.DeleteLectureAsync(lectureID);
        }

        public async Task<LectureResponse?> AddLectureAsync(LectureRequest request)
        {
            Lecture? lecture = request.RequestToLecture();

            if(lecture != null)
            {
                lecture.LectureID = await _lectureRepository.AddLectureAsync(lecture);

                if (lecture.LectureID != -1)
                    return await GetLectureByIDAsync(lecture.LectureID);
            }

            return null;
        }

        public async Task<bool> UpdateLectureAsync(LectureRequest request, int lectureID)
        {
            Lecture? lecture = await _lectureRepository.GetLectureByIDAsync(lectureID);

            lecture?.UpdateLectureFromRequest(request);

            if (lecture != null)
                return await _lectureRepository.UpdateLectureAsync(lecture);

            return false;
        }

        public async Task<IEnumerable<LectureResponse>?> GetPagedLecturesAsync(int pageNumber = 1, int pageSize = 10)
        {
            IEnumerable<Lecture>? lectures = await _lectureRepository.GetPagedLecturesAsync(pageNumber, pageSize);
            return lectures?.Select(m => m.LectureToResponse()).OfType<LectureResponse>();
        }

        public async Task<LectureResponse?> GetLectureByIDAsync(int lectureID)
        {
            Lecture? lecture = await _lectureRepository.GetLectureByIDAsync(lectureID);
            return lecture != null ? lecture.LectureToResponse() : null;
        }
    }
}
