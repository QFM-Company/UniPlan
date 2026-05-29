using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IHallRepository
    {
        Task<bool> DeleteHall(int hallID);

        Task<int> AddHall(Hall hall);

        Task<bool> UpdateHall(Hall hall);

        Task<IEnumerable<Hall>?> GetPagedHalls(int pageNumber = 1, int pageSize = 10);

        Task<Hall?> GetHallByID(int hallID);
    }
}
