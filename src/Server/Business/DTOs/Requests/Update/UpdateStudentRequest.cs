using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests.Update
{
    public class UpdateStudentRequest
    {

        [Required<UpdateAccountRequest>("بيانات الحساب مطلوبة")]
        public UpdateAccountRequest? AccountData { get; set; }

        [Required<PersonRequest>("بيانات الشخص مطلوبة")]
        public PersonRequest? PersonData { get; set; }

        [Required<int>("معرف التخصص مطلوب")]
        [Range<int>("يجب أن يكون المعرف أكبر من 0", 1, int.MaxValue)]
        public int MajorID { get; set; }

    }
}