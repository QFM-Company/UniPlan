using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace UniPlan.Controls.CustomButtons
{
    public class UniPlanButton : Button
    {
        private int _borderRadius = 15;

        public int BorderRadius
        {
            get => _borderRadius;
            set
            {
                _borderRadius = value;
                this.Invalidate();
            }
        }

        public UniPlanButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;

            this.BackColor = Theme.SecondaryColor;
            this.ForeColor = Theme.WhiteColor;

            this.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.Size = new Size(120, 45);

            this.TextAlign = ContentAlignment.MiddleCenter;

            this.FlatAppearance.MouseOverBackColor = Theme.SecondaryHoverColor;
            this.FlatAppearance.MouseDownBackColor = Theme.SecondaryClickColor;
        }

        private GraphicsPath GetRoundPath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();

            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);

            if (BorderRadius > 2)
            {
                using (GraphicsPath pathSurface = GetRoundPath(rectSurface, BorderRadius))
                using (Pen penSurface = new Pen(this.Parent?.BackColor ?? Theme.BackgroundColor, 2))
                {
                    this.Region = new Region(pathSurface);
                    pevent.Graphics.DrawPath(penSurface, pathSurface);
                }
            }
            else
            {
                this.Region = new Region(rectSurface);
            }
        }
    }
}