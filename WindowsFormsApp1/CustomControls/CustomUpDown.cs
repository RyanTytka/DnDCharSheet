using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace WindowsFormsApp1.CustomControls
{
    public partial class CustomUpDown : UserControl
    {
        string prevText = "";
        private int value = 0;
        public Color DrawColor;
        private System.Windows.Controls.TextBox box;
        bool alreadyFocused;

        public int Value
        {
            get { return value; }
            set { this.value = value; box.Text = this.value.ToString(); }
        }

        public CustomUpDown()
        {
            InitializeComponent();
            box = (textBox.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;
            box.TextChanged += textBox_TextChanged;
            box.GotFocus += textBox1_GotFocus;
            box.MouseUp += textBox1_MouseUp;
            box.LostFocus += textBox1_Leave;
            box.Text = "0";
            Value = int.Parse(box.Text);
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
            box.Text = Value.ToString();
        }

        //decrement value
        private void downBox_Click(object sender, EventArgs e)
        {
            Value--;
            box.Text = Value.ToString();
        }

        // update value and remove letters
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(box.Text, out int o))
            {
                Value = o;
                prevText = box.Text;
            }
            else
            {
                if (box.Text == "" || box.Text == "-")
                {
                    prevText = box.Text;
                }
                else
                {
                    box.Text = prevText;
                    box.Select(box.Text.Length, 0);
                }
            }

        }

        //makes sure there is always a value
        private void textBox_Leave(object sender, EventArgs e)
        {
            box.Text = Value.ToString();
        }

        /// <summary>
        /// increases the size of the control
        /// </summary>
        public void MakeBigger()
        {
            this.Size = new Size(80, 47);
            box.FontSize = 24;
            upButton.Size = new Size(24, 15);
            downButton.Size = new Size(24, 15);
            upButton.Location = new Point(42, 1);
            downButton.Location = new Point(42, 19);
            textBox.Size = new Size(40, 28);

        }

        // thses three methdos select text when clicking on the textbox (not currently working)
        void textBox1_Leave(object sender, EventArgs e)
        {
            alreadyFocused = false;
        }
        void textBox1_GotFocus(object sender, EventArgs e)
        {
            // Select all text only if the mouse isn't down.
            // This makes tabbing to the textbox give focus.
            if (MouseButtons == MouseButtons.None)
            {
                box.SelectAll();
                alreadyFocused = true;
            }
        }
        void textBox1_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!alreadyFocused && box.SelectionLength == 0)
            {
                alreadyFocused = true;
                box.SelectAll();
            }
        }
    }
}
