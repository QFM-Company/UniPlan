using Client.Models;
using Client.Models.Requests;
using Client.Models.Responses;
using Client.Services;
using Core.Interfaces.ExternalServices;
using System.Data;
using ViewModels.Interfaces;

namespace ViewModels
{
    public class LecturesViewModel : IViewModel
    {
        private readonly LectureApiService _lectureApi;
        private readonly IValidationService _validationService;

        public LecturesViewModel(LectureApiService lectureApiService, IValidationService validationService)
        {
            _lectureApi = lectureApiService;
            _validationService = validationService;
        }

        private DataView _ToDataView(List<LectureResponse>? lectures)
        {
            DataTable table = new DataTable();
            table.Columns.Add("معرف المحاضرة", typeof(int));
            table.Columns.Add("نوع المحاضرة", typeof(string));
            table.Columns.Add("المدة", typeof(int));
            table.Columns.Add("المقرر", typeof(string));
            table.PrimaryKey = new DataColumn[] { table.Columns[0] };

            if (lectures == null) return table.DefaultView;
            foreach (var l in lectures)
            {
                string course = l.CourseInfo?.CourseName ?? string.Empty;
                table.Rows.Add(l.LectureID, l.LectureType, l.DurationValue, course);
            }
            return table.DefaultView;
        }

        public async Task<DataView> GetDataView(int pageNumber, int pageSize)
        {
            var data = await _lectureApi.GetLecturesAsync(pageNumber, pageSize);
            return _ToDataView(data);
        }

        public async Task<DataView> GetDataViewByID(int id)
        {
            var data = await _lectureApi.GetLectureAsync(id);
            var list = data == null ? new List<LectureResponse>() : new List<LectureResponse> { data };
            return _ToDataView(list);
        }

        public async Task<bool> CreateAsync(BaseModel model)
        {
            var req = (LectureRequest)model;
            _validationService.Validate(req);
            req = await _lectureApi.PostLectureAsync(req);
            return req != null;
        }

        public async Task<bool> UpdateAsync(int id, BaseModel model)
        {
            var req = (LectureRequest)model;
            _validationService.Validate(req);
            return await _lectureApi.PutLectureAsync(id, req);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _lectureApi.DeleteLectureAsync(id);
        }
    }
}
