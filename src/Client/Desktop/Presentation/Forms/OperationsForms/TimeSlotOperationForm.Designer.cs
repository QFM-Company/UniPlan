using Controls.Customs;

namespace Presentation.Forms.OperationsForms
{
    partial class TimeSlotOperationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeSlotOperationForm));
            lblDay = new Label();
            lblPeriodID = new Label();
            txtDay = new UniPlanTextBox();
            txtPeriodID = new UniPlanTextBox();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(txtPeriodID);
            panel2.Controls.Add(txtDay);
            panel2.Controls.Add(lblPeriodID);
            panel2.Controls.Add(lblDay);
            panel2.Size = new Size(591, 283);
            panel2.Controls.SetChildIndex(lblDay, 0);
            panel2.Controls.SetChildIndex(lblPeriodID, 0);
            panel2.Controls.SetChildIndex(txtDay, 0);
            panel2.Controls.SetChildIndex(txtPeriodID, 0);
            // 
            // lblDay
            // 
            lblDay.AutoSize = true;
            lblDay.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDay.Location = new Point(393, 97);
            lblDay.Name = "lblDay";
            lblDay.RightToLeft = RightToLeft.Yes;
            lblDay.Size = new Size(73, 31);
            lblDay.TabIndex = 0;
            lblDay.Text = "اليوم :";
            // 
            // lblPeriodID
            // 
            lblPeriodID.AutoSize = true;
            lblPeriodID.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPeriodID.Location = new Point(393, 202);
            lblPeriodID.Name = "lblPeriodID";
            lblPeriodID.RightToLeft = RightToLeft.Yes;
            lblPeriodID.Size = new Size(143, 31);
            lblPeriodID.TabIndex = 1;
            lblPeriodID.Text = "معرف الفترة :";
            // 
            // txtDay
            // 
            txtDay.DataType = TextBoxDataType.Integer;
            txtDay.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDay.Location = new Point(41, 97);
            txtDay.Name = "txtDay";
            txtDay.Size = new Size(318, 34);
            txtDay.TabIndex = 2;
            // 
            // txtPeriodID
            // 
            txtPeriodID.DataType = TextBoxDataType.Integer;
            txtPeriodID.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPeriodID.Location = new Point(41, 199);
            txtPeriodID.Name = "txtPeriodID";
            txtPeriodID.Size = new Size(318, 34);
            txtPeriodID.TabIndex = 3;
            // 
            // TimeSlotOperationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(591, 496);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "TimeSlotOperationForm";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblDay;
        private Label lblPeriodID;
        private UniPlanTextBox txtDay;
        private UniPlanTextBox txtPeriodID;
    }
}
