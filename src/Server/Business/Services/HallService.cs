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

        private Hall _CreateRequestToHall(CreateHallRequest request)
        {
            return new Hall(request.HallName, request.Building, request.Floor, request.CreatedByAdminID);
        }

        private Hall _UpdateRequestToHall(UpdateHallRequest request,int hallID = -1)
        {
            return new Hall(hallID,request.HallName, request.Building, request.Floor);
        }

        private HallResponse? _HallToResponse(Hall hall)
        {
            return new HallResponse(hall.HallID, hall.HallName, hall.Building, hall.Floor, hall.CreatedByAdminID);
        }

        public async Task<bool> DeleteHallAsync(int hallID)
        {
            return await _hallRepository.DeleteHallAsync(hallID);
        }

        public async Task<HallResponse?> AddHallAsync(CreateHallRequest request)
        {
            HallResponse? hallResponse = null;

            if(request != null)
            {
                _hall = _CreateRequestToHall(request);
                _hall.HallID = await _hallRepository.AddHallAsync(_hall);
                hallResponse = _HallToResponse(_hall);
            }

            return hallResponse;
        }

        public async Task<HallResponse?> UpdateHallAsync(UpdateHallRequest request, int hallID)
        {
            HallResponse? hallResponse = null;

            if (request != null)
            {
                _hall = _UpdateRequestToHall(request,hallID);
                await _hallRepository.UpdateHallAsync(_hall);
                hallResponse = await GetHallByIDAsync(hallID);
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
