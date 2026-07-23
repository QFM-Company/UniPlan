using Controls.Customs;

namespace Presentation.Forms.OperationsForms
{
    partial class LectureOperationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LectureOperationForm));
            lblLectureType = new Label();
            lblDurationValue = new Label();
            lblCourseID = new Label();
            txtLectureType = new UniPlanTextBox();
            txtDurationValue = new UniPlanTextBox();
            txtCourseID = new UniPlanTextBox();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(txtCourseID);
            panel2.Controls.Add(txtDurationValue);
            panel2.Controls.Add(txtLectureType);
            panel2.Controls.Add(lblCourseID);
            panel2.Controls.Add(lblDurationValue);
            panel2.Controls.Add(lblLectureType);
            panel2.Size = new Size(591, 394);
            panel2.Controls.SetChildIndex(lblLectureType, 0);
            panel2.Controls.SetChildIndex(lblDurationValue, 0);
            panel2.Controls.SetChildIndex(lblCourseID, 0);
            panel2.Controls.SetChildIndex(txtLectureType, 0);
            panel2.Controls.SetChildIndex(txtDurationValue, 0);
            panel2.Controls.SetChildIndex(txtCourseID, 0);
            // 
            // lblLectureType
            // 
            lblLectureType.AutoSize = true;
            lblLectureType.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLectureType.Location = new Point(393, 97);
            lblLectureType.Name = "lblLectureType";
            lblLectureType.RightToLeft = RightToLeft.Yes;
            lblLectureType.Size = new Size(153, 31);
            lblLectureType.TabIndex = 0;
            lblLectureType.Text = "نوع المحاضرة :";
            // 
            // lblDurationValue
            // 
            lblDurationValue.AutoSize = true;
            lblDurationValue.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDurationValue.Location = new Point(393, 202);
            lblDurationValue.Name = "lblDurationValue";
            lblDurationValue.RightToLeft = RightToLeft.Yes;
            lblDurationValue.Size = new Size(77, 31);
            lblDurationValue.TabIndex = 1;
            lblDurationValue.Text = "المدة :";
            // 
            // lblCourseID
            // 
            lblCourseID.AutoSize = true;
            lblCourseID.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCourseID.Location = new Point(393, 307);
            lblCourseID.Name = "lblCourseID";
            lblCourseID.RightToLeft = RightToLeft.Yes;
            lblCourseID.Size = new Size(146, 31);
            lblCourseID.TabIndex = 2;
            lblCourseID.Text = "معرف المقرر :";
            // 
            // txtLectureType
            // 
            txtLectureType.DataType = TextBoxDataType.Integer;
            txtLectureType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLectureType.Location = new Point(41, 97);
            txtLectureType.Name = "txtLectureType";
            txtLectureType.Size = new Size(318, 34);
            txtLectureType.TabIndex = 3;
            // 
            // txtDurationValue
            // 
            txtDurationValue.DataType = TextBoxDataType.Integer;
            txtDurationValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDurationValue.Location = new Point(41, 199);
            txtDurationValue.Name = "txtDurationValue";
            txtDurationValue.Size = new Size(318, 34);
            txtDurationValue.TabIndex = 4;
            // 
            // txtCourseID
            // 
            txtCourseID.DataType = TextBoxDataType.Integer;
            txtCourseID.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCourseID.Location = new Point(41, 304);
            txtCourseID.Name = "txtCourseID";
            txtCourseID.Size = new Size(318, 34);
            txtCourseID.TabIndex = 5;
            // 
            // LectureOperationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(591, 607);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LectureOperationForm";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblLectureType;
        private Label lblDurationValue;
        private Label lblCourseID;
        private UniPlanTextBox txtLectureType;
        private UniPlanTextBox txtDurationValue;
        private UniPlanTextBox txtCourseID;
    }
}
