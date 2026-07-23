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
            table.AddCourseSessionColumns();
            table.PrimaryKey = new DataColumn[] { table.Columns[0] };

            if (sessions == null) 
                return table.DefaultView;

            foreach (var s in sessions)
            {
                var off = s.CourseOffering ?? new CourseOfferingResponse();
                var term = off.TermInfo ?? new AcademicTermResponse();
                var lect = off.LectureInfo ?? new LectureResponse();
                var course = lect.CourseInfo ?? new CourseResponse(0, null, 0, null);
                var hall = s.Hall ?? new HallResponse();

                table.Rows.Add(
                    s.SessionID,
                    s.StartTime,
                    s.EndTime,
                    s.CreatedByAdminID ?? 0,
                    s.Day,
                    off.OfferingID, off.SectionNumber, off.CreatedByAdminID,
                    term.TermID, term.TermType, term.TermYear,
                    lect.LectureID, lect.LectureType, lect.DurationValue,
                    course.CourseID, course.CourseName, course.CreditHours, course.CourseCode,
                    hall.HallID, hall.HallName, hall.Building, hall.Floor, hall.CreatedByAdminID
                );
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
            var data = await _sessionApi.GetCourseSessionByIDAsync(id);

            var list = data == null ? new List<CourseSessionResponse>() : new List<CourseSessionResponse> { data };
            return _ToDataView(list);
        }

        public async Task<bool> CreateAsync(Person model)
        {
            var req = (CourseSessionRequest)model;
            _validationService.Validate(req);

            var res = await _sessionApi.CreateCourseSessionAsync(req);
            return res != null;
        }

        public async Task<bool> UpdateAsync(int id, Person model)
        {
            var req = (CourseSessionRequest)model;
            _validationService.Validate(req);

            return await _sessionApi.UpdateCourseSessionAsync(id, req);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _sessionApi.DeleteCourseSessionAsync(id);
        }
    }
}