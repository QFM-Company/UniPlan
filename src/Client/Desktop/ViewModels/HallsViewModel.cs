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

        public async Task<DataView> GetDataView()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Hall ID");
            table.Columns.Add("Hall Name");
            table.Columns.Add("Building");
            table.Columns.Add("Floor");

            List<HallModel> hallModels = await _hallApi.GetHallsAsync();

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
    }
}