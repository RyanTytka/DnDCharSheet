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
    public partial class CustomPreparedCheck : UserControl
    {
        public int State = 0; // 0 = not prepared, 1 = prepared, 2 = locked

        public CustomPreparedCheck()
        {
            InitializeComponent();
        }

        //alternate between prepared states
        private void lockedButton_Click(object sender, EventArgs e)
        {
            State = 0;
            notPreparedButton.BringToFront();
            TabIndex++;
        }
        private void notPreparedButton_Click(object sender, EventArgs e)
        {
            State = 1;
            preparedButton.BringToFront();
            TabIndex++;
        }
        private void preparedButton_Click(object sender, EventArgs e)
        {
            State = 2;
            lockedButton.BringToFront();
            TabIndex++;
        }

        //sets the image and state value to the specified state
        public void SetState(CheckState state)
        {
            if(state == CheckState.Checked)
            {
                State = 1;
                preparedButton.BringToFront();
            }
            else if (state == CheckState.Indeterminate)
            {
                State = 2;
                lockedButton.BringToFront();
            }
            else
            {
                State = 0;
                notPreparedButton.BringToFront();
            }
        }
    }
}
