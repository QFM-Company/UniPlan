using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests.Create
{
    public class CreateStudentRequest
    {
        [Required<int>("معرف الطالب مطلوب")]
        [Range<int>("يجب أن يكون المعرف أكبر من 0", 1, int.MaxValue)]
        public int StudentID { get; set; }

        [Required<CreateAccountRequest>("بيانات الحساب مطلوبة")]
        public CreateAccountRequest AccountData { get; set; }

        [Required<PersonRequest>("بيانات الشخص مطلوبة")]
        public PersonRequest PersonData { get; set; }

        [Required<int>("معرف التخصص مطلوب")]
        [Range<int>("يجب أن يكون المعرف أكبر من 0", 1, int.MaxValue)]
        public int MajorID { get; set; }

        public CreateStudentRequest(int studentID, CreateAccountRequest accountData, PersonRequest personData, int majorID)
        {
            StudentID = studentID;
            AccountData = accountData;
            PersonData = personData;
            MajorID = majorID;
        }

        public CreateStudentRequest()
        {
            StudentID = -1;
            AccountData = new CreateAccountRequest();
            PersonData = new PersonRequest();
            MajorID = -1;
        }
    }
}