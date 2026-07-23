using Client.Models;
using Client.Models.Requests;
using Client.Models.Responses;
using ViewModels.Extensions;

namespace Presentation.Forms.OperationsForms
{
    public partial class CourseOperationForm : BaseOperationForm
    {
        public CourseOperationForm()
        {
            InitializeComponent();
        }

        public override void UpdateModel()
        {
            txtCreditHours.TryGetInt(out int creditHours);

            CourseRequest course = new CourseRequest
            {
                CourseName = txtCourseName.Text,
                CreditHours = creditHours,
                CourseCode = txtCourseCode.Text
            };

            Model = (Person)course;
        }

        public override void LoadData()
        {
            CourseResponse course = Model.ToCourse();

            txtCourseName.Text = course?.CourseName;
            txtCreditHours.Text = course?.CreditHours.ToString();
            txtCourseCode.Text = course?.CourseCode;
        }

        public override void InitializeFields()
        {
            txtCourseName.Text = string.Empty;
            txtCreditHours.Text = string.Empty;
            txtCourseCode.Text = string.Empty;
        }
    }
}
