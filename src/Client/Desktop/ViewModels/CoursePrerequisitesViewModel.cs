using Client.Models;
using Client.Models.Requests;
using Client.Models.Responses;
using Client.Services;
using Core.Interfaces.ExternalServices;
using System.Data;
using ViewModels.Interfaces;

namespace ViewModels
{
    public class CoursePrerequisitesViewModel : IViewModel
    {
        private readonly CoursePrerequisiteApiService _preReqApi;
        private readonly IValidationService _validationService;

        public CoursePrerequisitesViewModel(CoursePrerequisiteApiService preReqApiService, IValidationService validationService)
        {
            _preReqApi = preReqApiService;
            _validationService = validationService;
        }

        private DataView _ToDataView(List<CoursePrerequisiteResponse>? prereqs)
        {
            DataTable table = new DataTable();
            table.Columns.Add("معرف المتطلب", typeof(int));
            table.Columns.Add("المقرر الرئيسي", typeof(string));
            table.Columns.Add("المتطلب السابق", typeof(string));
            table.PrimaryKey = new DataColumn[] { table.Columns[0] };

            if (prereqs == null) return table.DefaultView;
            foreach (var p in prereqs)
            {
                string main = p.MainCourseInfo?.CourseName ?? string.Empty;
                string pre = p.PreRequestCourseInfo?.CourseName ?? string.Empty;
                table.Rows.Add(p.PreRequestID, main, pre);
            }
            return table.DefaultView;
        }

        public async Task<DataView> GetDataView(int pageNumber, int pageSize)
        {
            var data = await _preReqApi.GetCoursePrerequisitesAsync(pageNumber, pageSize);
            return _ToDataView(data);
        }

        public async Task<DataView> GetDataViewByID(int id)
        {
            var data = await _preReqApi.GetCoursePrerequisiteAsync(id);
            var list = data == null ? new List<CoursePrerequisiteResponse>() : new List<CoursePrerequisiteResponse> { data };
            return _ToDataView(list);
        }

        public async Task<bool> CreateAsync(BaseModel model)
        {
            var req = (CoursePrerequisiteRequest)model;
            _validationService.Validate(req);
            req = await _preReqApi.PostCoursePrerequisiteAsync(req);
            return req != null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _preReqApi.DeleteCoursePrerequisiteAsync(id);
        }

        public Task<bool> UpdateAsync(int id, BaseModel model)
        {
            throw new NotImplementedException();
        }
    }
}