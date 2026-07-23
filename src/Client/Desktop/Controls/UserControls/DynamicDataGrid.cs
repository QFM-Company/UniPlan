using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controls.UserControls
{
    public partial class DynamicDataGrid : UserControl
    {
        public delegate Task<DataView> GetByIDDelegate(int id);
        public delegate Task<DataView> LoadDataDelegate(int pageNumber, int pageSize);

        public event LoadDataDelegate? OnLoadData;
        public event GetByIDDelegate? OnGetByID;
        public event Action<object, int, DataRowView>? OnUpdateRow;
        public event Action<object, int>? OnDeleteRow;
        public event Action<object>? OnAddRow;

        private int _currentPage;

        [Category("Control Options")]
        [Description("Enables or disables the Delete button from the designer.")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool AddEnabled
        {
            get => btnAdd.Enabled; 
            set => btnAdd.Enabled = value;
        }

        [Category("Control Options")]
        [Description("Enables or disables the Update button from the designer.")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool UpdateEnabled
        {
            get { return btnUpdate.Enabled; }
            set { btnUpdate.Enabled = value; }
        }

        [Category("Control Options")]
        [Description("Enables or disables the Delete button from the designer.")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool DeleteEnabled
        {
            get => btnDelete.Enabled;
            set => btnDelete.Enabled = value;
        }

        public DynamicDataGrid()
        {
            InitializeComponent();
            _currentPage = 1;
        }

        private DataView _GetMessageView(string message)
        {
            DataTable table = new DataTable();

            table.Columns.Add("الرسائل");
            table.Rows.Add(message);

            return table.DefaultView;
        }

        public async Task TriggerLoadData(int pageNumber, int pageSize)
        {
            try
            {
                dataGrid.DataSource = _GetMessageView("يتم التحميل");

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
            DataTable? table = null;

            if (dataGrid.DataSource is DataTable dt)
                table = dt;

            else if (dataGrid.DataSource is DataView dv)
                table = dv.Table;

            if (table != null)
            {
                foreach (DataGridViewColumn col in dataGrid.Columns)
                {
                    if (!string.IsNullOrEmpty(col.DataPropertyName) &&
                        table.Columns.Contains(col.DataPropertyName))
                    {
                        var dataCol = table.Columns[col.DataPropertyName];

                        if (dataCol == null)
                            break;

                        bool hidden = dataCol.ExtendedProperties.ContainsKey("IsHidden") &&
                                      bool.Parse(dataCol?.ExtendedProperties["IsHidden"]?.ToString() ?? "true");

                        col.Visible = !hidden;
                    }
                }
            }

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


            var firstVisibleColumn = dataGrid.Columns
                                    .Cast<DataGridViewColumn>()
                                    .FirstOrDefault(c => c.Visible);

            if (firstVisibleColumn != null)
            {
                dataGrid.CurrentCell = dataGrid.Rows[0].Cells[firstVisibleColumn.Index];
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await TriggerGetByID();
        }

        private async Task TriggerGetByID()
        {
            try
            {
                if (OnGetByID != null && searchControl1.TextBox.TryGetInt(out int id))
                {
                    dataGrid.DataSource = _GetMessageView("يتم التحميل");
                    dataGrid.DataSource = await OnGetByID.Invoke(id);
                }
            }
            catch (Exception ex)
            {
                dataGrid.DataSource = _GetMessageView(ex.Message);
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGrid.CurrentRow != null && dataGrid.CurrentRow.DataBoundItem is DataRowView selectedRow)
            {
                DataTable currentTable = selectedRow.Row.Table;

                if (currentTable.PrimaryKey != null && currentTable.PrimaryKey.Length > 0)
                {
                    DataColumn pkColumn = currentTable.PrimaryKey[0];

                    if(int.TryParse(selectedRow.Row[pkColumn].ToString(), out int primaryKey))
                    {
                        OnDeleteRow?.Invoke(this, primaryKey);
                    }                   
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGrid.CurrentRow != null && dataGrid.CurrentRow.DataBoundItem is DataRowView selectedRow)
            {
                DataTable currentTable = selectedRow.Row.Table;

                if (currentTable.PrimaryKey != null && currentTable.PrimaryKey.Length > 0)
                {
                    DataColumn pkColumn = currentTable.PrimaryKey[0];

                    if (int.TryParse(selectedRow.Row[pkColumn].ToString(), out int primaryKey))
                    {
                        OnUpdateRow?.Invoke(this, primaryKey, selectedRow);
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OnAddRow?.Invoke(this);
        }
    }
}
