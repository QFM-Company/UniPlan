using Controls.Customs;

namespace Presentation.Forms.OperationsForms
{
    partial class CourseOperationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CourseOperationForm));
            lblCourseName = new Label();
            lblCreditHours = new Label();
            lblCourseCode = new Label();
            txtCourseName = new UniPlanTextBox();
            txtCreditHours = new UniPlanTextBox();
            txtCourseCode = new UniPlanTextBox();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(txtCourseCode);
            panel2.Controls.Add(txtCreditHours);
            panel2.Controls.Add(txtCourseName);
            panel2.Controls.Add(lblCourseCode);
            panel2.Controls.Add(lblCreditHours);
            panel2.Controls.Add(lblCourseName);
            panel2.Size = new Size(591, 400);
            panel2.Controls.SetChildIndex(lblCourseName, 0);
            panel2.Controls.SetChildIndex(lblCreditHours, 0);
            panel2.Controls.SetChildIndex(lblCourseCode, 0);
            panel2.Controls.SetChildIndex(txtCourseName, 0);
            panel2.Controls.SetChildIndex(txtCreditHours, 0);
            panel2.Controls.SetChildIndex(txtCourseCode, 0);
            // 
            // lblCourseName
            // 
            lblCourseName.AutoSize = true;
            lblCourseName.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCourseName.Location = new Point(393, 97);
            lblCourseName.Name = "lblCourseName";
            lblCourseName.RightToLeft = RightToLeft.Yes;
            lblCourseName.Size = new Size(127, 31);
            lblCourseName.TabIndex = 0;
            lblCourseName.Text = "اسم المقرر :";
            // 
            // lblCreditHours
            // 
            lblCreditHours.AutoSize = true;
            lblCreditHours.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCreditHours.Location = new Point(393, 202);
            lblCreditHours.Name = "lblCreditHours";
            lblCreditHours.RightToLeft = RightToLeft.Yes;
            lblCreditHours.Size = new Size(148, 31);
            lblCreditHours.TabIndex = 1;
            lblCreditHours.Text = "عدد الساعات :";
            // 
            // lblCourseCode
            // 
            lblCourseCode.AutoSize = true;
            lblCourseCode.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCourseCode.Location = new Point(393, 307);
            lblCourseCode.Name = "lblCourseCode";
            lblCourseCode.RightToLeft = RightToLeft.Yes;
            lblCourseCode.Size = new Size(120, 31);
            lblCourseCode.TabIndex = 2;
            lblCourseCode.Text = "رمز المقرر :";
            // 
            // txtCourseName
            // 
            txtCourseName.DataType = TextBoxDataType.String;
            txtCourseName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCourseName.Location = new Point(41, 97);
            txtCourseName.Name = "txtCourseName";
            txtCourseName.Size = new Size(318, 34);
            txtCourseName.TabIndex = 3;
            // 
            // txtCreditHours
            // 
            txtCreditHours.DataType = TextBoxDataType.Integer;
            txtCreditHours.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCreditHours.Location = new Point(41, 199);
            txtCreditHours.Name = "txtCreditHours";
            txtCreditHours.Size = new Size(318, 34);
            txtCreditHours.TabIndex = 4;
            // 
            // txtCourseCode
            // 
            txtCourseCode.DataType = TextBoxDataType.String;
            txtCourseCode.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCourseCode.Location = new Point(41, 304);
            txtCourseCode.Name = "txtCourseCode";
            txtCourseCode.Size = new Size(318, 34);
            txtCourseCode.TabIndex = 5;
            // 
            // CourseOperationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(591, 613);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CourseOperationForm";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblCourseName;
        private Label lblCreditHours;
        private Label lblCourseCode;
        private UniPlanTextBox txtCourseName;
        private UniPlanTextBox txtCreditHours;
        private UniPlanTextBox txtCourseCode;
    }
}
