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
        Feat selectedFeat;      //feat to be editing, null if creating new feat
        int featIndex;          //index of feat to edit
        Roll roll;

        public FeatCreation(Feat feat = null, int index = 0)
        {
            selectedFeat = feat;
            featIndex = index;

            InitializeComponent();
        }



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

            if (selectedFeat == null)
            {
                ((Form1)Owner).AddFeat(new Feat(nameTextBox.Text, abilitiesTextBox.Text,
                    usesRollCheckBox.Checked, roll, LimitedUsecheckBox.Checked,
                    type, (int)numUsesBox.Value));
            }
            else
            {
                ((Form1)Owner).SetFeat(new Feat(nameTextBox.Text, abilitiesTextBox.Text,
                    usesRollCheckBox.Checked, roll, LimitedUsecheckBox.Checked,
                    type, (int)numUsesBox.Value), featIndex);
            }
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
            //check if creating or editing feat
            if (selectedFeat == null)
            {
                //disable buttons for roll
                usesRollCheckBox.Checked = false;
                setRollButton.Enabled = false;
                LimitedUsecheckBox.Checked = true;
                nameTextBox.Select();
            }
            else
            {
                //set controls to feat stats
                nameTextBox.Text = selectedFeat.Name;
                abilitiesTextBox.Text = selectedFeat.Abilities;
                usesRollCheckBox.Checked = selectedFeat.UseRoll;
                //limited use
                if(selectedFeat.LimitedUse)
                {
                    if(selectedFeat.RefillTypeProperty == RefillType.SHORT)
                    {
                        shortRestRadioButton.Checked = true;
                    }
                    else if(selectedFeat.RefillTypeProperty == RefillType.LONG)
                    {
                        longRestradioButton.Checked = true;
                    }
                    else
                    {
                        OtherradioButton.Checked = true;
                    }
                    numUsesBox.Value = selectedFeat.NumUses;
                    LimitedUsecheckBox.Checked = selectedFeat.LimitedUse;
                    shortRestRadioButton.Enabled = true;
                    longRestradioButton.Enabled = true;
                    OtherradioButton.Enabled = true;
                }
                //roll
                if(selectedFeat.UseRoll)
                {
                    usesRollCheckBox.Checked = true;
                    roll = selectedFeat.Roll;
                    rollDisplayTextBox.Text = "Roll: " + roll.ToString();
                }
                saveButton.Text = "Save Feat";
            }
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
                setRollButton.Enabled = true;
                if (roll != null)
                    saveButton.Enabled = true;
                else
                    saveButton.Enabled = false;
            }
            else
            {
                setRollButton.Enabled = false;
                saveButton.Enabled = true;
            }
        }
    }
}
