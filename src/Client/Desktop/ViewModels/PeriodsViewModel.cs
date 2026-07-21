using Client.Models;
using Client.Models.Requests;
using Client.Models.Responses;
using Client.Services;
using Core.Interfaces.ExternalServices;
using System.Data;
using ViewModels.Interfaces;

namespace ViewModels
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
            table.Columns.Add("معرف الفترة", typeof(int));
            table.Columns.Add("وقت البداية", typeof(string));
            table.Columns.Add("وقت النهاية", typeof(string));
            table.PrimaryKey = new DataColumn[] { table.Columns[0] };

            if (periods == null) return table.DefaultView;
            foreach (var p in periods)
                table.Rows.Add(p.PeriodID, p.StartTime.ToString(@"hh\:mm"), p.EndTime.ToString(@"hh\:mm"));
            return table.DefaultView;
        }

        public async Task<DataView> GetDataView(int pageNumber, int pageSize)
        {
            var data = await _periodApi.GetPeriodsAsync(pageNumber, pageSize);
            return _ToDataView(data);
        }

        public async Task<DataView> GetDataViewByID(int id)
        {
            var data = await _periodApi.GetPeriodAsync(id);
            var list = data == null ? new List<PeriodResponse>() : new List<PeriodResponse> { data };
            return _ToDataView(list);
        }

        public async Task<bool> CreateAsync(BaseModel model)
        {
            var req = (PeriodRequest)model;
            _validationService.Validate(req);
            req = await _periodApi.PostPeriodAsync(req);
            return req != null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _periodApi.DeletePeriodAsync(id);
        }

        public Task<bool> UpdateAsync(int id, BaseModel model)
        {
            throw new NotImplementedException();
        }
    }
}