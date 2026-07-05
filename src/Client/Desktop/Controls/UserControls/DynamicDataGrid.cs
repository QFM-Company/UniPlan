using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controls.UserControls
{
    public partial class DynamicDataGrid : UserControl
    {
        public DynamicDataGrid()
        {
            InitializeComponent();
        }


        private int _columnCount = 0;
        public int ColumnCount
        {
            get { return _columnCount; }
            set
            {
                _columnCount = value;
                CreateColumns();
            }
        }

        private string _columnNames = "";
        public string ColumnNames
        {
            get { return _columnNames; }
            set
            {
                _columnNames = value;
                CreateColumns();
            }
        }

        private void CreateColumns()
        {
            if (dataGridView1 == null) return;

            dataGridView1.Columns.Clear();

            if (_columnCount <= 0 || string.IsNullOrEmpty(_columnNames))
                return;

            string[] namesArray = _columnNames.Split(',');
            int actualColumnCount = Math.Min(_columnCount, namesArray.Length);

            for (int i = 0; i < actualColumnCount; i++)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.Name = namesArray[i].Trim();
                col.HeaderText = namesArray[i].Trim();
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns.Add(col);
            }
        }

        public void LoadData(DataTable dt)
        {
            if (dt == null || dataGridView1 == null) return;

            _columnCount = dt.Columns.Count;
            _columnNames = string.Join(",", dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName));
            CreateColumns();

            dataGridView1.DataSource = dt;
        }

        public void LoadData<T>(List<T> list)
        {
            if (list == null || list.Count == 0)
                return;

            var dt = new DataTable();
            var properties = typeof(T).GetProperties();

            foreach (var prop in properties)
            {
                dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (var item in list)
            {
                var row = dt.NewRow();
                foreach (var prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                dt.Rows.Add(row);
            }

            LoadData(dt);
        }

        public bool AllowAddRows
        {
            get { return dataGridView1.AllowUserToAddRows; }
            set { dataGridView1.AllowUserToAddRows = value; }
        }

        public bool AllowEdit
        {
            get { return dataGridView1.ReadOnly; }
            set { dataGridView1.ReadOnly = value; }
        }

        public DataGridView GridView
        {
            get { return dataGridView1; }
        }
    }
}