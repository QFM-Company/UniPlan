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
            cmbHallName = new ComboBox();
            dgvHalls = new DataGridView();
            col1 = new DataGridViewTextBoxColumn();
            col2 = new DataGridViewTextBoxColumn();
            col3 = new DataGridViewTextBoxColumn();
            col4 = new DataGridViewTextBoxColumn();
            col5 = new DataGridViewButtonColumn();
            uniPlanButton1 = new UniPlan.Controls.CustomButtons.UniPlanButton();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHalls).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(244, 247, 249);
            panel1.Controls.Add(uniPlanButton1);
            panel1.Controls.Add(txtFloorNumber);
            panel1.Controls.Add(txtBuildingName);
            panel1.Controls.Add(cmbHallName);
            panel1.Location = new Point(105, 139);
            panel1.Name = "panel1";
            panel1.Size = new Size(1170, 91);
            panel1.TabIndex = 1;
            // 
            // txtFloorNumber
            // 
            txtFloorNumber.Location = new Point(704, 22);
            txtFloorNumber.Name = "txtFloorNumber";
            txtFloorNumber.PlaceholderText = "Floor Number";
            txtFloorNumber.Size = new Size(240, 35);
            txtFloorNumber.TabIndex = 2;
            // 
            // txtBuildingName
            // 
            txtBuildingName.Location = new Point(400, 25);
            txtBuildingName.Name = "txtBuildingName";
            txtBuildingName.PlaceholderText = "Building Name";
            txtBuildingName.Size = new Size(240, 35);
            txtBuildingName.TabIndex = 1;
            // 
            // cmbHallName
            // 
            cmbHallName.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHallName.FormattingEnabled = true;
            cmbHallName.Location = new Point(66, 22);
            cmbHallName.Name = "cmbHallName";
            cmbHallName.Size = new Size(240, 38);
            cmbHallName.TabIndex = 0;
            cmbHallName.SelectedIndexChanged += cmbHallName_SelectedIndexChanged;
            // 
            // dgvHalls
            // 
            dgvHalls.AllowUserToAddRows = false;
            dgvHalls.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHalls.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHalls.BackgroundColor = Color.FromArgb(244, 247, 249);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(52, 84, 99);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvHalls.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvHalls.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHalls.Columns.AddRange(new DataGridViewColumn[] { col1, col2, col3, col4, col5 });
            dgvHalls.EnableHeadersVisualStyles = false;
            dgvHalls.Location = new Point(105, 260);
            dgvHalls.Name = "dgvHalls";
            dgvHalls.RowHeadersWidth = 62;
            dgvHalls.Size = new Size(1170, 541);
            dgvHalls.TabIndex = 2;
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
            // uniPlanButton1
            // 
            uniPlanButton1.BackColor = Color.FromArgb(23, 147, 177);
            uniPlanButton1.FlatAppearance.BorderSize = 0;
            uniPlanButton1.FlatAppearance.MouseDownBackColor = Color.FromArgb(19, 122, 148);
            uniPlanButton1.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 177, 212);
            uniPlanButton1.FlatStyle = FlatStyle.Flat;
            uniPlanButton1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            uniPlanButton1.ForeColor = Color.FromArgb(255, 255, 255);
            uniPlanButton1.Location = new Point(990, 8);
            uniPlanButton1.Name = "uniPlanButton1";
            uniPlanButton1.Size = new Size(150, 68);
            uniPlanButton1.TabIndex = 3;
            uniPlanButton1.Text = "SAVE";
            uniPlanButton1.UseVisualStyleBackColor = false;
            // 
            // HallsManagement
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1378, 844);
            Controls.Add(dgvHalls);
            Controls.Add(panel1);
            Name = "HallsManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HallsManagementForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHalls).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private ComboBox cmbHallName;
        private TextBox txtFloorNumber;
        private TextBox txtBuildingName;
        private DataGridView dgvHalls;
        private DataGridViewTextBoxColumn col1;
        private DataGridViewTextBoxColumn col2;
        private DataGridViewTextBoxColumn col3;
        private DataGridViewTextBoxColumn col4;
        private DataGridViewButtonColumn col5;
        private UniPlan.Controls.CustomButtons.UniPlanButton uniPlanButton1;
    }
}