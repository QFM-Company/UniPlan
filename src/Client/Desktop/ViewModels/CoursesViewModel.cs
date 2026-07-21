using Client.Models;
using Client.Models.Requests;
using Client.Models.Responses;
using Client.Services;
using Core.Interfaces.ExternalServices;
using System.Data;
using ViewModels.Interfaces;

namespace ViewModels
{
    public class CoursesViewModel : IViewModel
    {
        private readonly CourseApiService _courseApi;
        private readonly IValidationService _validationService;

        public CoursesViewModel(CourseApiService courseApiService, IValidationService validationService)
        {
            _courseApi = courseApiService;
            _validationService = validationService;
        }

        private DataView _ToDataView(List<CourseResponse>? courses)
        {
            DataTable table = new DataTable();
            table.Columns.Add("معرف المقرر", typeof(int));
            table.Columns.Add("اسم المقرر", typeof(string));
            table.Columns.Add("رمز المقرر", typeof(string));
            table.Columns.Add("عدد الساعات", typeof(int));
            table.PrimaryKey = new DataColumn[] { table.Columns[0] };

            if (courses == null) return table.DefaultView;
            foreach (var c in courses) table.Rows.Add(c.CourseID, c.CourseName, c.CourseCode, c.CreditHours);
            return table.DefaultView;
        }

        public async Task<DataView> GetDataView(int pageNumber, int pageSize)
        {
            var data = await _courseApi.GetCoursesAsync(pageNumber, pageSize);
            return _ToDataView(data);
        }

        public async Task<DataView> GetDataViewByID(int id)
        {
            var data = await _courseApi.GetCourseAsync(id);
            var list = data == null ? new List<CourseResponse>() : new List<CourseResponse> { data };
            return _ToDataView(list);
        }

        public async Task<bool> CreateAsync(BaseModel model)
        {
            var req = (CourseRequest)model;
            _validationService.Validate(req);
            req = await _courseApi.PostCourseAsync(req);
            return req != null;
        }

        public async Task<bool> UpdateAsync(int id, BaseModel model)
        {
            var req = (CourseRequest)model;
            _validationService.Validate(req);
            return await _courseApi.PutCourseAsync(id, req);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _courseApi.DeleteCourseAsync(id);
        }
    }
}