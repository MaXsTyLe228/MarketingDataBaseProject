using System.Drawing;
using System.Windows.Forms;

namespace Курсач
{
    class gradientGrid : DataGridView
    {
        public new Color Top { get; set; }
        public Color Bot { get; set; }
        protected override void PaintBackground(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle gridBounds)
        {
            base.PaintBackground(graphics, clipBounds, gridBounds);

            System.Drawing.Drawing2D.LinearGradientBrush b = new System.Drawing.Drawing2D.LinearGradientBrush(clipBounds, this.Top, this.Bot, System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal);
            graphics.FillRectangle(b, clipBounds);
        }
    }
}
