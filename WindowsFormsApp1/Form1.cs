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
    public partial class Form1 : Form
    {
        bool saveThrowAdv;
        double[] Saveproficiencies = new double[6];
        TextBox[] mods;
        double[] proficiencies = new double[23];
        int profBonus = 2;
        int[] statMods = new int[6];
        List<string> outputList = new List<string>();
        List<Weapon> weapons;
        List<RadioButton> weaponButtons;
        int currentWeapon;
        List<Control> currentBonusRolls;
        int MaxHP = 10, currentHP = 0, tempHP = 0;
        int[] currentHitDice, maxHitDice;

        private void Form1_Load(object sender, EventArgs e)
        {
            weapons = new List<Weapon>();
            currentBonusRolls = new List<Control>();
            mods = new TextBox[23];
            currentHitDice = new int[4];
            maxHitDice = new int[4];


            mods[1] = strModLabel;
            mods[3] = dexModLabel; mods[4] = dexModLabel; mods[5] = dexModLabel;
            mods[7] = intModLabel; mods[8] = intModLabel; mods[9] = intModLabel; mods[10] = intModLabel; mods[11] = intModLabel;
            mods[13] = wisModLabel; mods[14] = wisModLabel; mods[15] = wisModLabel; mods[16] = wisModLabel; mods[17] = wisModLabel;
            mods[19] = chrModLabel; mods[20] = chrModLabel; mods[21] = chrModLabel; mods[22] = chrModLabel;

            //add weapon radio buttons to a list
            weaponButtons = new List<RadioButton>();
            weaponButtons.Add(weaponRadioButton1);
            weaponButtons.Add(weaponRadioButton2);
            weaponButtons.Add(weaponRadioButton3);
            weaponButtons.Add(weaponRadioButton4);
            weaponButtons.Add(weaponRadioButton5);
            weaponButtons.Add(weaponRadioButton6);
            weaponButtons.Add(weaponRadioButton7);
            weaponButtons.Add(weaponRadioButton8);
        }


        public Form1()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        // vvvvvvvvvvv attribute methods vvvvvvvvvvvvvv

        #region Saving Throws
        private void strSaveButton_Click(object sender, EventArgs e)
        {
            SaveThrow(0, "Strength");
        }
        private void dexSaveButton_Click(object sender, EventArgs e)
        {
            SaveThrow(1, "Dexterity");
        }
        private void conSaveButton_Click(object sender, EventArgs e)
        {
            SaveThrow(2, "Constitution");
        }
        private void intSaveButton_Click(object sender, EventArgs e)
        {
            SaveThrow(3, "Intelligence");
        }
        private void wisSaveButton_Click(object sender, EventArgs e)
        {
            SaveThrow(4, "Wisdom");
        }
        private void chrSaveButton_Click(object sender, EventArgs e)
        {
            SaveThrow(5, "Charisma");
        }
        #endregion

        #region Add/Subtract Buttons

        private void strAddButton_Click(object sender, EventArgs e)
        {
            strDisplayBox.Text = (int.Parse(strDisplayBox.Text) + 1).ToString();
        }
        private void strDecreaseButton_Click(object sender, EventArgs e)
        {
            strDisplayBox.Text = (int.Parse(strDisplayBox.Text) - 1).ToString(); 
        }
        private void dexAddButton_Click(object sender, EventArgs e)
        {
            dexDisplayBox.Text = (int.Parse(dexDisplayBox.Text) + 1).ToString();
        }
        private void dexDecreaseButton_Click(object sender, EventArgs e)
        {
            dexDisplayBox.Text = (int.Parse(dexDisplayBox.Text) - 1).ToString();
        }
        private void conAddButton_Click(object sender, EventArgs e)
        {
            conDisplayBox.Text = (int.Parse(conDisplayBox.Text) + 1).ToString();
        }
        private void conDecreaseButton_Click(object sender, EventArgs e)
        {
            conDisplayBox.Text = (int.Parse(conDisplayBox.Text) - 1).ToString();
        }
        private void intAddButton_Click(object sender, EventArgs e)
        {
            intDisplayBox.Text = (int.Parse(intDisplayBox.Text) + 1).ToString();
        }
        private void intDecreaseButton_Click(object sender, EventArgs e)
        {
            intDisplayBox.Text = (int.Parse(intDisplayBox.Text) - 1).ToString();
        }
        private void wisAddButton_Click(object sender, EventArgs e)
        {
            wisDisplayBox.Text = (int.Parse(wisDisplayBox.Text) + 1).ToString();
        }
        private void wisDecreaseButton_Click(object sender, EventArgs e)
        {
            wisDisplayBox.Text = (int.Parse(wisDisplayBox.Text) - 1).ToString();
        }
        private void chrAddButton_Click(object sender, EventArgs e)
        {
            chrDisplayBox.Text = (int.Parse(chrDisplayBox.Text) + 1).ToString();
        }
        private void chrDecreaseButton_Click(object sender, EventArgs e)
        {
            chrDisplayBox.Text = (int.Parse(chrDisplayBox.Text) - 1).ToString();
        }

        #endregion

        #region Attribute Modifiers / Proficiencies

        private void saveAdvantage_CheckedChanged(object sender, EventArgs e)
        {
            saveThrowAdv = saveAdvantage.Checked;
        }
        private void strProfBox_CheckedChanged(object sender, EventArgs e)
        {
            Saveproficiencies[0] = BoolToInt(strProfBox.Checked);
        }
        private void dexProfBox_CheckedChanged(object sender, EventArgs e)
        {
            Saveproficiencies[1] = BoolToInt(dexProfBox.Checked);
        }
        private void conProfBox_CheckedChanged(object sender, EventArgs e)
        {
            Saveproficiencies[2] = BoolToInt(conProfBox.Checked);
        }
        private void intProfBox_CheckedChanged(object sender, EventArgs e)
        {
            Saveproficiencies[3] = BoolToInt(intProfBox.Checked);
        }
        private void wisProfBox_CheckedChanged(object sender, EventArgs e)
        {
            Saveproficiencies[4] = BoolToInt(wisProfBox.Checked);
        }
        private void chrProfBox_CheckedChanged(object sender, EventArgs e)
        {
            Saveproficiencies[5] = BoolToInt(chrProfBox.Checked);
        }
        //change the modifier bonus text
        private void strDisplayBox_TextChanged(object sender, EventArgs e)
        {
            statMods[0] = (int.Parse(strDisplayBox.Text) / 2) - 5;

            //add plus sign if positive
            string sign = "";
            if (statMods[0] > 0)
                sign = "+";

            strModLabel.Text = sign + statMods[0];
        }
        private void dexModLabel_TextChanged(object sender, EventArgs e)
        {
            statMods[1] = (int.Parse(dexDisplayBox.Text) / 2) - 5;

            //add plus sign if positive
            string sign = "";
            if (statMods[1] > 0)
                sign = "+";

            dexModLabel.Text = sign + statMods[1];
        }
        private void conModLabel_TextChanged(object sender, EventArgs e)
        {
            statMods[2] = (int.Parse(conDisplayBox.Text) / 2) - 5;

            //add plus sign if positive
            string sign = "";
            if (statMods[2] > 0)
                sign = "+";

            conModLabel.Text = sign + statMods[2];
        }
        private void intModLabel_TextChanged(object sender, EventArgs e)
        {
            statMods[3] = (int.Parse(intDisplayBox.Text) / 2) - 5;

            //add plus sign if positive
            string sign = "";
            if (statMods[3] > 0)
                sign = "+";

            intModLabel.Text = sign + statMods[3];
        }
        private void wisModLabel_TextChanged(object sender, EventArgs e)
        {
            statMods[4] = (int.Parse(wisDisplayBox.Text) / 2) - 5;

            //add plus sign if positive
            string sign = "";
            if (statMods[4] > 0)
                sign = "+";

            wisModLabel.Text = sign + statMods[4];
        }
        private void chrModLabel_TextChanged(object sender, EventArgs e)
        {
            statMods[5] = (int.Parse(chrDisplayBox.Text) / 2) - 5;

            //add plus sign if positive
            string sign = "";
            if (statMods[5] > 0)
                sign = "+";

            chrModLabel.Text = sign + statMods[5];
        }

        #endregion



        // vvvvvvvvvvv Proficiencies vvvvvvvvvvvvvvvvvvv

        #region Misc

        // rolls an ability check
        private void rollEditButton_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(((Button)sender).Name.Substring(((Button)sender).Name.Length - 2));
            int roll = Roll.RollSingleDie(20);

            UpdateOutput(((Button)sender).Tag + " ability check: " + (roll + proficiencies[ID] * profBonus + int.Parse(mods[ID].Text)) +
                " (Roll: " + roll + ", Proficiency Bonus: " + (proficiencies[ID] * profBonus) + ", " +
                "Ability Modifier: " + int.Parse(mods[ID].Text) + ")");
            UpdateOutput(Environment.NewLine); UpdateOutput(Environment.NewLine);
        }

        //update each of the text on the prof roll buttons
        private void UpdateProficiencies(object sender, EventArgs e)
        {
            string sign;

            if (profBonus * proficiencies[1] + int.Parse(strModLabel.Text) > 0) sign = "+"; else sign = "";
            profRoll01.Text = sign + (profBonus * proficiencies[1] + int.Parse(strModLabel.Text));

            if (profBonus * proficiencies[3] + int.Parse(dexModLabel.Text) > 0) sign = "+"; else sign = "";
            profRoll03.Text = sign + (profBonus * proficiencies[3] + int.Parse(dexModLabel.Text));
            if (profBonus * proficiencies[4] + int.Parse(dexModLabel.Text) > 0) sign = "+"; else sign = "";
            profRoll04.Text = sign + (profBonus * proficiencies[4] + int.Parse(dexModLabel.Text));
            if (profBonus * proficiencies[5] + int.Parse(dexModLabel.Text) > 0) sign = "+"; else sign = "";
            profRoll05.Text = sign + (profBonus * proficiencies[5] + int.Parse(dexModLabel.Text));

            if (profBonus * proficiencies[7] + int.Parse(intModLabel.Text) > 0) sign = "+"; else sign = "";
            profRoll07.Text = sign + (profBonus * proficiencies[7] + int.Parse(intModLabel.Text));
            if (profBonus * proficiencies[8] + int.Parse(intModLabel.Text) > 0) sign = "+"; else sign = "";
            profRoll08.Text = sign + (profBonus * proficiencies[8] + int.Parse(intModLabel.Text));
            if (profBonus * proficiencies[9] + int.Parse(intModLabel.Text) > 0) sign = "+"; else sign = "";
            profRoll09.Text = sign + (profBonus * proficiencies[9] + int.Parse(intModLabel.Text));
            if (profBonus * proficiencies[10] + int.Parse(intModLabel.Text) > 0) sign = "+"; else sign = "";
            profRoll10.Text = sign + (profBonus * proficiencies[10] + int.Parse(intModLabel.Text));
            if (profBonus * proficiencies[11] + int.Parse(intModLabel.Text) > 0) sign = "+"; else sign = "";
            profRoll11.Text = sign + (profBonus * proficiencies[11] + int.Parse(intModLabel.Text));

            if (profBonus * proficiencies[13] + int.Parse(wisModLabel.Text) > 0) sign = "+"; else sign = "";
            profRoll13.Text = sign + (profBonus * proficiencies[13] + int.Parse(wisModLabel.Text));
            if (profBonus * proficiencies[14] + int.Parse(wisModLabel.Text) > 0) sign = "+"; else sign = "";
            profRoll14.Text = sign + (profBonus * proficiencies[14] + int.Parse(wisModLabel.Text));
            if (profBonus * proficiencies[15] + int.Parse(wisModLabel.Text) > 0) sign = "+"; else sign = "";
            profRoll15.Text = sign + (profBonus * proficiencies[15] + int.Parse(wisModLabel.Text));
            if (profBonus * proficiencies[16] + int.Parse(wisModLabel.Text) > 0) sign = "+"; else sign = "";
            profRoll16.Text = sign + (profBonus * proficiencies[16] + int.Parse(wisModLabel.Text));
            if (profBonus * proficiencies[17] + int.Parse(wisModLabel.Text) > 0) sign = "+"; else sign = "";
            profRoll17.Text = sign + (profBonus * proficiencies[17] + int.Parse(wisModLabel.Text));

            if (profBonus * proficiencies[19] + int.Parse(chrModLabel.Text) > 0) sign = "+"; else sign = "";
            profRoll19.Text = sign + (profBonus * proficiencies[19] + int.Parse(chrModLabel.Text));
            if (profBonus * proficiencies[20] + int.Parse(chrModLabel.Text) > 0) sign = "+"; else sign = "";
            profRoll20.Text = sign + (profBonus * proficiencies[20] + int.Parse(chrModLabel.Text));
            if (profBonus * proficiencies[21] + int.Parse(chrModLabel.Text) > 0) sign = "+"; else sign = "";
            profRoll21.Text = sign + (profBonus * proficiencies[21] + int.Parse(chrModLabel.Text));
            if (profBonus * proficiencies[22] + int.Parse(chrModLabel.Text) > 0) sign = "+"; else sign = "";
            profRoll22.Text = sign + (profBonus * proficiencies[22] + int.Parse(chrModLabel.Text));


        }
        #endregion

        #region Buttons

        private void ProficienciesChecks_SelectedIndexChanged(object sender, EventArgs e)
        {
            //update proficiencies array
            int ID = ((CheckedListBox)sender).SelectedIndex;

            if (ID != -1)
            {
                //update check boxes
                if (sender == ProficienciesChecks)
                {
                    if(ProficienciesChecks.GetItemChecked(ID)) 
                    { //prof is checked
                        profCheckshalf.SetItemChecked(ID, false);
                    }
                    else
                    { //prof unchecked
                        profChecksX2.SetItemChecked(ID, false);
                    }
                }
                else if (sender == profChecksX2)
                {
                    if (profChecksX2.GetItemChecked(ID))
                    { //prof is checked
                        profCheckshalf.SetItemChecked(ID, false);
                        ProficienciesChecks.SetItemChecked(ID, true);
                    }
                }
                else
                {
                    if (profCheckshalf.GetItemChecked(ID))
                    { //prof is checked
                        ProficienciesChecks.SetItemChecked(ID, false);
                        profChecksX2.SetItemChecked(ID, false);
                    }
                }
                //update arrays
                if (ProficienciesChecks.GetItemChecked(ID))
                {
                    if (profChecksX2.GetItemChecked(ID))
                        proficiencies[ID] = 2;
                    else
                        proficiencies[ID] = 1;
                }
                else
                {
                    if (profCheckshalf.GetItemChecked(ID))
                        proficiencies[ID] = .5;
                    else
                        proficiencies[ID] = 0;
                }
            }

            UpdateProficiencies(null, null);

            //clear highlight from check lists
            ((CheckedListBox)sender).ClearSelected();

        }



        #endregion



        // vvvvvvvv helper methods vvvvvvvvvvvv


        private string RollDice()
        {
            Random rng = new Random();
            string output = "You rolled a (";
            List<int>[] rolls = Roll.RollDice(0, 4);

            int sum = 0;
            //add the rolls together for total
            for (int j = 0; j < rolls.Length; j++)
            {
                if (rolls[j] != null)
                {
                    for (int k = 0; k < rolls[j].Count; k++)
                    {
                        sum += rolls[j][k];
                        output += rolls[j][k] + " ";
                    }
                }
            }
            output += ")" + sum;



            return output;
        }

        //add a string to the log.  Displays the last 10 lines
        private void UpdateOutput(string s)
        {
            //add s to history
            outputList.Add(s);

            //take the last 10 lines
            string log = "";
            for(int i = Math.Max(0,outputList.Count - 10); i < outputList.Count; i++)
            {
                log += outputList[i];
            }

            //set the display text box
            outputTextBox.Text = log;
        }

        //converts true to 1, false to 0
        private int BoolToInt(bool b)
        {
            if (b)
                return 1;
            else
                return 0;
        }

        private void SaveThrow(int statI, string statS)
        {
            int roll;
            int pb = (int)(profBonus * Saveproficiencies[statI]); //checks if you add proficiency bonus
            if (Saveproficiencies[statI] == 1)
                pb = profBonus;

            if (saveThrowAdv) //reroll for advantage/disadvantage
            {
                roll = Roll.RollSingleDie(20);
                UpdateOutput(statS + " saving throw: " + (roll + pb + statMods[statI]) + " (Roll: " + roll + ", " +
                    "Proficency Bonus: " + pb + ", Ability Modifier: " + statMods[statI] + ")");
                UpdateOutput(Environment.NewLine);
            }

            roll = Roll.RollSingleDie(20);
            UpdateOutput(statS + " saving throw: " + (roll + pb + statMods[statI]) + " (Roll: " + roll + ", " +
                "Proficency Bonus: " + pb + ", Ability Modifier: " + statMods[statI] + ")");
            UpdateOutput(Environment.NewLine); UpdateOutput(Environment.NewLine);
        }

        // vvvvvvvvvvvvvv    Weapons   vvvvvvvvvvvvvvvv


        //new weapon button is clicked
        private void createWeapon_Click(object sender, EventArgs e)
        {
            WeaponCreation weaponCreation = new WeaponCreation();
            weaponCreation.ShowDialog(this);

            //move new weapon button
            newWeaponButton.Location = new Point(newWeaponButton.Location.X, newWeaponButton.Location.Y + 18);
            if (weapons.Count >= 8)
                newWeaponButton.Visible = false;
            if (weapons.Count == 1)
            {
                weaponRadioButton1.Checked = true;
                weaponPropTextBox.Tag = "properties";
                propertiesButtonDisplay.Enabled = true;
                bonusButtonDisplay.Enabled = true;
                weapondDelButton.Enabled = true;
                weaponEditButton.Enabled = true;
                atkRoll1.Enabled = true;
                dmgRoll2.Enabled = true;
                //propertiesButtonDisplay.BackColor
            }
        }

        public void AddWeapon(Weapon w)
        {
            weapons.Add(w);

            //show controls
            foreach(RadioButton button in weaponButtons)
            {
                if (!button.Visible)
                {
                    button.Visible = true;
                    button.Text = w.Name;
                    return;
                }
            }

            
            
        }

        //make attack roll with current weapon
        private void atkRoll1_Click(object sender, EventArgs e)
        {
            int ID = currentWeapon;

            int roll = Roll.RollSingleDie(20);

            int modifier;
            if(weapons[ID].Finesse)
                modifier = statMods[1];
            else
                modifier = statMods[0];

            int prof = 0;
            if (weapons[ID].Proficient)
                prof = profBonus;
            string profStr = ", Proficiency Bonus: " + prof;

            string bonuses = "";
            int bonusesTotal = 0;
            int i = 0;
            foreach(Roll r in weapons[ID].BonusRolls)
            {
                if (r.Type == 1 || r.Type == 3)
                {
                    if (!r.Optional || r.CurrentState)
                    {
                        int tempRoll = r.RollDice();
                        bonusesTotal += tempRoll;
                        bonuses += ", " + r.Name + ": " + tempRoll;
                    }
                }
                i++;
            }

            UpdateOutput("Attack Roll: " + (roll + modifier + prof + bonusesTotal) + "  (Roll: " + roll + ", Ability Modifier: "
                + modifier + profStr + bonuses + ")");
            UpdateOutput(Environment.NewLine); UpdateOutput(Environment.NewLine);
        }


        private void UpdateWeapon(object sender, EventArgs e)
        {
            if(((RadioButton)sender).Checked)
            {
                currentWeapon = int.Parse(((RadioButton)sender).Name.Substring(17)) - 1;
                //update current weapon info
                if ((string)weaponPropTextBox.Tag == "properties")
                {
                    //show properties
                    weaponPropTextBox.Text = weapons[currentWeapon].Properties;
                }
                else
                {
                    //delete bonus roll controls
                    foreach (Control c in currentBonusRolls)
                    {
                        Weapon1.Controls.Remove(c);
                    }
                    currentBonusRolls.Clear();
                    //show bonus rolls
                    weaponPropTextBox.Text = "";
                    int rollNum = weapons[currentWeapon].BonusRolls.Count - 1;
                    foreach (Roll r in weapons[currentWeapon].BonusRolls)
                    {
                        if (r.Optional)
                        {
                            CheckBox newLabel = new CheckBox();
                            newLabel.Location = new Point(110, 58 + rollNum * 18);
                            newLabel.Checked =
                                weapons[currentWeapon].BonusRolls[weapons[currentWeapon].BonusRolls.Count - rollNum - 1].CurrentState;
                            newLabel.Text = r.Name;
                            if (r.Type == 1)
                                newLabel.ForeColor = Color.Red;
                            if (r.Type == 2)
                                newLabel.ForeColor = Color.RoyalBlue;
                            if (r.Type == 3)
                                newLabel.ForeColor = Color.Purple;
                            newLabel.BringToFront();
                            newLabel.CheckedChanged += new EventHandler(BonusCheckChanged);
                            newLabel.Font = new Font("Arial", 9.25f, FontStyle.Regular);
                            Weapon1.Controls.Add(newLabel);
                            currentBonusRolls.Add(newLabel);
                        }
                        else
                        {
                            Label newLabel = new Label();
                            newLabel.Location = new Point(110, 61 + rollNum * 18);
                            newLabel.Text = r.Name;
                            if (r.Type == 1)
                                newLabel.ForeColor = Color.Red;
                            if (r.Type == 2)
                                newLabel.ForeColor = Color.RoyalBlue;
                            if (r.Type == 3)
                                newLabel.ForeColor = Color.Purple;
                            newLabel.Font = new Font("Arial", 9.25f, FontStyle.Regular);
                            newLabel.BringToFront();
                            Weapon1.Controls.Add(newLabel);
                            currentBonusRolls.Add(newLabel);
                        }
                        rollNum--;


                    }
                }


            }
        }

        //switch between properties tab and bonus rolls tab
        private void SwitchWeaponDisplay(object sender, EventArgs e)
        {
            if (((string)weaponPropTextBox.Tag) != "")
            {
                weaponPropTextBox.Tag = ((Button)sender).Tag;
                //change colors/tag
                if ((string)((Button)sender).Tag == "properties")
                { //set properties box to active
                    propertiesButtonDisplay.BackColor = Color.WhiteSmoke;
                    bonusButtonDisplay.BackColor = Color.DimGray;
                    weaponPropTextBox.Text = weapons[currentWeapon].Properties;
                    weaponPropTextBox.Visible = true;
                    //delete bonus roll controls
                    foreach (Control c in currentBonusRolls)
                    {
                        Weapon1.Controls.Remove(c);
                    }
                }
                else
                {
                    weaponPropTextBox.Visible = false;
                    propertiesButtonDisplay.BackColor = Color.DimGray;
                    bonusButtonDisplay.BackColor = Color.WhiteSmoke;
                    weaponPropTextBox.Text = "";

                    //delete bonus roll controls
                    foreach (Control c in currentBonusRolls)
                    {
                        Weapon1.Controls.Remove(c);
                    }
                    currentBonusRolls.Clear();
                    //show bonus rolls
                    weaponPropTextBox.Text = "";
                    int rollNum = weapons[currentWeapon].BonusRolls.Count - 1;
                    foreach (Roll r in weapons[currentWeapon].BonusRolls)
                    {
                        if (r.Optional)
                        {
                            CheckBox newLabel = new CheckBox();
                            newLabel.Location = new Point(110, 58 + rollNum * 18);
                            newLabel.Text = r.Name;
                            newLabel.Checked =
                                weapons[currentWeapon].BonusRolls[weapons[currentWeapon].BonusRolls.Count - rollNum - 1].CurrentState;
                            newLabel.CheckedChanged += new EventHandler(BonusCheckChanged);
                            newLabel.BringToFront();
                            if (r.Type == 1)
                                newLabel.ForeColor = Color.Red;
                            if (r.Type == 2)
                                newLabel.ForeColor = Color.RoyalBlue;
                            if (r.Type == 3)
                                newLabel.ForeColor = Color.Purple;
                            newLabel.Font = new Font("Arial", 9.25f, FontStyle.Regular);
                            Weapon1.Controls.Add(newLabel);
                            currentBonusRolls.Add(newLabel);
                        }
                        else
                        {
                            Label newLabel = new Label();
                            if (r.Type == 1)
                                newLabel.ForeColor = Color.Red;
                            if (r.Type == 2)
                                newLabel.ForeColor = Color.RoyalBlue;
                            if (r.Type == 3)
                                newLabel.ForeColor = Color.Purple;
                            newLabel.Location = new Point(110, 61 + rollNum * 18);
                            newLabel.Text = r.Name;
                            newLabel.Font = new Font("Arial", 9.25f, FontStyle.Regular);
                            newLabel.BringToFront();
                            Weapon1.Controls.Add(newLabel);
                            currentBonusRolls.Add(newLabel);
                        }
                        rollNum--;

                    }
                }
            }

        }

        /// <summary> 
        ///updates current stats of roll when check box is clicked
        /// </summary>
        public void BonusCheckChanged(object sender, System.EventArgs e)
        {
            for (int i = 0; i < currentBonusRolls.Count; i++)
            {
                if (currentBonusRolls[i] is CheckBox &&
                    weapons[currentWeapon].BonusRolls[i].Name == ((CheckBox)sender).Text)
                {
                    weapons[currentWeapon].BonusRolls[i].CurrentState = ((CheckBox)sender).Checked;
                }

            } 
        }

        //make damage roll
        private void dmgRoll2_Click(object sender, EventArgs e)
        {
            int ID = currentWeapon;

            int roll = weapons[ID].Damage.RollDice();

            int modifier;
            if (weapons[ID].Finesse)
                modifier = statMods[1];
            else
                modifier = statMods[0];

            string bonuses = "";
            int bonusesTotal = 0;
            int i = 0;
            foreach (Roll r in weapons[ID].BonusRolls)
            {
                if (r.Type == 2 || r.Type == 3)
                {
                    if (!r.Optional || r.CurrentState)
                    {
                        int tempRoll = r.RollDice();
                        bonusesTotal += tempRoll;
                        bonuses += ", " + r.Name + ": " + tempRoll;
                    }
                }
                i++;
            }

            UpdateOutput("Damage Roll: " + (roll + modifier + bonusesTotal) + "  (Roll: " + roll + ", Ability Modifier: "
                + modifier + bonuses + ")");
            UpdateOutput(Environment.NewLine); UpdateOutput(Environment.NewLine);
        }




        // vvvvvvvvv Name / AC / etc vvvvvvvvvvvvvvvvvvvv

        //set internal prof bonus
        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            profBonus = (int)profBonusBox.Value;
        }




        #region HP


        //remove letters from the +/- box
        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            string s = ((TextBox)sender).Text;
            string end = "";
            for(int i = 0; i < s.Length; i++)
            {
                if(int.TryParse(s[i].ToString() , out int num) || 
                    ((string)((TextBox)sender).Tag != "max" && (
                    (i == 0 && s[i] == '+' && (string)((TextBox)sender).Tag != "temp") || s[i] == '-' && i == 0)))
                {
                    end += s[i];
                }
            }
            ((TextBox)sender).Size = new Size(12 + end.Length * 6,17);
            ((TextBox)sender).Text = end;
            ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
            ((TextBox)sender).SelectionLength = 0;
        }

        //press hp buttons
        private void HPButtonClick(object sender, EventArgs e)
        {
            if (((CustomButtons.ButtonNoPadding)sender).Tag.ToString() == "current") //current
            {
                if (CurrentAmountBox.Text != "")
                {
                    if (((CustomButtons.ButtonNoPadding)sender).Text == "+")
                    {
                        currentHP = Math.Min(MaxHP, currentHP + int.Parse(CurrentAmountBox.Text));
                        currentHPnumberlabel.Text = currentHP.ToString();
                    }
                    else if (((CustomButtons.ButtonNoPadding)sender).Text == "-")
                    {
                        currentHP = Math.Min(MaxHP, currentHP - int.Parse(CurrentAmountBox.Text));
                        currentHPnumberlabel.Text = currentHP.ToString();
                    }
                    else //=
                    {
                        currentHP = Math.Min(MaxHP, int.Parse(CurrentAmountBox.Text));
                        currentHPnumberlabel.Text = currentHP.ToString();
                        CurrentAmountBox.Text = "";
                    }
                }
                CurrentAmountBox.Focus();
                CurrentAmountBox.SelectAll();
            }
            else // temp
            {
                if (TempAmountBox.Text != "")
                {

                    if (((CustomButtons.ButtonNoPadding)sender).Text == "-")
                    {
                        tempHP = tempHP - int.Parse(TempAmountBox.Text);
                        temphpnumberslabel.Text = tempHP.ToString();
                        TempAmountBox.Text = "";
                        TempAmountBox.Focus();
                    }
                    else //set 
                    {
                        tempHP = int.Parse(TempAmountBox.Text);
                        temphpnumberslabel.Text = tempHP.ToString();
                        TempAmountBox.Text = "";
                        TempAmountBox.Focus();
                    }
                }
            }
        }


        //enter key pressed on hp boxes
        private void PuAddHPBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(int.TryParse(((TextBox)sender).Text, out int num) && e.KeyChar == (Char)13)
            {
                if ((string)((TextBox)sender).Tag == "max")
                {
                    MaxHP = int.Parse(MaxHPAmountBox.Text);
                    maxHPNumberLabel.Text = MaxHPAmountBox.Text;
                    MaxHPAmountBox.Text = "";
                }
                else if ((string)((TextBox)sender).Tag == "current")
                {
                    currentHP = Math.Min(MaxHP, int.Parse(CurrentAmountBox.Text));
                    currentHPnumberlabel.Text = currentHP.ToString();
                    CurrentAmountBox.Text = "";
                    CurrentAmountBox.Focus();
                    //CurrentAmountBox.SelectAll();
                }
                else if ((string)((TextBox)sender).Tag == "temp")
                {
                    if (TempAmountBox.Text[0] == '-')
                        tempHP = tempHP + int.Parse(TempAmountBox.Text);
                    else
                        tempHP = int.Parse(TempAmountBox.Text);
                    temphpnumberslabel.Text = tempHP.ToString();
                    TempAmountBox.Text = "";
                }
                ((TextBox)sender).Size = new Size(21, 17);
            }
            if (e.KeyChar == (Char)13)
                e.Handled = true;
        }

        //HP buttons
        private void SetMaxHP_Click(object sender, EventArgs e)
        {
            if(int.TryParse(MaxHPAmountBox.Text,out int i))
            MaxHP = int.Parse(MaxHPAmountBox.Text);
            maxHPNumberLabel.Text = MaxHP.ToString();
            MaxHPAmountBox.Focus();
            MaxHPAmountBox.Text = "";
        }

        private void SelectTextOnEnter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        #endregion

        #region Hit Dice

        //use hit dice button
        private void buttonNoPadding1_Click(object sender, EventArgs e)
        {
            HitDiced6NumBox.Value = Math.Min(HitDiced6NumBox.Value, currentHitDice[0]);
            HitDiced8NumBox.Value = Math.Min(HitDiced8NumBox.Value, currentHitDice[1]);
            HitDiced10NumBox.Value = Math.Min(HitDiced10NumBox.Value, currentHitDice[2]);
            HitDiced12NumBox.Value = Math.Min(HitDiced12NumBox.Value, currentHitDice[3]);

            if (HitDiced6NumBox.Value + HitDiced8NumBox.Value + HitDiced10NumBox.Value + HitDiced12NumBox.Value == 0)
            {
                return;
            }

            List<int>[] rolls = new List<int>[4];
            rolls[0] = new List<int>();
            rolls[1] = new List<int>();
            rolls[2] = new List<int>();
            rolls[3] = new List<int>();

            string result = " (";
            int Totalsum = 0;
            int partialSum = 0;
            int lastNum = 0;


            for (int i = 0; i < (int)HitDiced6NumBox.Value; i++)
            {
                rolls[0].Add(Roll.RollSingleDie(6));
                Totalsum += rolls[0][i];
                partialSum += rolls[0][i];
                lastNum++;
            }
            if (partialSum != 0)
                result += HitDiced6NumBox.Value + "d6: " + partialSum + ",  ";
            partialSum = 0;
            for (int i = 0; i < (int)HitDiced8NumBox.Value; i++)
            {
                rolls[1].Add(Roll.RollSingleDie(8));
                Totalsum += rolls[1][i];
                partialSum += rolls[1][i];
                lastNum++;
            }
            if (partialSum != 0)
                result += HitDiced8NumBox.Value + "d8: " + partialSum + ",  ";
            partialSum = 0;
            for (int i = 0; i < (int)HitDiced10NumBox.Value; i++)
            {
                rolls[2].Add(Roll.RollSingleDie(10));
                Totalsum += rolls[2][i];
                partialSum += rolls[2][i];
                lastNum++;
            }
            if (partialSum != 0)
                result += HitDiced10NumBox.Value + "d10: " + partialSum + ",  ";
            partialSum = 0;
            for (int i = 0; i < (int)HitDiced12NumBox.Value; i++)
            {
                rolls[3].Add(Roll.RollSingleDie(12));
                Totalsum += rolls[3][i];
                partialSum += rolls[3][i];
                lastNum++;
            }
            if (partialSum != 0)
                result += HitDiced12NumBox.Value + "d12: " + partialSum + ",  ";

            UpdateOutput("Total Healing: " + Totalsum + result.Substring(0, result.Length - 3) + ")");
            UpdateOutput(Environment.NewLine); UpdateOutput(Environment.NewLine);


            currentHitDice[0] = currentHitDice[0] - (int)HitDiced6NumBox.Value;
            currentHitDice[1] = currentHitDice[1] - (int)HitDiced8NumBox.Value;
            currentHitDice[2] = currentHitDice[2] - (int)HitDiced10NumBox.Value;
            currentHitDice[3] = currentHitDice[3] - (int)HitDiced12NumBox.Value;


            if (autoHealHitDice.Checked)
            {
                currentHP = Math.Min(currentHP + Totalsum, MaxHP);
                currentHPnumberlabel.Text = currentHP.ToString();
            } 

            string s = "";
            for (int i = 0; i < 4; i++)
            {
                if (maxHitDice[i] > 0)
                    s += currentHitDice[i] + "d" + (i * 2 + 6) + ", ";
            }
            currentHitDiceDisplayLabel.Text = "Current: " + s.Substring(0,Math.Max(0, s.Length - 2));
        }




        //set max hit dice
        private void HitDiceSetMaxButton_Click(object sender, EventArgs e)
        {
            if (HitDiced6NumBox.Value + HitDiced8NumBox.Value + HitDiced10NumBox.Value + HitDiced12NumBox.Value > 0)
            {
                maxHitDice[0] = (int)HitDiced6NumBox.Value;
                maxHitDice[1] = (int)HitDiced8NumBox.Value;
                maxHitDice[2] = (int)HitDiced10NumBox.Value;
                maxHitDice[3] = (int)HitDiced12NumBox.Value;

                string s = "";
                for (int i = 0; i < 4; i++)
                {
                    if (maxHitDice[i] > 0)
                        s += maxHitDice[i] + "d" + (i * 2 + 6) + ", ";
                }
                MaxHitDiceDisplayLabel.Text = "Max: " + s.Substring(0, s.Length - 2);

                HitDiced6NumBox.Value = 0;
                HitDiced8NumBox.Value = 0;
                HitDiced10NumBox.Value = 0;
                HitDiced12NumBox.Value = 0;

            }
        }



        //full refill hit dice
        private void HitDiceFullRefillButton_Click(object sender, EventArgs e)
        {
            currentHitDice[0] = maxHitDice[0];
            currentHitDice[1] = maxHitDice[1];
            currentHitDice[2] = maxHitDice[2];
            currentHitDice[3] = maxHitDice[3];
            string s = "";
            for (int i = 0; i < 4; i++)
            {
                if (currentHitDice[i] > 0)
                    s += currentHitDice[i] + "d" + (i * 2 + 6) + ", ";
            }
            currentHitDiceDisplayLabel.Text = "Current: " + s.Substring(0, s.Length - 2);

        }





        //partial refill
        private void HitDicePartialRefillButton_Click(object sender, EventArgs e)
        {
            currentHitDice[0] = Math.Min(currentHitDice[0] + (int)HitDiced6NumBox.Value, maxHitDice[0]);
            currentHitDice[1] = currentHitDice[1] + (int)HitDiced8NumBox.Value;
            currentHitDice[2] = currentHitDice[2] + (int)HitDiced10NumBox.Value;
            currentHitDice[3] = currentHitDice[3] + (int)HitDiced12NumBox.Value;

            HitDiced6NumBox.Value = 0;
            HitDiced8NumBox.Value = 0;
            HitDiced10NumBox.Value = 0;
            HitDiced12NumBox.Value = 0;

            string s = "";
            for (int i = 0; i < 4; i++)
            {
                if (maxHitDice[i] > 0)
                    s += currentHitDice[i] + "d" + (i * 2 + 6) + ", ";
            }
            currentHitDiceDisplayLabel.Text = "Current: " + s.Substring(0, Math.Max(0, s.Length - 2));
        }



        #endregion

        #region AC

        //set total AC box text
        private void ACTextBoxChange(object sender, EventArgs e)
        {
            //remove letters
            string s = ((TextBox)sender).Text;
            string end = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (int.TryParse(s[i].ToString(), out int num) || 
                    (i == 0 && s[i] == '-'))
                {
                    end += s[i];
                }
            }
            ((TextBox)sender).Text = end;
            ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
            ((TextBox)sender).SelectionLength = 0;


            int armor = 0, dex = 0, misc = 0;
            if (int.TryParse(ACArmorBox.Text, out int i1))
                armor = i1;
            if (int.TryParse(ACDexBox.Text, out int i2))
                dex = i2;
            if (int.TryParse(ACMiscBox.Text, out int i3))
                misc = i3;

            ACBox.Text = (armor + dex + misc).ToString();
        }

        #endregion

        private void InitiativeRollButton_Click(object sender, EventArgs e)
        {
            int roll = Roll.RollSingleDie(20);
            string misc = "";
            if(int.TryParse(InitiativeTextBoxNum.Text, out int x) && x != 0)
                misc = ", Misc: " + x;
            int total = roll + statMods[1] + x;

            InitiativeRollDisplay.Text = total.ToString();

            UpdateOutput("Initiative Roll: " + total + "  (Roll: " + roll + ", Dex: " + statMods[1] + misc + ")");
            UpdateOutput(Environment.NewLine); UpdateOutput(Environment.NewLine);
        }

        private void RemoveLetters(object sender, EventArgs e)
        {
            //remove letters
            string s = ((TextBox)sender).Text;
            string end = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (int.TryParse(s[i].ToString(), out int num) ||
                    (i == 0 && s[i] == '-'))
                {
                    end += s[i];
                }
            }
            ((TextBox)sender).Text = end;
            ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
            ((TextBox)sender).SelectionLength = 0;
        }



    }
}
