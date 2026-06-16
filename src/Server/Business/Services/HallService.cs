using Business.DTOs.Requests;
using Business.DTOs.Requests.Create;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;
using Business.Interfaces;
using Business.Mapper;
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

        public async Task<bool> DeleteHallAsync(int hallID)
        {
            return await _hallRepository.DeleteHallAsync(hallID);
        }

        public async Task<HallResponse?> AddHallAsync(CreateHallRequest request)
        {
            _hall = new Hall();
            _hall = _hall.CreateRequestToHall(request);

            if(_hall != null)
            {
                _hall.HallID = await _hallRepository.AddHallAsync(_hall);

                if (_hall.HallID != -1)
                    return _hall.HallToResponse();
            }

            return null;
        }

        public async Task<HallResponse?> UpdateHallAsync(UpdateHallRequest request, int hallID)
        {
            _hall = new Hall();
            _hall = _hall.UpdateRequestToHall(request, hallID);

            if (_hall != null && await _hallRepository.UpdateHallAsync(_hall))
                return _hall.HallToResponse();

            return null;
        }

        public async Task<IEnumerable<HallResponse>?> GetPagedHallsAsync(int pageNumber = 1, int pageSize = 10)
        {
            IEnumerable<Hall>? halls = await _hallRepository.GetPagedHallsAsync(pageNumber, pageSize);
            return halls?.Select(m => m.HallToResponse()).OfType<HallResponse>();
        }

        public async Task<HallResponse?> GetHallByIDAsync(int hallID)
        {
            _hall = await _hallRepository.GetHallByIDAsync(hallID);
            return _hall != null ? _hall.HallToResponse() : null;
        }
    }
}
