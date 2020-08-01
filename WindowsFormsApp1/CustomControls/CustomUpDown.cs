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
    public partial class CustomUpDown : UserControl
    {
        string prevText = "";
        public int Value;
        public Color DrawColor;
        
        public CustomUpDown()
        {
            InitializeComponent();
            DrawColor = Color.FromArgb(135, 20, 20);
            Value = int.Parse(textBox.Text);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //int upX = upBox.Location.X;
            //int upY = upBox.Location.Y;
            //int width = upBox.Width;
            //int height = upBox.Height;
            //e.Graphics.DrawLines(new Pen(DrawColor, 2), new Point[4]
            //    { new Point(upX, upY), new Point(upX + width, upY), new Point(upX + width / 2, upY + height), new Point(upX, upY) });

        }

        //increment value
        private void upBox_Click(object sender, EventArgs e)
        {
            Value++;
            textBox.Text = Value.ToString();
        }

        //decrement value
        private void downBox_Click(object sender, EventArgs e)
        {
            Value--;
            textBox.Text = Value.ToString();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox.Text, out int o))
            {
                Value = o;
                prevText = textBox.Text;
            }
            else
            {
                if (textBox.Text == "" || textBox.Text == "-")
                {
                    prevText = textBox.Text;
                }
                else
                {
                    textBox.Text = prevText;
                    textBox.Select(textBox.Text.Length, 0);
                }
            }

        }

        //makes sure there is always a value
        private void textBox_Leave(object sender, EventArgs e)
        {
            textBox.Text = Value.ToString();
        }
    }
}
