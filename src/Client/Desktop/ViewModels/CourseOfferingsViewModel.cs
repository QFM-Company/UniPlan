using Client.Models;
using Client.Models.Requests;
using Client.Models.Responses;
using Client.Services;
using Core.Interfaces.ExternalServices;
using System.Data;
using ViewModels.Interfaces;

namespace ViewModels
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
            table.Columns.Add("معرف الشعبة", typeof(int));
            table.Columns.Add("رقم القسم", typeof(int));
            table.Columns.Add("نوع المحاضرة", typeof(string));
            table.Columns.Add("الفصل الأكاديمي", typeof(string));
            table.PrimaryKey = new DataColumn[] { table.Columns[0] };

            if (offerings == null) return table.DefaultView;

            foreach (var of in offerings)
            {
                string lectureType = of.LectureInfo?.LectureType ?? string.Empty;
                string term = of.TermInfo != null ? $"{of.TermInfo.TermType} {of.TermInfo.TermYear}" : string.Empty;
                table.Rows.Add(of.OfferingID, of.SectionNumber, lectureType, term);
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
            var data = await _offeringApi.GetCourseOfferingAsync(id);
            var list = data == null ? new List<CourseOfferingResponse>() : new List<CourseOfferingResponse> { data };
            return _ToDataView(list);
        }

        public async Task<bool> CreateAsync(BaseModel model)
        {
            var req = (CourseOfferingRequest)model;
            _validationService.Validate(req);
            req = await _offeringApi.PostCourseOfferingAsync(req);
            return req != null;
        }

        public async Task<bool> UpdateAsync(int id, BaseModel model)
        {
            var req = (CourseOfferingRequest)model;
            _validationService.Validate(req);
            return await _offeringApi.PutCourseOfferingAsync(id, req);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _offeringApi.DeleteCourseOfferingAsync(id);
        }
    }
}