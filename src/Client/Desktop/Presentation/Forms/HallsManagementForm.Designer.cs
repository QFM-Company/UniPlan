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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel1 = new Panel();
            searchControl1 = new Controls.UserControls.SearchControl();
            txtFloorNumber = new TextBox();
            txtBuildingName = new TextBox();
            header1 = new Controls.UserControls.Header();
            DV_halls = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
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
            // searchControl1
            // 
            searchControl1.BackColor = Color.White;
            searchControl1.Location = new Point(94, 26);
            searchControl1.Margin = new Padding(0);
            searchControl1.Name = "searchControl1";
            searchControl1.Size = new Size(250, 36);
            searchControl1.TabIndex = 3;
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
            // header1
            // 
            header1.BackColor = Color.White;
            header1.Location = new Point(-1, 1);
            header1.Name = "header1";
            header1.Size = new Size(1377, 98);
            header1.TabIndex = 3;
            header1.Title = "UniPlan";
            // 
            // DV_halls
            // 
            DV_halls.AllowUserToAddRows = false;
            DV_halls.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DV_halls.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DV_halls.BackgroundColor = Color.FromArgb(244, 247, 249);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(52, 84, 99);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.5F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DV_halls.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DV_halls.ColumnHeadersHeight = 35;
            DV_halls.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DV_halls.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            DV_halls.EnableHeadersVisualStyles = false;
            DV_halls.Location = new Point(105, 248);
            DV_halls.Name = "DV_halls";
            DV_halls.RowHeadersWidth = 62;
            DV_halls.Size = new Size(1170, 565);
            DV_halls.TabIndex = 4;
            // 
            // Column1
            // 
            Column1.HeaderText = "Hall ID";
            Column1.MinimumWidth = 8;
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Hall Name";
            Column2.MinimumWidth = 8;
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "Building";
            Column3.MinimumWidth = 8;
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Floor";
            Column4.MinimumWidth = 8;
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "Action";
            Column5.MinimumWidth = 8;
            Column5.Name = "Column5";
            // 
            // HallsManagement
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1378, 844);
            Controls.Add(DV_halls);
            Controls.Add(header1);
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
        private UniPlan.Controls.CustomButtons.UniPlanButton HallsBtn;
        private Controls.UserControls.Header header1;
        private UniPlan.Controls.CustomButtons.UniPlanButton uniPlanButton1;
        private UniPlan.Controls.CustomButtons.UniPlanButton uniPlanButton2;
        private Controls.UserControls.SearchControl searchControl1;
        private DataGridView DV_halls;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
    }
}
