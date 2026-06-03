namespace Business.DTOs.Requests
{
    public class UpdateHallRequest
    {
        public string HallName { get; set; } = string.Empty;

        public string Building { get; set; } = string.Empty;

        public int Floor { get; set; }

        public UpdateHallRequest(string hallName, string building, int floor)
        {
            HallName = hallName;
            Building = building;
            Floor = floor;
        }
    }
}
