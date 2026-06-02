using Business.DTOs.Requests;
using Business.DTOs.Responses;

namespace Business.Interfaces
{
    public interface IHallService
    {
        Task<bool> DeleteHallAsync(int hallID);

        Task<HallResponse?> AddHallAsync(HallRequest request);

        Task<HallResponse?> UpdateHallAsync(HallRequest request, int hallID);

        Task<IEnumerable<HallResponse>?> GetPagedHallsAsync(int pageNumber = 1, int pageSize = 10);

        Task<HallResponse?> GetHallByIDAsync(int hallID);
    }
}
