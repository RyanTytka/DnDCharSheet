using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.Integration;
using System.Windows.Media;

namespace WindowsFormsApp1.CustomControls
{
    public class CustomTextBox : System.Windows.Forms.UserControl
    {
        private ElementHost elementHost = new ElementHost();
        private TextBox textBox = new TextBox();
        public CustomTextBox()
        {
            textBox.FontSize = 14;
            textBox.Background = new SolidColorBrush(Colors.LightGray);
            textBox.BorderThickness = new Thickness(0);
            textBox.SelectionBrush = new SolidColorBrush(Colors.Gray);
            textBox.SelectionOpacity = 0.5;
            textBox.TextAlignment = TextAlignment.Center;
            textBox.VerticalContentAlignment = VerticalAlignment.Center;
            elementHost.Dock = System.Windows.Forms.DockStyle.Fill;
            elementHost.Name = "elementHost";
            elementHost.Child = textBox;
            textBox.TextChanged += (s, e) => OnTextChanged(EventArgs.Empty);
            Controls.Add(elementHost);
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }
    }
}