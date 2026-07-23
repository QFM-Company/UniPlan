using Client.Models;
using System.Data;

namespace ViewModels.Interfaces
{
    public interface IViewModel
    {
        Task<DataView> GetDataView(int pageNumber, int pageSize);

        Task<DataView> GetDataViewByID(int id);

        Task<bool> CreateAsync(Person model);

        Task<bool> UpdateAsync(int id, Person model);

        Task<bool> DeleteAsync(int id);
    }
}
