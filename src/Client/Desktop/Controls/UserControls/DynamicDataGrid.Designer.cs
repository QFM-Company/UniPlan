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
            btnPervious = new UniPlan.Controls.CustomButtons.UniPlanButton();
            btnNext = new UniPlan.Controls.CustomButtons.UniPlanButton();
            DV_halls = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DV_halls).BeginInit();
            SuspendLayout();
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
            btnPervious.Location = new Point(13, 363);
            btnPervious.Margin = new Padding(2);
            btnPervious.Name = "btnPervious";
            btnPervious.Size = new Size(84, 31);
            btnPervious.TabIndex = 1;
            btnPervious.Tag = "-";
            btnPervious.Text = "◀";
            btnPervious.UseVisualStyleBackColor = false;
            btnPervious.Visible = false;
            btnPervious.Click += PageNavigation_Click;
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
            btnNext.Location = new Point(429, 363);
            btnNext.Margin = new Padding(2);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(84, 31);
            btnNext.TabIndex = 2;
            btnNext.Tag = "+";
            btnNext.Text = "▶";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Visible = false;
            btnNext.Click += PageNavigation_Click;
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
            DV_halls.Location = new Point(13, 49);
            DV_halls.Margin = new Padding(2);
            DV_halls.Name = "DV_halls";
            DV_halls.RowHeadersWidth = 62;
            DV_halls.Size = new Size(500, 310);
            DV_halls.TabIndex = 5;
            DV_halls.DataSourceChanged += DV_halls_DataSourceChanged;
            // 
            // DynamicDataGrid
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(DV_halls);
            Controls.Add(btnNext);
            Controls.Add(btnPervious);
            Margin = new Padding(2);
            Name = "DynamicDataGrid";
            Size = new Size(533, 400);
            Load += DynamicDataGrid_Load;
            ((System.ComponentModel.ISupportInitialize)DV_halls).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private UniPlan.Controls.CustomButtons.UniPlanButton btnPervious;
        private UniPlan.Controls.CustomButtons.UniPlanButton btnNext;
        private SearchControl searchControl1;
        private DataGridView DV_halls;
    }
}
