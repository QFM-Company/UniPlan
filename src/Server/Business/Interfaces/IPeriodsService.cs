using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Requests;
using Business.DTOs.Responses;

namespace Core.Interfaces.Services
{
    public interface IPeriodService
    {
        Task<IEnumerable<PeriodResponse>> GetPagePeriodsAsync(int pageNumber, int pageSize);
        Task<PeriodResponse?> GetPeriodByIdAsync(int periodID);
        Task<bool> AddPeriodAsync(PeriodRequest period);
        Task<bool> DeletePeriodAsync(int periodID);
    }
}