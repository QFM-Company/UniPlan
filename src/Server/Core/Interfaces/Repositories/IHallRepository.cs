using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IHallRepository
    {
        Task<bool> DeleteHallAsync(int hallID);

        Task<int> AddHallAsync(Hall hall);

        Task<bool> UpdateHallAsync(Hall hall);

        Task<IEnumerable<Hall>?> GetPagedHallsAsync(int pageNumber = 1, int pageSize = 10);

        Task<Hall?> GetHallByIDAsync(int hallID);
    }
}
