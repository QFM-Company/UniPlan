using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace Business.Services
{
    public class HallService : IHallService
    {
        private IHallRepository _hallRepository;
        private Hall? _hall;

        public HallService(IHallRepository hallRepository)
        {
            _hallRepository = hallRepository;
            _hall = null;
        }

        private Hall _RequestToHall(HallRequest request)
        {
            return new Hall(request.HallName, request.Building, request.Floor, request.CreatedByAdminID);
        }

        private HallResponse? _HallToResponse(Hall hall)
        {
            return new HallResponse(hall.HallID, hall.HallName, hall.Building, hall.Floor, hall.CreatedByAdminID);
        }

        public async Task<bool> DeleteHallAsync(int hallID)
        {
            return await _hallRepository.DeleteHallAsync(hallID);
        }

        public async Task<HallResponse?> AddHallAsync(HallRequest request)
        {
            HallResponse? hallResponse = null;

            if(request != null)
            {
                _hall = _RequestToHall(request);
                _hall.HallID = await _hallRepository.AddHallAsync(_hall);
                hallResponse = _HallToResponse(_hall);
            }

            return hallResponse;
        }

        public async Task<HallResponse?> UpdateHallAsync(HallRequest request, int hallID)
        {
            HallResponse? hallResponse = null;

            if (request != null)
            {
                _hall = _RequestToHall(request);
                await _hallRepository.UpdateHallAsync(_hall);
                hallResponse = _HallToResponse(_hall);
            }

            return hallResponse;
        }

        public async Task<IEnumerable<HallResponse>?> GetPagedHallsAsync(int pageNumber = 1, int pageSize = 10)
        {
            IEnumerable<Hall>? halls = await _hallRepository.GetPagedHallsAsync(pageNumber, pageSize);
            var responses = halls?.ToList();
            return responses?.Select(h => _HallToResponse(h)).OfType<HallResponse>();
        }

        public async Task<HallResponse?> GetHallByIDAsync(int hallID)
        {
            _hall = await _hallRepository.GetHallByIDAsync(hallID);
            return _hall != null ? _HallToResponse(_hall) : null;
        }
    }
}
