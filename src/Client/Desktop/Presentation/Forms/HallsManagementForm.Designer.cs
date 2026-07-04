namespace Presentation.Forms
{
    partial class HallsManagement
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            txtFloorNumber = new TextBox();
            txtBuildingName = new TextBox();
            DV_halls = new DataGridView();
            col1 = new DataGridViewTextBoxColumn();
            col2 = new DataGridViewTextBoxColumn();
            col3 = new DataGridViewTextBoxColumn();
            col4 = new DataGridViewTextBoxColumn();
            col5 = new DataGridViewButtonColumn();
            searchControl1 = new Controls.UserControls.SearchControl();
            header1 = new Controls.UserControls.Header();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DV_halls).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(244, 247, 249);
            panel1.Controls.Add(searchControl1);
            panel1.Controls.Add(txtFloorNumber);
            panel1.Controls.Add(txtBuildingName);
            panel1.Location = new Point(105, 123);
            panel1.Name = "panel1";
            panel1.Size = new Size(1170, 92);
            panel1.TabIndex = 1;
            // 
            // txtFloorNumber
            // 
            txtFloorNumber.ForeColor = Color.SteelBlue;
            txtFloorNumber.Location = new Point(704, 22);
            txtFloorNumber.Name = "txtFloorNumber";
            txtFloorNumber.PlaceholderText = "Floor Number";
            txtFloorNumber.Size = new Size(240, 35);
            txtFloorNumber.TabIndex = 2;
            // 
            // txtBuildingName
            // 
            txtBuildingName.ForeColor = Color.SteelBlue;
            txtBuildingName.Location = new Point(400, 26);
            txtBuildingName.Name = "txtBuildingName";
            txtBuildingName.PlaceholderText = "Building Name";
            txtBuildingName.Size = new Size(240, 35);
            txtBuildingName.TabIndex = 1;
            // 
            // DV_halls
            // 
            DV_halls.AllowUserToAddRows = false;
            DV_halls.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DV_halls.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DV_halls.BackgroundColor = Color.FromArgb(244, 247, 249);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(52, 84, 99);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DV_halls.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DV_halls.ColumnHeadersHeight = 35;
            DV_halls.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DV_halls.Columns.AddRange(new DataGridViewColumn[] { col1, col2, col3, col4, col5 });
            DV_halls.EnableHeadersVisualStyles = false;
            DV_halls.Location = new Point(105, 234);
            DV_halls.Name = "DV_halls";
            DV_halls.RowHeadersWidth = 62;
            DV_halls.Size = new Size(1170, 542);
            DV_halls.TabIndex = 2;
            // 
            // col1
            // 
            col1.HeaderText = "Hall ID";
            col1.MinimumWidth = 8;
            col1.Name = "col1";
            // 
            // col2
            // 
            col2.HeaderText = "Hall Name";
            col2.MinimumWidth = 8;
            col2.Name = "col2";
            // 
            // col3
            // 
            col3.HeaderText = "Building";
            col3.MinimumWidth = 8;
            col3.Name = "col3";
            // 
            // col4
            // 
            col4.HeaderText = "Floor";
            col4.MinimumWidth = 8;
            col4.Name = "col4";
            // 
            // col5
            // 
            col5.HeaderText = "Action";
            col5.MinimumWidth = 8;
            col5.Name = "col5";
            // 
            // searchControl1
            // 
            searchControl1.BackColor = Color.White;
            searchControl1.Location = new Point(94, 26);
            searchControl1.Margin = new Padding(0);
            searchControl1.Name = "searchControl1";
            searchControl1.Size = new Size(250, 36);
            searchControl1.TabIndex = 3;
            // 
            // header1
            // 
            header1.BackColor = Color.White;
            header1.Location = new Point(-1, 1);
            header1.Name = "header1";
            header1.Size = new Size(1377, 98);
            header1.TabIndex = 3;
            header1.Title = "UniPlan";
            // 
            // HallsManagement
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1378, 844);
            Controls.Add(header1);
            Controls.Add(DV_halls);
            Controls.Add(panel1);
            Name = "HallsManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Load += HallsManagement_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DV_halls).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private TextBox txtFloorNumber;
        private TextBox txtBuildingName;
        private DataGridView DV_halls;
        private DataGridViewTextBoxColumn col1;
        private DataGridViewTextBoxColumn col2;
        private DataGridViewTextBoxColumn col3;
        private DataGridViewTextBoxColumn col4;
        private DataGridViewButtonColumn col5;
        private UniPlan.Controls.CustomButtons.UniPlanButton HallsBtn;
        private Controls.UserControls.Header header1;
        private UniPlan.Controls.CustomButtons.UniPlanButton uniPlanButton1;
        private UniPlan.Controls.CustomButtons.UniPlanButton uniPlanButton2;
        private Controls.UserControls.SearchControl searchControl1;
    }
}
