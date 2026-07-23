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
            table.AddAdministratorColumns();
            table.PrimaryKey = new DataColumn[] { table.Columns[0] };

            if (admins == null) 
                return table.DefaultView;

            foreach (var admin in admins)
            {
                var p = admin.Person ?? new PersonResponse();
                var acc = admin.Account ?? new AccountResponse();
                table.Rows.Add(
                    admin.AdminID,
                    admin.IsActive ? "نعم" : "لا",
                    p.PersonID,
                    p.FirstName,
                    p.MiddleName,
                    p.LastName,
                    "",
                    acc.AccountID,
                    acc.AccountName,
                    acc.Email
                );
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
            var data = await _adminApi.GetAdministratorByIDAsync(id);

            var list = data == null ? new List<AdministratorResponse>() : new List<AdministratorResponse> { data };
            return _ToDataView(list);
        }

        public async Task<bool> CreateAsync(Person model)
        {
            var req = (AdministratorRequest)model;

            _validationService.Validate(req);

            var res = await _adminApi.CreateAdministratorAsync(req);
            return res != null;
        }

        public async Task<bool> UpdateAsync(int id, Person model)
        {
            var req = (AdministratorRequest)model;
            _validationService.Validate(req);

            return await _adminApi.UpdateAdministratorAsync(id, req);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _adminApi.DeleteAdministratorAsync(id);
        }
    }
}