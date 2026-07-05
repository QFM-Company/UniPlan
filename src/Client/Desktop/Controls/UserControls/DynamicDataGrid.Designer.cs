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
            uniPlanButton1 = new UniPlan.Controls.CustomButtons.UniPlanButton();
            uniPlanButton2 = new UniPlan.Controls.CustomButtons.UniPlanButton();
            searchControl1 = new SearchControl();
            DV_halls = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DV_halls).BeginInit();
            SuspendLayout();
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
            uniPlanButton1.Location = new Point(19, 544);
            uniPlanButton1.Name = "uniPlanButton1";
            uniPlanButton1.Size = new Size(126, 46);
            uniPlanButton1.TabIndex = 1;
            uniPlanButton1.Text = "◀";
            uniPlanButton1.UseVisualStyleBackColor = false;
            // 
            // uniPlanButton2
            // 
            uniPlanButton2.BackColor = Color.FromArgb(23, 147, 177);
            uniPlanButton2.BorderRadius = 15;
            uniPlanButton2.FlatAppearance.BorderSize = 0;
            uniPlanButton2.FlatAppearance.MouseDownBackColor = Color.FromArgb(19, 122, 148);
            uniPlanButton2.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 177, 212);
            uniPlanButton2.FlatStyle = FlatStyle.Flat;
            uniPlanButton2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            uniPlanButton2.ForeColor = Color.FromArgb(255, 255, 255);
            uniPlanButton2.Location = new Point(643, 544);
            uniPlanButton2.Name = "uniPlanButton2";
            uniPlanButton2.Size = new Size(126, 46);
            uniPlanButton2.TabIndex = 2;
            uniPlanButton2.Text = "▶";
            uniPlanButton2.UseVisualStyleBackColor = false;
            // 
            // searchControl1
            // 
            searchControl1.BackColor = Color.White;
            searchControl1.Location = new Point(19, 23);
            searchControl1.Margin = new Padding(0);
            searchControl1.Name = "searchControl1";
            searchControl1.Size = new Size(225, 36);
            searchControl1.TabIndex = 3;
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
            DV_halls.EnableHeadersVisualStyles = false;
            DV_halls.Location = new Point(19, 73);
            DV_halls.Name = "DV_halls";
            DV_halls.RowHeadersWidth = 62;
            DV_halls.Size = new Size(750, 465);
            DV_halls.TabIndex = 5;
            // 
            // DynamicDataGrid
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(DV_halls);
            Controls.Add(searchControl1);
            Controls.Add(uniPlanButton2);
            Controls.Add(uniPlanButton1);
            Name = "DynamicDataGrid";
            Size = new Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)DV_halls).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private UniPlan.Controls.CustomButtons.UniPlanButton uniPlanButton1;
        private UniPlan.Controls.CustomButtons.UniPlanButton uniPlanButton2;
        private SearchControl searchControl1;
        private DataGridView DV_halls;
    }
}
