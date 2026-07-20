using Client.Models;
using System.Data;

namespace ViewModels.Interfaces
{
    public interface IViewModel
    {
        Task<DataView> GetDataView(int pageNumber, int pageSize);

        Task<DataView> GetDataViewByID(int id);

        Task<bool> CreateAsync(BaseModel model);

        Task<bool> UpdateAsync(BaseModel model);

        Task<bool> DeleteAsync(int id);
    }
}
