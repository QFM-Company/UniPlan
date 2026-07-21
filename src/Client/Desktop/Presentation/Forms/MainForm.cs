using Presentation.Forms.ManagementForms;
using ViewModels;

namespace Presentation.Forms
{
    public partial class MainForm : Form
    {
        private readonly HallsManagementForm _hallsManagementForm;
        private readonly AdministratorsManagementForm _administratorsManagementForm;
        private readonly CourseOfferingsManagementForm _courseOfferingsManagementForm;
        private readonly CourseSessionsManagementForm _courseSessionsManagementForm;
        private readonly AcademicTermsManagementForm _academicTermsManagementForm;
        private readonly CoursesManagementForm _coursesManagementForm;
        private readonly CoursePrerequisitesManagementForm _coursePrerequisitesManagementForm;
        private readonly LecturesManagementForm _lecturesManagementForm;
        private readonly MajorsManagementForm _majorsManagementForm;
        private readonly PeriodsManagementForm _periodsManagementForm;
        private readonly TimeSlotsManagementForm _timeSlotsManagementForm;
        private readonly StudentsManagementForm _studentsManagementForm;

        public MainForm(
            HallsManagementForm hallsManagementForm,
            AdministratorsManagementForm administratorsManagementForm,
            CourseOfferingsManagementForm courseOfferingsManagementForm,
            CourseSessionsManagementForm courseSessionsManagementForm,
            AcademicTermsManagementForm academicTermsManagementForm,
            CoursesManagementForm coursesManagementForm,
            CoursePrerequisitesManagementForm coursePrerequisitesManagementForm,
            LecturesManagementForm lecturesManagementForm,
            MajorsManagementForm majorsManagementForm,
            PeriodsManagementForm periodsManagementForm,
            TimeSlotsManagementForm timeSlotsManagementForm,
            StudentsManagementForm studentsManagementForm)
        {
            InitializeComponent();

            _hallsManagementForm = hallsManagementForm;
            _administratorsManagementForm = administratorsManagementForm;
            _courseOfferingsManagementForm = courseOfferingsManagementForm;
            _courseSessionsManagementForm = courseSessionsManagementForm;
            _academicTermsManagementForm = academicTermsManagementForm;
            _coursesManagementForm = coursesManagementForm;
            _coursePrerequisitesManagementForm = coursePrerequisitesManagementForm;
            _lecturesManagementForm = lecturesManagementForm;
            _majorsManagementForm = majorsManagementForm;
            _periodsManagementForm = periodsManagementForm;
            _timeSlotsManagementForm = timeSlotsManagementForm;
            _studentsManagementForm = studentsManagementForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _hallsManagementForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _majorsManagementForm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _academicTermsManagementForm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _administratorsManagementForm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            _courseOfferingsManagementForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _coursePrerequisitesManagementForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _coursesManagementForm.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            _courseSessionsManagementForm.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            _lecturesManagementForm.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            _periodsManagementForm.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            _studentsManagementForm.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            _timeSlotsManagementForm.ShowDialog();
        }
    }
}
