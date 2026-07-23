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
    public class PeriodsViewModel : IViewModel
    {
        private readonly PeriodApiService _periodApi;
        private readonly IValidationService _validationService;

        public PeriodsViewModel(PeriodApiService periodApiService, IValidationService validationService)
        {
            _periodApi = periodApiService;
            _validationService = validationService;
        }

        private DataView _ToDataView(List<PeriodResponse>? periods)
        {
            DataTable table = new DataTable();
            table.AddPeriodColumnsTyped(); 
            table.PrimaryKey = new DataColumn[] { table.Columns[0] };

            if (periods == null)
                return table.DefaultView;

            foreach (var p in periods)
                table.Rows.Add(p.PeriodID, p.StartTime, p.EndTime);

            return table.DefaultView;
        }

        public async Task<DataView> GetDataView(int pageNumber, int pageSize)
        {
            var data = await _periodApi.GetPeriodsAsync(pageNumber, pageSize);
            return _ToDataView(data);
        }

        public async Task<DataView> GetDataViewByID(int id)
        {
            var data = await _periodApi.GetPeriodByIDAsync(id);
            var list = data == null ? new List<PeriodResponse>() : new List<PeriodResponse> { data };

            return _ToDataView(list);
        }

        public async Task<bool> CreateAsync(Person model)
        {
            var req = (PeriodRequest)model;
            _validationService.Validate(req);

            var res = await _periodApi.CreatePeriodAsync(req);
            return res != null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _periodApi.DeletePeriodAsync(id);
        }

        public Task<bool> UpdateAsync(int id, Person model)
        {
            throw new NotImplementedException();
        }
    }
}