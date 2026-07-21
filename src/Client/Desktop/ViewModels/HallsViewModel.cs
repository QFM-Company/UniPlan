using Client.Models;
using Client.Models.Requests;
using Client.Models.Responses;
using Client.Services;
using Core.Interfaces.ExternalServices;
using System.Data;
using ViewModels.Interfaces;

namespace ViewModels
{
    public class HallsViewModel : IViewModel
    {
        private readonly HallApiService _hallApi;
        private readonly IValidationService _validationService;

        public HallsViewModel(HallApiService hallApiService, IValidationService validationService)
        {
            _hallApi = hallApiService;
            _validationService = validationService;
        }

        private DataView _ToDataView(List<HallResponse>? hallResponses)
        {
            DataTable table = new DataTable();

            DataColumn primaryKey = new DataColumn("معرف القاعة");

            table.Columns.Add(primaryKey);
            table.Columns.Add("اسم القاعة");
            table.Columns.Add("المبنى");
            table.Columns.Add("الطابق");

            table.PrimaryKey = new DataColumn[] { primaryKey };

            if (hallResponses == null)
                return table.DefaultView;

            foreach (var hall in hallResponses)
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
            List<HallResponse>? hallResponses = await _hallApi.GetHallsAsync(pageNumber, pageSize);
            return _ToDataView(hallResponses);
        }

        public async Task<DataView> GetDataViewByID(int id)
        {
            HallResponse? hallResponse = await _hallApi.GetHallAsync(id);

            List<HallResponse> hallResponses = new List<HallResponse>();

            if (hallResponse != null)
                hallResponses.Add(hallResponse);

            return _ToDataView(hallResponses);
        }

        public async Task<bool> CreateAsync(BaseModel model)
        {
            HallRequest? hall = (HallRequest)model;

            _validationService.Validate(hall);

            hall = await _hallApi.PostHallAsync(hall);

            return hall != null;
        }

        public async Task<bool> UpdateAsync(int id, BaseModel model)
        {
            HallRequest? hall = (HallRequest)model;

            _validationService.Validate(hall);

            return await _hallApi.PutHallAsync(id, hall);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _hallApi.DeleteHallAsync(id);
        }
    }
}
