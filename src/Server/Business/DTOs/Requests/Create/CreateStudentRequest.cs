namespace Business.DTOs.Requests.Create
{
    public class CreateStudentRequest
    {
        public int StudentID { get; set; }

        public CreateAccountRequest AccountData { get; set; }

        public PersonRequest PersonData { get; set; }

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
