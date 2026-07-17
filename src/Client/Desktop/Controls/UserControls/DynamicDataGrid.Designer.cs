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
            uniPlanButton1 = new UniPlan.Controls.CustomButtons.UniPlanButton();
            panel1 = new Panel();
            searchControl1 = new SearchControl();
            uniPlanButton2 = new UniPlan.Controls.CustomButtons.UniPlanButton();
            panel2 = new Panel();
            panel4 = new Panel();
            uniPlanButton5 = new UniPlan.Controls.CustomButtons.UniPlanButton();
            uniPlanButton4 = new UniPlan.Controls.CustomButtons.UniPlanButton();
            uniPlanButton3 = new UniPlan.Controls.CustomButtons.UniPlanButton();
            panel3 = new Panel();
            btnPervious = new UniPlan.Controls.CustomButtons.UniPlanButton();
            btnNext = new UniPlan.Controls.CustomButtons.UniPlanButton();
            dataGrid = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            SuspendLayout();
            // 
            // uniPlanButton1
            // 
            uniPlanButton1.BackColor = Color.FromArgb(30, 58, 138);
            uniPlanButton1.BorderRadius = 15;
            uniPlanButton1.FlatAppearance.BorderSize = 0;
            uniPlanButton1.FlatAppearance.MouseDownBackColor = Color.FromArgb(19, 122, 148);
            uniPlanButton1.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 177, 212);
            uniPlanButton1.FlatStyle = FlatStyle.Flat;
            uniPlanButton1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            uniPlanButton1.ForeColor = Color.FromArgb(255, 255, 255);
            uniPlanButton1.Location = new Point(247, 19);
            uniPlanButton1.Margin = new Padding(2);
            uniPlanButton1.Name = "uniPlanButton1";
            uniPlanButton1.Size = new Size(50, 40);
            uniPlanButton1.TabIndex = 11;
            uniPlanButton1.Tag = "-";
            uniPlanButton1.Text = "🔎";
            uniPlanButton1.UseVisualStyleBackColor = false;
            uniPlanButton1.Click += uniPlanButton1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(searchControl1);
            panel1.Controls.Add(uniPlanButton2);
            panel1.Controls.Add(uniPlanButton1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(807, 79);
            panel1.TabIndex = 13;
            // 
            // searchControl1
            // 
            searchControl1.BackColor = Color.White;
            searchControl1.Location = new Point(16, 19);
            searchControl1.Margin = new Padding(0);
            searchControl1.Name = "searchControl1";
            searchControl1.Size = new Size(229, 40);
            searchControl1.TabIndex = 13;
            // 
            // uniPlanButton2
            // 
            uniPlanButton2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            uniPlanButton2.BackColor = Color.FromArgb(30, 58, 138);
            uniPlanButton2.BorderRadius = 15;
            uniPlanButton2.FlatAppearance.BorderSize = 0;
            uniPlanButton2.FlatAppearance.MouseDownBackColor = Color.FromArgb(19, 122, 148);
            uniPlanButton2.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 177, 212);
            uniPlanButton2.FlatStyle = FlatStyle.Flat;
            uniPlanButton2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            uniPlanButton2.ForeColor = Color.FromArgb(255, 255, 255);
            uniPlanButton2.Location = new Point(741, 19);
            uniPlanButton2.Margin = new Padding(2);
            uniPlanButton2.Name = "uniPlanButton2";
            uniPlanButton2.Size = new Size(48, 40);
            uniPlanButton2.TabIndex = 12;
            uniPlanButton2.Tag = "-";
            uniPlanButton2.Text = "🔄";
            uniPlanButton2.UseVisualStyleBackColor = false;
            uniPlanButton2.Click += uniPlanButton2_Click;
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
            panel4.Controls.Add(uniPlanButton5);
            panel4.Controls.Add(uniPlanButton4);
            panel4.Controls.Add(uniPlanButton3);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(297, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(510, 70);
            panel4.TabIndex = 1;
            // 
            // uniPlanButton5
            // 
            uniPlanButton5.Anchor = AnchorStyles.Top;
            uniPlanButton5.BackColor = Color.Gray;
            uniPlanButton5.BorderRadius = 15;
            uniPlanButton5.FlatAppearance.BorderSize = 0;
            uniPlanButton5.FlatAppearance.MouseDownBackColor = Color.FromArgb(19, 122, 148);
            uniPlanButton5.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 177, 212);
            uniPlanButton5.FlatStyle = FlatStyle.Flat;
            uniPlanButton5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            uniPlanButton5.ForeColor = Color.White;
            uniPlanButton5.Location = new Point(195, 16);
            uniPlanButton5.Margin = new Padding(2);
            uniPlanButton5.Name = "uniPlanButton5";
            uniPlanButton5.Size = new Size(119, 39);
            uniPlanButton5.TabIndex = 5;
            uniPlanButton5.Tag = "-";
            uniPlanButton5.Text = "Update";
            uniPlanButton5.UseVisualStyleBackColor = false;
            // 
            // uniPlanButton4
            // 
            uniPlanButton4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            uniPlanButton4.BackColor = Color.FromArgb(220, 38, 38);
            uniPlanButton4.BorderRadius = 15;
            uniPlanButton4.FlatAppearance.BorderSize = 0;
            uniPlanButton4.FlatAppearance.MouseDownBackColor = Color.FromArgb(19, 122, 148);
            uniPlanButton4.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 177, 212);
            uniPlanButton4.FlatStyle = FlatStyle.Flat;
            uniPlanButton4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            uniPlanButton4.ForeColor = Color.FromArgb(255, 255, 255);
            uniPlanButton4.Location = new Point(358, 16);
            uniPlanButton4.Margin = new Padding(2);
            uniPlanButton4.Name = "uniPlanButton4";
            uniPlanButton4.Size = new Size(119, 39);
            uniPlanButton4.TabIndex = 4;
            uniPlanButton4.Tag = "-";
            uniPlanButton4.Text = "Delete";
            uniPlanButton4.UseVisualStyleBackColor = false;
            // 
            // uniPlanButton3
            // 
            uniPlanButton3.BackColor = Color.FromArgb(30, 58, 138);
            uniPlanButton3.BorderRadius = 15;
            uniPlanButton3.FlatAppearance.BorderSize = 0;
            uniPlanButton3.FlatAppearance.MouseDownBackColor = Color.FromArgb(19, 122, 148);
            uniPlanButton3.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 177, 212);
            uniPlanButton3.FlatStyle = FlatStyle.Flat;
            uniPlanButton3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            uniPlanButton3.ForeColor = Color.FromArgb(255, 255, 255);
            uniPlanButton3.Location = new Point(32, 16);
            uniPlanButton3.Margin = new Padding(2);
            uniPlanButton3.Name = "uniPlanButton3";
            uniPlanButton3.Size = new Size(119, 39);
            uniPlanButton3.TabIndex = 3;
            uniPlanButton3.Tag = "-";
            uniPlanButton3.Text = "Add";
            uniPlanButton3.UseVisualStyleBackColor = false;
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(210, 230, 250);
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
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
        private UniPlan.Controls.CustomButtons.UniPlanButton uniPlanButton1;
        private Panel panel1;
        private UniPlan.Controls.CustomButtons.UniPlanButton uniPlanButton2;
        private Panel panel2;
        private DataGridView dataGrid;
        private UniPlan.Controls.CustomButtons.UniPlanButton btnPervious;
        private Panel panel4;
        private Panel panel3;
        private UniPlan.Controls.CustomButtons.UniPlanButton btnNext;
        private SearchControl searchControl1;
        private UniPlan.Controls.CustomButtons.UniPlanButton uniPlanButton5;
        private UniPlan.Controls.CustomButtons.UniPlanButton uniPlanButton4;
        private UniPlan.Controls.CustomButtons.UniPlanButton uniPlanButton3;
    }
}
