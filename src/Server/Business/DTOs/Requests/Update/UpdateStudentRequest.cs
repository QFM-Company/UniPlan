using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests.Update
{
    public class UpdateStudentRequest
    {
        [Required<int>("معرف الطالب مطلوب")]
        [Range<int>("يجب أن يكون المعرف أكبر من 0", 1, int.MaxValue)]
        public int StudentID { get; set; }

        [Required<UpdateAccountRequest>("بيانات الحساب مطلوبة")]
        public UpdateAccountRequest AccountData { get; set; }

        [Required<PersonRequest>("بيانات الشخص مطلوبة")]
        public PersonRequest PersonData { get; set; }

        [Required<int>("معرف التخصص مطلوب")]
        [Range<int>("يجب أن يكون المعرف أكبر من 0", 1, int.MaxValue)]
        public int MajorID { get; set; }

        public UpdateStudentRequest(int studentID, UpdateAccountRequest accountData, PersonRequest personData, int majorID)
        {
            StudentID = studentID;
            AccountData = accountData;
            PersonData = personData;
            MajorID = majorID;
        }

        public UpdateStudentRequest()
        {
            StudentID = -1;
            AccountData = new UpdateAccountRequest();
            PersonData = new PersonRequest();
            MajorID = default;
        }
    }
}