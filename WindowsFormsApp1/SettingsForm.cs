using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class SettingsForm : Form
    {
        public SettingsForm(bool showHelp)
        {
            InitializeComponent();

            showHelpCheckBox.Checked = showHelp;
        }

        private void Apply(object sender, EventArgs e)
        {
            (Owner as Form1).SaveSettings(showHelpCheckBox.Checked);
            this.Close();
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
