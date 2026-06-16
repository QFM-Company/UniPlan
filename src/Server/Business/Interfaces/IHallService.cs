using Business.DTOs.Requests.Create;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;

namespace Business.Interfaces
{
    public interface IHallService
    {
        Task<bool> DeleteHallAsync(int hallID);

        Task<HallResponse?> AddHallAsync(CreateHallRequest request);

        Task<bool> UpdateHallAsync(UpdateHallRequest request, int hallID);

        Task<IEnumerable<HallResponse>?> GetPagedHallsAsync(int pageNumber = 1, int pageSize = 10);

        Task<HallResponse?> GetHallByIDAsync(int hallID);
    }
}
