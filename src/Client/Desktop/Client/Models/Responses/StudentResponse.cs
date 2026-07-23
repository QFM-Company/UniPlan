namespace Client.Models.Responses
{
    public class StudentResponse : Person
    {
        public int StudentID { get; set; }

        public PersonResponse? PersonInfo { get; set; }

        public AccountResponse? AccountInfo { get; set; }

        public MajorResponse? MajorInfo { get; set; }


        public StudentResponse(int studentID, PersonResponse? personInfo, AccountResponse? accountInfo, MajorResponse? majorInfo)
        {
            StudentID = studentID;
            PersonInfo = personInfo;
            AccountInfo = accountInfo;
            MajorInfo = majorInfo;
        }

        public StudentResponse()
        {
            StudentID = -1;
            PersonInfo = new PersonResponse();
            AccountInfo = new AccountResponse();
            MajorInfo = new MajorResponse();
        }
    }
}
