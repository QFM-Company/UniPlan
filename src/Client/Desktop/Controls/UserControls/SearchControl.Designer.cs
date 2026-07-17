using Controls.Customs;

namespace Controls.UserControls
{
    partial class SearchControl
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
            txtSearch = new UniPlanTextBox();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.DataType = TextBoxDataType.Integer;
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(0, 0);
            txtSearch.Margin = new Padding(4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(216, 38);
            txtSearch.TabIndex = 2;
            txtSearch.Text = "بحث حسب المعرف";
            txtSearch.TextAlign = HorizontalAlignment.Right;
            txtSearch.Click += txtSearch_Enter;
            txtSearch.Leave += txtSearch_Leave;
            // 
            // SearchControl
            // 
            AutoScaleDimensions = new SizeF(12F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(txtSearch);
            Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(0);
            Name = "SearchControl";
            Size = new Size(216, 36);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UniPlanTextBox txtSearch;
    }
}
