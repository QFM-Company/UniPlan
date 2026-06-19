using Business.DTOs.Requests.Create;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;
using Core.Entities;

namespace Business.Mapper
{
    public static class HallMapper
    {
        public static Hall ToHall(this CreateHallRequest request)
        {
            return new Hall(request.HallName, request.Building, request.Floor, request.CreatedByAdminID);
        }

        public static void UpdateHall(this Hall hall, UpdateHallRequest? request)
        {
            if (request == null)
                return;

            hall.HallName = request.HallName;
            hall.Building = request.Building;
            hall.Floor = request.Floor;
        }

        public static HallResponse ToResponse(this Hall hall)
        {
            return new HallResponse(hall.HallID, hall.HallName, hall.Building, hall.Floor, hall.CreatedByAdminID);
        }
    }
}
