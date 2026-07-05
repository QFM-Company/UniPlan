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
            txtSearch = new TextBox();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Cursor = Cursors.IBeam;
            txtSearch.ForeColor = Color.Black;
            txtSearch.Location = new Point(0, 0);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(260, 35);
            txtSearch.TabIndex = 0;
            txtSearch.Text = "Search...";
            txtSearch.UseWaitCursor = true;
            // 
            // SearchControl
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(txtSearch);
            Margin = new Padding(0);
            Name = "SearchControl";
            Size = new Size(260, 24);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearch;
    }
}
