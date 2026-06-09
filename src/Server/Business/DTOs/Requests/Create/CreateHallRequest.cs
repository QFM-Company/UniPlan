using Business.DTOs.Requests.Update;

namespace Business.DTOs.Requests.Create
{
    public class CreateHallRequest : UpdateHallRequest
    {
        public int CreatedByAdminID { get; set; }

        public CreateHallRequest(string hallName, string building, int floor, int createdByAdminID)
         : base(hallName,building,floor)
        {
            CreatedByAdminID = createdByAdminID;
        }
    }
}
