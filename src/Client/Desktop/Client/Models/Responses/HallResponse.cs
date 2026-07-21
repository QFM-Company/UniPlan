namespace Client.Models.Responses
{
    public class HallResponse : BaseModel
    {
        public int HallID { get; set; }

        public string HallName { get; set; } = string.Empty;

        public string Building { get; set; } = string.Empty;

        public int Floor { get; set; }

        public int CreatedByAdminID { get; set; }

    }
}
