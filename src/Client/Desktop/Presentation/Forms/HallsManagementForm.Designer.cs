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
            HallsBtn = new UniPlan.Controls.CustomButtons.UniPlanButton();
            txtFloorNumber = new TextBox();
            txtBuildingName = new TextBox();
            cmbHallName = new ComboBox();
            S = new DataGridView();
            col1 = new DataGridViewTextBoxColumn();
            col2 = new DataGridViewTextBoxColumn();
            col3 = new DataGridViewTextBoxColumn();
            col4 = new DataGridViewTextBoxColumn();
            col5 = new DataGridViewButtonColumn();
            header1 = new Controls.UserControls.Header();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)S).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(244, 247, 249);
            panel1.Controls.Add(HallsBtn);
            panel1.Controls.Add(txtFloorNumber);
            panel1.Controls.Add(txtBuildingName);
            panel1.Controls.Add(cmbHallName);
            panel1.Location = new Point(105, 139);
            panel1.Name = "panel1";
            panel1.Size = new Size(1170, 91);
            panel1.TabIndex = 1;
            // 
            // HallsBtn
            // 
            HallsBtn.BackColor = Color.FromArgb(23, 147, 177);
            HallsBtn.BorderRadius = 15;
            HallsBtn.FlatAppearance.BorderSize = 0;
            HallsBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(19, 122, 148);
            HallsBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 177, 212);
            HallsBtn.FlatStyle = FlatStyle.Flat;
            HallsBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            HallsBtn.ForeColor = Color.FromArgb(255, 255, 255);
            HallsBtn.Location = new Point(970, 8);
            HallsBtn.Name = "HallsBtn";
            HallsBtn.Size = new Size(180, 68);
            HallsBtn.TabIndex = 3;
            HallsBtn.Text = "SAVE";
            HallsBtn.UseVisualStyleBackColor = false;
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
            // S
            // 
            S.AllowUserToAddRows = false;
            S.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            S.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            S.BackgroundColor = Color.FromArgb(244, 247, 249);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(52, 84, 99);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.5F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            S.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            S.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            S.Columns.AddRange(new DataGridViewColumn[] { col1, col2, col3, col4, col5 });
            S.EnableHeadersVisualStyles = false;
            S.Location = new Point(105, 260);
            S.Name = "S";
            S.RowHeadersWidth = 62;
            S.Size = new Size(1170, 541);
            S.TabIndex = 2;
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
            // header1
            // 
            header1.BackColor = Color.White;
            header1.Location = new Point(2, 0);
            header1.Name = "header1";
            header1.Size = new Size(2100, 102);
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
            Controls.Add(S);
            Controls.Add(panel1);
            Name = "HallsManagement";
            StartPosition = FormStartPosition.CenterScreen;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)S).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private ComboBox cmbHallName;
        private TextBox txtFloorNumber;
        private TextBox txtBuildingName;
        private DataGridView S;
        private DataGridViewTextBoxColumn col1;
        private DataGridViewTextBoxColumn col2;
        private DataGridViewTextBoxColumn col3;
        private DataGridViewTextBoxColumn col4;
        private DataGridViewButtonColumn col5;
        private UniPlan.Controls.CustomButtons.UniPlanButton HallsBtn;
        private Controls.UserControls.Header header1;
    }
}