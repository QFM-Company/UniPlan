using System.Data;

namespace ViewModels.Interfaces
{
    public interface IViewModel
    {
        Task<DataView> GetDataView(int pageNumber, int pageSize);

        Task<DataView> GetDataViewByID(int id);
    }
}
