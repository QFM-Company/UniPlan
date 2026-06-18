using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace Business.Services
{
    public class AdministratorService : IAdministratorService
    {
        
        private IAdminRepository _AdminRepository;
        private Administrator? _admin;


        public AdministratorService(IAdminRepository adminRepostery)
        {
            _AdminRepository = adminRepostery;
            _admin = null;
        }

        private Administrator? RequestToAdministrator(AdministratorRequest? request, int adminID = -1)
        {
            if (request != null)
            {
                if (request.PersonID > 0)
                {
                    if (request.Account != null)
                    {
                        Person person = new Person(request.PersonID);
                        Account account = new Account(request.Account.AccountName, request.Account.Password, request.Account.Email);
                        return new Administrator(adminID, person, account , true);
                    }
                }
            }
            return null;
        }

        private AdministratorResponse? AdministratorToResponse(Administrator? admin)
        {
            if (admin != null)
            {
                if (admin.Person != null)
                {
                    if (admin.Account != null)
                    {
                        PersonRequest person = new PersonRequest(admin.Person.PersonID, admin.Person.FirstName, admin.Person.MiddleName, admin.Person.LastName);
                        AccountResponse account = new AccountResponse(admin.Account.AccountID , admin.Account.AccountName, admin.Account.Email);
                        return new AdministratorResponse(admin.AdminID, person, account, admin.IsActive);
                    }
                }
            }
            return null;
        }


        public async Task<AdministratorResponse?> AddAdministratorAsync(AdministratorRequest request)
        {
            _admin = RequestToAdministrator(request);
            if (_admin != null && _admin.Account != null)
            {
                var result = await _AdminRepository.AddAdminAsync(_admin);
                if (result != null && result.Account != null)
                {
                    _admin.AdminID = result.AdminID;
                    _admin.Account.AccountID = result.Account.AccountID;
                    _admin.Person = result.Person;
                    if (_admin.AdminID > 0 && _admin.Account.AccountID > 0)
                    {
                        return AdministratorToResponse(_admin)!;
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
            return AdministratorToResponse(_admin) ?? null;
        }

        public async Task<AdministratorResponse?> UpdateAdministratorAsync(int adminID, AdministratorRequest request)
        {
            _admin = RequestToAdministrator(request, adminID);
            if (_admin != null)
            {
                bool result = await _AdminRepository.UpdateAdminAsync(_admin);
                if (result)
                {
                    return AdministratorToResponse(_admin)!;
                }
            }
            return null;
        }

        public async Task<IEnumerable<AdministratorResponse>> GetPageAdministratorsAsync(int pageNumber = 1, int pageSize = 10)
        {
            var admins = await _AdminRepository.GetPageAdminsAsync(pageNumber, pageSize);

            var responses = admins?.Select(admin => AdministratorToResponse(admin)).Where(adm => adm != null);

            return responses?.Select(response => response!).ToList() ?? new List<AdministratorResponse>();
        }


    }
}
