using System.Data;

namespace ViewModels.Interface
{
    public interface IHallsViewModel
    {
        Task<DataView> GetDataView(int pageNumber, int pageSize);
    }
}
