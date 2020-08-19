using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace WindowsFormsApp1
{
    public partial class SpellInfoDisplay : Form
    {
        private Spell spell;
        private System.Windows.Controls.TextBox descBox;

        public SpellInfoDisplay(Spell s)
        {
            InitializeComponent();

            spell = s;
            descBox = (desc.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;
            descBox.IsReadOnly = true;
        }

        //display spell info
        private void SpellInfoDisplay_Load(object sender, EventArgs e)
        {
            nameLabel.Text = spell.Name;
            descBox.Text = spell.Description;
        }
    }
}
