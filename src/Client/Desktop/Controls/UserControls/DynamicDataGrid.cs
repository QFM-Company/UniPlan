using System.Data;

namespace Controls.UserControls
{
    public partial class DynamicDataGrid : UserControl
    {
        public delegate Task<DataView> LoadDataDelegate(int pageNumber, int pageSize);

        public event LoadDataDelegate? OnLoadData;
        private int _currentPage;

        public DynamicDataGrid()
        {
            InitializeComponent();
            _currentPage = 1;

            DV_halls.DataSource = _GetMessageView("Load...");
        }

        private DataView _GetMessageView(string message)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Message");
            table.Rows.Add(message);

            return table.DefaultView;
        }

        public async Task TriggerLoadData(int pageNumber, int pageSize)
        {
            try
            {
                if (OnLoadData != null)
                    DV_halls.DataSource = await OnLoadData.Invoke(pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                DV_halls.DataSource = _GetMessageView(ex.Message);
            }
        }

        private async void PageNavigation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button?.Tag?.ToString() == "+")
            {
                _currentPage++;
            }
            else
            {
                _currentPage--;
            }

            await TriggerLoadData(_currentPage, 10);
        }

        private async void DynamicDataGrid_Load(object sender, EventArgs e)
        {
            await TriggerLoadData(_currentPage, 10);
        }

        private void DV_halls_DataSourceChanged(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                btnPervious.Visible = true;
            }
            else
            {
                btnPervious.Visible = false;
            }

            if (DV_halls.Rows.Count < 10)
            {
                btnNext.Visible = false;
            }
            else
            {
                btnNext.Visible = true;
            }
        }
    }
}