namespace Presentation.Forms
{
    partial class HallsManagement
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
            panel1 = new Panel();
            txtFloorNumber = new TextBox();
            txtBuildingName = new TextBox();
            header1 = new Controls.UserControls.Header();
            dynamicDataGrid1 = new Controls.UserControls.DynamicDataGrid();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(244, 247, 249);
            panel1.Controls.Add(txtFloorNumber);
            panel1.Controls.Add(txtBuildingName);
            panel1.Location = new Point(70, 82);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(780, 61);
            panel1.TabIndex = 1;
            // 
            // txtFloorNumber
            // 
            txtFloorNumber.ForeColor = Color.SteelBlue;
            txtFloorNumber.Location = new Point(469, 15);
            txtFloorNumber.Margin = new Padding(2);
            txtFloorNumber.Name = "txtFloorNumber";
            txtFloorNumber.PlaceholderText = "Floor Number";
            txtFloorNumber.Size = new Size(161, 27);
            txtFloorNumber.TabIndex = 2;
            // 
            // txtBuildingName
            // 
            txtBuildingName.ForeColor = Color.SteelBlue;
            txtBuildingName.Location = new Point(267, 17);
            txtBuildingName.Margin = new Padding(2);
            txtBuildingName.Name = "txtBuildingName";
            txtBuildingName.PlaceholderText = "Building Name";
            txtBuildingName.Size = new Size(161, 27);
            txtBuildingName.TabIndex = 1;
            // 
            // header1
            // 
            header1.BackColor = Color.White;
            header1.Location = new Point(-1, 1);
            header1.Margin = new Padding(1);
            header1.Name = "header1";
            header1.Size = new Size(918, 65);
            header1.TabIndex = 3;
            header1.Title = "UniPlan";
            // 
            // dynamicDataGrid1
            // 
            dynamicDataGrid1.Location = new Point(33, 147);
            dynamicDataGrid1.Margin = new Padding(2);
            dynamicDataGrid1.Name = "dynamicDataGrid1";
            dynamicDataGrid1.Size = new Size(855, 405);
            dynamicDataGrid1.TabIndex = 4;
            // 
            // HallsManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(919, 563);
            Controls.Add(dynamicDataGrid1);
            Controls.Add(header1);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "HallsManagement";
            StartPosition = FormStartPosition.CenterScreen;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private TextBox txtFloorNumber;
        private TextBox txtBuildingName;
        private UniPlan.Controls.CustomButtons.UniPlanButton HallsBtn;
        private Controls.UserControls.Header header1;
        private UniPlan.Controls.CustomButtons.UniPlanButton uniPlanButton1;
        private UniPlan.Controls.CustomButtons.UniPlanButton uniPlanButton2;
        private Controls.UserControls.SearchControl searchControl1;
        private Controls.UserControls.DynamicDataGrid dynamicDataGrid1;
    }
}
