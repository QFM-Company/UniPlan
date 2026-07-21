using Client.Models;
using Client.Models.Requests;
using Client.Models.Responses;
using Client.Services;
using Core.Interfaces.ExternalServices;
using System.Data;
using ViewModels.Interfaces;

namespace ViewModels
{
    public class AdministratorsViewModel : IViewModel
    {
        private readonly AdministratorApiService _adminApi;
        private readonly IValidationService _validationService;

        public AdministratorsViewModel(AdministratorApiService adminApiService, IValidationService validationService)
        {
            _adminApi = adminApiService;
            _validationService = validationService;
        }

        private DataView _ToDataView(List<AdministratorResponse>? admins)
        {
            DataTable table = new DataTable();
            table.Columns.Add("معرف المسؤول", typeof(int));
            table.Columns.Add("الاسم الكامل", typeof(string));
            table.Columns.Add("البريد الإلكتروني", typeof(string));
            table.Columns.Add("نشط", typeof(string));
            table.PrimaryKey = new DataColumn[] { table.Columns[0] };

            if (admins == null) return table.DefaultView;

            foreach (var admin in admins)
            {
                string fullName = admin.Person?.FullName ?? string.Empty;
                string email = admin.Account?.Email ?? string.Empty;
                table.Rows.Add(admin.AdminID, fullName, email, admin.IsActive ? "نعم" : "لا");
            }
            return table.DefaultView;
        }

        public async Task<DataView> GetDataView(int pageNumber, int pageSize)
        {
            var data = await _adminApi.GetAdministratorsAsync(pageNumber, pageSize);
            return _ToDataView(data);
        }

        public async Task<DataView> GetDataViewByID(int id)
        {
            var data = await _adminApi.GetAdministratorAsync(id);
            var list = data == null ? new List<AdministratorResponse>() : new List<AdministratorResponse> { data };
            return _ToDataView(list);
        }

        public async Task<bool> CreateAsync(BaseModel model)
        {
            var req = (AdministratorRequest)model;
            _validationService.Validate(req);
            req = await _adminApi.PostAdministratorAsync(req);
            return req != null;
        }

        public async Task<bool> UpdateAsync(int id, BaseModel model)
        {
            var req = (AdministratorRequest)model;
            _validationService.Validate(req);
            return await _adminApi.PutAdministratorAsync(id, req);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _adminApi.DeleteAdministratorAsync(id);
        }
    }
}