namespace Controls.UserControls
{
    partial class DynamicDataGrid
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            btnSearch = new Controls.Customs.UniPlanButton();
            panel1 = new Panel();
            searchControl1 = new SearchControl();
            btnRefresh = new Controls.Customs.UniPlanButton();
            panel2 = new Panel();
            panel4 = new Panel();
            btnUpdate = new Controls.Customs.UniPlanButton();
            btnDelete = new Controls.Customs.UniPlanButton();
            btnAdd = new Controls.Customs.UniPlanButton();
            panel3 = new Panel();
            btnPervious = new Controls.Customs.UniPlanButton();
            btnNext = new Controls.Customs.UniPlanButton();
            dataGrid = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(30, 58, 138);
            btnSearch.BorderRadius = 15;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatAppearance.MouseDownBackColor = Color.FromArgb(19, 122, 148);
            btnSearch.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 177, 212);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSearch.ForeColor = Color.FromArgb(255, 255, 255);
            btnSearch.Location = new Point(247, 19);
            btnSearch.Margin = new Padding(2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(50, 40);
            btnSearch.TabIndex = 11;
            btnSearch.Tag = "-";
            btnSearch.Text = "🔎";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(searchControl1);
            panel1.Controls.Add(btnRefresh);
            panel1.Controls.Add(btnSearch);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(807, 79);
            panel1.TabIndex = 13;
            // 
            // searchControl1
            // 
            searchControl1.BackColor = Color.White;
            searchControl1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            searchControl1.Location = new Point(16, 19);
            searchControl1.Margin = new Padding(0);
            searchControl1.Name = "searchControl1";
            searchControl1.Size = new Size(229, 40);
            searchControl1.TabIndex = 13;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.FromArgb(30, 58, 138);
            btnRefresh.BorderRadius = 15;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatAppearance.MouseDownBackColor = Color.FromArgb(19, 122, 148);
            btnRefresh.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 177, 212);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.FromArgb(255, 255, 255);
            btnRefresh.Location = new Point(740, 19);
            btnRefresh.Margin = new Padding(2);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(48, 40);
            btnRefresh.TabIndex = 12;
            btnRefresh.Tag = "-";
            btnRefresh.Text = "🔄";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(45, 45, 48);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 487);
            panel2.Name = "panel2";
            panel2.Size = new Size(807, 70);
            panel2.TabIndex = 14;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(btnUpdate);
            panel4.Controls.Add(btnDelete);
            panel4.Controls.Add(btnAdd);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(297, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(510, 70);
            panel4.TabIndex = 1;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Top;
            btnUpdate.BackColor = Color.Gray;
            btnUpdate.BorderRadius = 15;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatAppearance.MouseDownBackColor = Color.FromArgb(19, 122, 148);
            btnUpdate.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 177, 212);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(195, 16);
            btnUpdate.Margin = new Padding(2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(119, 39);
            btnUpdate.TabIndex = 5;
            btnUpdate.Tag = "-";
            btnUpdate.Text = "تعديل";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.BackColor = Color.FromArgb(220, 38, 38);
            btnDelete.BorderRadius = 15;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatAppearance.MouseDownBackColor = Color.FromArgb(19, 122, 148);
            btnDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 177, 212);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDelete.ForeColor = Color.FromArgb(255, 255, 255);
            btnDelete.Location = new Point(358, 16);
            btnDelete.Margin = new Padding(2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(119, 39);
            btnDelete.TabIndex = 4;
            btnDelete.Tag = "-";
            btnDelete.Text = "حذف";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(30, 58, 138);
            btnAdd.BorderRadius = 15;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatAppearance.MouseDownBackColor = Color.FromArgb(19, 122, 148);
            btnAdd.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 177, 212);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAdd.ForeColor = Color.FromArgb(255, 255, 255);
            btnAdd.Location = new Point(32, 16);
            btnAdd.Margin = new Padding(2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(119, 39);
            btnAdd.TabIndex = 3;
            btnAdd.Tag = "-";
            btnAdd.Text = "اضافة";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(btnPervious);
            panel3.Controls.Add(btnNext);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(297, 70);
            panel3.TabIndex = 0;
            // 
            // btnPervious
            // 
            btnPervious.BackColor = Color.Gray;
            btnPervious.BorderRadius = 15;
            btnPervious.Enabled = false;
            btnPervious.FlatAppearance.BorderSize = 0;
            btnPervious.FlatAppearance.MouseDownBackColor = Color.FromArgb(19, 122, 148);
            btnPervious.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 177, 212);
            btnPervious.FlatStyle = FlatStyle.Flat;
            btnPervious.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnPervious.ForeColor = Color.White;
            btnPervious.Location = new Point(16, 20);
            btnPervious.Margin = new Padding(2);
            btnPervious.Name = "btnPervious";
            btnPervious.Size = new Size(62, 35);
            btnPervious.TabIndex = 2;
            btnPervious.Tag = "-";
            btnPervious.Text = "◀";
            btnPervious.UseVisualStyleBackColor = false;
            btnPervious.Click += PageNavigation_Click;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNext.BackColor = Color.Gray;
            btnNext.BorderRadius = 15;
            btnNext.Enabled = false;
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatAppearance.MouseDownBackColor = Color.FromArgb(19, 122, 148);
            btnNext.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 177, 212);
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnNext.ForeColor = Color.FromArgb(255, 255, 255);
            btnNext.Location = new Point(195, 20);
            btnNext.Margin = new Padding(2);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(62, 35);
            btnNext.TabIndex = 3;
            btnNext.Tag = "+";
            btnNext.Text = "▶";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += PageNavigation_Click;
            // 
            // dataGrid
            // 
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.AllowUserToResizeColumns = false;
            dataGrid.AllowUserToResizeRows = false;
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid.BackgroundColor = Color.FromArgb(248, 249, 250);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(210, 230, 250);
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.Desktop;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(210, 230, 250);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            dataGrid.Dock = DockStyle.Fill;
            dataGrid.EnableHeadersVisualStyles = false;
            dataGrid.GridColor = Color.FromArgb(45, 45, 48);
            dataGrid.Location = new Point(0, 79);
            dataGrid.Margin = new Padding(2);
            dataGrid.MultiSelect = false;
            dataGrid.Name = "dataGrid";
            dataGrid.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(210, 230, 250);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGrid.RowHeadersVisible = false;
            dataGrid.RowHeadersWidth = 62;
            dataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid.Size = new Size(807, 408);
            dataGrid.TabIndex = 15;
            dataGrid.DataSourceChanged += dataGrid_DataSourceChanged;
            // 
            // DynamicDataGrid
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGrid);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "DynamicDataGrid";
            Size = new Size(807, 557);
            Load += DynamicDataGrid_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Controls.Customs.UniPlanButton btnSearch;
        private Panel panel1;
        private Controls.Customs.UniPlanButton btnRefresh;
        private Panel panel2;
        private DataGridView dataGrid;
        private Controls.Customs.UniPlanButton btnPervious;
        private Panel panel4;
        private Panel panel3;
        private Controls.Customs.UniPlanButton btnNext;
        private SearchControl searchControl1;
        private Controls.Customs.UniPlanButton btnUpdate;
        private Controls.Customs.UniPlanButton btnDelete;
        private Controls.Customs.UniPlanButton btnAdd;
    }
}
