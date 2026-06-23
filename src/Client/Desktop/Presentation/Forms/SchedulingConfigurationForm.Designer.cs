namespace Presentation.Forms
{
    partial class SchedulingConfigurationForm
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
            pictureBox1 = new PictureBox();
            pnlHeader = new Panel();
            lbHeader = new Label();
            dgvHalls = new DataGridView();
            col1 = new DataGridViewTextBoxColumn();
            col2 = new DataGridViewTextBoxColumn();
            col3 = new DataGridViewTextBoxColumn();
            col4 = new DataGridViewTextBoxColumn();
            col6 = new DataGridViewTextBoxColumn();
            col5 = new DataGridViewButtonColumn();
            panel1 = new Panel();
            txtFloorNumber = new TextBox();
            txtBuildingName = new TextBox();
            cmbHallName = new ComboBox();
            uniPlanButton1 = new UniPlan.Controls.CustomButtons.UniPlanButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHalls).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.UniPlan;
            pictureBox1.Location = new Point(1, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(103, 103);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = SystemColors.HighlightText;
            pnlHeader.Controls.Add(lbHeader);
            pnlHeader.Controls.Add(pictureBox1);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1378, 100);
            pnlHeader.TabIndex = 1;
            // 
            // lbHeader
            // 
            lbHeader.AutoSize = true;
            lbHeader.Font = new Font("Tajawal", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbHeader.ForeColor = Color.FromArgb(30, 58, 71);
            lbHeader.Location = new Point(110, 26);
            lbHeader.Name = "lbHeader";
            lbHeader.Size = new Size(126, 47);
            lbHeader.TabIndex = 2;
            lbHeader.Text = "UniPlan";
            // 
            // dgvHalls
            // 
            dgvHalls.AllowUserToAddRows = false;
            dgvHalls.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHalls.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHalls.BackgroundColor = Color.FromArgb(244, 247, 249);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(52, 84, 99);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.5F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvHalls.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvHalls.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHalls.Columns.AddRange(new DataGridViewColumn[] { col1, col2, col3, col4, col6, col5 });
            dgvHalls.EnableHeadersVisualStyles = false;
            dgvHalls.Location = new Point(110, 253);
            dgvHalls.Name = "dgvHalls";
            dgvHalls.RowHeadersWidth = 62;
            dgvHalls.Size = new Size(1170, 541);
            dgvHalls.TabIndex = 4;
            dgvHalls.CellContentClick += dgvHalls_CellContentClick;
            // 
            // col1
            // 
            col1.HeaderText = "Period ID";
            col1.MinimumWidth = 8;
            col1.Name = "col1";
            // 
            // col2
            // 
            col2.HeaderText = "Period Number";
            col2.MinimumWidth = 8;
            col2.Name = "col2";
            // 
            // col3
            // 
            col3.HeaderText = "Day";
            col3.MinimumWidth = 8;
            col3.Name = "col3";
            // 
            // col4
            // 
            col4.HeaderText = "Start Time";
            col4.MinimumWidth = 8;
            col4.Name = "col4";
            // 
            // col6
            // 
            col6.HeaderText = "End Time";
            col6.MinimumWidth = 8;
            col6.Name = "col6";
            // 
            // col5
            // 
            col5.HeaderText = "Action";
            col5.MinimumWidth = 8;
            col5.Name = "col5";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(244, 247, 249);
            panel1.Controls.Add(uniPlanButton1);
            panel1.Controls.Add(txtFloorNumber);
            panel1.Controls.Add(txtBuildingName);
            panel1.Controls.Add(cmbHallName);
            panel1.Location = new Point(110, 132);
            panel1.Name = "panel1";
            panel1.Size = new Size(1170, 91);
            panel1.TabIndex = 3;
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
            uniPlanButton1.Location = new Point(988, 8);
            uniPlanButton1.Name = "uniPlanButton1";
            uniPlanButton1.Size = new Size(150, 68);
            uniPlanButton1.TabIndex = 4;
            uniPlanButton1.Text = "SAVE";
            uniPlanButton1.UseVisualStyleBackColor = false;
            // 
            // SchedulingConfigurationForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1378, 844);
            Controls.Add(dgvHalls);
            Controls.Add(panel1);
            Controls.Add(pnlHeader);
            Name = "SchedulingConfigurationForm";
            Text = "SchedulingConfigurationForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHalls).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel pnlHeader;
        private Label lbHeader;
        private DataGridView dgvHalls;
        private Panel panel1;
        private TextBox txtFloorNumber;
        private TextBox txtBuildingName;
        private ComboBox cmbHallName;
        private DataGridViewTextBoxColumn col1;
        private DataGridViewTextBoxColumn col2;
        private DataGridViewTextBoxColumn col3;
        private DataGridViewTextBoxColumn col4;
        private DataGridViewTextBoxColumn col6;
        private DataGridViewButtonColumn col5;
        private UniPlan.Controls.CustomButtons.UniPlanButton uniPlanButton1;
    }
}