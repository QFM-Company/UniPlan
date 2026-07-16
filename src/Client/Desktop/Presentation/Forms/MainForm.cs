using ViewModels;

namespace Presentation.Forms
{
    public partial class MainForm : Form
    {
        private readonly HallsManagementForm _hallsManagementForm;
        private readonly MajorsManagementForm _majorsManagementForm;

        public MainForm(HallsManagementForm hallsManagementForm, MajorsManagementForm majorsManagementForm)
        {
            InitializeComponent();

            _hallsManagementForm = hallsManagementForm;
            _majorsManagementForm = majorsManagementForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _hallsManagementForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _majorsManagementForm.ShowDialog();
        }
    }
}
