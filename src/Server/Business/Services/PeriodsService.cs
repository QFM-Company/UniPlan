using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.Entities;
using Core.Enums;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Business.Services
{
    public class PeriodsService : IPeriodService
    {
        private IPeriodRepository _PeriodRepository;
        private Period? _period;

        public PeriodsService(IPeriodRepository PeriodRepository)
        {
            _PeriodRepository = PeriodRepository;
            _period = null;
        }

        private Period? RequestToPeriod(PeriodRequest? request, int periodID = -1)
        {
            if (request != null)
            {
                return new Period(periodID, request.StartTime, request.EndTime);
            }
            return null;
        }

        private PeriodResponse? PeriodToResponse(Period? period)
        {
            if (period != null)
            {
                return new PeriodResponse(period.PeriodID, period.StartTime, period.EndTime);
            }
            return null;
        }

        public async Task<bool> AddPeriodAsync(PeriodRequest request)
        {
            _period = RequestToPeriod(request);
            if (_period != null)
            {
                _period.PeriodID = await _PeriodRepository.AddPeriodAsync(_period);
                return _period?.PeriodID != -1;
            }

            return false;
        }

        public async Task<bool> DeletePeriodAsync(int periodID)
        {
            return await _PeriodRepository.DeletePeriodAsync(periodID);
        }

        public async Task<PeriodResponse?> GetPeriodByIdAsync(int periodID)
        {
            _period = await _PeriodRepository.GetPeriodByIDAsync(periodID);
            return PeriodToResponse(_period) ?? null;
        }

        public async Task<IEnumerable<PeriodResponse>> GetPagePeriodsAsync(int pageNumber = 1, int pageSize = 10)
        {
            var periods = await _PeriodRepository.GetPagedPeriodsAsync(pageNumber, pageSize);

            var responses = periods?.Select(period => PeriodToResponse(period)).Where(per => per != null);

            return responses?.Select(response => response!).ToList() ?? new List<PeriodResponse>();
        }



    }
}
