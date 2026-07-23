using Client.Models;
using Client.Models.Requests;
using Client.Models.Responses;
using ViewModels.Extensions;

namespace Presentation.Forms.OperationsForms
{
    public partial class LectureOperationForm : BaseOperationForm
    {
        public LectureOperationForm()
        {
            InitializeComponent();
        }

        public override void UpdateModel()
        {
            txtLectureType.TryGetInt(out int lectureType);
            txtDurationValue.TryGetInt(out int durationValue);
            txtCourseID.TryGetInt(out int courseID);

            LectureRequest lecture = new LectureRequest
            {
                LectureType = lectureType,
                DurationValue = durationValue,
                CourseID = courseID
            };

            Model = (Person)lecture;
        }

        public override void LoadData()
        {
            LectureResponse lecture = Model.ToLecture();

            txtLectureType.Text = lecture?.LectureType;
            txtDurationValue.Text = lecture?.DurationValue.ToString();
            txtCourseID.Text = lecture?.CourseInfo?.CourseID.ToString();
        }

        public override void InitializeFields()
        {
            txtLectureType.Text = string.Empty;
            txtDurationValue.Text = string.Empty;
            txtCourseID.Text = string.Empty;
        }
    }
}
