namespace Business.DTOs.Requests.Update
{
    public class UpdateHallRequest
    {
        public int HallID { get; set; }

        public string HallName { get; set; } = string.Empty;

        public string Building { get; set; } = string.Empty;

        public int Floor { get; set; }

        public UpdateHallRequest()
        {
            HallID = -1;
            HallName = string.Empty;
            Building = string.Empty;
            Floor = default;
        }

        public UpdateHallRequest(int hallID, string hallName, string building, int floor)
        {
            HallID = hallID;
            HallName = hallName;
            Building = building;
            Floor = floor;
        }
    }
}
