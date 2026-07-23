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
            table.AddCoursePrerequisiteColumns(); 
            table.PrimaryKey = new DataColumn[] { table.Columns[0] };

            if (prereqs == null) 
                return table.DefaultView;

            foreach (var p in prereqs)
            {
                var main = p.MainCourseInfo ?? new CourseResponse(0, null, 0, null);
                var pre = p.PreRequestCourseInfo ?? new CourseResponse(0, null, 0, null);

                table.Rows.Add(
                    p.PreRequestID,
                    main.CourseID, main.CourseName, main.CreditHours, main.CourseCode,
                    pre.CourseID, pre.CourseName, pre.CreditHours, pre.CourseCode
                );
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
            var data = await _preReqApi.GetCoursePrerequisiteByIDAsync(id);

            var list = data == null ? new List<CoursePrerequisiteResponse>() : new List<CoursePrerequisiteResponse> { data };
            return _ToDataView(list);
        }

        public async Task<bool> CreateAsync(Person model)
        {
            var req = (CoursePrerequisiteRequest)model;
            _validationService.Validate(req);

            var res = await _preReqApi.CreateCoursePrerequisiteAsync(req);
            return res != null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _preReqApi.DeleteCoursePrerequisiteAsync(id);
        }

        public Task<bool> UpdateAsync(int id, Person model)
        {
            throw new NotImplementedException();
        }
    }
}