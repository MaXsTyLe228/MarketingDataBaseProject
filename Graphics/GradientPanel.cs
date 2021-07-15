using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Курсач
{
    class GradientPanel: Panel
    {
        public new Color Top { get; set; }
        public Color Bot { get; set; }
        public int Gradus { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            LinearGradientBrush l = new LinearGradientBrush(this.ClientRectangle, this.Top, this.Bot, Gradus);
            Graphics g = e.Graphics;
            g.FillRectangle(l, this.ClientRectangle);
            base.OnPaint(e);
        }
    }
}
