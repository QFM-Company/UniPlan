using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Requests;
using Business.DTOs.Responses;

namespace Business.Interfaces
{
    public interface IAdministratorService
    {
        Task<IEnumerable<AdministratorResponse>> GetPageAdministratorsAsync(int pageNumber, int pageSize);
        Task<AdministratorResponse?> GetAdministratorByIdAsync(int adminID);
        Task<bool> AddAdministratorAsync(AdministratorRequest admin);
        Task<bool> UpdateAdministratorAsync(int adminID, AdministratorRequest admin);
        Task<bool> DeleteAdministratorAsync(int adminID);
    }
}
