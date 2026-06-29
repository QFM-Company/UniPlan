namespace Client.Models
{
    public class HallModel
    {
        public int HallID { get; set; }

        public string HallName { get; set; } = string.Empty;

        public string Building { get; set; } = string.Empty;

        public int Floor { get; set; }
    }
}
