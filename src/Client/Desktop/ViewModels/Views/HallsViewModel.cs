using Client.Models;
using Client.Models.Requests;
using Client.Models.Responses;
using Client.Services;
using Core.Interfaces.ExternalServices;
using System.Data;
using ViewModels.Extensions;
using ViewModels.Interfaces;

namespace ViewModels.Views
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

        private DataView _ToDataView(List<HallResponse>? halls)
        {
            DataTable table = new DataTable();
            table.AddHallColumns();
            table.PrimaryKey = new DataColumn[] { table.Columns[0] };

            if (halls == null) 
                return table.DefaultView;

            foreach (var h in halls)
                table.Rows.Add(h.HallID, h.HallName, h.Building, h.Floor, h.CreatedByAdminID);

            return table.DefaultView;
        }

        public async Task<DataView> GetDataView(int pageNumber, int pageSize)
        {
            List<HallResponse>? hallResponses = await _hallApi.GetHallsAsync(pageNumber, pageSize);
            return _ToDataView(hallResponses);
        }

        public async Task<DataView> GetDataViewByID(int id)
        {
            HallResponse? hallResponse = await _hallApi.GetHallByIDAsync(id);
            List<HallResponse> hallResponses = new List<HallResponse>();

            if (hallResponse != null)
                hallResponses.Add(hallResponse);

            return _ToDataView(hallResponses);
        }

        public async Task<bool> CreateAsync(Person model)
        {
            var req = (HallRequest)model;
            _validationService.Validate(req);

            var res = await _hallApi.CreateHallAsync(req);
            return res != null;
        }

        public async Task<bool> UpdateAsync(int id, Person model)
        {
            HallRequest? hall = (HallRequest)model;
            _validationService.Validate(hall);

            return await _hallApi.UpdateHallAsync(id, hall);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _hallApi.DeleteHallAsync(id);
        }
    }
}
