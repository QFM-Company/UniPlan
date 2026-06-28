namespace Client.Models
{
    public class HallModel
    {
        public int HallID { get; set; }

        public string HallName { get; set; } = string.Empty;

        public string Building { get; set; } = string.Empty;

        public string Floor { get; set; } = string.Empty;


        public HallModel(int hallID, string hallName, string building, string floor)
        {
            HallID = hallID;
            HallName = hallName;
            Building = building;
            Floor = floor;
        }
    }
}
