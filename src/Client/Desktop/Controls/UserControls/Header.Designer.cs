using Controls.Properties;

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
            lbHeader.BackColor = Color.Transparent;
            lbHeader.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbHeader.ForeColor = Color.FromArgb(44, 62, 80);
            lbHeader.Location = new Point(77, 19);
            lbHeader.Margin = new Padding(2, 0, 2, 0);
            lbHeader.Name = "lbHeader";
            lbHeader.Size = new Size(116, 31);
            lbHeader.TabIndex = 2;
            lbHeader.Text = "UniPlan";
            // 
            // piclogo
            // 
            piclogo.Image = Resources.UniPlan;
            piclogo.Location = new Point(1, 1);
            piclogo.Margin = new Padding(2);
            piclogo.Name = "piclogo";
            piclogo.Size = new Size(69, 69);
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
            pnlHeader.Margin = new Padding(2);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(933, 70);
            pnlHeader.TabIndex = 1;
            // 
            // Header
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pnlHeader);
            Margin = new Padding(2);
            Name = "Header";
            Size = new Size(933, 70);
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