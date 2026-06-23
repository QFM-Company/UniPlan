using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Requests.Create;
using Business.DTOs.Responses;

namespace Business.Interfaces
{
    public interface IAdministratorService
    {
        Task<IEnumerable<AdministratorResponse>> GetPageAdministratorsAsync(int pageNumber, int pageSize);
        Task<AdministratorResponse?> GetAdministratorByIdAsync(int adminID);
        Task<AdministratorResponse?> AddAdministratorAsync(CreateAdministratorRequest admin);
        Task<AdministratorResponse?> UpdateAdministratorAsync(int adminID, CreateAdministratorRequest admin);
        Task<bool> DeleteAdministratorAsync(int adminID);
    }
}
