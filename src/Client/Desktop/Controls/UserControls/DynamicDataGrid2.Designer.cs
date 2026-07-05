namespace Controls.UserControls
{
    partial class DynamicDataGrid2
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
            DV_halls = new DataGridView();
            btnNext = new UniPlan.Controls.CustomButtons.UniPlanButton();
            btnPervious = new UniPlan.Controls.CustomButtons.UniPlanButton();
            searchControl1 = new SearchControl();
            ((System.ComponentModel.ISupportInitialize)DV_halls).BeginInit();
            SuspendLayout();
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
            DV_halls.Location = new Point(25, 68);
            DV_halls.Name = "DV_halls";
            DV_halls.RowHeadersWidth = 62;
            DV_halls.Size = new Size(750, 465);
            DV_halls.TabIndex = 6;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNext.BackColor = Color.FromArgb(23, 147, 177);
            btnNext.BorderRadius = 15;
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatAppearance.MouseDownBackColor = Color.FromArgb(19, 122, 148);
            btnNext.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 177, 212);
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnNext.ForeColor = Color.FromArgb(255, 255, 255);
            btnNext.Location = new Point(649, 539);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(126, 46);
            btnNext.TabIndex = 7;
            btnNext.Tag = "+";
            btnNext.Text = "▶";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Visible = false;
            // 
            // btnPervious
            // 
            btnPervious.BackColor = Color.FromArgb(23, 147, 177);
            btnPervious.BorderRadius = 15;
            btnPervious.FlatAppearance.BorderSize = 0;
            btnPervious.FlatAppearance.MouseDownBackColor = Color.FromArgb(19, 122, 148);
            btnPervious.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 177, 212);
            btnPervious.FlatStyle = FlatStyle.Flat;
            btnPervious.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnPervious.ForeColor = Color.FromArgb(255, 255, 255);
            btnPervious.Location = new Point(25, 539);
            btnPervious.Name = "btnPervious";
            btnPervious.Size = new Size(126, 46);
            btnPervious.TabIndex = 8;
            btnPervious.Tag = "-";
            btnPervious.Text = "◀";
            btnPervious.UseVisualStyleBackColor = false;
            btnPervious.Visible = false;
            // 
            // searchControl1
            // 
            searchControl1.BackColor = Color.White;
            searchControl1.Location = new Point(25, 15);
            searchControl1.Margin = new Padding(0);
            searchControl1.Name = "searchControl1";
            searchControl1.Size = new Size(214, 36);
            searchControl1.TabIndex = 10;
            // 
            // DynamicDataGrid2
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(searchControl1);
            Controls.Add(btnPervious);
            Controls.Add(btnNext);
            Controls.Add(DV_halls);
            Name = "DynamicDataGrid2";
            Size = new Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)DV_halls).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DV_halls;
        private UniPlan.Controls.CustomButtons.UniPlanButton btnNext;
        private UniPlan.Controls.CustomButtons.UniPlanButton btnPervious;
        private SearchControl searchControl1;
    }
}
