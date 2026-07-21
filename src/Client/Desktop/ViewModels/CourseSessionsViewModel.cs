using Client.Models;
using Client.Models.Requests;
using Client.Models.Responses;
using Client.Services;
using Core.Interfaces.ExternalServices;
using System.Data;
using ViewModels.Interfaces;

namespace ViewModels
{
    public class CourseSessionsViewModel : IViewModel
    {
        private readonly CourseSessionApiService _sessionApi;
        private readonly IValidationService _validationService;

        public CourseSessionsViewModel(CourseSessionApiService sessionApiService, IValidationService validationService)
        {
            _sessionApi = sessionApiService;
            _validationService = validationService;
        }

        private DataView _ToDataView(List<CourseSessionResponse>? sessions)
        {
            DataTable table = new DataTable();
            table.Columns.Add("معرف الجلسة", typeof(int));
            table.Columns.Add("القاعة", typeof(string));
            table.Columns.Add("اليوم", typeof(string));
            table.Columns.Add("وقت البداية", typeof(string));
            table.Columns.Add("وقت النهاية", typeof(string));
            table.PrimaryKey = new DataColumn[] { table.Columns[0] };

            if (sessions == null) return table.DefaultView;

            foreach (var s in sessions)
            {
                string hall = s.Hall?.HallName ?? string.Empty;
                table.Rows.Add(s.SessionID, hall, s.Day, s.StartTime.ToString(@"hh\:mm"), s.EndTime.ToString(@"hh\:mm"));
            }
            return table.DefaultView;
        }

        public async Task<DataView> GetDataView(int pageNumber, int pageSize)
        {
            var data = await _sessionApi.GetCourseSessionsAsync(pageNumber, pageSize);
            return _ToDataView(data);
        }

        public async Task<DataView> GetDataViewByID(int id)
        {
            var data = await _sessionApi.GetCourseSessionAsync(id);
            var list = data == null ? new List<CourseSessionResponse>() : new List<CourseSessionResponse> { data };
            return _ToDataView(list);
        }

        public async Task<bool> CreateAsync(BaseModel model)
        {
            var req = (CourseSessionRequest)model;
            _validationService.Validate(req);
            req = await _sessionApi.PostCourseSessionAsync(req);
            return req != null;
        }

        public async Task<bool> UpdateAsync(int id, BaseModel model)
        {
            var req = (CourseSessionRequest)model;
            _validationService.Validate(req);
            return await _sessionApi.PutCourseSessionAsync(id, req);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _sessionApi.DeleteCourseSessionAsync(id);
        }
    }
}