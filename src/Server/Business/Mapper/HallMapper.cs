using Business.DTOs.Requests.Create;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;
using Core.Entities;

namespace Business.Mapper
{
    public static class HallMapper
    {
        public static Hall? CreateRequestToHall(this Hall hall, CreateHallRequest request)
        {
            if (request != null)
                return new Hall(request.HallName, request.Building, request.Floor, request.CreatedByAdminID);
            
            return null;
        }

        public static Hall? UpdateRequestToHall(this Hall hall, UpdateHallRequest request, int hallID = -1)
        {
            if(request != null)
                return new Hall(hallID, request.HallName, request.Building, request.Floor);
            
            return null;
        }

        public static HallResponse HallToResponse(this Hall hall)
        {
            return new HallResponse(hall.HallID, hall.HallName, hall.Building, hall.Floor, hall.CreatedByAdminID);
        }
    }
}
