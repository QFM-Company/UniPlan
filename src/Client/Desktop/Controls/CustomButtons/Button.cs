using System;
using System.Windows.Forms;
using System.Drawing;

namespace UniPlan.Controls.CustomButtons
{
    public class UniPlanButton : Button
    {
        public UniPlanButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;

            this.BackColor = Theme.SecondaryColor; 
            this.ForeColor = Theme.WhiteColor;    

            this.Font = new Font("Segoe UI", 12F, FontStyle.Bold); 

            this.Size = new Size(100, 45);

            this.TextAlign = ContentAlignment.MiddleCenter;

            this.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 177, 212);
            this.FlatAppearance.MouseDownBackColor = Color.FromArgb(19, 122, 148);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
        }
    }
}