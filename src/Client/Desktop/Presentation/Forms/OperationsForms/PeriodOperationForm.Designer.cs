using Controls.Customs;

namespace Presentation.Forms.OperationsForms
{
    partial class PeriodOperationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PeriodOperationForm));
            lblStartTime = new Label();
            lblEndTime = new Label();
            txtStartTime = new UniPlanTextBox();
            txtEndTime = new UniPlanTextBox();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(txtEndTime);
            panel2.Controls.Add(txtStartTime);
            panel2.Controls.Add(lblEndTime);
            panel2.Controls.Add(lblStartTime);
            panel2.Size = new Size(591, 282);
            panel2.Controls.SetChildIndex(lblStartTime, 0);
            panel2.Controls.SetChildIndex(lblEndTime, 0);
            panel2.Controls.SetChildIndex(txtStartTime, 0);
            panel2.Controls.SetChildIndex(txtEndTime, 0);
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStartTime.Location = new Point(393, 97);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.RightToLeft = RightToLeft.Yes;
            lblStartTime.Size = new Size(137, 31);
            lblStartTime.TabIndex = 0;
            lblStartTime.Text = "وقت البداية :";
            // 
            // lblEndTime
            // 
            lblEndTime.AutoSize = true;
            lblEndTime.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEndTime.Location = new Point(393, 202);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.RightToLeft = RightToLeft.Yes;
            lblEndTime.Size = new Size(137, 31);
            lblEndTime.TabIndex = 1;
            lblEndTime.Text = "وقت النهاية :";
            // 
            // txtStartTime
            // 
            txtStartTime.DataType = TextBoxDataType.String;
            txtStartTime.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStartTime.Location = new Point(41, 97);
            txtStartTime.Name = "txtStartTime";
            txtStartTime.Size = new Size(318, 34);
            txtStartTime.TabIndex = 2;
            // 
            // txtEndTime
            // 
            txtEndTime.DataType = TextBoxDataType.String;
            txtEndTime.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEndTime.Location = new Point(41, 199);
            txtEndTime.Name = "txtEndTime";
            txtEndTime.Size = new Size(318, 34);
            txtEndTime.TabIndex = 3;
            // 
            // PeriodOperationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(591, 495);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PeriodOperationForm";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblStartTime;
        private Label lblEndTime;
        private UniPlanTextBox txtStartTime;
        private UniPlanTextBox txtEndTime;
    }
}
