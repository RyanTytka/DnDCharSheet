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
    public partial class ProficiencyCheckBox : CheckBox
    {
        private Color FillInColor { get; set; }
        private Color BoxColor { get; set; }
        public bool FullBox { get; set; }

        public ProficiencyCheckBox()
        {
            BoxColor = Color.FromArgb(135, 20, 20);
            FillInColor = Color.White;
            FullBox = true;

            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            if (FullBox)
            {
                if (this.Checked)
                {
                    pevent.Graphics.FillRectangle(new SolidBrush(BoxColor), new Rectangle(1, 2, 11, 11));
                    pevent.Graphics.DrawRectangle(new Pen(BoxColor, 2), new Rectangle(1, 2, 11, 12));
                }
                else
                {
                    pevent.Graphics.FillRectangle(new SolidBrush(BackColor), new Rectangle(1, 2, 11, 11));
                    pevent.Graphics.DrawRectangle(new Pen(BoxColor, 2), new Rectangle(1, 2, 11, 12));
                }
            }
            else
            {
                if (this.Checked)
                {
                    pevent.Graphics.FillRectangle(new SolidBrush(BackColor), new Rectangle(0, 1, 13, 13));
                    pevent.Graphics.DrawLines(new Pen(BoxColor, 2), new Point[4]
                        { new Point(1, 2), new Point(1, 15), new Point(13, 15), new Point(1,3) });
                    pevent.Graphics.DrawLines(new Pen(BoxColor, 2), new Point[4]
                        { new Point(3, 4), new Point(3, 13), new Point(11, 13), new Point(3,5) });
                    pevent.Graphics.DrawLines(new Pen(BoxColor, 2), new Point[4]
                        { new Point(5, 6), new Point(5, 11), new Point(9, 11), new Point(5,7) });
                }
                else
                {
                    pevent.Graphics.FillRectangle(new SolidBrush(BackColor), new Rectangle(0, 1, 13, 13));
                    pevent.Graphics.DrawLines(new Pen(BoxColor, 2), new Point[4] 
                        { new Point(1, 2), new Point(1, 15), new Point(13, 15), new Point(1,3) });
                }
            }
        }
    }
}
