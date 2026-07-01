using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests.Create
{
    public class CreateHallRequest
    {
        [Required<string>("اسم القاعة مطلوب")]
        [Length("يجب ألا يتجاوز اسم القاعة 50 حرفًا", 50, 1)]
        public string HallName { get; set; } = string.Empty;

        [Length("يجب ألا يتجاوز اسم المبنى 50 حرفًا", 50, 0)]
        public string Building { get; set; } = string.Empty;

        [Required<int>("رقم الطابق مطلوب")]
        [Range<int>("يجب أن يكون رقم الطابق أكبر من أو يساوي 1", 1, int.MaxValue)]
        public int Floor { get; set; }

        [Required<int>("معرف الأدمن المنشئ مطلوب")]
        [Range<int>("يجب أن يكون المعرف أكبر من 0", 1, int.MaxValue)]
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