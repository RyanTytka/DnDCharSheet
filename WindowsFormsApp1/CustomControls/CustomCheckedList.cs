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
    public partial class CustomCheckedList : UserControl
    {
        public int profBonus;
        public int[] attributes;        // array of attributes to calculate bonuses
        public double[] modifiers;      // multipliers (0, .5, 1, 2)
        private int[] indexToModifer;   // converts prof index to stat mod

        private Label[] displayLabels;
        public ProficiencyCheckBox[] checks1;
        public ProficiencyCheckBox[] checks2;
        public ProficiencyCheckBox[] halfChecks;

        public CustomCheckedList()
        {
            InitializeComponent();
        }

        private void CustomCheckedList_Load(object sender, EventArgs e)
        {
            indexToModifer = new int[18] { 0, 1,1,1,3,3,3,3,3,4,4,4,4,4,5,5,5,5};
            displayLabels = new Label[18];
            checks1 = new ProficiencyCheckBox[18];
            checks2 = new ProficiencyCheckBox[18];
            halfChecks = new ProficiencyCheckBox[18];

            //add checkboxes to list
            foreach(Control c in Controls)
            {
                // add checkboxes to lists
                if(c is ProficiencyCheckBox)
                {
                    if(c.Tag.ToString().Substring(0,1) == "1")
                    {
                        checks1[int.Parse(c.Tag.ToString().Substring(2))] = (c as ProficiencyCheckBox);
                    }
                    else if (c.Tag.ToString().Substring(0, 1) == "2")
                    {
                        checks2[int.Parse(c.Tag.ToString().Substring(2))] = (c as ProficiencyCheckBox);
                    }
                    else
                    {
                        halfChecks[int.Parse(c.Tag.ToString().Substring(2))] = (c as ProficiencyCheckBox);
                    }
                }
                // add labels to list
                if(c is Label && c.Tag != null)
                {
                    displayLabels[int.Parse(c.Tag.ToString())] = c as Label;
                }
            }

            foreach(ProficiencyCheckBox checkBox in halfChecks)
            {
                checkBox.FullBox = false;
            }
        }

        // when a checkbox is checked/unchecked
        private void CheckChange(object sender, EventArgs e)
        {
            int index = int.Parse((sender as ProficiencyCheckBox).Tag.ToString().Substring(2));
            if ((sender as ProficiencyCheckBox).Tag.ToString().Substring(0, 1) == "3")
            {
                //uncheck prof1 and 2
                if ((sender as ProficiencyCheckBox).Checked)
                {
                    checks1[index].Checked = false;
                    checks2[index].Checked = false;
                }
            }
            else
            {
                //uncheck half prof
                if ((sender as ProficiencyCheckBox).Checked)
                {
                    halfChecks[index].Checked = false;
                }
            }
            CalculateModifiers(modifiers);
        }

        // calculates and places all modifiers into array
        public void CalculateModifiers(double[] array)
        {
            for(int i = 0; i < 18; i++)
            {
                // check checkboxes
                if(halfChecks[i].Checked)
                {
                    array[i] = .5;
                }
                else if(checks1[i].Checked)
                {
                    if(checks2[i].Checked)
                    {
                        array[i] = 2;
                    }
                    else
                    {
                        array[i] = 1;
                    }
                }
                else if(checks2[i].Checked)
                {
                    if (checks1[i].Checked)
                    {
                        array[i] = 2;
                    }
                    else
                    {
                        array[i] = 1;
                    }
                }
                else
                {
                    array[i] = 0;
                }
                // set label text
                string sign;
                if (profBonus * array[i] + attributes[indexToModifer[i]] > 0) sign = "+"; else sign = "";
                displayLabels[i].Text = sign + (int)(profBonus * array[i] + attributes[indexToModifer[i]]);
            }
        }

        //rolls ability check
        private void RollAbiltyCheck_Click(object sender, EventArgs e)
        {
            int ID = int.Parse((sender as CustomButtons.ButtonNoPadding).Tag.ToString());
            int roll = Roll.RollSingleDie(20);

            (Parent as Form1).UpdateOutput(((Button)sender).Text + " ability check: " + 
                (roll + modifiers[ID] * profBonus + attributes[indexToModifer[ID]]) +
                " (Roll: " + roll + ", Proficiency Bonus: " + (modifiers[ID] * profBonus) + ", " +
                "Ability Modifier: " + attributes[indexToModifer[ID]] + ")");
            (Parent as Form1).UpdateOutput(Environment.NewLine); (Parent as Form1).UpdateOutput(Environment.NewLine);
        }
    }
}
