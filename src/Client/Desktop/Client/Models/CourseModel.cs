namespace Client.Models
{
    public class CourseModel : BaseModel
    {
        public int CourseID { get; set; }
        public string? CourseName { get; set; }
        public int CreditHours { get; set; }
        public string? CourseCode { get; set; }
    }
}
