namespace Business.DTOs.Requests.Create
{
    public class CreateHallRequest
    {
        public string HallName { get; set; } = string.Empty;

        public string Building { get; set; } = string.Empty;

        public int Floor { get; set; }

        public int CreatedByAdminID { get; set; }

        public CreateHallRequest(string hallName, string building, int floor, int createdByAdminID)
        {
            HallName = hallName;
            Building = building;
            Floor = floor;
            CreatedByAdminID = createdByAdminID;
        }

        public CreateHallRequest()
        {
            HallName = string.Empty;
            Building = string.Empty;
            Floor = default;
            CreatedByAdminID = default;
        }
    }
}
