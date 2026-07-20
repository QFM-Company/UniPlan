namespace Presentation.Forms.OperationsForms
{
    partial class BaseOperationForm
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
            header1 = new Controls.UserControls.Header();
            panel1 = new Panel();
            btnSave = new Controls.Customs.UniPlanButton();
            panel2 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // header1
            // 
            header1.BackColor = Color.White;
            header1.Dock = DockStyle.Top;
            header1.Location = new Point(0, 0);
            header1.Margin = new Padding(2);
            header1.Name = "header1";
            header1.Size = new Size(615, 88);
            header1.TabIndex = 0;
            header1.Title = "UniPlan";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnSave);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 592);
            panel1.Name = "panel1";
            panel1.Size = new Size(615, 125);
            panel1.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.AllowDrop = true;
            btnSave.BackColor = Color.FromArgb(30, 58, 138);
            btnSave.BorderRadius = 15;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatAppearance.MouseDownBackColor = Color.FromArgb(19, 122, 148);
            btnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 177, 212);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.FromArgb(255, 255, 255);
            btnSave.Location = new Point(229, 33);
            btnSave.Margin = new Padding(2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(130, 58);
            btnSave.TabIndex = 4;
            btnSave.Tag = "-";
            btnSave.Text = "حفظ";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 88);
            panel2.Name = "panel2";
            panel2.Size = new Size(615, 504);
            panel2.TabIndex = 2;
            // 
            // BaseOperationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(615, 717);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(header1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "BaseOperationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Load += BaseOperationForm_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Controls.UserControls.Header header1;
        private Panel panel1;
        private Controls.Customs.UniPlanButton btnSave;
        protected Panel panel2;
    }
}