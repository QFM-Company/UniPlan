using Controls.Customs;

namespace Presentation.Forms.OperationsForms
{
    partial class MajorOperationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MajorOperationForm));
            lblMajorName = new Label();
            lblParentMajorID = new Label();
            txtMajorName = new UniPlanTextBox();
            txtParentMajorID = new UniPlanTextBox();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(txtParentMajorID);
            panel2.Controls.Add(txtMajorName);
            panel2.Controls.Add(lblParentMajorID);
            panel2.Controls.Add(lblMajorName);
            panel2.Size = new Size(591, 299);
            panel2.Controls.SetChildIndex(lblMajorName, 0);
            panel2.Controls.SetChildIndex(lblParentMajorID, 0);
            panel2.Controls.SetChildIndex(txtMajorName, 0);
            panel2.Controls.SetChildIndex(txtParentMajorID, 0);
            // 
            // lblMajorName
            // 
            lblMajorName.AutoSize = true;
            lblMajorName.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMajorName.Location = new Point(355, 112);
            lblMajorName.Name = "lblMajorName";
            lblMajorName.RightToLeft = RightToLeft.Yes;
            lblMajorName.Size = new Size(159, 31);
            lblMajorName.TabIndex = 0;
            lblMajorName.Text = "اسم التخصص :";
            // 
            // lblParentMajorID
            // 
            lblParentMajorID.AutoSize = true;
            lblParentMajorID.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblParentMajorID.Location = new Point(355, 217);
            lblParentMajorID.Name = "lblParentMajorID";
            lblParentMajorID.RightToLeft = RightToLeft.Yes;
            lblParentMajorID.Size = new Size(225, 31);
            lblParentMajorID.TabIndex = 1;
            lblParentMajorID.Text = "معرف التخصص الأب :";
            // 
            // txtMajorName
            // 
            txtMajorName.DataType = TextBoxDataType.String;
            txtMajorName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMajorName.Location = new Point(3, 112);
            txtMajorName.Name = "txtMajorName";
            txtMajorName.Size = new Size(318, 34);
            txtMajorName.TabIndex = 2;
            // 
            // txtParentMajorID
            // 
            txtParentMajorID.DataType = TextBoxDataType.Integer;
            txtParentMajorID.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtParentMajorID.Location = new Point(3, 214);
            txtParentMajorID.Name = "txtParentMajorID";
            txtParentMajorID.Size = new Size(318, 34);
            txtParentMajorID.TabIndex = 3;
            // 
            // MajorOperationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(591, 512);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MajorOperationForm";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblMajorName;
        private Label lblParentMajorID;
        private UniPlanTextBox txtMajorName;
        private UniPlanTextBox txtParentMajorID;
    }
}
