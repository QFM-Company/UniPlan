namespace Presentation.Forms
{
    partial class MainForm
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
            button2 = new Button();
            button1 = new Button();
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
            header1.Size = new Size(991, 88);
            header1.TabIndex = 0;
            header1.Title = "UniPlan";
            // 
            // panel1
            // 
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 88);
            panel1.Name = "panel1";
            panel1.Size = new Size(991, 455);
            panel1.TabIndex = 1;
            // 
            // button2
            // 
            button2.Location = new Point(77, 262);
            button2.Name = "button2";
            button2.Size = new Size(164, 79);
            button2.TabIndex = 1;
            button2.Text = "Majors";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(77, 52);
            button1.Name = "button1";
            button1.Size = new Size(164, 79);
            button1.TabIndex = 0;
            button1.Text = "Halls";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(991, 543);
            Controls.Add(panel1);
            Controls.Add(header1);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Controls.UserControls.Header header1;
        private Panel panel1;
        private Button button2;
        private Button button1;
    }
}