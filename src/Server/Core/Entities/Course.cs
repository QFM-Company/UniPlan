using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Course
    {
        public int CourseID { get; set; }
        public string? CourseName { get; set; }
        public int CreditHours { get; set; }
        public Major Major { get; set; }

        public Course(int courseID, string? courseName, int creditHours, Major major)
        {
            CourseID = courseID;
            CourseName = courseName;
            CreditHours = creditHours;
            Major = major;
        }
    }
}
