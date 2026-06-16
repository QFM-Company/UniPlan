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

        public HallService(IHallRepository hallRepository)
        {
            _hallRepository = hallRepository;
        }

        public async Task<bool> DeleteHallAsync(int hallID)
        {
            return await _hallRepository.DeleteHallAsync(hallID);
        }

        public async Task<HallResponse?> AddHallAsync(CreateHallRequest request)
        {
            Hall? hall = request.CreateRequestToHall();

            if(hall != null)
            {
                hall.HallID = await _hallRepository.AddHallAsync(hall);

                if (hall.HallID != -1)
                    return hall.HallToResponse();
            }

            return null;
        }

        public async Task<bool> UpdateHallAsync(UpdateHallRequest request, int hallID)
        {
            Hall? hall = await _hallRepository.GetHallByIDAsync(hallID);

            hall?.UpdateHallFromRequest(request);

            if (hall != null)
                return await _hallRepository.UpdateHallAsync(hall);

            return false;
        }

        public async Task<IEnumerable<HallResponse>?> GetPagedHallsAsync(int pageNumber = 1, int pageSize = 10)
        {
            IEnumerable<Hall>? halls = await _hallRepository.GetPagedHallsAsync(pageNumber, pageSize);
            return halls?.Select(m => m.HallToResponse()).OfType<HallResponse>();
        }

        public async Task<HallResponse?> GetHallByIDAsync(int hallID)
        {
            Hall? hall = await _hallRepository.GetHallByIDAsync(hallID);
            return hall != null ? hall.HallToResponse() : null;
        }
    }
}
