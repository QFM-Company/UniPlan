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
    public class TimeSlotsViewModel : IViewModel
    {
        private readonly TimeSlotApiService _timeSlotApi;
        private readonly IValidationService _validationService;

        public TimeSlotsViewModel(TimeSlotApiService timeSlotApiService, IValidationService validationService)
        {
            _timeSlotApi = timeSlotApiService;
            _validationService = validationService;
        }

        private DataView _ToDataView(List<TimeSlotResponse>? slots)
        {
            DataTable table = new DataTable();
            table.AddTimeSlotColumnsTyped(); 
            table.PrimaryKey = new DataColumn[] { table.Columns[0] };

            if (slots == null)
                return table.DefaultView;

            foreach (var s in slots)
                table.Rows.Add(
                    s.SlotID,
                    s.Day.ToString(),
                    s.Period?.PeriodID ?? 0,
                    s.Period?.StartTime ?? TimeSpan.Zero,
                    s.Period?.EndTime ?? TimeSpan.Zero
                );

            return table.DefaultView;
        }

        public async Task<DataView> GetDataView(int pageNumber, int pageSize)
        {
            var data = await _timeSlotApi.GetTimeSlotsAsync(pageNumber, pageSize);
            return _ToDataView(data);
        }

        public async Task<DataView> GetDataViewByID(int id)
        {
            var data = await _timeSlotApi.GetTimeSlotByIDAsync(id);

            var list = data == null ? new List<TimeSlotResponse>() : new List<TimeSlotResponse> { data };
            return _ToDataView(list);
        }

        public async Task<bool> CreateAsync(Person model)
        {
            var req = (TimeSlotRequest)model;
            _validationService.Validate(req);

            var res = await _timeSlotApi.CreateTimeSlotAsync(req);
            return res != null;
        }

        public async Task<bool> UpdateAsync(int id, Person model)
        {
            var req = (TimeSlotRequest)model;
            _validationService.Validate(req);

            return await _timeSlotApi.UpdateTimeSlotAsync(id, req);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _timeSlotApi.DeleteTimeSlotAsync(id);
        }
    }
}