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
    public partial class FeatCreation : Form
    {
        public FeatCreation()
        {
            InitializeComponent();
        }

        Roll roll;


        //save/create weapon
        private void button1_Click(object sender, EventArgs e)
        {
            ((Form1)Owner).AddFeat(new Feat(nameTextBox.Text, rollNameTextBox.Text, abilitiesTextBox.Text,
                usesRollCheckBox.Checked, roll));
            this.Close();
        }

        //display new roll form
        private void newRoll(object sender, EventArgs e)
        {
            CustomRollForm rollPage = new CustomRollForm(3, 8);
            rollPage.ShowDialog(this);
        }

        //set new roll
        public void SetRoll(Roll r)
        {
            roll = r;
            rollDisplayTextBox.Text = "Roll: " + roll.ToString();
        }

        //clear text of roll name
        private void rollNameTextBox_Enter(object sender, EventArgs e)
        {
            if (rollNameTextBox.Text == "roll name")
            {
                rollNameTextBox.Text = "";
                rollNameTextBox.ForeColor = DefaultForeColor;
            }
        }
        private void rollNameTextBox_Leave(object sender, EventArgs e)
        {
            if (rollNameTextBox.Text == "")
            {
                rollNameTextBox.ForeColor = Color.DimGray;
                rollNameTextBox.Text = "roll name";
            }
        }

        //disable buttons for roll
        private void FeatCreation_Load(object sender, EventArgs e)
        {
            usesRollCheckBox.Checked = false;
            setRollButton.Enabled = false;
            LimitedUsecheckBox.Checked = true;
            numUsesBox.Enabled = true;
        }
    }
}
