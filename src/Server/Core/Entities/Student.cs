
namespace Core.Entities
{
    public class Student
    {

        public int StudentID { get; set; }

        public Person? Person { get; set; }

        public Account? Account { get; set; }

        public Major? Major { get; set; }


        public Student(int studentID, Person? person, Account? account, Major? major)
        {
            StudentID = studentID;
            Person = person;
            Account = account;
            Major = major;
        }

        public Student()
        {
            StudentID = default;
            Person = null;
            Account = null;
            Major = null;
        }
    }
}
