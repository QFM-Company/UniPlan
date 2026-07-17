using System.Data;
using System.Threading.Tasks;

namespace Controls.UserControls
{
    public partial class DynamicDataGrid : UserControl
    {
        public delegate Task<DataView> GetByIDDelegate(int id);
        public delegate Task<DataView> LoadDataDelegate(int pageNumber, int pageSize);

        public event LoadDataDelegate? OnLoadData;
        public event GetByIDDelegate? OnGetByID;
        private int _currentPage;

        public DynamicDataGrid()
        {
            InitializeComponent();
            _currentPage = 1;

            dataGrid.DataSource = _GetMessageView("Load...");
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
                    dataGrid.DataSource = await OnLoadData.Invoke(pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                dataGrid.DataSource = _GetMessageView(ex.Message);
            }
        }

        public async void RefreshData()
        {
            await TriggerLoadData(_currentPage, 10);
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

        private void dataGrid_DataSourceChanged(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                btnPervious.Enabled = true;
            }
            else
            {
                btnPervious.Enabled = false;
            }

            if (dataGrid.Rows.Count < 10)
            {
                btnNext.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
            }
        }

        private async void uniPlanButton1_Click(object sender, EventArgs e)
        {
            await TriggerGetByID();
        }

        private async Task TriggerGetByID()
        {
            try
            {
                if (OnGetByID != null && !string.IsNullOrWhiteSpace(searchControl1.TextBox.Text) && int.TryParse(searchControl1.TextBox.Text, out int id))
                {
                    dataGrid.DataSource = await OnGetByID.Invoke(id);
                }
            }
            catch (Exception ex)
            {
                dataGrid.DataSource = _GetMessageView(ex.Message);
            }

        }

        private void uniPlanButton2_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
