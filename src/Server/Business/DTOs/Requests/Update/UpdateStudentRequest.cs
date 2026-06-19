namespace Business.DTOs.Requests.Update
{
    public class UpdateStudentRequest
    {
        public int StudentID { get; set; }

        public UpdateAccountRequest AccountData { get; set; }

        public PersonRequest PersonData { get; set; }

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
