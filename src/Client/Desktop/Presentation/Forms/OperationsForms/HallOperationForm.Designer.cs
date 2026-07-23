using Controls.Customs;

namespace Presentation.Forms.OperationsForms
{
    partial class HallOperationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HallOperationForm));
            lblHallName = new Label();
            lblBuilding = new Label();
            lblFloor = new Label();
            lblCreatedByAdminID = new Label();
            txtHallName = new UniPlanTextBox();
            txtBuilding = new UniPlanTextBox();
            txtFloor = new UniPlanTextBox();
            txtCreatedByAdminID = new UniPlanTextBox();
            panel2.SuspendLayout();
            SuspendLayout();
            //
            // panel2
            //
            panel2.Controls.Add(txtCreatedByAdminID);
            panel2.Controls.Add(txtFloor);
            panel2.Controls.Add(txtBuilding);
            panel2.Controls.Add(txtHallName);
            panel2.Controls.Add(lblCreatedByAdminID);
            panel2.Controls.Add(lblFloor);
            panel2.Controls.Add(lblBuilding);
            panel2.Controls.Add(lblHallName);
            panel2.Size = new Size(591, 510);
            panel2.Controls.SetChildIndex(lblHallName, 0);
            panel2.Controls.SetChildIndex(lblBuilding, 0);
            panel2.Controls.SetChildIndex(lblFloor, 0);
            panel2.Controls.SetChildIndex(lblCreatedByAdminID, 0);
            panel2.Controls.SetChildIndex(txtHallName, 0);
            panel2.Controls.SetChildIndex(txtBuilding, 0);
            panel2.Controls.SetChildIndex(txtFloor, 0);
            panel2.Controls.SetChildIndex(txtCreatedByAdminID, 0);
            //
            // lblHallName
            //
            lblHallName.AutoSize = true;
            lblHallName.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHallName.Location = new Point(393, 97);
            lblHallName.Name = "lblHallName";
            lblHallName.RightToLeft = RightToLeft.Yes;
            lblHallName.Size = new Size(133, 31);
            lblHallName.TabIndex = 0;
            lblHallName.Text = " اسم القاعة :";
            //
            // lblBuilding
            //
            lblBuilding.AutoSize = true;
            lblBuilding.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBuilding.Location = new Point(393, 202);
            lblBuilding.Name = "lblBuilding";
            lblBuilding.RightToLeft = RightToLeft.Yes;
            lblBuilding.Size = new Size(88, 31);
            lblBuilding.TabIndex = 1;
            lblBuilding.Text = " المبنى:";
            //
            // lblFloor
            //
            lblFloor.AutoSize = true;
            lblFloor.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFloor.Location = new Point(393, 307);
            lblFloor.Name = "lblFloor";
            lblFloor.RightToLeft = RightToLeft.Yes;
            lblFloor.Size = new Size(84, 31);
            lblFloor.TabIndex = 2;
            lblFloor.Text = "الطابق:";
            //
            // lblCreatedByAdminID
            //
            lblCreatedByAdminID.AutoSize = true;
            lblCreatedByAdminID.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCreatedByAdminID.Location = new Point(393, 412);
            lblCreatedByAdminID.Name = "lblCreatedByAdminID";
            lblCreatedByAdminID.RightToLeft = RightToLeft.Yes;
            lblCreatedByAdminID.Size = new Size(143, 31);
            lblCreatedByAdminID.TabIndex = 3;
            lblCreatedByAdminID.Text = "معرف الأدمن:";
            //
            // txtHallName
            //
            txtHallName.DataType = TextBoxDataType.String;
            txtHallName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtHallName.Location = new Point(41, 97);
            txtHallName.Name = "txtHallName";
            txtHallName.Size = new Size(318, 34);
            txtHallName.TabIndex = 4;
            //
            // txtBuilding
            //
            txtBuilding.DataType = TextBoxDataType.String;
            txtBuilding.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuilding.Location = new Point(41, 199);
            txtBuilding.Name = "txtBuilding";
            txtBuilding.Size = new Size(318, 34);
            txtBuilding.TabIndex = 5;
            //
            // txtFloor
            //
            txtFloor.DataType = TextBoxDataType.Integer;
            txtFloor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFloor.Location = new Point(41, 304);
            txtFloor.Name = "txtFloor";
            txtFloor.Size = new Size(318, 34);
            txtFloor.TabIndex = 6;
            //
            // txtCreatedByAdminID
            //
            txtCreatedByAdminID.DataType = TextBoxDataType.Integer;
            txtCreatedByAdminID.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCreatedByAdminID.Location = new Point(41, 412);
            txtCreatedByAdminID.Name = "txtCreatedByAdminID";
            txtCreatedByAdminID.Size = new Size(318, 34);
            txtCreatedByAdminID.TabIndex = 7;
            //
            // HallOperationForm
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(591, 723);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "HallOperationForm";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblHallName;
        private Label lblBuilding;
        private Label lblFloor;
        private Label lblCreatedByAdminID;
        private UniPlanTextBox txtHallName;
        private UniPlanTextBox txtBuilding;
        private UniPlanTextBox txtFloor;
        private UniPlanTextBox txtCreatedByAdminID;
    }
}
