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
            RefillType type;
            if (longRestradioButton.Checked)
                type = RefillType.LONG;
            else if (shortRestRadioButton.Checked)
                type = RefillType.SHORT;
            else
                type = RefillType.OTHER;

            ((Form1)Owner).AddFeat(new Feat(nameTextBox.Text, abilitiesTextBox.Text,
                usesRollCheckBox.Checked, roll, (usesRollCheckBox.Checked && LimitedUsecheckBox.Checked), 
                type, (int)numUsesBox.Value));
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
            saveButton.Enabled = true;
        }


        //initialize form
        private void FeatCreation_Load(object sender, EventArgs e)
        {
            //disable buttons for roll
            usesRollCheckBox.Checked = false;
            setRollButton.Enabled = false;
            LimitedUsecheckBox.Checked = true;
            //numUsesBox.Enabled = true;
            //focus the name text box
            nameTextBox.Select();
        }

        //enable/disable numOfUses box and radio buttons
        private void LimitedUsecheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(((CheckBox)sender).Checked)
            {
                numUsesBox.Enabled = true;
                if (!(shortRestRadioButton.Checked || longRestradioButton.Checked || OtherradioButton.Checked))
                    longRestradioButton.Checked = true;
                shortRestRadioButton.Enabled = true;
                longRestradioButton.Enabled = true;
                OtherradioButton.Enabled = true;
            }
            else
            {
                numUsesBox.Enabled = false;
                shortRestRadioButton.Enabled = false;
                longRestradioButton.Enabled = false;
                OtherradioButton.Enabled = false;
            }
        }

        //enable/disable roll buttons/boxes
        private void usesRollCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                //if(LimitedUsecheckBox.Checked)
                //    numUsesBox.Enabled = true;
                //else
                //    numUsesBox.Enabled = false;
                //LimitedUsecheckBox.Enabled = true;
                setRollButton.Enabled = true;
                if (roll != null)
                    saveButton.Enabled = true;
                else
                    saveButton.Enabled = false;
            }
            else
            {
                //numUsesBox.Enabled = false;
                //LimitedUsecheckBox.Enabled = false;
                setRollButton.Enabled = false;
                saveButton.Enabled = true;
            }
        }
    }
}
