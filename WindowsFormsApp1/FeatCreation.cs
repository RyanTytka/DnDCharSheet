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


        //save/create feat
        private void CreateFeat(object sender, EventArgs e)
        {
            ((Form1)Owner).AddFeat(new Feat(nameTextBox.Text, abilitiesTextBox.Text,
                usesRollCheckBox.Checked, roll, (usesRollCheckBox.Checked && LimitedUsecheckBox.Checked), 
                (int)numUsesBox.Value));
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


        //initialize form
        private void FeatCreation_Load(object sender, EventArgs e)
        {
            //disable buttons for roll
            usesRollCheckBox.Checked = false;
            setRollButton.Enabled = false;
            LimitedUsecheckBox.Checked = true;
            numUsesBox.Enabled = true;
            //focus the name text box
            nameTextBox.Select();
        }

        //enable/disable numOfUses box
        private void LimitedUsecheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(((CheckBox)sender).Checked)
            {
                //if(usesRollCheckBox.Checked)
                    numUsesBox.Enabled = true;
            }
            else
            {
                numUsesBox.Enabled = false;
            }
        }

        //enable/disable roll buttons/boxes
        private void usesRollCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                if(LimitedUsecheckBox.Checked)
                    numUsesBox.Enabled = true;
                else
                    numUsesBox.Enabled = false;
                setRollButton.Enabled = true;
                LimitedUsecheckBox.Enabled = true;
            }
            else
            {
                numUsesBox.Enabled = false;
                setRollButton.Enabled = false;
                LimitedUsecheckBox.Enabled = false;
            }
        }
    }
}
