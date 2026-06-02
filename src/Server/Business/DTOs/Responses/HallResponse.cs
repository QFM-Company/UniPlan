namespace Business.DTOs.Responses
{
    public class HallResponse
    {
        public int HallID { get; set; }

        public string HallName { get; set; } = string.Empty;

        public string Building { get; set; } = string.Empty;

        public int Floor { get; set; }

        public int CreatedByAdminID { get; set; }

        public HallResponse(int hallID, string hallName, string building, int floor, int createdByAdminID)
        {
            HallID = hallID;
            HallName = hallName;
            Building = building;
            Floor = floor;
            CreatedByAdminID = createdByAdminID;
        }

    }
}
