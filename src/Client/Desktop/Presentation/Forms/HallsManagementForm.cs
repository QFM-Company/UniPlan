using ViewModels.Interface;

namespace Presentation.Forms
{
    public partial class HallsManagement : Form
    {
        public IHallsViewModel HallsViewModel { get; set; } 

        public HallsManagement(IHallsViewModel hallsViewModel)
        {
            InitializeComponent();
            HallsViewModel = hallsViewModel;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbHallName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void header1_Load(object sender, EventArgs e)
        {

        }

        private async void HallsManagement_Load(object sender, EventArgs e)
        {
            try
            {
                DV_halls.Columns.Clear();
                DV_halls.DataSource = await HallsViewModel.GetDataView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "UniPlan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
