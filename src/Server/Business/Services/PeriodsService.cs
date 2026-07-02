using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Mapper;
using Core.Entities;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Business.Services
{
    public class PeriodsService : IPeriodService
    {
        private IPeriodRepository _PeriodRepository;
        private Period? _period;
        private IValidationService _ValidationService;


        public PeriodsService(IPeriodRepository PeriodRepository, IValidationService validationService)
        {
            _PeriodRepository = PeriodRepository;
            _period = null;
            _ValidationService = validationService;
        }


        public async Task<PeriodResponse?> AddPeriodAsync(PeriodRequest request)
        {
            _ValidationService.Validate(request);

            _period = request?.ToPeriod() ?? null;
            if (_period != null)
            {
                _period.PeriodID = await _PeriodRepository.AddPeriodAsync(_period);
                if (_period.PeriodID > 0)
                    return _period.ToResponse();
            }

            return null;
        }

        public async Task<bool> DeletePeriodAsync(int periodID)
        {
            return await _PeriodRepository.DeletePeriodAsync(periodID);
        }

        public async Task<PeriodResponse?> GetPeriodByIdAsync(int periodID)
        {
            _period = await _PeriodRepository.GetPeriodByIDAsync(periodID);
            return _period?.ToResponse() ?? null;
        }

        public async Task<IEnumerable<PeriodResponse>> GetPagePeriodsAsync(int pageNumber = 1, int pageSize = 10)
        {
            var periods = await _PeriodRepository.GetPagedPeriodsAsync(pageNumber, pageSize);

            var responses = periods?.Select(period => period.ToResponse()).Where(per => per != null);

            return responses?.Select(response => response!).ToList() ?? new List<PeriodResponse>();
        }
    }
}
