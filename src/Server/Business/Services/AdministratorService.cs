using Business.DTOs.Requests.Create;
using Business.DTOs.Responses;
using Business.Interfaces;
using Business.Mapper;
using Core.Entities;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;

namespace Business.Services
{
    public class AdministratorService : IAdministratorService
    {

        private IAdminRepository _AdminRepository;
        private Administrator? _admin;
        private IValidationService _ValidationService;

        public AdministratorService(IAdminRepository adminRepostery, IValidationService iValidationService)
        {
            _AdminRepository = adminRepostery;
            _admin = null;
            _ValidationService = iValidationService;
        }



        public async Task<AdministratorResponse?> AddAdministratorAsync(CreateAdministratorRequest request)
        {
            _ValidationService.Validate(request);
            _admin = request?.ToAdministrator() ?? null;
            if (_admin != null && _admin.Account != null)
            {
                var result = await _AdminRepository.AddAdminAsync(_admin);
                _admin = await _AdminRepository.GetAdminByIDAsync(_admin.AdminID);
                if (result && _admin?.Account != null && _admin?.Person != null)
                {
                    _admin.AdminID = _admin.AdminID;
                    _admin.Account.AccountID = _admin.Account.AccountID;
                    _admin.Person = _admin.Person;
                    if (_admin.AdminID > 0 && _admin.Account.AccountID > 0)
                    {
                        return _admin.ToResponse();
                    }
                }
            }

            return null;
        }

        public async Task<bool> DeleteAdministratorAsync(int adminID)
        {
            return await _AdminRepository.DeleteAdminAsync(adminID);
        }

        public async Task<AdministratorResponse?> GetAdministratorByIdAsync(int adminID)
        {
            _admin = await _AdminRepository.GetAdminByIDAsync(adminID);
            return _admin?.ToResponse() ?? null;
        }

        public async Task<AdministratorResponse?> UpdateAdministratorAsync(int adminID, CreateAdministratorRequest request)
        {
            _ValidationService.Validate(request);
            _admin = request.ToAdministrator(adminID);
            if (_admin != null)
            {
                bool result = await _AdminRepository.UpdateAdminAsync(_admin);
                if (result)
                {
                    return _admin.ToResponse();
                }
            }
            return null;
        }

        public async Task<IEnumerable<AdministratorResponse>> GetPageAdministratorsAsync(int pageNumber = 1, int pageSize = 10)
        {
            var admins = await _AdminRepository.GetPageAdminsAsync(pageNumber, pageSize);

            var responses = admins?.Select(admin => admin.ToResponse()).Where(adm => adm != null);

            return responses?.Select(response => response!).ToList() ?? new List<AdministratorResponse>();
        }
    }
}
