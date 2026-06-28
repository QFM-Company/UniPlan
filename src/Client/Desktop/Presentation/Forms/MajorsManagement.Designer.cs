namespace Presentation.Forms
{
    partial class MajorsManagement
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
            header1 = new Controls.UserControls.Header();
            S = new DataGridView();
            col1 = new DataGridViewTextBoxColumn();
            col2 = new DataGridViewTextBoxColumn();
            col5 = new DataGridViewButtonColumn();
            panel1 = new Panel();
            lbMajorName = new Label();
            tbaddMajor = new TextBox();
            uniPlanButton1 = new UniPlan.Controls.CustomButtons.UniPlanButton();
            ((System.ComponentModel.ISupportInitialize)S).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // header1
            // 
            header1.BackColor = Color.White;
            header1.Location = new Point(-2, 0);
            header1.Name = "header1";
            header1.Size = new Size(1381, 105);
            header1.TabIndex = 0;
            header1.Title = "UniPlan";
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
            S.Columns.AddRange(new DataGridViewColumn[] { col1, col2, col5 });
            S.EnableHeadersVisualStyles = false;
            S.Location = new Point(546, 152);
            S.Name = "S";
            S.RowHeadersWidth = 62;
            S.Size = new Size(797, 658);
            S.TabIndex = 3;
            S.CellContentClick += S_CellContentClick;
            // 
            // col1
            // 
            col1.HeaderText = "Major ID";
            col1.MinimumWidth = 8;
            col1.Name = "col1";
            // 
            // col2
            // 
            col2.HeaderText = "Major Name";
            col2.MinimumWidth = 8;
            col2.Name = "col2";
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
            panel1.Controls.Add(tbaddMajor);
            panel1.Controls.Add(lbMajorName);
            panel1.Location = new Point(61, 266);
            panel1.Name = "panel1";
            panel1.Size = new Size(383, 413);
            panel1.TabIndex = 4;
            // 
            // lbMajorName
            // 
            lbMajorName.AutoSize = true;
            lbMajorName.Font = new Font("Tajawal Medium", 15.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbMajorName.ForeColor = Color.FromArgb(30, 58, 71);
            lbMajorName.Location = new Point(90, 16);
            lbMajorName.Name = "lbMajorName";
            lbMajorName.Size = new Size(206, 45);
            lbMajorName.TabIndex = 0;
            lbMajorName.Text = "Major Name ";
            // 
            // tbaddMajor
            // 
            tbaddMajor.BorderStyle = BorderStyle.FixedSingle;
            tbaddMajor.Font = new Font("Tajawal", 15.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbaddMajor.ForeColor = Color.FromArgb(30, 58, 71);
            tbaddMajor.Location = new Point(31, 168);
            tbaddMajor.Name = "tbaddMajor";
            tbaddMajor.PlaceholderText = "Add Major...";
            tbaddMajor.Size = new Size(317, 52);
            tbaddMajor.TabIndex = 1;
            tbaddMajor.TextChanged += tbaddMajor_TextChanged;
            // 
            // uniPlanButton1
            // 
            uniPlanButton1.BackColor = Color.FromArgb(23, 147, 177);
            uniPlanButton1.BorderRadius = 15;
            uniPlanButton1.FlatAppearance.BorderSize = 0;
            uniPlanButton1.FlatAppearance.MouseDownBackColor = Color.FromArgb(19, 122, 148);
            uniPlanButton1.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 177, 212);
            uniPlanButton1.FlatStyle = FlatStyle.Flat;
            uniPlanButton1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            uniPlanButton1.ForeColor = Color.FromArgb(255, 255, 255);
            uniPlanButton1.Location = new Point(100, 307);
            uniPlanButton1.Name = "uniPlanButton1";
            uniPlanButton1.Size = new Size(180, 68);
            uniPlanButton1.TabIndex = 5;
            uniPlanButton1.Text = "ADD";
            uniPlanButton1.UseVisualStyleBackColor = false;
            uniPlanButton1.Click += uniPlanButton1_Click;
            // 
            // MajorsManagement
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1378, 844);
            Controls.Add(panel1);
            Controls.Add(S);
            Controls.Add(header1);
            Name = "MajorsManagement";
            Text = "MajorsManagement";
            ((System.ComponentModel.ISupportInitialize)S).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Controls.UserControls.Header header1;
        private DataGridView S;
        private DataGridViewTextBoxColumn col1;
        private DataGridViewTextBoxColumn col2;
        private DataGridViewButtonColumn col5;
        private Panel panel1;
        private Label lbMajorName;
        private TextBox tbaddMajor;
        private UniPlan.Controls.CustomButtons.UniPlanButton uniPlanButton1;
    }
}