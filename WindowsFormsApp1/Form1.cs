using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApp1
{


    public partial class Form1 : Form
    {

        #region initialization

        string[] attributeNames;        //strings for each of the attributes in order
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
        List<Feat> feats;
        List<RadioButton> featButtons;
        Feat selectedFeat;
        bool removedLetters = false;
        List<Spell> spells;         //spells loaded from the spells.data file
        int currentSpell;           //selected spell
        List<int> knownSpells;      //list of indexes of spells that the player knows
        List<int> preparedSpells;   //list of indexs of spells that are cureently prepared
        List<RadioButton> spellRadioButtons;    //list of radio buttons currently displayed
        int[] classModifierTypes;   //array of ints that relate each spellcasting class to what attribute they use
        int classSpellType;     //what kind of spellcasting is being used

        string fileName;
        bool saved = true;


        //these are not being used right now
        int[] spellTypes;       //what kind of spellcasting each class is
        int[] spellModTypes;    //which stat to use for spellcasting
        int[][,] spellSlots;     //how many spells slots are per class

        public List<Spell> Spells
        {
            get { return spells; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            weapons = new List<Weapon>();
            currentBonusRolls = new List<Control>();
            mods = new TextBox[23];
            currentHitDice = new int[4];
            maxHitDice = new int[4];
            feats = new List<Feat>();
            featButtons = new List<RadioButton>();

            attributeNames = new string[] { "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma" };

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

            saveButton.Enabled = false;

            classModifierTypes = new int[] { 3, 5, 4, 4, 3, 4, 4, 3, 5, 5, 3 };
            spellTypeDropdown.Text = "Sorcerer";
            spells = new List<Spell>();
            knownSpells = new List<int>();
            preparedSpells = new List<int>();
            spellRadioButtons = new List<RadioButton>();
            LoadSpells();
        }


        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        #region Saving Throws

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
            SetUnsaved();
        }
        private void dexProfBox_CheckedChanged(object sender, EventArgs e)
        {
            Saveproficiencies[1] = BoolToInt(dexProfBox.Checked);
            SetUnsaved();
        }
        private void conProfBox_CheckedChanged(object sender, EventArgs e)
        {
            Saveproficiencies[2] = BoolToInt(conProfBox.Checked);
            SetUnsaved();
        }
        private void intProfBox_CheckedChanged(object sender, EventArgs e)
        {
            Saveproficiencies[3] = BoolToInt(intProfBox.Checked);
            SetUnsaved();
        }
        private void wisProfBox_CheckedChanged(object sender, EventArgs e)
        {
            Saveproficiencies[4] = BoolToInt(wisProfBox.Checked);
            SetUnsaved();
        }
        private void chrProfBox_CheckedChanged(object sender, EventArgs e)
        {
            Saveproficiencies[5] = BoolToInt(chrProfBox.Checked);
            SetUnsaved();
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

        #region Proficiencies

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


        private void ProficienciesChecks_SelectedIndexChanged(object sender, EventArgs e)
        {
            //update proficiencies array
            int ID = ((CheckedListBox)sender).SelectedIndex;

            if (ID != -1)
            {
                //update check boxes
                if (sender == ProficienciesChecks)
                {
                    if (ProficienciesChecks.GetItemChecked(ID))
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
            SetUnsaved();
            //clear highlight from check lists
            ((CheckedListBox)sender).ClearSelected();

        }



        #endregion

        #region weapons

        //new weapon button is clicked
        private void createWeapon_Click(object sender, EventArgs e)
        {
            WeaponCreation weaponCreation = new WeaponCreation();
            weaponCreation.ShowDialog(this);
        }

        public void AddWeapon(Weapon w)
        {
            weapons.Add(w);
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
                SwitchWeaponDisplay(propertiesButtonDisplay, null);
            }
            UpdateWeaponDisplay();
            SetUnsaved();
            //show controls
            foreach (RadioButton button in weaponButtons)
            {
                if (!button.Visible)
                {
                    button.Visible = true;
                    button.Text = w.Name;
                    return;
                }
            }
        }

        public void SetWeapon(Weapon w, int index)
        {
            weapons[index] = w;
            weaponButtons[index].Text = w.Name;
            UpdateWeaponDisplay();
            SetUnsaved();
        }

        private void EditWeapon(object sender, EventArgs e)
        {
            WeaponCreation weaponCreation = new WeaponCreation(weapons[currentWeapon], currentWeapon);
            weaponCreation.ShowDialog(this);
        }


        private void DeleteWeapon(object sender, EventArgs e)
        {
            weaponButtons[weapons.Count - 1].Visible = false;
            for (int i = currentWeapon; i < weapons.Count - 1; i++)
            {
                weaponButtons[i].Text = weaponButtons[i + 1].Text;
            }
            weapons.RemoveAt(currentWeapon);
            //move new weapon button
            newWeaponButton.Location = new Point(newWeaponButton.Location.X, newWeaponButton.Location.Y - 18);
            if (weapons.Count < 8)
                newWeaponButton.Visible = true;
            if (currentWeapon == weapons.Count)
                currentWeapon--;
            if (weapons.Count > 0)
                weaponButtons[currentWeapon].Checked = true;
            UpdateWeaponDisplay();
            SetUnsaved();
            if (weapons.Count == 0)
            {
                //set text boxes to gray
                propertiesButtonDisplay.BackColor = Color.DimGray;
                bonusButtonDisplay.BackColor = Color.DimGray;
                weaponPropTextBox.Visible = false;
                //delete bonus roll controls
                foreach (Control c in currentBonusRolls)
                {
                    Weapon1.Controls.Remove(c);
                }
                //disable buttons
                atkRoll1.Enabled = false;
                dmgRoll2.Enabled = false;
                weapondDelButton.Enabled = false;
                weaponEditButton.Enabled = false;
            }
        }

        //make attack roll with current weapon
        private void atkRoll1_Click(object sender, EventArgs e)
        {
            int ID = currentWeapon;

            int roll = Roll.RollSingleDie(20);

            int modifier;
            if (weapons[ID].Finesse)
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
            foreach (Roll r in weapons[ID].BonusRolls)
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

        //finds active weapon and calls updateWeaponDisplay
        private void UpdateWeapon(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                currentWeapon = int.Parse(((RadioButton)sender).Name.Substring(17)) - 1;
                //update current weapon info
                UpdateWeaponDisplay();
            }
        }

        //updates weapon display tab
        private void UpdateWeaponDisplay()
        {
            if (weapons.Count > 0)
            {
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
            if (((string)weaponPropTextBox.Tag) != "" && weapons.Count > 0)
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

        #endregion

        #region HP


        //remove letters from the +/- box
        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            string s = ((TextBox)sender).Text;
            string end = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (int.TryParse(s[i].ToString(), out int num) ||
                    ((string)((TextBox)sender).Tag != "max" && (
                    (i == 0 && s[i] == '+' && (string)((TextBox)sender).Tag != "temp") || s[i] == '-' && i == 0)))
                {
                    end += s[i];
                }
            }
            ((TextBox)sender).Size = new Size(12 + end.Length * 6, 17);
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
            if (int.TryParse(((TextBox)sender).Text, out int num) && e.KeyChar == (Char)13)
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
            if (int.TryParse(MaxHPAmountBox.Text, out int i))
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
            currentHitDiceDisplayLabel.Text = "Current: " + s.Substring(0, Math.Max(0, s.Length - 2));
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

        #region Feats

        public void AddFeat(Feat f)
        {
            feats.Add(f);
            //add radioButton
            RadioButton newButton = new RadioButton();
            newButton.Width = 350;
            if (f.LimitedUse)
            {
                newButton.Text = "(" + f.UsesLeft + "/" + f.NumUses + ") " + f.Name;
            }
            else
            {
                newButton.Text = f.Name;
            }
            newButton.Location = new Point(132, -20 + feats.Count * 20);
            newButton.BringToFront();
            newButton.CheckedChanged += new EventHandler(SelectFeat);
            newButton.Font = new Font("Arial", 9.25f, FontStyle.Regular);
            newButton.Tag = feats.Count - 1;
            featsPanel.Controls.Add(newButton);
            featButtons.Add(newButton);
            selectedFeat = f;
            newButton.Select();
            SetUnsaved();
            //enable edit/delete buttons
            featEditButton.Enabled = true;
            featDeleteButton.Enabled = true;
        }

        //open form for new feat
        private void newFeatButton_Click(object sender, EventArgs e)
        {
            FeatCreation featCreation = new FeatCreation();
            featCreation.ShowDialog(this);
        }


        private void DeleteFeat(object sender, EventArgs e)
        {
            //find selected feat
            int i = 0, index = 0;
            foreach (RadioButton b in featButtons)
            {
                if (b.Checked)
                    index = i;
                i++;
            }
            feats.RemoveAt(index);
            featsPanel.Controls.Remove(featButtons[index]);
            featButtons.RemoveAt(index);
            //reset tags
            i = 0;
            foreach (RadioButton b in featButtons)
            {
                b.Tag = i;
                i++;
            }
            //move buttons
            for (int n = index; n < featButtons.Count; n++)
            {
                featButtons[n].Location = new Point(featButtons[n].Location.X, featButtons[n].Location.Y - 20);
            }
            if (featButtons.Count > 0)
            {
                //select current feat
                featButtons[Math.Min(index, featButtons.Count - 1)].Checked = true;
            }
            else
            {
                //disable edit/delete/roll buttons
                featEditButton.Enabled = false;
                featDeleteButton.Enabled = false;
                featRollButton.Enabled = false;
            }
            SetUnsaved();
        }

        //set description when selecting a new feat to display
        private void SelectFeat(object sender, EventArgs e)
        {
            Feat feat = feats[int.Parse(((RadioButton)sender).Tag.ToString())];

            //change description text box to checked box
            if (((RadioButton)sender).Checked)
                featDescriptionTextbox.Text = feat.Abilities;
            //check to enable/disable roll button
            if (feat.UseRoll)
            {
                featRollButton.Enabled = true;
                featRollButton.Text = "Roll";
            }
            else
            {
                featRollButton.Text = "Use";
                if (feat.LimitedUse)
                {
                    featRollButton.Enabled = true;
                }
                else
                {
                    featRollButton.Enabled = false;
                }
            }
            //enable/disable roll button if enough uses left
            if (feat.UsesLeft > 0)
            {
                featRollButton.Enabled = true;
            }
            else
            {
                featRollButton.Enabled = false;
            }
            //enable /disable other button
            if (feat.LimitedUse && feat.RefillTypeProperty == RefillType.OTHER)
            {
                otherFeatButton.Enabled = true;
            }
            else
            {
                otherFeatButton.Enabled = false;
            }
        }

        //make the roll for the selected feat
        private void featRoll(object sender, EventArgs e)
        {
            //find selected feat
            int index = 0;
            foreach (RadioButton button in featButtons)
            {
                if (button.Checked)
                {
                    //update button text
                    if (feats[index].LimitedUse)
                    {
                        feats[index].UsesLeft--;
                        //update button text
                        featButtons[index].Text = "(" + feats[index].UsesLeft + "/" + feats[index].NumUses + ") " + feats[index].Name;
                        //disable roll button if 0 uses left
                        if (feats[index].UsesLeft == 0)
                        {
                            featRollButton.Enabled = false;
                        }
                    }
                    else
                    {

                        featButtons[index].Text = feats[index].Name;
                    }
                    //output
                    if (feats[index].UseRoll)
                    {
                        UpdateOutput(feats[index].Name + ": " + feats[index].Roll.RollDice() + " (" + feats[index].Roll.ToString() + ")");
                        UpdateOutput(Environment.NewLine); UpdateOutput(Environment.NewLine);
                    }
                    else
                    {
                        UpdateOutput(feats[index].Name + " used");
                        UpdateOutput(Environment.NewLine); UpdateOutput(Environment.NewLine);
                    }
                    SetUnsaved();
                }
                index++;
            }
        }

        // refill feats that refill on short rest
        private void featRefillButton(object sender, EventArgs e)
        {
            //get type from button tag
            RefillType buttonType = RefillType.LONG;
            if ((string)((CustomButtons.ButtonNoPadding)sender).Tag == "OTHER")
            {
                buttonType = RefillType.OTHER;
            }
            else if ((string)((CustomButtons.ButtonNoPadding)sender).Tag == "SHORT")
            {
                UpdateOutput("You have taken a short rest");
                buttonType = RefillType.SHORT;
            }
            else
            {
                UpdateOutput("You have taken a long rest");
            }

            //loop through feats
            int index = 0;
            foreach (Feat f in feats)
            {
                if (f.LimitedUse)
                {
                    if (f.LimitedUse)
                    {
                        //short and long
                        if ((f.RefillTypeProperty == buttonType && buttonType != RefillType.OTHER) ||
                            (buttonType == RefillType.LONG && f.RefillTypeProperty == RefillType.SHORT))
                        {
                            f.UsesLeft = f.NumUses;
                            featButtons[index].Text = "(" + feats[index].UsesLeft + "/" + feats[index].NumUses + ") " + feats[index].Name;
                        }
                        //other type
                        if (buttonType == RefillType.OTHER && f.RefillTypeProperty == RefillType.OTHER)
                        {
                            if (featButtons[index].Checked)
                            {
                                f.UsesLeft = f.NumUses;
                                featButtons[index].Text = "(" + feats[index].UsesLeft + "/" + feats[index].NumUses + ") " + feats[index].Name;
                                UpdateOutput(feats[index].Name + " has been regained its uses");
                            }
                        }
                    }
                }
                index++;
            }

            //output
            featRollButton.Enabled = true;
            UpdateOutput(Environment.NewLine); UpdateOutput(Environment.NewLine);
            SetUnsaved();
        }


        //open feat creation form to edit selected feat
        private void EditFeat(object sender, EventArgs e)
        {
            //find selected feat
            Feat selectedFeat = null;
            int index = 0;
            foreach (RadioButton button in featButtons)
            {
                if (button.Checked)
                {
                    selectedFeat = feats[index];
                    FeatCreation featCreation = new FeatCreation(selectedFeat, index);
                    featCreation.ShowDialog(this);
                }
                index++;
            }
        }

        public void SetFeat(Feat f, int index)
        {
            feats[index] = f;
            if (f.LimitedUse)
            {
                featButtons[index].Text = "(" + f.UsesLeft + "/" + f.NumUses + ") " + f.Name;
            }
            else
            {
                featButtons[index].Text = f.Name;
            }
            SetUnsaved();
        }


        #endregion

        #region save / load


        //even handler to for when the form is changed
        private void SetUnsaved(object sender, EventArgs e)
        {
            SetUnsaved();
        }

        //internal method, sets saved to false and append name
        private void SetUnsaved()
        {
            if (saved)
                this.Text += " *";
            saved = false;
        }


        private void SaveAsButtonClick(object sender, EventArgs e)
        {
            saveFile();
            saveButton.Enabled = true;
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            saveFile(fileName);
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            //load file and open editor
            OpenFileDialog loadFileDialog = new OpenFileDialog();
            loadFileDialog.Title = "Load a Character";
            loadFileDialog.Filter = "Player Character| *.pc";
            DialogResult result = loadFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                //place info in
                fileName = loadFileDialog.FileName;
                loadFile(fileName);
            }
            saveButton.Enabled = true;
        }

        //click new button
        private void NewCharacter(object sender, EventArgs e)
        {
            NewCharacter();
            saved = true;
            saveButton.Enabled = false;
        }

        private void saveFile(string filePath = "")
        {
            string saveFilePath = "";
            DialogResult result = DialogResult.None;
            SaveFileDialog saveFile = null;
            if (filePath == "")
            {
                saveFile = new SaveFileDialog();
                saveFile.Title = "Save a Character";
                saveFile.Filter = "Player Character| *.pc";
                result = saveFile.ShowDialog();
            }
            if ((result == DialogResult.OK && saveFile.FileName != null) || filePath != "")
            {
                if (filePath == "")
                {
                    saveFilePath = saveFile.FileNames[0];
                    fileName = saveFilePath;
                }
                else
                {
                    saveFilePath = filePath;
                }
                Stream outStream = File.OpenWrite(saveFilePath);
                BinaryWriter output = new BinaryWriter(outStream);
                //save data into file
                output.Write(nameLabel.Text);               //char name
                output.Write(levelTextBox.Text);            //char level/class
                //stats
                output.Write(strDisplayBox.Text);
                output.Write(dexDisplayBox.Text);
                output.Write(conDisplayBox.Text);
                output.Write(intDisplayBox.Text);
                output.Write(wisDisplayBox.Text);
                output.Write(chrDisplayBox.Text);
                //stat proficiencies
                output.Write(strProfBox.Checked);
                output.Write(dexProfBox.Checked);
                output.Write(conProfBox.Checked);
                output.Write(intProfBox.Checked);
                output.Write(wisProfBox.Checked);
                output.Write(chrProfBox.Checked);
                //
                output.Write(profBonusBox.Value);           //proficiency bonus
                output.Write(raceTextBox.Text);             //race 
                output.Write(backgroundtextBox.Text);       //background
                output.Write(AlignmenttextBox.Text);        //alignment
                //proficiencies
                for (int i = 0; i < 23; i++)
                    output.Write(ProficienciesChecks.GetItemChecked(i));    //normal prof
                for (int i = 0; i < 23; i++)
                    output.Write(profCheckshalf.GetItemChecked(i));         //half prof
                for (int i = 0; i < 23; i++)
                    output.Write(profChecksX2.GetItemChecked(i));           //expertise
                //
                output.Write(InitiativeTextBoxNum.Text);                //initiative misc bonus
                //armor class
                output.Write(ACArmorBox.Text);
                output.Write(ACDexBox.Text);
                output.Write(ACMiscBox.Text);
                //hp
                output.Write(currentHPnumberlabel.Text);
                output.Write(temphpnumberslabel.Text);
                output.Write(maxHPNumberLabel.Text);
                //hit dice
                output.Write(autoHealHitDice.Checked);
                output.Write(currentHitDiceDisplayLabel.Text);
                output.Write(MaxHitDiceDisplayLabel.Text);
                output.Write(currentHitDice[0]);                //current hit dice array
                output.Write(currentHitDice[1]);
                output.Write(currentHitDice[2]);
                output.Write(currentHitDice[3]);
                output.Write(maxHitDice[0]);                //max hit dice array
                output.Write(maxHitDice[1]);
                output.Write(maxHitDice[2]);
                output.Write(maxHitDice[3]);
                //weapons
                foreach (Weapon w in weapons)
                {
                    output.Write(-2);               //start marker
                    output.Write(w.Name);              //weapon name
                    output.Write(w.Finesse);           //finesse
                    output.Write(w.Proficient);        //proficient
                    //properties
                    output.Write(w.PropertiesArray.Length);     //how many times to loop
                    foreach (string s in w.PropertiesArray)
                    {
                        output.Write(s);
                    }
                    //damage roll
                    foreach (int i in w.Damage.DieNum)
                    {
                        output.Write(i);                    //dieNums
                    }
                    output.Write(-1);               //end marker
                    foreach (int i in w.Damage.DieAmount)
                    {
                        output.Write(i);                    //dieAmounts
                    }
                    output.Write(-1);               //end marker
                    output.Write(w.Damage.Flat);            //flat amount
                    //bonus rolls
                    foreach (Roll r in w.BonusRolls)
                    {
                        output.Write(-2);                   //start marker
                        output.Write(r.Type);                   //roll type
                        output.Write(r.Name);                   //roll name
                        output.Write(r.Optional);               //optional
                        foreach (int i in r.DieNum)
                        {
                            output.Write(i);                    //dieNums
                        }
                        output.Write(-1);            //end marker
                        foreach (int i in r.DieAmount)
                        {
                            output.Write(i);                    //dieAmounts
                        }
                        output.Write(-1);            //end marker
                        output.Write(r.Flat);            //flat amount
                    }
                    output.Write(-1);            //end marker
                }
                output.Write(-1);            //end marker
                //inventory
                output.Write(InventoryTextBox.Text);
                //feats
                foreach (Feat f in feats)
                {
                    output.Write(-2);       //feat start marker
                    output.Write(f.Name);                   //feat name
                    output.Write(f.Abilities);              //abilities
                    //uses
                    output.Write(f.LimitedUse);             //limited use
                    if (f.LimitedUse)
                    {
                        output.Write(f.NumUses);                //num of uses
                        output.Write(f.UsesLeft);               //uses left
                        output.Write((int)f.RefillTypeProperty);     //refill type  short=1, long, other
                    }
                    //roll
                    output.Write(f.UseRoll);                //uses roll
                    if (f.UseRoll)
                    {
                        foreach (int i in f.Roll.DieNum)
                        {
                            output.Write(i);        //die Nums
                        }
                        output.Write(-1);       //end marker
                        foreach (int i in f.Roll.DieAmount)
                        {
                            output.Write(i);        //die Amounts
                        }
                        output.Write(-1);       //end marker
                        output.Write(f.Roll.Flat);
                    }
                }
                output.Write(-1);       //feat end marker
                //spells known
                output.Write(knownSpells.Count);
                foreach(int i in knownSpells)
                {
                    output.Write(i);
                }

                if (!saved)
                    this.Text = this.Text.Substring(0, this.Text.Length - 2);
                saved = true;
                output.Close();
                MessageBox.Show("File saved successfully", "Save loaded");
            }
        }



        private void loadFile(string filePath)
        {
            //reset form first
            NewCharacter();
            //load characater file
            if (filePath != "")
            {
                Stream inStream = File.OpenRead(filePath);
                BinaryReader reader = new BinaryReader(inStream);
                nameLabel.Text = reader.ReadString();       //char name
                levelTextBox.Text = reader.ReadString();    //char level/class
                //stats
                strDisplayBox.Text = reader.ReadString();
                dexDisplayBox.Text = reader.ReadString();
                conDisplayBox.Text = reader.ReadString();
                intDisplayBox.Text = reader.ReadString();
                wisDisplayBox.Text = reader.ReadString();
                chrDisplayBox.Text = reader.ReadString();
                //stat proficincies
                strProfBox.Checked = reader.ReadBoolean();
                dexProfBox.Checked = reader.ReadBoolean();
                conProfBox.Checked = reader.ReadBoolean();
                intProfBox.Checked = reader.ReadBoolean();
                wisProfBox.Checked = reader.ReadBoolean();
                chrProfBox.Checked = reader.ReadBoolean();
                //
                profBonusBox.Value = reader.ReadDecimal();      //proficiency bonus
                profBonus = (int)profBonusBox.Value;
                raceTextBox.Text = reader.ReadString();         //race
                backgroundtextBox.Text = reader.ReadString();   //background
                AlignmenttextBox.Text = reader.ReadString();    //alignment
                //proficiencies
                for (int i = 0; i < 23; i++)
                    ProficienciesChecks.SetItemChecked(i, reader.ReadBoolean());    //normal prof
                for (int i = 0; i < 23; i++)
                    profCheckshalf.SetItemChecked(i, reader.ReadBoolean());         //half prof
                for (int i = 0; i < 23; i++)
                    profChecksX2.SetItemChecked(i, reader.ReadBoolean());           //expertise
                //
                InitiativeTextBoxNum.Text = reader.ReadString();                    //initiative misc bonus
                //armor class
                ACArmorBox.Text = reader.ReadString();
                ACDexBox.Text = reader.ReadString();
                ACMiscBox.Text = reader.ReadString();
                //hp
                currentHPnumberlabel.Text = reader.ReadString();
                temphpnumberslabel.Text = reader.ReadString();
                maxHPNumberLabel.Text = reader.ReadString();
                //hit dice
                autoHealHitDice.Checked = reader.ReadBoolean();
                currentHitDiceDisplayLabel.Text = reader.ReadString();
                MaxHitDiceDisplayLabel.Text = reader.ReadString();
                currentHitDice[0] = reader.ReadInt32();                 //current hit dice array
                currentHitDice[1] = reader.ReadInt32();
                currentHitDice[2] = reader.ReadInt32();
                currentHitDice[3] = reader.ReadInt32();
                maxHitDice[0] = reader.ReadInt32();                     //max hit dice array
                maxHitDice[1] = reader.ReadInt32();
                maxHitDice[2] = reader.ReadInt32();
                maxHitDice[3] = reader.ReadInt32();
                //weapons
                //create weapons
                int readIn = reader.ReadInt32();
                while (readIn != -1)
                {
                    //weapon stats
                    string name = reader.ReadString();          //read name
                    bool finesse = reader.ReadBoolean();        //finesse
                    bool prof = reader.ReadBoolean();           //proficient
                    //properties
                    int numOfProps = reader.ReadInt32();
                    string[] properties = new string[numOfProps];
                    for (int i = 0; i < numOfProps; i++)
                    {
                        properties[i] = reader.ReadString();
                    }
                    //damage
                    List<int> damageDieNums = new List<int>();
                    List<int> damageDieAmounts = new List<int>();
                    int readIn2 = reader.ReadInt32();
                    while (readIn2 != -1)
                    {
                        damageDieNums.Add(readIn2);      //dieNums
                        readIn2 = reader.ReadInt32();
                    }
                    readIn2 = reader.ReadInt32();
                    while (readIn2 != -1)
                    {
                        damageDieAmounts.Add(readIn2);      //dieAmounts
                        readIn2 = reader.ReadInt32();
                    }
                    int DamageFlat = reader.ReadInt32();
                    Roll damageRoll = new Roll(damageDieNums, damageDieAmounts, DamageFlat);
                    //bonus rolls
                    List<Roll> bonusRolls = new List<Roll>();
                    readIn2 = reader.ReadInt32();
                    while (readIn2 != -1)
                    {
                        List<int> bonusDieNums = new List<int>();
                        List<int> bonusDieAmounts = new List<int>();
                        int rollType = reader.ReadInt32();
                        string bonusName = reader.ReadString();
                        bool optional = reader.ReadBoolean();

                        int readIn3 = reader.ReadInt32();
                        while (readIn3 != -1)
                        {
                            bonusDieNums.Add(readIn3);      //dieNums
                            readIn3 = reader.ReadInt32();
                        }
                        readIn3 = reader.ReadInt32();
                        while (readIn3 != -1)
                        {
                            bonusDieAmounts.Add(readIn3);      //dieAmounts
                            readIn3 = reader.ReadInt32();
                        }
                        int bonusFlat = reader.ReadInt32();

                        Roll r = new Roll(bonusDieNums, bonusDieAmounts, bonusFlat, rollType, bonusName, optional);
                        bonusRolls.Add(r);
                        readIn2 = reader.ReadInt32();
                    }
                    //add weapon
                    AddWeapon(new Weapon(name, bonusRolls, properties, finesse, prof, damageRoll));
                    readIn = reader.ReadInt32();
                }
                //enable buttons
                if (weapons.Count >= 8)
                    newWeaponButton.Visible = false;
                if (weapons.Count >= 1)
                {
                    weaponRadioButton1.Checked = true;
                    weaponPropTextBox.Tag = "properties";
                    propertiesButtonDisplay.Enabled = true;
                    bonusButtonDisplay.Enabled = true;
                    weapondDelButton.Enabled = true;
                    weaponEditButton.Enabled = true;
                    atkRoll1.Enabled = true;
                    dmgRoll2.Enabled = true;
                }
                //inventory
                InventoryTextBox.Text = reader.ReadString();
                //feats
                readIn = reader.ReadInt32();
                while (readIn != -1)
                {
                    string featName = reader.ReadString();          //name
                    string featAbilities = reader.ReadString();     //abilities
                    //uses
                    bool featLimitedUses = reader.ReadBoolean();    //limited uses
                    RefillType featRefillType = 0;
                    int featNumUses = 0;
                    int featUsesLeft = 0;
                    if (featLimitedUses)
                    {
                        featNumUses = reader.ReadInt32();
                        featUsesLeft = reader.ReadInt32();
                        featRefillType = (RefillType)reader.ReadInt32();
                    }
                    //roll
                    bool featUseRoll = reader.ReadBoolean();
                    Roll featRoll = null;
                    if (featUseRoll)
                    {
                        List<int> featDieNums = new List<int>();
                        List<int> featDieAmounts = new List<int>();
                        int readIn2 = reader.ReadInt32();
                        while (readIn2 != -1)
                        {
                            featDieNums.Add(readIn2);
                            readIn2 = reader.ReadInt32();
                        }
                        readIn2 = reader.ReadInt32();
                        while (readIn2 != -1)
                        {
                            featDieAmounts.Add(readIn2);
                            readIn2 = reader.ReadInt32();
                        }
                        int featFlat = reader.ReadInt32();
                        featRoll = new Roll(featDieNums, featDieAmounts, featFlat);
                    }
                    //create feat
                    Feat newFeat = new Feat(featName, featAbilities, featUseRoll, featRoll, featLimitedUses,
                        featRefillType, featNumUses);
                    if (featLimitedUses)
                        newFeat.UsesLeft = featUsesLeft;
                    //add feat
                    AddFeat(newFeat);
                    //update readIn
                    readIn = reader.ReadInt32();
                }
                //known spells
                int numOfSpells = reader.ReadInt32();
                for(int i = 0; i < numOfSpells; i++)
                {
                    int index = reader.ReadInt32();
                    if (index < spells.Count)  //make sure the spell is in your saved list
                        LearnSpell(index);
                }

                saved = true;
                this.Text = nameLabel.Text + " Character sheet";
                fileName = filePath;
                reader.Close();

                UpdateOutput("Character Loaded");
                UpdateOutput(Environment.NewLine); UpdateOutput(Environment.NewLine);
            }
        }


        //reset form
        private void NewCharacter()
        {
            //stats
            strDisplayBox.Text = "10";
            dexDisplayBox.Text = "10";
            conDisplayBox.Text = "10";
            intDisplayBox.Text = "10";
            wisDisplayBox.Text = "10";
            chrDisplayBox.Text = "10";
            strProfBox.Checked = false;
            dexProfBox.Checked = false;
            conProfBox.Checked = false;
            intProfBox.Checked = false;
            wisProfBox.Checked = false;
            chrProfBox.Checked = false;
            profBonusBox.Value = 2;
            SpeedTextBox.Text = "30";
            raceTextBox.Text = "Click to Edit";
            backgroundtextBox.Text = "Click to Edit";
            AlignmenttextBox.Text = "Click to Edit";
            for (int i = 0; i < 23; i++)
                ProficienciesChecks.SetItemChecked(i, false);
            for (int i = 0; i < 23; i++)
                profCheckshalf.SetItemChecked(i, false);
            for (int i = 0; i < 23; i++)
                profChecksX2.SetItemChecked(i, false);
            InitiativeTextBoxNum.Text = "";
            InitiativeRollDisplay.Text = "";
            ACArmorBox.Text = "10";
            ACBox.Text = "10";
            ACDexBox.Text = "0";
            ACMiscBox.Text = "0";
            InventoryTextBox.Text = "";
            currentHPnumberlabel.Text = "0";
            maxHPNumberLabel.Text = "10";
            temphpnumberslabel.Text = "0";
            autoHealHitDice.Checked = false;
            currentHitDiceDisplayLabel.Text = "Current: ";
            MaxHitDiceDisplayLabel.Text = "Max: ";
            HitDiced6NumBox.Value = 0;
            HitDiced8NumBox.Value = 0;
            HitDiced10NumBox.Value = 0;
            HitDiced12NumBox.Value = 0;
            nameLabel.Text = "Character Name";
            levelTextBox.Text = "Level / Class";
            weaponPropTextBox.Text = "";
            //buttons
            foreach (RadioButton b in weaponButtons)
            {
                b.Visible = false;
            }
            foreach (Control c in currentBonusRolls)
            {
                Weapon1.Controls.Remove(c);
            }
            newWeaponButton.Location = new Point(13, 19);
            newWeaponButton.Visible = true;
            weapondDelButton.Enabled = false;
            weaponEditButton.Enabled = false;
            atkRoll1.Enabled = false;
            dmgRoll2.Enabled = false;
            foreach (RadioButton b in featButtons)
            {
                featsPanel.Controls.Remove(b);
            }
            featEditButton.Enabled = false;
            featDeleteButton.Enabled = false;
            featRollButton.Enabled = false;
            otherFeatButton.Enabled = false;
            //reset variables
            weapons = new List<Weapon>();
            currentWeapon = 0;
            profBonus = 2;
            outputList = new List<string>();
            currentBonusRolls = new List<Control>();
            MaxHP = 10;
            currentHP = 0;
            tempHP = 0;
            currentHitDice = new int[4];
            maxHitDice = new int[4];
            feats = new List<Feat>();
            featButtons = new List<RadioButton>();
            selectedFeat = null;
            featDescriptionTextbox.Text = "";
            this.Text = "Character sheet";
        }

        //make sure user has saved before exiting
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved)
            {
                if (MessageBox.Show("There are unsaved changes.  Are you sure you want to exit?", "Unsaved changes", MessageBoxButtons.YesNo) == DialogResult.No)
                    e.Cancel = true;
            }
        }

        #endregion

        #region Misc



        //set internal prof bonus
        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            profBonus = (int)profBonusBox.Value;
            SetUnsaved();
        }

        private void InitiativeRollButton_Click(object sender, EventArgs e)
        {
            int roll = Roll.RollSingleDie(20);
            string misc = "";
            if (int.TryParse(InitiativeTextBoxNum.Text, out int x) && x != 0)
                misc = ", Misc: " + x;
            int total = roll + statMods[1] + x;

            InitiativeRollDisplay.Text = total.ToString();

            UpdateOutput("Initiative Roll: " + total + "  (Roll: " + roll + ", Dex: " + statMods[1] + misc + ")");
            UpdateOutput(Environment.NewLine); UpdateOutput(Environment.NewLine);
        }

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

        private void nameLabel_TextChanged(object sender, EventArgs e)
        {
            saved = false;
            this.Text = nameLabel.Text + " Character sheet *";
        }


        //add a string to the log.  Displays the last 10 lines
        private void UpdateOutput(string s)
        {
            //add s to history
            outputList.Add(s);

            //take the last 10 lines
            string log = "";
            for (int i = Math.Max(0, outputList.Count - 10); i < outputList.Count; i++)
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

        #endregion

        #region helper methods



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
            if (s.Length > 0 && !s.Substring(0, s.Length - 1).Equals(end) && !removedLetters)
                SetUnsaved();
            removedLetters = true;      //"mutex" so that setting the text does not trigger this again
            ((TextBox)sender).Text = end;
            removedLetters = false;
            ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
            ((TextBox)sender).SelectionLength = 0;
        }

        private void buttonNoPadding7_Click(object sender, EventArgs e)
        {

        }

        private void spellListPanel_Paint(object sender, PaintEventArgs e)
        {

        }


        #endregion

        #region Spells

        //resize form1 to show/hide spells tab
        private void ChangeSpellType(object sender, EventArgs e)
        {
            if (((ComboBox)sender).Text == "None")
            {
                spellPanel.Visible = false;
                this.Size = new Size(892, 637);
            }
            else
            {
                spellPanel.Visible = true;
                this.Size = new Size(1156, 637);
            }
            classSpellType = spellTypeDropdown.SelectedIndex;
            this.CenterToScreen();
            addModDisplayLabel.Text = "(" + attributeNames[classModifierTypes[Math.Max(classSpellType - 1, 0)]] + ")";
        }

        private void SpellDescriptionShow(object sender, EventArgs e)
        {
            spellDescriptionTextbox.BringToFront();
            spellDescriptionTextbox.Visible = true;
            spellDesLabel.BackColor = Color.WhiteSmoke;
            spellDescriptionTextbox.Text = spells[currentSpell].Description;
            //set box of description textbox
            spellDescriptionTextbox.Width = 228;
            SizeF MessageSize = spellDescriptionTextbox.CreateGraphics().MeasureString(spellDescriptionTextbox.Text,
                spellDescriptionTextbox.Font, spellDescriptionTextbox.Width, new StringFormat(0));
            spellDescriptionTextbox.Height = (int)(MessageSize.Height * 1) + 10;

        }

        private void SpellDescriptionHide(object sender, EventArgs e)
        {
            spellDescriptionTextbox.Visible = false;
            spellDesLabel.BackColor = Color.Gainsboro;
        }

        //open spell menu to select spell to edit
        private void BrowseSpells(object sender, EventArgs e)
        {
            SpellMenu spellMenu = new SpellMenu(spells);
            spellMenu.ShowDialog(this);
        }

        private void SpellAttackRoll(object sender, EventArgs e)
        {
            string s = "";
            Spell spell = spells[0];
            int roll = Roll.RollSingleDie(20);
            //int mod = 0;
            //if(spellattacktypeDropDown.SelectedIndex > 0)
            int mod = statMods[classModifierTypes[classSpellType - 1]];
            s += spell.Name + " attack roll: ";
            s += (roll + mod + profBonus + MiscBonusnumericUpDown.Value);
            s += "(Roll: " + roll;
            //if (spell.AttackType > 0)
            s += ", " + attributeNames[classModifierTypes[classSpellType - 1]] + ": " + mod;
            s += ", Proficiency Bonus: " + profBonus; 
            if (MiscBonusnumericUpDown.Value != 0)
                s += ", Misc Bonus: " + MiscBonusnumericUpDown.Value;
            s += ")";
            UpdateOutput(s);
            UpdateOutput(Environment.NewLine);
            UpdateOutput(Environment.NewLine);
        }

        //make a roll for the spell
        private void SpellMiscRollButton_Click(object sender, EventArgs e)
        {
            Spell s = spells[currentSpell];
            //find the correct roll from the drop down
            foreach (Roll r in s.Rolls)
            {
                if (r.Name == spellrolldropdown.Text)
                {
                    //add multiplier to roll
                    List<int> totalDieNums = new List<int>();
                    totalDieNums.AddRange(r.DieAmount);
                    List<int> totalDieAmounts = new List<int>();
                    totalDieAmounts.AddRange(r.DieNum);
                    if (r.UsesMul)
                    {
                        if (totalDieNums.Contains(r.Multiplier.DieAmount[0]))
                        {
                            totalDieAmounts[totalDieNums.IndexOf(r.Multiplier.DieAmount[0])] += 
                                r.Multiplier.DieNum[0] * (int)MultipliernumericUpDown.Value; 
                        }
                        else
                        {
                            totalDieNums.Add(r.Multiplier.DieAmount[0]);
                            totalDieAmounts.Add(r.Multiplier.DieNum[0]);
                        }
                    }
                    //create and roll dice
                    Roll newRoll = new Roll(totalDieAmounts, totalDieNums, r.Flat);
                    int roll = newRoll.RollDice();
                    string rollString = newRoll.ToString();
                    if(addModcheckBox.Checked || MiscBonusnumericUpDown.Value != 0)
                        rollString += ": " + roll;
                    //add modifier to roll
                    string modString = "";
                    if(addModcheckBox.Checked)
                    {
                        modString += ", " + attributeNames[classModifierTypes[classSpellType - 1]];
                        modString += ": " + statMods[classModifierTypes[classSpellType - 1]];
                        roll += statMods[classModifierTypes[classSpellType - 1]];
                    }
                    //misc bonus
                    roll += (int)MiscBonusnumericUpDown.Value;
                    string miscString = "";
                    if (MiscBonusnumericUpDown.Value != 0)
                        miscString = ", Misc Bonus: " + MiscBonusnumericUpDown.Value;
                    //output roll
                    UpdateOutput(s.Name + " - " + r.Name + ": " + roll + " (" + rollString + modString + miscString + ")");
                    UpdateOutput(Environment.NewLine); UpdateOutput(Environment.NewLine);
                }
            }
        }

        private void buttonNoPadding5_Click(object sender, EventArgs e)
        {

        }

        //add spell to current spell list
        public void LearnSpell(int index)
        {
            knownSpells.Add(index);
        }

        //select spell level radio button
        private void SelectSpellLevel(object sender, EventArgs e)
        {
            //get selected level and update label
            int level = int.Parse(((RadioButton)sender).Tag.ToString());
            spellListLabel.Text = "Level " + level + " Spells";
            if (level == 0)
                spellListLabel.Text = "Cantrips";
            //clear currently displayed spells
            spellListPanel.Controls.Clear();
            spellRadioButtons.Clear();
            //display spell list
            int spellsDisplayed = 0;
            for(int i = 0; i < knownSpells.Count; i++)
            {
                if(spells[knownSpells[i]].Level == level)
                {
                    //add new control
                    RadioButton newButton = new RadioButton();
                    newButton.Text = spells[knownSpells[i]].Name;
                    newButton.Tag = knownSpells[i];   //adds the spells index in spells to the tag
                    newButton.Location = new Point(5, spellsDisplayed * 20 + 5);
                    newButton.CheckedChanged += SpellSelected;
                    //add to lists
                    spellListPanel.Controls.Add(newButton);
                    spellRadioButtons.Add(newButton);
                    spellsDisplayed++;
                }
            }
            if(spellRadioButtons.Count > 0)
                spellRadioButtons[0].Checked = true;
        }
        
        //when a spell display radio button is checked
        private void SpellSelected(object sender, EventArgs e)
        {
            if(((RadioButton)sender).Checked)
                currentSpell = int.Parse(((RadioButton)sender).Tag.ToString());
            UpdateSpellInfo();
        }



        //set spell info to currently selected spell
        private void UpdateSpellInfo()
        {
            Spell s = spells[currentSpell];
            //spell info
            castTimedisplaylabel.Text = s.CastTime;
            rangeDisplaylabel.Text = s.Range;
            DurationDisplaylabel.Text = s.Duration;
            componentsDisplaylabel.Text = s.Components;
            //spell rolls
            spellrolldropdown.Items.Clear();
            foreach (Roll r in s.Rolls)
            {
                spellrolldropdown.Items.Add(r.Name);
            }
            if (s.Rolls.Count > 0)
                spellrolldropdown.Text = s.Rolls[0].Name;
            //enable/disable attack buttons
            spellAttackButton.Enabled = s.UsesAttack;
            //enable/disable misc roll buttons
            SpellMiscRollButton.Enabled = s.Rolls.Count > 0;
            spellrolldropdown.Enabled = s.Rolls.Count > 0;
        }

        public void SetSpell(Spell s, int index)
        {
            spells[index] = s;
            SaveSpells();
        }

        public void AddSpell(Spell s)
        {
            spells.Add(s);
            SaveSpells();
        }

        //change display label of multiplier
        private void UpdateMultiplierLabel(object sender, EventArgs e)
        {
            //loop through rolls in spell to find selected roll
            foreach (Roll r in spells[currentSpell].Rolls)
            {
                if (r.Name == spellrolldropdown.Text)
                {
                    multiplierDicedisplaylabel.Text = r.Multiplier.DieNum[0] + "d" + r.Multiplier.DieAmount[0];
                }
            }
        }

        //delete spell from list at index
        public void DeleteSpell(int index)
        {
            spells.RemoveAt(index);
            SaveSpells();
        }

        //inputs spells from text file into a list on load
        private void LoadSpells()
        {
            Stream inStream = File.OpenRead("spells.data");
            BinaryReader reader = new BinaryReader(inStream);
            int numOfSpells = reader.ReadInt32();
            for (int i = 0; i < numOfSpells; i++)
            {
                string name = reader.ReadString();
                int lvl = reader.ReadInt32();
                string castTime = reader.ReadString();
                string range = reader.ReadString();
                string duration = reader.ReadString();
                string components = reader.ReadString();
                string description = reader.ReadString();
                bool useAtk = reader.ReadBoolean();
                //rolls
                List<Roll> rolls = new List<Roll>();
                int numOfRolls = reader.ReadInt32();
                for (int i2 = 0; i2 < numOfRolls; i2++)
                {
                    string rollName = reader.ReadString();
                    List<int> rollDieNum = new List<int>();
                    List<int> rollDieAmount = new List<int>();
                    int numOfInts = reader.ReadInt32();
                    for (int i3 = 0; i3 < numOfInts; i3++)
                    {
                        rollDieNum.Add(reader.ReadInt32());
                    }
                    for (int i3 = 0; i3 < numOfInts; i3++)
                    {
                        rollDieAmount.Add(reader.ReadInt32());
                    }
                    int rollFlat = reader.ReadInt32();
                    bool usesMul = reader.ReadBoolean();
                    int mulDieNum = 0;
                    int mulDieAmount = 0;
                    if (usesMul)
                    {
                        mulDieNum = reader.ReadInt32();
                        mulDieAmount = reader.ReadInt32();
                    }
                    Roll r = new Roll(rollDieNum, rollDieAmount, rollFlat, rollName, mulDieNum, mulDieAmount, usesMul);
                    rolls.Add(r);
                }
                spells.Add(new Spell(name, castTime, range, duration, components, rolls, lvl, description, useAtk));
            }
        }


        //writes all spells in list to text file
        private void SaveSpells()
        {
            //open writer
            string saveFilePath = "spells.data";
            Stream outStream = File.OpenWrite(saveFilePath);
            BinaryWriter output = new BinaryWriter(outStream);
            //write spells
            output.Write(spells.Count);
            foreach(Spell s in spells)
            {
                output.Write(s.Name);
                output.Write(s.Level);
                output.Write(s.CastTime);
                output.Write(s.Range);
                output.Write(s.Duration);
                output.Write(s.Components);
                output.Write(s.Description);
                output.Write(s.UsesAttack);
                //rolls
                output.Write(s.Rolls.Count);
                foreach(Roll r in s.Rolls)
                {
                    output.Write(r.Name);
                    output.Write(r.DieNum.Count);
                    foreach(int i in r.DieNum)
                    {
                        output.Write(i);
                    }
                    foreach (int i in r.DieAmount)
                    {
                        output.Write(i);
                    }
                    output.Write(r.Flat); 
                    output.Write(r.UsesMul);
                    if (r.UsesMul)
                    {
                        output.Write(r.Multiplier.DieNum[0]);
                        output.Write(r.Multiplier.DieAmount[0]);
                    }
                }
            }
            //close
            output.Close();
        }


        #endregion

    }
}
