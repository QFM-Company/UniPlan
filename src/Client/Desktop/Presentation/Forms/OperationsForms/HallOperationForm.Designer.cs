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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            uniPlanTextBox1 = new UniPlanTextBox();
            uniPlanTextBox2 = new UniPlanTextBox();
            uniPlanTextBox3 = new UniPlanTextBox();
            uniPlanTextBox4 = new UniPlanTextBox();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(uniPlanTextBox4);
            panel2.Controls.Add(uniPlanTextBox3);
            panel2.Controls.Add(uniPlanTextBox2);
            panel2.Controls.Add(uniPlanTextBox1);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Size = new Size(591, 510);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(393, 73);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(133, 31);
            label1.TabIndex = 0;
            label1.Text = " اسم القاعة :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(393, 178);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(88, 31);
            label2.TabIndex = 1;
            label2.Text = " المبنى:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(393, 283);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(84, 31);
            label3.TabIndex = 2;
            label3.Text = "الطابق:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(393, 388);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.Yes;
            label4.Size = new Size(143, 31);
            label4.TabIndex = 3;
            label4.Text = "معرف الأدمن:";
            // 
            // uniPlanTextBox1
            // 
            uniPlanTextBox1.DataType = TextBoxDataType.String;
            uniPlanTextBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            uniPlanTextBox1.Location = new Point(41, 73);
            uniPlanTextBox1.Name = "uniPlanTextBox1";
            uniPlanTextBox1.Size = new Size(318, 34);
            uniPlanTextBox1.TabIndex = 4;
            // 
            // uniPlanTextBox2
            // 
            uniPlanTextBox2.DataType = TextBoxDataType.String;
            uniPlanTextBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            uniPlanTextBox2.Location = new Point(41, 175);
            uniPlanTextBox2.Name = "uniPlanTextBox2";
            uniPlanTextBox2.Size = new Size(318, 34);
            uniPlanTextBox2.TabIndex = 5;
            // 
            // uniPlanTextBox3
            // 
            uniPlanTextBox3.DataType = TextBoxDataType.Integer;
            uniPlanTextBox3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            uniPlanTextBox3.Location = new Point(41, 280);
            uniPlanTextBox3.Name = "uniPlanTextBox3";
            uniPlanTextBox3.Size = new Size(318, 34);
            uniPlanTextBox3.TabIndex = 6;
            // 
            // uniPlanTextBox4
            // 
            uniPlanTextBox4.DataType = TextBoxDataType.Integer;
            uniPlanTextBox4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            uniPlanTextBox4.Location = new Point(41, 388);
            uniPlanTextBox4.Name = "uniPlanTextBox4";
            uniPlanTextBox4.Size = new Size(318, 34);
            uniPlanTextBox4.TabIndex = 7;
            // 
            // HallOperationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(591, 723);
            Name = "HallOperationForm";
            Text = "HallOperationForm";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Controls.Customs.UniPlanTextBox uniPlanTextBox4;
        private Controls.Customs.UniPlanTextBox uniPlanTextBox3;
        private Controls.Customs.UniPlanTextBox uniPlanTextBox2;
        private Controls.Customs.UniPlanTextBox uniPlanTextBox1;
    }
}