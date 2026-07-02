namespace Business.DTOs.Responses
{
    public class StudentTermResponse
    {
        public int RegistrationID { get; set; }

        public int StudentID { get; set; }

        public AcademicTermResponse? AcademicTerm { get; set; }



        public StudentTermResponse()
        {
            RegistrationID = -1;
            StudentID = -1;
            AcademicTerm = null;
        }

        public StudentTermResponse(int registrationID, int studentID, AcademicTermResponse? academicTerm)
        {
            RegistrationID = registrationID;
            StudentID = studentID;
            AcademicTerm = academicTerm;
        }
    }
}
