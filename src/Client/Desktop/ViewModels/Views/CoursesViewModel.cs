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
            table.AddCourseColumns();
            table.PrimaryKey = new DataColumn[] { table.Columns[0] };

            if (courses == null) 
                return table.DefaultView;

            foreach (var c in courses)
                table.Rows.Add(c.CourseID, c.CourseName, c.CreditHours, c.CourseCode);

            return table.DefaultView;
        }

        public async Task<DataView> GetDataView(int pageNumber, int pageSize)
        {
            var data = await _courseApi.GetCoursesAsync(pageNumber, pageSize);
            return _ToDataView(data);
        }

        public async Task<DataView> GetDataViewByID(int id)
        {
            var data = await _courseApi.GetCourseByIDAsync(id);

            var list = data == null ? new List<CourseResponse>() : new List<CourseResponse> { data };
            return _ToDataView(list);
        }

        public async Task<bool> CreateAsync(Person model)
        {
            var req = (CourseRequest)model;
            _validationService.Validate(req);

            var res = await _courseApi.CreateCourseAsync(req);
            return res != null;
        }

        public async Task<bool> UpdateAsync(int id, Person model)
        {
            var req = (CourseRequest)model;
            _validationService.Validate(req);

            return await _courseApi.UpdateCourseAsync(id, req);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _courseApi.DeleteCourseAsync(id);
        }
    }
}