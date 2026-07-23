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
    public class CourseOfferingsViewModel : IViewModel
    {
        private readonly CourseOfferingApiService _offeringApi;
        private readonly IValidationService _validationService;

        public CourseOfferingsViewModel(CourseOfferingApiService offeringApiService, IValidationService validationService)
        {
            _offeringApi = offeringApiService;
            _validationService = validationService;
        }

        private DataView _ToDataView(List<CourseOfferingResponse>? offerings)
        {
            DataTable table = new DataTable();
            table.AddCourseOfferingColumns(); 
            table.PrimaryKey = new DataColumn[] { table.Columns[0] };

            if (offerings == null) 
                return table.DefaultView;

            foreach (var of in offerings)
            {
                var term = of.TermInfo ?? new AcademicTermResponse();
                var lect = of.LectureInfo ?? new LectureResponse();
                var course = lect.CourseInfo ?? new CourseResponse(0, null, 0, null);

                table.Rows.Add(
                    of.OfferingID,
                    of.SectionNumber,
                    of.CreatedByAdminID,
                    term.TermID, term.TermType, term.TermYear,
                    lect.LectureID, lect.LectureType, lect.DurationValue,
                    course.CourseID, course.CourseName, course.CreditHours, course.CourseCode
                );
            }

            return table.DefaultView;
        }

        public async Task<DataView> GetDataView(int pageNumber, int pageSize)
        {
            var data = await _offeringApi.GetCourseOfferingsAsync(pageNumber, pageSize);
            return _ToDataView(data);
        }

        public async Task<DataView> GetDataViewByID(int id)
        {
            var data = await _offeringApi.GetCourseOfferingByIDAsync(id);

            var list = data == null ? new List<CourseOfferingResponse>() : new List<CourseOfferingResponse> { data };
            return _ToDataView(list);
        }

        public async Task<bool> CreateAsync(Person model)
        {
            var req = (CourseOfferingRequest)model;
            _validationService.Validate(req);

            var res = await _offeringApi.CreateCourseOfferingAsync(req);
            return req != null;
        }

        public async Task<bool> UpdateAsync(int id, Person model)
        {
            var req = (CourseOfferingRequest)model;
            _validationService.Validate(req);

            return await _offeringApi.UpdateCourseOfferingAsync(id, req);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _offeringApi.DeleteCourseOfferingAsync(id);
        }
    }
}