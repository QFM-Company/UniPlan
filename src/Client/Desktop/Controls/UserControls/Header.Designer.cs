namespace Controls.UserControls
{
    partial class Header
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            lbHeader = new Label();
            piclogo = new PictureBox();
            pnlHeader = new Panel();
            ((System.ComponentModel.ISupportInitialize)piclogo).BeginInit();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // lbHeader
            // 
            lbHeader.AutoSize = true;
            lbHeader.Font = new Font("Tajawal", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbHeader.ForeColor = Color.FromArgb(30, 58, 71);
            lbHeader.Location = new Point(115, 28);
            lbHeader.Name = "lbHeader";
            lbHeader.Size = new Size(126, 47);
            lbHeader.TabIndex = 2;
            lbHeader.Text = "UniPlan";
            // 
            // piclogo
            // 
            piclogo.Image = global::Controls.Properties.Resources.UniPlan;
            piclogo.Location = new Point(1, 1);
            piclogo.Name = "piclogo";
            piclogo.Size = new Size(103, 103);
            piclogo.SizeMode = PictureBoxSizeMode.Zoom;
            piclogo.TabIndex = 1;
            piclogo.TabStop = false;
            piclogo.Click += pictureBox1_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lbHeader);
            pnlHeader.Controls.Add(piclogo);
            pnlHeader.Dock = DockStyle.Fill;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1400, 105);
            pnlHeader.TabIndex = 1;
            // 
            // Header
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pnlHeader);
            Name = "Header";
            Size = new Size(1400, 105);
            ((System.ComponentModel.ISupportInitialize)piclogo).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lbHeader;
        private PictureBox piclogo;
        private Panel pnlHeader;
    }
}