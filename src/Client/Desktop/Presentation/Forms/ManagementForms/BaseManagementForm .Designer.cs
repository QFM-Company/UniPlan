namespace Presentation.Forms
{
    partial class BaseManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseManagementForm));
            header1 = new Controls.UserControls.Header();
            dataGrid = new Controls.UserControls.DynamicDataGrid();
            SuspendLayout();
            // 
            // header1
            // 
            header1.BackColor = Color.White;
            header1.Dock = DockStyle.Top;
            header1.Location = new Point(0, 0);
            header1.Margin = new Padding(1);
            header1.Name = "header1";
            header1.Size = new Size(1009, 83);
            header1.TabIndex = 3;
            header1.Title = "UniPlan";
            // 
            // dataGrid
            // 
            dataGrid.AddEnabled = true;
            dataGrid.DeleteEnabled = true;
            dataGrid.Dock = DockStyle.Fill;
            dataGrid.Location = new Point(0, 83);
            dataGrid.Margin = new Padding(2);
            dataGrid.Name = "dataGrid";
            dataGrid.Size = new Size(1009, 554);
            dataGrid.TabIndex = 4;
            dataGrid.UpdateEnabled = true;
            // 
            // BaseManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1009, 637);
            Controls.Add(dataGrid);
            Controls.Add(header1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "BaseManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UniPlan";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }

        #endregion
        private Controls.Customs.UniPlanButton HallsBtn;
        private Controls.UserControls.Header header1;
        private Controls.Customs.UniPlanButton uniPlanButton1;
        private Controls.Customs.UniPlanButton uniPlanButton2;
        private Controls.UserControls.SearchControl searchControl1;
        protected Controls.UserControls.DynamicDataGrid dataGrid;
    }
}
