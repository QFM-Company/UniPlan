
namespace Core.Entities
{
    public class Student
    {

        public int StudentID { get; set; }

        public Person? Person { get; set; }

        public Account? Account { get; set; }

        public Major? Major { get; set; }

        public int CompletedHours { get; set; }

        public Student(int studentID)
        {
            StudentID = studentID;
            CompletedHours = 0;
        }

        public Student(int studentID, Person? person, Account? account, Major? major , int completedHours)
        {
            StudentID = studentID;
            Person = person;
            Account = account;
            Major = major;
            CompletedHours = completedHours;
        }

        public Student()
        {
            StudentID = -1;
            Person = null;
            Account = null;
            Major = null;
            CompletedHours = 0;
        }
    }
}
