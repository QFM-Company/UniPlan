using Business.DTOs.Requests.Create;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;
using Business.Interfaces;
using Business.Mapper;
using Core.Entities;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;

namespace Business.Services
{
    public class HallService : IHallService
    {
        private readonly IHallRepository _hallRepository;
        private readonly IValidationService _validationService;

        public HallService(IHallRepository hallRepository, IValidationService validationService)
        {
            _validationService = validationService;
            _hallRepository = hallRepository;
        }

        public async Task<bool> DeleteHallAsync(int hallID)
        {
            return hallID > 0 && await _hallRepository.DeleteHallAsync(hallID);
        }

        public async Task<HallResponse?> AddHallAsync(CreateHallRequest request)
        {
            _validationService.Validate(request);

            Hall hall = request.ToHall();

            hall.HallID = await _hallRepository.AddHallAsync(hall);

            if (hall.HallID != -1)
                return hall.ToResponse();

            return null;
        }

        public async Task<bool> UpdateHallAsync(UpdateHallRequest request, int hallID)
        {
            _validationService.Validate(request);

            Hall? hall = await _hallRepository.GetHallByIDAsync(hallID);

            hall?.UpdateHall(request);

            if (hall != null)
                return await _hallRepository.UpdateHallAsync(hall);

            return false;
        }

        public async Task<IEnumerable<HallResponse>?> GetPagedHallsAsync(int pageNumber = 1, int pageSize = 10)
        {
            IEnumerable<Hall>? halls = await _hallRepository.GetPagedHallsAsync(pageNumber, pageSize);
            return halls?.Select(m => m.ToResponse()).OfType<HallResponse>();
        }

        public async Task<HallResponse?> GetHallByIDAsync(int hallID)
        {
            if (hallID <= 0)
                return null;

            Hall? hall = await _hallRepository.GetHallByIDAsync(hallID);
            return hall != null ? hall.ToResponse() : null;
        }
    }
}
