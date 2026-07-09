using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests.Update
{
    public class UpdateHallRequest
    {
        [Required<int>("معرف القاعة مطلوب")]
        [Range<int>("يجب أن يكون المعرف أكبر من 0", 1, int.MaxValue)]
        public int HallID { get; set; }

        [Required<string>("اسم القاعة مطلوب")]
        [Length("يجب ألا يتجاوز اسم القاعة 50 حرفًا", 50, 1)]
        public string HallName { get; set; } = string.Empty;

        [Length("يجب ألا يتجاوز اسم المبنى 50 حرفًا", 50, 0)]
        public string Building { get; set; } = string.Empty;

        [Range<int>("يجب أن يكون رقم الطابق بين الصفر و 10", 0, 10)]
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