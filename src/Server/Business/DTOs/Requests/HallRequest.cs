namespace Business.DTOs.Requests
{
    public class HallRequest
    {
        public string HallName { get; set; } = string.Empty;

        public string Building { get; set; } = string.Empty;

        public int Floor { get; set; }

        public int CreatedByAdminID { get; set; }

        public HallRequest(string hallName, string building, int floor, int createdByAdminID)
        {
            HallName = hallName;
            Building = building;
            Floor = floor;
            CreatedByAdminID = createdByAdminID;
        }
    }
}
