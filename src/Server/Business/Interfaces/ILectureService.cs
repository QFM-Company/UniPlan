using Business.DTOs.Requests;
using Business.DTOs.Responses;

namespace Business.Interfaces
{
    public interface ILectureService
    {
        Task<bool> DeleteLectureAsync(int lectureID);

        Task<LectureResponse?> AddLectureAsync(LectureRequest request);

        Task<bool> UpdateLectureAsync(LectureRequest request, int lectureID);

        Task<IEnumerable<LectureResponse>?> GetPagedLecturesAsync(int pageNumber = 1, int pageSize = 10);

        Task<LectureResponse?> GetLectureByIDAsync(int lectureID);
    }
}
