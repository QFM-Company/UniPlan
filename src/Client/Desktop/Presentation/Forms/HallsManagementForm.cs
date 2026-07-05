using ViewModels.Interface;

namespace Presentation.Forms
{
    public partial class HallsManagement : Form
    {
        private readonly IHallsViewModel _hallsViewModel;

        private int currentPage;

        public HallsManagement(IHallsViewModel hallsViewModel)
        {
            InitializeComponent();
            _hallsViewModel = hallsViewModel;
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

        private void HallsManagement_Load(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadPage();
        }

        private void PageNavigation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button?.Tag?.ToString() == "+")
            {
                currentPage++;
            }
            else
            {
                currentPage--;
            }

            LoadPage();
        }

        private async void LoadPage()
        {
            try
            {
                DV_halls.Columns.Clear();
                DV_halls.DataSource = await _hallsViewModel.GetDataView(currentPage, 10);

                if (currentPage > 1)
                {
                    uniPlanButton2.Visible = true;
                }
                else
                {
                    uniPlanButton2.Visible = false;
                }

                if (DV_halls.Rows.Count < 10)
                {
                    uniPlanButton1.Visible = false;
                }
                else
                {
                    uniPlanButton1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "UniPlan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dynamicDataGrid1_Load(object sender, EventArgs e)
        {

        }
    }
}
