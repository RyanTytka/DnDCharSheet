using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.CustomControls
{
    public partial class CustomCheckBox : CheckBox
    {
        private Color FillInColor { get; set; }
        private Color BoxColor { get; set; }

        public CustomCheckBox()
        {
            BoxColor = Color.FromArgb(135, 20, 20);
            FillInColor = Color.White;

            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            if (this.Checked)
            {
                pevent.Graphics.FillRectangle(new SolidBrush(FillInColor), new Rectangle(1, 1, 12, 12));
                pevent.Graphics.DrawRectangle(new Pen(BoxColor, 3), new Rectangle(1, 1, 12, 13));
                pevent.Graphics.DrawLines(new Pen(BoxColor, 2), new Point[3] { new Point(3,7), new Point(5, 12), new Point(12, 0) });
            }
            else
            {
                pevent.Graphics.FillRectangle(new SolidBrush(FillInColor), new Rectangle(1, 1, 12, 12));
                pevent.Graphics.DrawRectangle(new Pen(BoxColor, 3), new Rectangle(1, 1, 12, 13));
            }
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            FillInColor = Color.LightGray;
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            FillInColor = Color.White;
            Invalidate();   // redraws with white fill color

        }
    }
}
