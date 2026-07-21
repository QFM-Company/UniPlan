using Client.Models;
using Client.Models.Requests;
using Client.Models.Responses;
using Client.Services;
using Core.Interfaces.ExternalServices;
using System.Data;
using ViewModels.Interfaces;

namespace ViewModels
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
            table.Columns.Add("معرف القطعة الزمنية", typeof(int));
            table.Columns.Add("اليوم", typeof(string));
            table.Columns.Add("وقت البداية", typeof(string));
            table.Columns.Add("وقت النهاية", typeof(string));
            table.PrimaryKey = new DataColumn[] { table.Columns[0] };

            if (slots == null) return table.DefaultView;
            foreach (var s in slots)
            {
                string start = s.Period?.StartTime.ToString(@"hh\:mm") ?? string.Empty;
                string end = s.Period?.EndTime.ToString(@"hh\:mm") ?? string.Empty;
                table.Rows.Add(s.SlotID, s.Day.ToString(), start, end);
            }
            return table.DefaultView;
        }

        public async Task<DataView> GetDataView(int pageNumber, int pageSize)
        {
            var data = await _timeSlotApi.GetTimeSlotsAsync(pageNumber, pageSize);
            return _ToDataView(data);
        }

        public async Task<DataView> GetDataViewByID(int id)
        {
            var data = await _timeSlotApi.GetTimeSlotAsync(id);
            var list = data == null ? new List<TimeSlotResponse>() : new List<TimeSlotResponse> { data };
            return _ToDataView(list);
        }

        public async Task<bool> CreateAsync(BaseModel model)
        {
            var req = (TimeSlotRequest)model;
            _validationService.Validate(req);
            req = await _timeSlotApi.PostTimeSlotAsync(req);
            return req != null;
        }

        public async Task<bool> UpdateAsync(int id, BaseModel model)
        {
            var req = (TimeSlotRequest)model;
            _validationService.Validate(req);
            return await _timeSlotApi.PutTimeSlotAsync(id, req);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _timeSlotApi.DeleteTimeSlotAsync(id);
        }
    }
}