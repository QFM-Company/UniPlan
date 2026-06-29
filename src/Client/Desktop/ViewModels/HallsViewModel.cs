using System.Data;
using ViewModels.Interface;
using Client.Models;
using Client.Services;

namespace ViewModels
{
    public class HallsViewModel : IHallsViewModel
    {
        private readonly HallApiService _hallApi;

        public HallsViewModel(HallApiService hallApiService)
        {
            _hallApi = hallApiService;
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
            List<HallModel>? hallModels = await _hallApi.GetHallsAsync(pageNumber, pageSize);
            return _ConvertToDataView(hallModels);
        }
    }
}