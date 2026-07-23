using Controls.Customs;

namespace Presentation.Forms.OperationsForms
{
    partial class AcademicTermOperationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AcademicTermOperationForm));
            lblTermType = new Label();
            lblTermYear = new Label();
            txtTermType = new UniPlanTextBox();
            txtTermYear = new UniPlanTextBox();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(txtTermYear);
            panel2.Controls.Add(txtTermType);
            panel2.Controls.Add(lblTermYear);
            panel2.Controls.Add(lblTermType);
            panel2.Size = new Size(591, 289);
            panel2.Controls.SetChildIndex(lblTermType, 0);
            panel2.Controls.SetChildIndex(lblTermYear, 0);
            panel2.Controls.SetChildIndex(txtTermType, 0);
            panel2.Controls.SetChildIndex(txtTermYear, 0);
            // 
            // lblTermType
            // 
            lblTermType.AutoSize = true;
            lblTermType.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTermType.Location = new Point(393, 97);
            lblTermType.Name = "lblTermType";
            lblTermType.RightToLeft = RightToLeft.Yes;
            lblTermType.Size = new Size(130, 31);
            lblTermType.TabIndex = 0;
            lblTermType.Text = "نوع الفصل :";
            // 
            // lblTermYear
            // 
            lblTermYear.AutoSize = true;
            lblTermYear.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTermYear.Location = new Point(393, 202);
            lblTermYear.Name = "lblTermYear";
            lblTermYear.RightToLeft = RightToLeft.Yes;
            lblTermYear.Size = new Size(79, 31);
            lblTermYear.TabIndex = 1;
            lblTermYear.Text = "السنة :";
            // 
            // txtTermType
            // 
            txtTermType.DataType = TextBoxDataType.Integer;
            txtTermType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTermType.Location = new Point(41, 97);
            txtTermType.Name = "txtTermType";
            txtTermType.Size = new Size(318, 34);
            txtTermType.TabIndex = 2;
            // 
            // txtTermYear
            // 
            txtTermYear.DataType = TextBoxDataType.Integer;
            txtTermYear.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTermYear.Location = new Point(41, 199);
            txtTermYear.Name = "txtTermYear";
            txtTermYear.Size = new Size(318, 34);
            txtTermYear.TabIndex = 3;
            // 
            // AcademicTermOperationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(591, 502);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AcademicTermOperationForm";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTermType;
        private Label lblTermYear;
        private UniPlanTextBox txtTermType;
        private UniPlanTextBox txtTermYear;
    }
}
