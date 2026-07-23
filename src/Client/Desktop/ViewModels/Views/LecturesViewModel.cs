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
            table.AddLectureColumns(); 
            table.PrimaryKey = new DataColumn[] { table.Columns[0] };

            if (lectures == null) return table.DefaultView;

            foreach (var l in lectures)
            {
                var c = l.CourseInfo ?? new CourseResponse(0, null, 0, null);
                table.Rows.Add(
                    l.LectureID,
                    l.LectureType,
                    l.DurationValue,
                    c.CourseID, c.CourseName, c.CreditHours, c.CourseCode
                );
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
            var data = await _lectureApi.GetLectureByIDAsync(id);

            var list = data == null ? new List<LectureResponse>() : new List<LectureResponse> { data };
            return _ToDataView(list);
        }

        public async Task<bool> CreateAsync(Person model)
        {
            var req = (LectureRequest)model;
            _validationService.Validate(req);

            var res = await _lectureApi.CreateLectureAsync(req);
            return res != null;
        }

        public async Task<bool> UpdateAsync(int id, Person model)
        {
            var req = (LectureRequest)model;
            _validationService.Validate(req);

            return await _lectureApi.UpdateLectureAsync(id, req);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _lectureApi.DeleteLectureAsync(id);
        }
    }
}
