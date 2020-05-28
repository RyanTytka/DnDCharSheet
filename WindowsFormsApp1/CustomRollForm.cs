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
    public partial class CustomRollForm : Form
    {
        List<int> numList, amountList;
        int intDieNum;
        int formType; //1 = weapon bonus roll; 2 = weapon damage roll; 3 = feat roll; 4 = spell roll

        public CustomRollForm(int type, int intDieNum)
        {
            formType = type;
            this.intDieNum = intDieNum;
            numList = new List<int>();
            amountList = new List<int>();
            InitializeComponent();
        }

        //add the current roll to the list, update the textbox and reset counters
        private void addButton_Click(object sender, EventArgs e)
        {
            if (numList.Count > 0)
                totalRollLabel.Text += " + ";
            totalRollLabel.Text += dieAmountBox.Value + "d" + dieNumBox.Value;

            numList.Add((int)dieNumBox.Value);
            amountList.Add((int)dieAmountBox.Value);

            dieNumBox.Value = intDieNum;
            dieAmountBox.Value = 1;

            saveButton.Enabled = true;

        }

        private void CustomRollForm_Load(object sender, EventArgs e)
        {
            dieNumBox.Value = intDieNum;
        }


        private void flatNumBox_ValueChanged(object sender, EventArgs e)
        {
            if (flatNumBox.Value != 0 || numList.Count > 0)
                saveButton.Enabled = true;
            else
                saveButton.Enabled = false;
        }


        //exit and save
        private void button2_Click(object sender, EventArgs e)
        {

            Roll r = new Roll(numList, amountList);

            if (formType == 1) //add to bonus rolls
            {
                ((WeaponCreation)Owner).AddBonusRolls(amountList, numList, (int)flatNumBox.Value);
                this.Close();
            }
            else if (formType == 2) //set damage roll
            {
                ((WeaponCreation)Owner).SetDamageRoll(new Roll(amountList,numList, (int)flatNumBox.Value));
                this.Close();
            }
            else if (formType == 3) //set feat roll
            {   
                ((FeatCreation)Owner).SetRoll(new Roll(amountList, numList, (int)flatNumBox.Value));
                this.Close();
            }
            else if(formType == 4)   //set spell roll
            {
                ((SpellCreationForm)Owner).AddRoll(amountList, numList, (int)flatNumBox.Value);
                this.Close();
            }
        }



    }
}
