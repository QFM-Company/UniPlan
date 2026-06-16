using Business.DTOs.Requests.Create;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;
using Core.Entities;

namespace Business.Mapper
{
    public static class HallMapper
    {
        public static Hall? CreateRequestToHall(this CreateHallRequest request)
        {
            if (request != null)
                return new Hall(request.HallName, request.Building, request.Floor, request.CreatedByAdminID);
            
            return null;
        }

        public static void UpdateHallFromRequest(this Hall hall, UpdateHallRequest request)
        {
            hall.HallName = request.HallName;
            hall.Building = request.Building;
            hall.Floor = request.Floor;
        }

        public static HallResponse HallToResponse(this Hall hall)
        {
            return new HallResponse(hall.HallID, hall.HallName, hall.Building, hall.Floor, hall.CreatedByAdminID);
        }
    }
}
