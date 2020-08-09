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
    public partial class CustomRadioButton : RadioButton
    {
        Pen pen = new Pen(Color.Maroon, 2);

        public CustomRadioButton()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            if(Checked)
            {
                pevent.Graphics.FillEllipse(new SolidBrush(Color.Maroon), 0, 2, 12, 12);
            }
            else
            {
                pevent.Graphics.FillEllipse(new SolidBrush(Color.Maroon), 0, 2, 12, 12);
                pevent.Graphics.FillEllipse(new SolidBrush(BackColor), 1.5f, 3.5f, 9, 9);
                //pevent.Graphics.DrawEllipse(pen, 0, 2, 12, 12);
            }
        }
    }
}
