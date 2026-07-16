using System.Data;
using Client.Models;
using Client.Services;
using ViewModels.Interfaces;

namespace ViewModels
{
    public class HallsViewModel : IViewModel
    {
        private readonly ApiService<HallModel> _hallApi;

        public HallsViewModel(ApiService<HallModel> hallApiService)
        {
            _hallApi = hallApiService;
            _hallApi.SubUri = "api/halls";
        }

        private DataView _ConvertToDataView(List<HallModel>? hallModels)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Hall ID");
            table.Columns.Add("Hall Name");
            table.Columns.Add("Building");
            table.Columns.Add("Floor");

            if (hallModels == null)
                return table.DefaultView;

            foreach (var hall in hallModels)
            {
                table.Rows.Add(
                    hall.HallID,
                    hall.HallName,
                    hall.Building,
                    hall.Floor
                );
            }

            return table.DefaultView;
        }

        public async Task<DataView> GetDataView(int pageNumber, int pageSize)
        {
            List<HallModel>? hallModels = await _hallApi.GetAllAsync(pageNumber, pageSize);
            return _ConvertToDataView(hallModels);
        }

        public async Task<DataView> GetDataViewByID(int id)
        {
            HallModel? hallModel = await _hallApi.GetByIdAsync(id);

            List<HallModel> hallModels = new List<HallModel>();

            if (hallModel != null)
                hallModels.Add(hallModel);

            return _ConvertToDataView(hallModels);
        }
    }
}
