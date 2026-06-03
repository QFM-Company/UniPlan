namespace Business.DTOs.Requests
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
