namespace Controls.UserControls
{
    partial class Header
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
            lbHeader.Location = new Point(110, 26);
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
            pnlHeader.BackColor = SystemColors.HighlightText;
            pnlHeader.Controls.Add(lbHeader);
            pnlHeader.Controls.Add(piclogo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1400, 100);
            pnlHeader.TabIndex = 1;
            // 
            // Header
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pnlHeader);
            Name = "Header";
            Size = new Size(1400, 100);
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
