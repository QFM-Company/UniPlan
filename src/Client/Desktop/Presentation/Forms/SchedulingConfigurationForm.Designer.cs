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
            dgvHalls = new DataGridView();
            col1 = new DataGridViewTextBoxColumn();
            col2 = new DataGridViewTextBoxColumn();
            col3 = new DataGridViewTextBoxColumn();
            col4 = new DataGridViewTextBoxColumn();
            col6 = new DataGridViewTextBoxColumn();
            col5 = new DataGridViewButtonColumn();
            panel1 = new Panel();
            TineSloteBtn = new UniPlan.Controls.CustomButtons.UniPlanButton();
            textBox1 = new TextBox();
            txtFloorNumber = new TextBox();
            txtBuildingName = new TextBox();
            cmbHallName = new ComboBox();
            header1 = new Controls.UserControls.Header();
            ((System.ComponentModel.ISupportInitialize)dgvHalls).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
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
            panel1.Controls.Add(TineSloteBtn);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(txtFloorNumber);
            panel1.Controls.Add(txtBuildingName);
            panel1.Controls.Add(cmbHallName);
            panel1.Location = new Point(110, 132);
            panel1.Name = "panel1";
            panel1.Size = new Size(1170, 91);
            panel1.TabIndex = 3;
            // 
            // TineSloteBtn
            // 
            TineSloteBtn.BackColor = Color.FromArgb(23, 147, 177);
            TineSloteBtn.BorderRadius = 15;
            TineSloteBtn.FlatAppearance.BorderSize = 0;
            TineSloteBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(19, 122, 148);
            TineSloteBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 177, 212);
            TineSloteBtn.FlatStyle = FlatStyle.Flat;
            TineSloteBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            TineSloteBtn.ForeColor = Color.FromArgb(255, 255, 255);
            TineSloteBtn.Location = new Point(977, 11);
            TineSloteBtn.Name = "TineSloteBtn";
            TineSloteBtn.Size = new Size(180, 68);
            TineSloteBtn.TabIndex = 6;
            TineSloteBtn.Text = "SAVE";
            TineSloteBtn.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(279, 25);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Day";
            textBox1.Size = new Size(188, 35);
            textBox1.TabIndex = 5;
            // 
            // txtFloorNumber
            // 
            txtFloorNumber.Location = new Point(742, 25);
            txtFloorNumber.Name = "txtFloorNumber";
            txtFloorNumber.PlaceholderText = "End Time";
            txtFloorNumber.Size = new Size(215, 35);
            txtFloorNumber.TabIndex = 2;
            // 
            // txtBuildingName
            // 
            txtBuildingName.Location = new Point(505, 25);
            txtBuildingName.Name = "txtBuildingName";
            txtBuildingName.PlaceholderText = "Start Time";
            txtBuildingName.Size = new Size(213, 35);
            txtBuildingName.TabIndex = 1;
            // 
            // cmbHallName
            // 
            cmbHallName.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHallName.FormattingEnabled = true;
            cmbHallName.Location = new Point(21, 22);
            cmbHallName.Name = "cmbHallName";
            cmbHallName.Size = new Size(240, 38);
            cmbHallName.TabIndex = 0;
            // 
            // header1
            // 
            header1.BackColor = Color.White;
            header1.Location = new Point(-2, 0);
            header1.Name = "header1";
            header1.Size = new Size(2100, 105);
            header1.TabIndex = 5;
            header1.Title = "UniPlan";
            // 
            // SchedulingConfigurationForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1378, 844);
            Controls.Add(header1);
            Controls.Add(dgvHalls);
            Controls.Add(panel1);
            Name = "SchedulingConfigurationForm";
            Text = "SchedulingConfigurationForm";
            Load += SchedulingConfigurationForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHalls).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
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
        private TextBox textBox1;
        private UniPlan.Controls.CustomButtons.UniPlanButton TineSloteBtn;
        private Controls.UserControls.Header header1;
    }
}