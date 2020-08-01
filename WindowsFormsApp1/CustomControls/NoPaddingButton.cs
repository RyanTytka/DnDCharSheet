using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace CustomButtons
{
    public partial class ButtonNoPadding : Button
    {
        private string _textCurrent;

        //private Color ButtonBackColor = Color.FromArgb(200,200,200);
        //private Rectangle ButtonBackRec;

        public ButtonNoPadding()
        {
            //ButtonBackRec = Rectangle.Inflate(ClientRectangle, -2, -2);
            //BackColor = Color.White;

            FlatStyle = FlatStyle.Flat;
            FlatAppearance.MouseDownBackColor = Color.FromArgb(190, 190, 190);
            FlatAppearance.MouseOverBackColor = Color.FromArgb(220, 220, 220);

        }


        private string _Text;
        [Category("Appearance")]
        public override string Text
        {
            get { return _Text; }
            set
            {
                if (value != _Text)
                {
                    _Text = value;
                    Invalidate();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            _textCurrent = Text;
            _Text = string.Empty;
            base.OnPaint(e);
            _Text = _textCurrent;

            using (var brush = new SolidBrush(ForeColor))
            {
                using (var stringFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    //e.Graphics.DrawRectangle(new Pen(Color.Black, 1), Rectangle.Inflate(ClientRectangle, -2, -2));
                    //e.Graphics.FillRectangle(new SolidBrush(ButtonBackColor), ButtonBackRec);
                    e.Graphics.DrawString(Text, Font, brush, Rectangle.Inflate(ClientRectangle, -2, -2), stringFormat);
                }
            }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            if (Enabled)
                BackColor = Color.FromArgb(235,235,235);
            else
                BackColor = Color.FromArgb(150,150,150);
        }

        // remove focus from button when clicked.  not currently working
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            //if(Parent as Form1 == null)
                //(Parent.Parent as Form1).ActiveControl = Parent.Parent;
            //else
                //(Parent as Form1).ActiveControl = Parent;
        }

    }
}
