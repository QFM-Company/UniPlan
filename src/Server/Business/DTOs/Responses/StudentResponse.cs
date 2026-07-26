namespace Business.DTOs.Responses
{
    public class StudentResponse
    {
        public int StudentID { get; set; }

        public PersonResponse PersonInfo { get; set; }

        public AccountResponse AccountInfo { get; set; }

        public MajorResponse MajorInfo { get; set; }

        public int CompletedHours { get; set; }

        public StudentResponse(int studentID, PersonResponse personInfo, AccountResponse accountInfo, MajorResponse majorInfo, int completedHours)
        {
            StudentID = studentID;
            PersonInfo = personInfo;
            AccountInfo = accountInfo;
            MajorInfo = majorInfo;
            CompletedHours = completedHours;
        }

        public StudentResponse()
        {
            StudentID = -1;
            PersonInfo = new PersonResponse();
            AccountInfo = new AccountResponse();
            MajorInfo = new MajorResponse();
            CompletedHours = 0;
        }
    }
}
