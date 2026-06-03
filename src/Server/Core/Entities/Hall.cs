using System.Drawing;

namespace Core.Entities
{
    public class Hall
    {
        public int HallID { get; set; }

        public string HallName { get; set; } = string.Empty;

        public string Building { get; set; } = string.Empty;

        public int Floor { get; set; }

        public int CreatedByAdminID { get; set; }

        public Hall(int hallID, string hallName, string building, int floor, int createdByAdminID)
        {
            HallID = hallID;
            HallName = hallName;
            Building = building;
            Floor = floor;
            CreatedByAdminID = createdByAdminID;
        }

        public Hall(string hallName, string building, int floor, int createdByAdminID)
        {
            HallName = hallName;
            Building = building;
            Floor = floor;
            CreatedByAdminID = createdByAdminID;
        }

        public Hall()
        {
            HallID = -1;
            HallName = string.Empty;
            Building = string.Empty;
            Floor = default;
            CreatedByAdminID = -1;
        }

        public Hall(int hallID, string hallName, string building, int floor)
        {
            HallID = hallID;
            HallName = hallName;
            Building = building;
            Floor = floor;
        }
    }
}
