using Client.Models;
using Client.Models.Requests;
using Client.Models.Responses;
using Client.Services;
using Core.Interfaces.ExternalServices;
using System.Data;
using ViewModels.Interfaces;

namespace ViewModels
{
    public class AcademicTermsViewModel : IViewModel
    {
        private readonly AcademicTermApiService _termApi;
        private readonly IValidationService _validationService;

        public AcademicTermsViewModel(AcademicTermApiService termApiService, IValidationService validationService)
        {
            _termApi = termApiService;
            _validationService = validationService;
        }

        private DataView _ToDataView(List<AcademicTermResponse>? terms)
        {
            DataTable table = new DataTable();
            table.Columns.Add("معرف الفصل", typeof(int));
            table.Columns.Add("نوع الفصل", typeof(string));
            table.Columns.Add("السنة", typeof(int));
            table.PrimaryKey = new DataColumn[] { table.Columns[0] };

            if (terms == null) return table.DefaultView;
            foreach (var t in terms) table.Rows.Add(t.TermID, t.TermType, t.TermYear);
            return table.DefaultView;
        }

        public async Task<DataView> GetDataView(int pageNumber, int pageSize)
        {
            var data = await _termApi.GetAcademicTermsAsync(pageNumber, pageSize);
            return _ToDataView(data);
        }

        public async Task<DataView> GetDataViewByID(int id)
        {
            var data = await _termApi.GetAcademicTermAsync(id);
            var list = data == null ? new List<AcademicTermResponse>() : new List<AcademicTermResponse> { data };
            return _ToDataView(list);
        }

        public async Task<bool> CreateAsync(BaseModel model)
        {
            var req = (AcademicTermRequest)model;
            _validationService.Validate(req);
            req = await _termApi.PostAcademicTermAsync(req);
            return req != null;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            return await _termApi.DeleteAcademicTermAsync(id);
        }

        public Task<bool> UpdateAsync(int id, BaseModel model)
        {
            throw new NotImplementedException();
        }
    }
}