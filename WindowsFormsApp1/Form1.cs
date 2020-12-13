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
using System.Windows.Forms.Integration;



namespace WindowsFormsApp1
{


    public partial class Form1 : Form
    { 
        //to make form look a little nicer
        //protected override void OnPaint(PaintEventArgs e)
        //{
            //ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
        //}
        #region initialization

        string[] attributeNames;        //strings for each of the attributes in order
        bool saveThrowAdv;
        double[] Saveproficiencies = new double[6];
        Label[] mods;
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
        int currentSpell;           //selected spell
        List<int> preparedSpells;   //list of spell id's of spells that are currently prepared
        List<int> alwaysPreparedSpells;   //list of spell id's of spells that are always prepared
        List<RadioButton> spellRadioButtons;    //list of radio buttons currently displayed
        int[] classModifierTypes;   //array of ints that relate each spellcasting class to what attribute they use
        int classSpellType;     //what kind of spellcasting is being used
        List<RadioButton> spellLevelButtons;    // list containing controls for selecting spell levels
        int currentSpellLevel = 1;              // what level spells are currently being shown
        public static int nextSpellId;      //static int that increases each time a spell is made
        List<Label> spellSlotsLabels;   //labels showing spell slots 
        int[,] spellSlots;          // array of (current spell slots, max spell slots)
        bool[] prepareSpells;       //which classes prepare spells
        bool[] usedArcanums;        //true if arcanum has been used
        int[] warlockSpellSlots;      //spell slots of a warlock  [current/max]
        string directory = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\DnD Data"; //where data is saved to
        int[] moneyStore; //holds value while adding/subtracting to money

        string fileName;
        bool saved = true;

        public string[] charInfo { get; set; }  // extra character info textboxes
        public byte[] portrait { get; set; } //image of player to store as byte array
        public List<Spell> Spells { get; private set; }  //spells loaded from the spells.data file
        public List<int> KnownSpells { get; private set; }  //list of spell id's that the player knows



        private void Form1_Load(object sender, EventArgs e)
        {
            //this.AutoScaleMode = AutoScaleMode.None;
            //set dpi scale % in settings to 100% to fix scaling issues

            weapons = new List<Weapon>();
            currentBonusRolls = new List<Control>();
            mods = new Label[23];
            currentHitDice = new int[4];
            maxHitDice = new int[4];
            feats = new List<Feat>();
            featButtons = new List<RadioButton>();


            attributeNames = new string[] { "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma" };

            mods[1] = strModLabel;
            mods[3] = dexmodlabel; mods[4] = dexmodlabel; mods[5] = dexmodlabel;
            mods[7] = intmodlabel; mods[8] = intmodlabel; mods[9] = intmodlabel; mods[10] = intmodlabel; mods[11] = intmodlabel;
            mods[13] = wismodlabel; mods[14] = wismodlabel; mods[15] = wismodlabel; mods[16] = wismodlabel; mods[17] = wismodlabel;
            mods[19] = charmodlabel; mods[20] = charmodlabel; mods[21] = charmodlabel; mods[22] = charmodlabel;

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

            classModifierTypes = new int[] { 3, 5, 4, 4, 3, 5, 4, 3, 5, 5, 3 };
            prepareSpells = new bool[] { true, false, true, true, false, true, false, false, false, false, true };
            preparedSpells = new List<int>();
            usedArcanums = new bool[4];
            Spells = new List<Spell>();
            spellSlots = new int[9, 2];
            KnownSpells = new List<int>();
            alwaysPreparedSpells = new List<int>();
            warlockSpellSlots = new int[] { 0, 0 };
            spellRadioButtons = new List<RadioButton>();
            spellLevelButtons = new List<RadioButton>();
            spellLevelButtons.Add(Level0SpellButton);
            spellLevelButtons.Add(Level1SpellButton);
            spellLevelButtons.Add(Level2SpellButton);
            spellLevelButtons.Add(Level3SpellButton);
            spellLevelButtons.Add(Level4SpellButton);
            spellLevelButtons.Add(Level5SpellButton);
            spellLevelButtons.Add(Level6SpellButton);
            spellLevelButtons.Add(Level7SpellButton);
            spellLevelButtons.Add(Level8SpellButton);
            spellLevelButtons.Add(Level9SpellButton);
            spellSlotsLabels = new List<Label>();
            spellSlotsLabels.Add(lvl1slotslabel);
            spellSlotsLabels.Add(lvl2slotslabel);
            spellSlotsLabels.Add(lvl3slotslabel);
            spellSlotsLabels.Add(lvl4slotslabel);
            spellSlotsLabels.Add(lvl5slotslabel);
            spellSlotsLabels.Add(lvl6slotslabel);
            spellSlotsLabels.Add(lvl7slotslabel);
            spellSlotsLabels.Add(lvl8slotslabel);
            spellSlotsLabels.Add(lvl9slotslabel);
            LoadSpells();
            spellTypeDropdown.Text = "None";

            miscRollDropDown.SelectedIndex = 0;

            charInfo = new string[8];
            for(int i = 0; i < charInfo.Length; i++)
            {
                charInfo[i] = "";
            }


            proficienciesCheckBoxes.attributes = statMods;
            proficienciesCheckBoxes.modifiers = proficiencies;
            proficienciesCheckBoxes.profBonus = profBonus;

            moneyStore = new int[4];

            #region Custom Textboxes Setup
            // sets appreances and events of custom textboxes

            var redBrush = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 135, 20, 20));

            //hp
            var box = (currentHPTextbox.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;
            box.TextChanged += RemoveLetters;
            box.KeyDown += HPTextboxPressEnter;
            box.Tag = "current";
            box.LostFocus += ClearText;

            box = (maxHPTextbox.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;
            box.TextChanged += RemoveLetters;
            box.KeyDown += HPTextboxPressEnter;
            box.Tag = "max";
            box.LostFocus += ClearText;

            box = (tempHPTextbox.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;
            box.TextChanged += RemoveLetters;
            box.KeyDown += HPTextboxPressEnter;
            box.Tag = "temp";
            box.LostFocus += ClearText;

            //name/class
            box = (nameTextBox.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;
            box.Text = "Character Name";
            box.TextChanged += UpdateTitle;
            box.FontSize = 18;
            box.FontWeight = System.Windows.FontWeights.Bold;
            box.Foreground = redBrush;

            box = (levelTextBox.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;
            box.Text = "Level / Class";
            box.TextChanged += SetUnsaved;
            box.FontSize = 12;
            box.FontWeight = System.Windows.FontWeights.Bold;

            box = (raceTextbox.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;
            box.Text = "Race";
            box.TextChanged += SetUnsaved;
            box.FontSize = 10;

            box = (backgroundTextbox.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;
            box.Text = "Background";
            box.TextChanged += SetUnsaved;
            box.FontSize = 10;

            box = (alignmentTextbox.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;
            box.Text = "Alignment";
            box.TextChanged += SetUnsaved;
            box.FontSize = 10;

            //prof check list
            var boxes = proficienciesCheckBoxes.Controls;
            foreach(Control c in boxes)
            {
                if (c is Label)
                    c.TextChanged += SetUnsaved;
            }

            //initiative
            box = getBox(initiativeNumUpDown.Controls.Find("textBox", false)[0]);
            box.TextChanged += SetUnsaved;

            // speed
            box = ((speedTextBox.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox);
            box.TextChanged += SetUnsaved;
            box.FontSize = 18;

            //ac
            getBox(ACarmorTextbox).TextChanged += ACTextBoxChange;
            getBox(DexarmorTextbox).TextChanged += ACTextBoxChange;
            getBox(MiscarmorTextbox).TextChanged += ACTextBoxChange;

            //money
            box = getBox(copperTextbox);
            box.FontSize = 10;
            box.MouseDoubleClick += copperTextbox_DoubleClick;
            box.KeyDown += copperTextbox_KeyPress;
            box.Text = "0";
            box.Tag = "0";
            box.TextChanged += SetUnsaved;

            box = getBox(silverTextbox);
            box.FontSize = 10;
            box.MouseDoubleClick += copperTextbox_DoubleClick;
            box.KeyDown += copperTextbox_KeyPress;
            box.Text = "0";
            box.Tag = "1";
            box.TextChanged += SetUnsaved;

            box = getBox(goldTextbox);
            box.FontSize = 10;
            box.MouseDoubleClick += copperTextbox_DoubleClick;
            box.KeyDown += copperTextbox_KeyPress;
            box.Text = "0";
            box.Tag = "2";
            box.TextChanged += SetUnsaved;

            box = getBox(platTextbox);
            box.FontSize = 10;
            box.MouseDoubleClick += copperTextbox_DoubleClick;
            box.KeyDown += copperTextbox_KeyPress;
            box.Text = "0";
            box.Tag = "3";
            box.TextChanged += SetUnsaved;

            //spell bonuses
            box = getBox(spellAtkBonusnumUpDown.Controls[0]);
            box.TextChanged += UpdateProficiencies;
            box.TextChanged += SetUnsaved;

            box = getBox(spellsavedcnumupdown.Controls[0]);
            box.TextChanged += UpdateProficiencies;
            box.TextChanged += SetUnsaved;

            #endregion
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
            strLabel.Text = (int.Parse(strLabel.Text) + 1).ToString();
        }
        private void strDecreaseButton_Click(object sender, EventArgs e)
        {
            strLabel.Text = (int.Parse(strLabel.Text) - 1).ToString();
        }
        private void dexAddButton_Click(object sender, EventArgs e)
        {
            dexlabel.Text = (int.Parse(dexlabel.Text) + 1).ToString();
        }
        private void dexDecreaseButton_Click(object sender, EventArgs e)
        {
            dexlabel.Text = (int.Parse(dexlabel.Text) - 1).ToString();
        }
        private void conAddButton_Click(object sender, EventArgs e)
        {
            conlabel.Text = (int.Parse(conlabel.Text) + 1).ToString();
        }
        private void conDecreaseButton_Click(object sender, EventArgs e)
        {
            conlabel.Text = (int.Parse(conlabel.Text) - 1).ToString();
        }
        private void intAddButton_Click(object sender, EventArgs e)
        {
            intlabel.Text = (int.Parse(intlabel.Text) + 1).ToString();
        }
        private void intDecreaseButton_Click(object sender, EventArgs e)
        {
            intlabel.Text = (int.Parse(intlabel.Text) - 1).ToString();
        }
        private void wisAddButton_Click(object sender, EventArgs e)
        {
            wislabel.Text = (int.Parse(wislabel.Text) + 1).ToString();
        }
        private void wisDecreaseButton_Click(object sender, EventArgs e)
        {
            wislabel.Text = (int.Parse(wislabel.Text) - 1).ToString();
        }
        private void chrAddButton_Click(object sender, EventArgs e)
        {
            charlabel.Text = (int.Parse(charlabel.Text) + 1).ToString();
        }
        private void chrDecreaseButton_Click(object sender, EventArgs e)
        {
            charlabel.Text = (int.Parse(charlabel.Text) - 1).ToString();
        }

        #endregion

        #region Attribute Modifiers / Proficiencies

        //increase prof Bonus
        private void profUpButton_Click(object sender, EventArgs e)
        {
            profBonus++;
            profBonusLabel.Text = profBonus.ToString();
            proficienciesCheckBoxes.profBonus = profBonus;
            UpdateProficiencies(sender, null);
            SetUnsaved();
        }
        //decrease prof bonus
        private void profDownLabel_Click(object sender, EventArgs e)
        {
            profBonus--;
            profBonusLabel.Text = profBonus.ToString();
            proficienciesCheckBoxes.profBonus = profBonus;
            UpdateProficiencies(sender, null);
            SetUnsaved();
        }

        private void saveAdvantage_CheckedChanged(object sender, EventArgs e)
        {
            //saveThrowAdv = saveAdvantage.Checked;
            //old mehtod, not needed
        }
        private void strProfBox_CheckedChanged(object sender, EventArgs e)
        {
            Saveproficiencies[0] = BoolToInt(strProf.Checked);
            SetUnsaved();
        }
        private void dexProfBox_CheckedChanged(object sender, EventArgs e)
        {
            Saveproficiencies[1] = BoolToInt(dexProf.Checked);
            SetUnsaved();
        }
        private void conProfBox_CheckedChanged(object sender, EventArgs e)
        {
            Saveproficiencies[2] = BoolToInt(conProf.Checked);
            SetUnsaved();
        }
        private void intProfBox_CheckedChanged(object sender, EventArgs e)
        {
            Saveproficiencies[3] = BoolToInt(intProf.Checked);
            SetUnsaved();
        }
        private void wisProfBox_CheckedChanged(object sender, EventArgs e)
        {
            Saveproficiencies[4] = BoolToInt(wisProf.Checked);
            SetUnsaved();
        }
        private void chrProfBox_CheckedChanged(object sender, EventArgs e)
        {
            Saveproficiencies[5] = BoolToInt(charProf.Checked);
            SetUnsaved();
        }
        //change the modifier bonus text
        private void strDisplayBox_TextChanged(object sender, EventArgs e)
        {
            statMods[0] = (int.Parse(strLabel.Text) / 2) - 5;

            //add plus sign if positive
            string sign = "";
            if (statMods[0] > 0)
                sign = "+";

            strModLabel.Text = sign + statMods[0];
            UpdateProficiencies(sender, null);
            SetUnsaved();
        }
        private void dexModLabel_TextChanged(object sender, EventArgs e)
        {
            statMods[1] = (int.Parse(dexlabel.Text) / 2) - 5;

            //add plus sign if positive
            string sign = "";
            if (statMods[1] > 0)
                sign = "+";

            dexmodlabel.Text = sign + statMods[1];
            UpdateProficiencies(sender, null);
            SetUnsaved();
        }
        private void conModLabel_TextChanged(object sender, EventArgs e)
        {
            statMods[2] = (int.Parse(conlabel.Text) / 2) - 5;

            //add plus sign if positive
            string sign = "";
            if (statMods[2] > 0)
                sign = "+";

            conmodlabel.Text = sign + statMods[2];
            UpdateProficiencies(sender, null);
            SetUnsaved();
        }
        private void intModLabel_TextChanged(object sender, EventArgs e)
        {
            statMods[3] = (int.Parse(intlabel.Text) / 2) - 5;

            //add plus sign if positive
            string sign = "";
            if (statMods[3] > 0)
                sign = "+";

            intmodlabel.Text = sign + statMods[3];
            UpdateProficiencies(sender, null);
            SetUnsaved();
        }
        private void wisModLabel_TextChanged(object sender, EventArgs e)
        {
            statMods[4] = (int.Parse(wislabel.Text) / 2) - 5;

            //add plus sign if positive
            string sign = "";
            if (statMods[4] > 0)
                sign = "+";

            wismodlabel.Text = sign + statMods[4];
            UpdateProficiencies(sender, null);
            SetUnsaved();
        }
        private void chrModLabel_TextChanged(object sender, EventArgs e)
        {
            statMods[5] = (int.Parse(charlabel.Text) / 2) - 5;

            //add plus sign if positive
            string sign = "";
            if (statMods[5] > 0)
                sign = "+";

            charmodlabel.Text = sign + statMods[5];
            UpdateProficiencies(sender, null);
            SetUnsaved();
        }

        #endregion

        #region Proficiencies

        // rolls an ability check
        private void rollEditButton_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(((Button)sender).Name.Substring(((Button)sender).Name.Length - 2));
            int roll = Roll.RollSingleDie(20);

            int prof = (int)(proficiencies[ID] * profBonus);
            UpdateOutput(((Button)sender).Tag + " ability check: " + (roll + prof + int.Parse(mods[ID].Text)) +
                " (Roll: " + roll + ", Proficiency Bonus: " + prof + ", " +
                "Ability Modifier: " + int.Parse(mods[ID].Text) + ")");
            UpdateOutput(Environment.NewLine); UpdateOutput(Environment.NewLine);
        }

        //update each of the text on the prof roll buttons
        private void UpdateProficiencies(object sender, EventArgs e)
        {
            proficienciesCheckBoxes.CalculateModifiers(proficiencies);

            //set spell dc/atk bonus boxes
            if (classSpellType > 0)
            {
                spellattackBonusDisplayBox.Text = "+" + (profBonus + spellAtkBonusnumUpDown.Value + statMods[classModifierTypes[classSpellType - 1]]);
                spellSaveDCdisplayLabel.Text = (8 + profBonus + spellsavedcnumupdown.Value + statMods[classModifierTypes[classSpellType - 1]]).ToString();
            }
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
                weapondDelButton.Enabled = true;
                weaponEditButton.Enabled = true;
                atkRoll1.Enabled = true;
                dmgRoll2.Enabled = true;
                UpdateWeaponDisplay();
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
            string message = $"Are you sure you want to delete {weapons[currentWeapon].Name}?";
            DialogResult result = MessageBox.Show(message, "Delete Weapon", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
                return;

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

                //show properties
                weaponPropTextBox.Text = weapons[currentWeapon].Properties;

                //delete bonus roll controls
                foreach (Control c in currentBonusRolls)
                {
                    Weapon1.Controls.Remove(c);
                }
                for(int i = 0; i < Weapon1.Controls.Count; i++)
                {
                    if (Weapon1.Controls[i].Tag?.ToString() == "temp")
                    {
                        Weapon1.Controls.Remove(Weapon1.Controls[i]);
                        i--;
                    }
                }
                currentBonusRolls.Clear();
                //show bonus rolls
                int rollNum = weapons[currentWeapon].BonusRolls.Count - 1;
                foreach (Roll r in weapons[currentWeapon].BonusRolls)
                {
                    if (r.Optional)
                    {
                        CheckBox newLabel = new CheckBox();
                        newLabel.Location = new Point(85, 198 + rollNum * 18);
                        newLabel.Checked =
                            weapons[currentWeapon].BonusRolls[weapons[currentWeapon].BonusRolls.Count - rollNum - 1].CurrentState;
                        newLabel.Text = r.Name;
                        if (r.Type == 1 || r.Type == 3)
                        {
                            newLabel.Location = new Point(105, 198 + rollNum * 18);
                            PictureBox pb = new PictureBox();
                            pb.Location = new Point(85, 200 + rollNum * 18);
                            pb.Size = new Size(18, 18);
                            pb.BackgroundImage = atkPictureBox.Image;
                            pb.BackgroundImageLayout = ImageLayout.Stretch;
                            pb.Tag = "temp";
                            Weapon1.Controls.Add(pb);
                        }
                        if (r.Type == 2)
                        {
                            newLabel.Location = new Point(105, 198 + rollNum * 18);
                            PictureBox pb = new PictureBox();
                            pb.Location = new Point(85, 200 + rollNum * 18);
                            pb.Size = new Size(18, 18);
                            pb.BackgroundImage = dmgPictureBox.Image;
                            pb.BackgroundImageLayout = ImageLayout.Stretch;
                            pb.Tag = "temp";
                            Weapon1.Controls.Add(pb);
                        }
                        if (r.Type == 3)
                        {
                            newLabel.Location = new Point(125, 198 + rollNum * 18);
                            PictureBox pb = new PictureBox();
                            pb.Location = new Point(105, 200 + rollNum * 18);
                            pb.Size = new Size(18, 18);
                            pb.BackgroundImage = dmgPictureBox.Image;
                            pb.BackgroundImageLayout = ImageLayout.Stretch;
                            pb.Tag = "temp";
                            Weapon1.Controls.Add(pb);
                        }
                        newLabel.BringToFront();
                        newLabel.CheckedChanged += new EventHandler(BonusCheckChanged);
                        newLabel.Font = new Font("Arial", 9.25f, FontStyle.Regular);
                        Weapon1.Controls.Add(newLabel);
                        currentBonusRolls.Add(newLabel);
                    }
                    else
                    {
                        Label newLabel = new Label();
                        newLabel.Location = new Point(85, 198 + rollNum * 18);
                        newLabel.Text = r.Name;
                        if (r.Type == 1 || r.Type == 3)
                        {
                            newLabel.Location = new Point(105, 198 + rollNum * 18);
                            PictureBox pb = new PictureBox();
                            pb.Location = new Point(85, 200 + rollNum * 18);
                            pb.Size = new Size(18, 18);
                            pb.BackgroundImage = atkPictureBox.Image;
                            pb.BackgroundImageLayout = ImageLayout.Stretch;
                            pb.Tag = "temp";
                            Weapon1.Controls.Add(pb);
                        }
                        if (r.Type == 2)
                        {
                            newLabel.Location = new Point(105, 198 + rollNum * 18);
                            PictureBox pb = new PictureBox();
                            pb.Location = new Point(85, 200 + rollNum * 18);
                            pb.Size = new Size(18, 18);
                            pb.BackgroundImage = dmgPictureBox.Image;
                            pb.BackgroundImageLayout = ImageLayout.Stretch;
                            pb.Tag = "temp";
                            Weapon1.Controls.Add(pb);
                        }
                        if (r.Type == 3)
                        {
                            newLabel.Location = new Point(125, 198 + rollNum * 18);
                            PictureBox pb = new PictureBox();
                            pb.Location = new Point(105, 200 + rollNum * 18);
                            pb.Size = new Size(18, 18);
                            pb.BackgroundImage = dmgPictureBox.Image;
                            pb.BackgroundImageLayout = ImageLayout.Stretch;
                            pb.Tag = "temp";
                            Weapon1.Controls.Add(pb);
                        }
                        newLabel.Font = new Font("Arial", 9.25f, FontStyle.Regular);
                        newLabel.BringToFront();
                        Weapon1.Controls.Add(newLabel);
                        currentBonusRolls.Add(newLabel);
                    }
                    rollNum--;


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

        // press enter key to submit hp changes
        private void HPTextboxPressEnter(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var box = sender as System.Windows.Controls.TextBox;
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                if (box.Text.Length == 0)
                    return;

                if (box.Text[0] == '+' || box.Text[0] == '-')
                {
                    if (box.Text.Length == 1)
                        return;

                    // add/subtract value
                    if (box.Tag.ToString() == "current")
                    {
                        currentHPlabel.Text = (int.Parse(box.Text) + int.Parse(currentHPlabel.Text)).ToString();
                    }
                    else if (box.Tag.ToString() == "max")
                    {
                        MaxHPlabel.Text = (int.Parse(box.Text) + int.Parse(MaxHPlabel.Text)).ToString();
                    }
                    else
                    {
                        tempHPlabel.Text = (int.Parse(box.Text) + int.Parse(tempHPlabel.Text)).ToString();
                    }
                }
                else
                {
                    // set value
                    if (box.Tag.ToString() == "current")
                    {
                        currentHPlabel.Text = box.Text;
                    }
                    else if (box.Tag.ToString() == "max")
                    {
                        MaxHPlabel.Text = box.Text;
                    }
                    else
                    {
                        tempHPlabel.Text = box.Text;
                    }
                }

                box.SelectAll();
                // stop ding sound
                e.Handled = true;

            }
        }

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

        private void SelectTextOnEnter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        #endregion

        #region Hit Dice

        //use hit dice button
        private void buttonNoPadding1_Click(object sender, EventArgs e)
        {
            d6NumUpDown.Value = Math.Min(d6NumUpDown.Value, currentHitDice[0]);
            d8NumUpDown.Value = Math.Min(d8NumUpDown.Value, currentHitDice[1]);
            d10NumUpDown.Value = Math.Min(d10NumUpDown.Value, currentHitDice[2]);
            d12NumUpDown.Value = Math.Min(d12NumUpDown.Value, currentHitDice[3]);

            if (d6NumUpDown.Value + d8NumUpDown.Value + d10NumUpDown.Value + d12NumUpDown.Value == 0)
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


            for (int i = 0; i < (int)d6NumUpDown.Value; i++)
            {
                rolls[0].Add(Roll.RollSingleDie(6));
                Totalsum += rolls[0][i];
                partialSum += rolls[0][i];
                lastNum++;
            }
            if (partialSum != 0)
                result += d6NumUpDown.Value + "d6: " + partialSum + ",  ";
            partialSum = 0;
            for (int i = 0; i < (int)d8NumUpDown.Value; i++)
            {
                rolls[1].Add(Roll.RollSingleDie(8));
                Totalsum += rolls[1][i];
                partialSum += rolls[1][i];
                lastNum++;
            }
            if (partialSum != 0)
                result += d8NumUpDown.Value + "d8: " + partialSum + ",  ";
            partialSum = 0;
            for (int i = 0; i < (int)d10NumUpDown.Value; i++)
            {
                rolls[2].Add(Roll.RollSingleDie(10));
                Totalsum += rolls[2][i];
                partialSum += rolls[2][i];
                lastNum++;
            }
            if (partialSum != 0)
                result += d10NumUpDown.Value + "d10: " + partialSum + ",  ";
            partialSum = 0;
            for (int i = 0; i < (int)d12NumUpDown.Value; i++)
            {
                rolls[3].Add(Roll.RollSingleDie(12));
                Totalsum += rolls[3][i];
                partialSum += rolls[3][i];
                lastNum++;
            }
            if (partialSum != 0)
                result += d12NumUpDown.Value + "d12: " + partialSum + ",  ";

            UpdateOutput("Total Healing: " + Totalsum + result.Substring(0, result.Length - 3) + ")");
            UpdateOutput(Environment.NewLine); UpdateOutput(Environment.NewLine);


            currentHitDice[0] = currentHitDice[0] - (int)d6NumUpDown.Value;
            currentHitDice[1] = currentHitDice[1] - (int)d8NumUpDown.Value;
            currentHitDice[2] = currentHitDice[2] - (int)d10NumUpDown.Value;
            currentHitDice[3] = currentHitDice[3] - (int)d12NumUpDown.Value;


            if (autoHealHitDice.Checked)
            {
                currentHP = Math.Min(currentHP + Totalsum, MaxHP);
                currentHPlabel.Text = currentHP.ToString();
            }

            string s = "";
            for (int i = 0; i < 4; i++)
            {
                if (maxHitDice[i] > 0)
                    s += currentHitDice[i] + "d" + (i * 2 + 6) + ", ";
            }
            currentHitDiceDisplayLabel.Text = "Current: " + s.Substring(0, Math.Max(0, s.Length - 2));
            SetUnsaved();
        }




        //set max hit dice
        private void HitDiceSetMaxButton_Click(object sender, EventArgs e)
        {
            if (d6NumUpDown.Value + d8NumUpDown.Value + d10NumUpDown.Value + d12NumUpDown.Value > 0)
            {
                maxHitDice[0] = (int)d6NumUpDown.Value;
                maxHitDice[1] = (int)d8NumUpDown.Value;
                maxHitDice[2] = (int)d10NumUpDown.Value;
                maxHitDice[3] = (int)d12NumUpDown.Value;

                string s = "";
                for (int i = 0; i < 4; i++)
                {
                    if (maxHitDice[i] > 0)
                        s += maxHitDice[i] + "d" + (i * 2 + 6) + ", ";
                }
                MaxHitDiceDisplayLabel.Text = "Max: " + s.Substring(0, s.Length - 2);

                d6NumUpDown.Value = 0;
                d8NumUpDown.Value = 0;
                d10NumUpDown.Value = 0;
                d12NumUpDown.Value = 0;

                SetUnsaved();
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
            SetUnsaved();
        }





        //partial refill
        private void HitDicePartialRefillButton_Click(object sender, EventArgs e)
        {
            currentHitDice[0] = Math.Min(currentHitDice[0] + d6NumUpDown.Value, maxHitDice[0]);
            currentHitDice[1] = Math.Min(currentHitDice[1] + d8NumUpDown.Value, maxHitDice[1]);
            currentHitDice[2] = Math.Min(currentHitDice[2] + d10NumUpDown.Value, maxHitDice[2]);
            currentHitDice[3] = Math.Min(currentHitDice[3] + d12NumUpDown.Value, maxHitDice[3]);

            d6NumUpDown.Value = 0;
            d8NumUpDown.Value = 0;
            d10NumUpDown.Value = 0;
            d12NumUpDown.Value = 0;

            string s = "";
            for (int i = 0; i < 4; i++)
            {
                if (maxHitDice[i] > 0)
                    s += currentHitDice[i] + "d" + (i * 2 + 6) + ", ";
            }
            currentHitDiceDisplayLabel.Text = "Current: " + s.Substring(0, Math.Max(0, s.Length - 2));
            SetUnsaved();
        }



        #endregion

        #region AC

        //set total AC box text
        private void ACTextBoxChange(object sender, EventArgs e)
        {
            var box = sender as System.Windows.Controls.TextBox;
            //remove letters
            string s = box.Text;
            string end = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (int.TryParse(s[i].ToString(), out int num) ||
                    (i == 0 && s[i] == '-'))
                {
                    end += s[i];
                }
            }
            box.Text = end;
            box.SelectionStart = box.Text.Length;
            box.SelectionLength = 0;

            //calculate
            int armor = 0, dex = 0, misc = 0;
            if (int.TryParse(getBox(ACarmorTextbox).Text, out int i1))
                armor = i1;
            if (int.TryParse(getBox(DexarmorTextbox).Text, out int i2))
                dex = i2;
            if (int.TryParse(getBox(MiscarmorTextbox).Text, out int i3))
                misc = i3;

            ACDisplayLabel.Text = (armor + dex + misc).ToString();
            SetUnsaved();
        }


        #endregion

        #region Feats

        public void AddFeat(Feat f)
        {
            feats.Add(f);
            //add radioButton
            CustomControls.CustomRadioButton newButton = new CustomControls.CustomRadioButton();
            newButton.Width = 350;
            newButton.Height = 18;
            if (f.LimitedUse)
            {
                newButton.Text = "(" + f.UsesLeft + "/" + f.NumUses + ") " + f.Name;
            }
            else
            {
                newButton.Text = f.Name;
            }
            newButton.Location = new Point(0, -20 + feats.Count * 20);
            newButton.BringToFront();
            newButton.CheckedChanged += new EventHandler(SelectFeat);
            newButton.Font = new Font("Arial", 8.25f, FontStyle.Regular);
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
            foreach (CustomControls.CustomRadioButton b in featButtons)
            {
                if (b.Checked)
                    index = i;
                i++;
            }
            //confirmation
            string message = $"Are you sure you want to delete {feats[index].Name}?";
            DialogResult result = MessageBox.Show(message, "Delete Feat", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
                return;
            //delete
            feats.RemoveAt(index);
            featsPanel.Controls.Remove(featButtons[index]);
            featButtons.RemoveAt(index);
            //reset tags
            i = 0;
            foreach (CustomControls.CustomRadioButton b in featButtons)
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
            Feat feat = feats[int.Parse(((CustomControls.CustomRadioButton)sender).Tag.ToString())];

            //change description text box to checked box
            if (((CustomControls.CustomRadioButton)sender).Checked)
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
            foreach (CustomControls.CustomRadioButton button in featButtons)
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
        public void SetUnsaved()
        {
            if (saved)
                this.Text += " *";
            saved = false;
        }

        private void UpdateTitle(object sender, EventArgs e)
        {
            this.Text = nameTextBox.Text + " *";
            saved = false;
        }

        private void SaveAsButtonClick(object sender, EventArgs e)
        {
            LoadCharMenu menu = new LoadCharMenu(1);
            menu.ShowDialog(this);
            saveButton.Enabled = true;
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            saveFile(fileName);
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadCharMenu menu = new LoadCharMenu(2);
            menu.ShowDialog(this);
            //saveButton.Enabled = true;
            //SelectSpellLevel(spellLevelButtons[currentSpellLevel], null);
        }

        //click new button
        private void NewCharacter(object sender, EventArgs e)
        {
            if (!saved)
            {
                if (MessageBox.Show("There are unsaved changes.  Are you sure you want to create a new character?", "Unsaved changes", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }
            NewCharacter();
            saved = true;
            saveButton.Enabled = false;
        }

        public void saveFile(string filePath = "")
        {
            string saveFilePath;
            {
                saveFilePath = filePath;
                Stream outStream = File.OpenWrite(saveFilePath);
                BinaryWriter output = new BinaryWriter(outStream);
                //save data into file
                output.Write(getBox(nameTextBox).Text);               //char name
                output.Write(levelTextBox.Text);            //char level/class
                //stats
                output.Write(strLabel.Text);
                output.Write(dexlabel.Text);
                output.Write(conlabel.Text);
                output.Write(intlabel.Text);
                output.Write(wislabel.Text);
                output.Write(charlabel.Text);
                //stat proficiencies
                output.Write(strProf.Checked);
                output.Write(dexProf.Checked);
                output.Write(conProf.Checked);
                output.Write(intProf.Checked);
                output.Write(wisProf.Checked);
                output.Write(charProf.Checked);
                //
                output.Write(profBonus);           //proficiency bonus
                output.Write(getBox(raceTextbox).Text);             //race 
                output.Write(getBox(backgroundTextbox).Text);       //background
                output.Write(getBox(alignmentTextbox).Text);        //alignment
                output.Write(getBox(speedTextBox).Text);  //speed
                //proficiencies
                foreach(CustomControls.ProficiencyCheckBox c in proficienciesCheckBoxes.checks1)
                    output.Write(c.Checked);
                foreach (CustomControls.ProficiencyCheckBox c in proficienciesCheckBoxes.checks2)
                    output.Write(c.Checked);
                foreach (CustomControls.ProficiencyCheckBox c in proficienciesCheckBoxes.halfChecks)
                    output.Write(c.Checked);
                //Initiative
                output.Write(initiativeNumUpDown.Value.ToString());     //misc bonus
                output.Write(initiativeLabel.Text);                     
                output.Write(initiativeAdvCheckbox.Checked);
                //armor class
                output.Write(getBox(ACarmorTextbox).Text);
                output.Write(getBox(DexarmorTextbox).Text);
                output.Write(getBox(MiscarmorTextbox).Text);
                //hp
                output.Write(currentHPlabel.Text);
                output.Write(tempHPlabel.Text);
                output.Write(MaxHPlabel.Text);
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
                    output.Write(w.Properties);     //properties
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
                //spellcasting type
                output.Write(spellTypeDropdown.Text);

                if (spellTypeDropdown.Text != "None")
                {
                    //spells known
                    output.Write(KnownSpells.Count);
                    foreach (int i in KnownSpells)
                    {
                        output.Write(i);
                    }
                    //prepared spells
                    output.Write(classSpellType > 0 && prepareSpells[classSpellType - 1]);
                    if (classSpellType > 0 && prepareSpells[classSpellType - 1])
                    {
                        output.Write(preparedSpells.Count);
                        foreach (int i in preparedSpells)
                        {
                            output.Write(i);
                        }
                        output.Write(alwaysPreparedSpells.Count);
                        foreach (int i in alwaysPreparedSpells)
                        {
                            output.Write(i);
                        }
                        output.Write((int)preparednumericUpDown.Value);
                        output.Write(spellsPreparedAmountlabel.Text);
                    }
                    //spell slots
                    if (spellTypeDropdown.Text == "Warlock")
                    {
                        output.Write(warlockSpellSlots[0]); //min
                        output.Write(warlockSpellSlots[1]); //max
                        output.Write((int)warlockSpellLevelnumericUpDown.Value); //slot level
                        output.Write(Arcanum6checkBox.Checked);
                        output.Write(Arcanum7checkBox.Checked);
                        output.Write(Arcanum8checkBox.Checked);
                        output.Write(Arcanum9checkBox.Checked);
                    }
                    else
                    {
                        for(int i = 0; i < 9; i++)
                        {
                            output.Write(spellSlots[i, 0]); //current
                            output.Write(spellSlots[i, 1]); //max
                        }
                    }
                    //misc bonuses
                    output.Write((int)spellAtkBonusnumUpDown.Value);
                    output.Write((int)spellsavedcnumupdown.Value);
                }
                //char info
                if (portrait == null)
                {
                    output.Write(-1);
                }
                else
                {
                    output.Write(portrait.Length);
                    output.Write(portrait);
                }
                foreach (string s in charInfo)
                {
                    output.Write(s);
                }
                //money
                output.Write(getBox(copperTextbox).Text);
                output.Write(getBox(silverTextbox).Text);
                output.Write(getBox(goldTextbox).Text);
                output.Write(getBox(platTextbox).Text);
                //death saves
                output.Write(DeathPass1.Visible);
                output.Write(DeathPass2.Visible);
                output.Write(DeathPass3.Visible);
                output.Write(DeathFail1.Visible);
                output.Write(DeathFail2.Visible);
                output.Write(DeathFail3.Visible);

                saveButton.Enabled = true;
                if (!saved)
                    this.Text = this.Text.Substring(0, this.Text.Length - 2);
                saved = true;
                output.Close();
                MessageBox.Show("Character saved successfully", "Saved Character");
            }
        }



        public void loadFile(string filePath)
        {
            //reset form first
            NewCharacter();
            //load characater file
            if (filePath != "")
            {
                Stream inStream = File.OpenRead(filePath);
                BinaryReader reader = new BinaryReader(inStream);
                getBox(nameTextBox).Text = reader.ReadString();       //char name
                levelTextBox.Text = reader.ReadString();    //char level/class
                //stats
                strLabel.Text = reader.ReadString();
                dexlabel.Text = reader.ReadString();
                conlabel.Text = reader.ReadString();
                intlabel.Text = reader.ReadString();
                wislabel.Text = reader.ReadString();
                charlabel.Text = reader.ReadString();
                //stat proficincies
                strProf.Checked = reader.ReadBoolean();
                dexProf.Checked = reader.ReadBoolean();
                conProf.Checked = reader.ReadBoolean();
                intProf.Checked = reader.ReadBoolean();
                wisProf.Checked = reader.ReadBoolean();
                charProf.Checked = reader.ReadBoolean();
                //
                profBonus = reader.ReadInt32();      //proficiency bonus
                profBonusLabel.Text = profBonus.ToString();
                getBox(raceTextbox).Text = reader.ReadString();         //race
                getBox(backgroundTextbox).Text = reader.ReadString();   //background
                getBox(alignmentTextbox).Text = reader.ReadString();    //alignment
                getBox(speedTextBox).Text = reader.ReadString();
                //proficiencies
                foreach (CustomControls.ProficiencyCheckBox c in proficienciesCheckBoxes.checks1)
                    c.Checked = reader.ReadBoolean();
                foreach (CustomControls.ProficiencyCheckBox c in proficienciesCheckBoxes.checks2)
                    c.Checked = reader.ReadBoolean();
                foreach (CustomControls.ProficiencyCheckBox c in proficienciesCheckBoxes.halfChecks)
                    c.Checked = reader.ReadBoolean();
                //Initiative
                initiativeNumUpDown.Value = int.Parse(reader.ReadString());     //misc bonus
                initiativeLabel.Text = reader.ReadString();
                initiativeAdvCheckbox.Checked = reader.ReadBoolean();
                //armor class
                getBox(ACarmorTextbox).Text = reader.ReadString();
                getBox(DexarmorTextbox).Text = reader.ReadString();
                getBox(MiscarmorTextbox).Text = reader.ReadString();
                //hp
                currentHP = int.Parse(reader.ReadString());
                currentHPlabel.Text = currentHP.ToString();
                tempHP = int.Parse(reader.ReadString());
                tempHPlabel.Text = tempHP.ToString();
                MaxHP = int.Parse(reader.ReadString());
                MaxHPlabel.Text = MaxHP.ToString();
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
                    string properties = reader.ReadString();    //props
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
                //spellcasting type
                spellTypeDropdown.Text = reader.ReadString();
                if (spellTypeDropdown.Text != "None")
                {
                    //known spells
                    int numOfSpells = reader.ReadInt32();
                    for (int i = 0; i < numOfSpells; i++)
                    {
                        int id = reader.ReadInt32();
                        if (FindSpellFromID(id) != null)  //make sure the spell is in your saved list
                            LearnSpell(id);
                    }
                    //prepared spells
                    if (reader.ReadBoolean())
                    {
                        int numOfPrepared = reader.ReadInt32();
                        for (int i = 0; i < numOfPrepared; i++)
                        {
                            preparedSpells.Add(reader.ReadInt32());
                        }
                        int numOfAlwaysPrepared = reader.ReadInt32();
                        for (int i = 0; i < numOfAlwaysPrepared; i++)
                        {
                            alwaysPreparedSpells.Add(reader.ReadInt32());
                        }
                        preparednumericUpDown.Value = reader.ReadInt32();
                        spellsPreparedAmountlabel.Text = reader.ReadString();
                    }
                    //spell slots
                    if (spellTypeDropdown.Text == "Warlock")
                    {
                        warlockSpellSlots[0] = reader.ReadInt32();
                        warlockSpellSlots[1] = reader.ReadInt32();
                        warlockSLotsDisplayLabel.Text = $"{warlockSpellSlots[0]}/{warlockSpellSlots[1]}";
                        warlockSpellLevelnumericUpDown.Value = reader.ReadInt32();
                        Arcanum6checkBox.Checked = reader.ReadBoolean();
                        Arcanum7checkBox.Checked = reader.ReadBoolean();
                        Arcanum8checkBox.Checked = reader.ReadBoolean();
                        Arcanum9checkBox.Checked = reader.ReadBoolean();
                    }
                    else
                    {
                        for(int i = 0; i < 9; i++)
                        {
                            spellSlots[i, 0] = reader.ReadInt32();
                            spellSlots[i, 1] = reader.ReadInt32();
                            spellSlotsLabels[i].Text = $"{spellSlots[i, 0]}/{spellSlots[i, 1]}";
                        }
                    }
                    //misc bonuses
                    spellAtkBonusnumUpDown.Value = reader.ReadInt32();
                    spellsavedcnumupdown.Value = reader.ReadInt32();                   
                }
                //char info
                int length = reader.ReadInt32();
                if (length > 0)
                {
                    portrait = reader.ReadBytes(length);
                }
                for (int i = 0; i < charInfo.Length; i++)
                {
                    charInfo[i] = reader.ReadString();
                }
                //money
                getBox(copperTextbox).Text = reader.ReadString();
                getBox(silverTextbox).Text = reader.ReadString();
                getBox(goldTextbox).Text = reader.ReadString();
                getBox(platTextbox).Text = reader.ReadString();
                //death saves
                DeathPass1.Visible = reader.ReadBoolean();
                DeathPass2.Visible = reader.ReadBoolean();
                DeathPass3.Visible = reader.ReadBoolean();
                DeathFail1.Visible = reader.ReadBoolean();
                DeathFail2.Visible = reader.ReadBoolean();
                DeathFail3.Visible = reader.ReadBoolean();

                UpdateProficiencies(null, null); // Update Expertise and half prof
                saveButton.Enabled = true;
                saved = true;
                this.Text = getBox(nameTextBox).Text;
                fileName = filePath;
                reader.Close();
            }
        }


        //reset form
        private void NewCharacter()
        {
            //stats
            strLabel.Text = "10";
            dexlabel.Text = "10";
            conlabel.Text = "10";
            intlabel.Text = "10";
            wislabel.Text = "10";
            charlabel.Text = "10";
            strProf.Checked = false;
            dexProf.Checked = false;
            conProf.Checked = false;
            intProf.Checked = false;
            wisProf.Checked = false;
            charProf.Checked = false;
            profBonus = 2;
            profBonusLabel.Text = "2";
            ((speedTextBox.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox).Text = "";
            getBox(raceTextbox).Text = "Race";
            getBox(backgroundTextbox).Text = "Background";
            getBox(alignmentTextbox).Text = "Alignment";
            foreach (CustomControls.ProficiencyCheckBox c in proficienciesCheckBoxes.checks1)
                c.Checked = false;
            foreach (CustomControls.ProficiencyCheckBox c in proficienciesCheckBoxes.checks2)
                c.Checked = false;
            foreach (CustomControls.ProficiencyCheckBox c in proficienciesCheckBoxes.halfChecks)
                c.Checked = false;
            initiativeNumUpDown.Value = 0;
            initiativeLabel.Text = "";
            initiativeAdvCheckbox.Checked = false;
            getBox(ACarmorTextbox).Text = "10";
            ACDisplayLabel.Text = "10";
            getBox(DexarmorTextbox).Text = "";
            getBox(MiscarmorTextbox).Text = "";
            InventoryTextBox.Text = "";
            currentHPlabel.Text = "10";
            MaxHPlabel.Text = "10";
            tempHPlabel.Text = "0";
            autoHealHitDice.Checked = false;
            currentHitDiceDisplayLabel.Text = "Current: ";
            MaxHitDiceDisplayLabel.Text = "Max: ";
            d6NumUpDown.Value = 0;
            d8NumUpDown.Value = 0;
            d10NumUpDown.Value = 0;
            d12NumUpDown.Value = 0;
            getBox(nameTextBox).Text = "Character Name";
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
            //delete spells / spell buttons
            spellListPanel.Controls.Clear();
            KnownSpells = new List<int>();
            preparedSpells = new List<int>();
            alwaysPreparedSpells = new List<int>();
            spellSlots = new int[9, 2];
            for (int i = 0; i < 9; i++)
                spellSlotsLabels[i].Text = $"{spellSlots[i, 0]}/{spellSlots[i, 1]}";
            spellsPreparedAmountlabel.Text = $"Prepared: {preparedSpells.Count}/";
            preparednumericUpDown.Value = 0;
            spellTypeDropdown.Text = "None";
            castTimedisplaylabel.Text = "";
            rangeDisplaylabel.Text = "";
            DurationDisplaylabel.Text = "";
            componentsDisplaylabel.Text = "";
            spellnamelabel.Text = "";
            multiplierDicedisplaylabel.Text = "";
            MultipliernumericUpDown.Value = 0;
            otherBonusnumericUpDown.Value = 0;
            spellAtkBonusnumUpDown.Value = 0;
            spellsavedcnumupdown.Value = 0;
            addModcheckBox.Checked = false;
            addModDisplayLabel.Text = "";
            warlockSpellSlots = new int[2];
            warlockSpellLevelnumericUpDown.Value = 0;
            warlockSLotsDisplayLabel.Text = $"{warlockSpellSlots[0]}/{warlockSpellSlots[1]}";
            Arcanum6checkBox.Checked = false;
            Arcanum7checkBox.Checked = false;
            Arcanum8checkBox.Checked = false;
            Arcanum9checkBox.Checked = false;
            castTimelabel.Enabled = false;
            rangelabel.Enabled = false;
            durationlabel.Enabled = false;
            componentlabel.Enabled = false;
            //money
            getBox(copperTextbox).Text = "0";
            getBox(silverTextbox).Text = "0";
            getBox(goldTextbox).Text = "0";
            getBox(platTextbox).Text = "0";
            //char info
            portrait = null;
            charInfo = new string[8];
            for (int i = 0; i < charInfo.Length; i++)
            {
                charInfo[i] = "";
            }
            //death saves
            DeathPass1.Visible = false;
            DeathPass2.Visible = false;
            DeathPass3.Visible = false;
            DeathFail1.Visible = false;
            DeathFail2.Visible = false;
            DeathFail3.Visible = false;

            saveButton.Enabled = false;
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

        #region Money

        private void copperTextbox_DoubleClick(object sender, EventArgs e)
        {
            var box = sender as System.Windows.Controls.TextBox;
            if (box.Background == System.Windows.Media.Brushes.White)
                return;
            if (int.TryParse(box.Text, out int i))
                moneyStore[int.Parse(box.Tag.ToString())] = i;
            else
                return;
            box.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 135, 20, 20));
            box.Background = System.Windows.Media.Brushes.White;
            box.Text = "";
            box.Select(0, 0);

        }

        private void copperTextbox_KeyPress(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                var box = sender as System.Windows.Controls.TextBox;
                if (box.Background == System.Windows.Media.Brushes.LightGray)
                    return;
                box.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 0, 0, 0));
                box.Background = System.Windows.Media.Brushes.LightGray;
                if (int.TryParse(box.Text, out int i))
                    moneyStore[int.Parse(box.Tag.ToString())] += i;
                box.Text = moneyStore[int.Parse(box.Tag.ToString())].ToString();

            }
        }


        #endregion

        #region Misc

        //changes color
        private void buttonNoPadding3_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if(cd.ShowDialog() == DialogResult.OK)
                this.BackColor = cd.Color;
        }

        // open char info window
        private void BackgroundInfobutton_Click(object sender, EventArgs e)
        {
            CharacterInfo charInfo = new CharacterInfo();
            charInfo.Show(this);
        }

        private void InitiativeRollButton_Click(object sender, EventArgs e)
        {
            string adv = "";
            int roll = Roll.RollSingleDie(20);
            if (initiativeAdvCheckbox.Checked)
            {
                int roll2 = Roll.RollSingleDie(20);
                roll = Math.Max(roll, roll2);
                adv = "(advantage)";
            }

            string misc = "";
            if (initiativeNumUpDown.Value != 0)
                misc = ", Misc: " + initiativeNumUpDown.Value;
            int total = roll + statMods[1] + initiativeNumUpDown.Value;

            initiativeLabel.Text = total.ToString();

            UpdateOutput("Initiative Roll" + adv + ": " + total + " (Roll: " + roll + ", Dex: " + statMods[1] + misc + ")");
            UpdateOutput(Environment.NewLine); UpdateOutput(Environment.NewLine);

            SetUnsaved();
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
            this.Text = getBox(nameTextBox).Text + " Character sheet *";
        }


        //add a string to the log.  Displays the last 10 lines
        public void UpdateOutput(string s)
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

        private System.Windows.Controls.TextBox getBox(Control c)
        {
            return (c.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;  
        }


        private void ClearText(object sender, EventArgs e)
        {
            (sender as System.Windows.Controls.TextBox).Text = "";
        }


        private void RemoveLetters(object sender, EventArgs e)
        {
            //remove letters
            var box = ((System.Windows.Controls.TextBox)sender);
            string s = box.Text;
            string end = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (int.TryParse(s[i].ToString(), out int num) ||
                    (i == 0 && s[i] == '-') || (i == 0 && s[i] == '+'))
                {
                    end += s[i];
                }
            }
            if (s.Length > 0 && !s.Substring(0, s.Length - 1).Equals(end) && !removedLetters)
                SetUnsaved();
            removedLetters = true;      //"mutex" so that setting the text does not trigger this again
            box.Text = end;
            removedLetters = false;
            box.SelectionStart = box.Text.Length;
            box.SelectionLength = 0;
        }

        private void buttonNoPadding7_Click(object sender, EventArgs e)
        {

        }

        private void spellListPanel_Paint(object sender, PaintEventArgs e)
        {

        }




        #endregion

        #region Spells

        //when spell class is selected
        private void ChangeSpellType(object sender, EventArgs e)
        {
            classSpellType = spellTypeDropdown.SelectedIndex;
            if (((ComboBox)sender).Text == "None")
            {
                spellPanel.Visible = false;
                this.Size = new Size(844, 687);
            }
            else
            {
                spellPanel.Visible = true;
                this.Size = new Size(1131, 687);
            }
            this.CenterToScreen();
            addModDisplayLabel.Text = "(" + attributeNames[classModifierTypes[Math.Max(classSpellType - 1, 0)]] + ")";
            spellcastingAbilityDisplayLabel.Text = attributeNames[classModifierTypes[Math.Max(classSpellType - 1, 0)]];
            //warlock
            warlockSpellPanel.Visible = ((ComboBox)sender).Text == "Warlock";

            //set spell dc/atk bonus boxes
            if (classSpellType > 0)
            {
                spellattackBonusDisplayBox.Text = "+" + (profBonus + spellAtkBonusnumUpDown.Value + statMods[classModifierTypes[classSpellType - 1]]);
                spellSaveDCdisplayLabel.Text = (8 + profBonus + spellsavedcnumupdown.Value + statMods[classModifierTypes[classSpellType - 1]]).ToString();
            }

            if (classSpellType == 0)
                return;

            bool prepared = prepareSpells[classSpellType - 1];// && currentSpellLevel > 0;
            preparedhelpLabel.Visible = prepared;
            spellsPreparedAmountlabel.Visible = prepared;
            preparednumericUpDown.Visible = prepared;
            if(prepared)
            {
                spellListPanel.Location = new Point(2, 360);
                spellListPanel.Size = new Size(241, 216);
            }
            else
            {
                spellListPanel.Location = new Point(2, 338);
                spellListPanel.Size = new Size(241, 236);
            }

            // Update spell list
            SelectSpellLevel(spellLevelButtons[currentSpellLevel], null);

            spellsPreparedAmountlabel.Text = $"Prepared: {preparedSpells.Count}/";

            SetUnsaved();
        }

        /*
        private void SpellDescriptionShow(object sender, EventArgs e)
        {
            if (Spells[currentSpell].Description == "")
                spellDescriptionTextbox.Text = "No description set";
            else
                spellDescriptionTextbox.Text = Spells[currentSpell].Description;
            spellDescriptionTextbox.BringToFront();
            spellDescriptionTextbox.Visible = true;
            spellDesLabel.BackColor = Color.WhiteSmoke;
            spellDescriptionTextbox.Width = Math.Min(228, (int)spellDescriptionTextbox.CreateGraphics().
                MeasureString(spellDescriptionTextbox.Text, spellDescriptionTextbox.Font).Width);
            SizeF MessageSize = spellDescriptionTextbox.CreateGraphics().MeasureString(spellDescriptionTextbox.Text,
                spellDescriptionTextbox.Font, spellDescriptionTextbox.Width, new StringFormat(0));
            spellDescriptionTextbox.Height = (int)(MessageSize.Height * 1.06) - 8;
            int xPos = Math.Max( Math.Min(113, 235 - spellDescriptionTextbox.Width), 11);
            spellDescriptionTextbox.Location = new Point(xPos, 300);
        }
        */


        //open form with spell info
        private void SpellDescriptionButton_Click(object sender, EventArgs e)
        {
            SpellInfoDisplay info = new SpellInfoDisplay(Spells[currentSpell]);
            info.Show();
        }

        //open spell menu to select spell to edit
        private void BrowseSpells(object sender, EventArgs e)
        {
            SpellMenu spellMenu = new SpellMenu(Spells);
            spellMenu.ShowDialog(this);
        }

        private void SpellAttackRoll(object sender, EventArgs e)
        {
            string s = "";
            Spell spell = Spells[currentSpell]; 
            int roll = Roll.RollSingleDie(20);
            //int mod = 0;
            //if(spellattacktypeDropDown.SelectedIndex > 0)
            int mod = statMods[classModifierTypes[classSpellType - 1]];
            s += spell.Name + " attack roll: ";
            s += (roll + mod + profBonus + spellAtkBonusnumUpDown.Value);
            s += "(Roll: " + roll;
            //if (spell.AttackType > 0)
            s += ", " + attributeNames[classModifierTypes[classSpellType - 1]] + ": " + mod;
            s += ", Proficiency Bonus: " + profBonus; 
            if (spellAtkBonusnumUpDown.Value != 0)
                s += ", Misc Bonus: " + spellAtkBonusnumUpDown.Value;
            s += ")";
            UpdateOutput(s);
            UpdateOutput(Environment.NewLine);
            UpdateOutput(Environment.NewLine);
        }

        //make a roll for the spell
        private void SpellMiscRollButton_Click(object sender, EventArgs e)
        {
            Spell s = Spells[currentSpell];
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
                    if(addModcheckBox.Checked || otherBonusnumericUpDown.Value != 0)
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
                    roll += (int)otherBonusnumericUpDown.Value;
                    string miscString = "";
                    if (otherBonusnumericUpDown.Value != 0)
                        miscString = ", Misc Bonus: " + otherBonusnumericUpDown.Value;
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
        public void LearnSpell(int id)
        {
            KnownSpells.Add(id);
            SelectSpellLevel(spellLevelButtons[currentSpellLevel] , null);
            SetUnsaved();
        }

        //select spell level radio button
        private void SelectSpellLevel(object sender, EventArgs e)
        {
            //return if dont cast spells
            if (classSpellType <= 0)
                return;

            //get selected level and update labels
            currentSpellLevel = int.Parse(((RadioButton)sender).Tag.ToString());
            bool prepared = prepareSpells[classSpellType - 1];// && currentSpellLevel > 0;
            preparedhelpLabel.Visible = prepared;
            spellsPreparedAmountlabel.Visible = prepared;
            preparednumericUpDown.Visible = prepared;
            if (prepared)
            {
                spellListPanel.Location = new Point(2, 364);
                spellListPanel.Size = new Size(272, 216);
            }
            else
            {
                spellListPanel.Location = new Point(2, 338);
                spellListPanel.Size = new Size(272, 236);
            }
            spellListLabel.Text = "Level " + currentSpellLevel + " Spells";
            if (currentSpellLevel == 0)
                spellListLabel.Text = "Cantrips";
            //clear currently displayed spells
            CustomButtons.ButtonNoPadding b = forgetSpellButton; //save forget button from being deleted
            spellListPanel.Controls.Clear();
            spellListPanel.Controls.Add(b);
            spellRadioButtons.Clear();
            //disable/clear buttons.  will be enabled when adding spells
            castTimelabel.Enabled = false;
            rangelabel.Enabled = false;
            durationlabel.Enabled = false;
            componentlabel.Enabled = false;
            SpellDescriptionButton.Enabled = false;
            castTimedisplaylabel.Text = "";
            rangeDisplaylabel.Text = "";
            DurationDisplaylabel.Text = "";
            componentsDisplaylabel.Text = "";
            spellrolldropdown.Enabled = false;
            SpellMiscRollButton.Enabled = false;
            spellAttackButton.Enabled = false;
            mullabel.Enabled = false;
            multiplierDicedisplaylabel.Enabled = false;
            MultipliernumericUpDown.Enabled = false;
            miscBonuslabel.Enabled = false;
            otherBonusnumericUpDown.Enabled = false;
            addModcheckBox.Enabled = false;
            addModDisplayLabel.Enabled = false;

            //display spell list
            int spellsDisplayed = 0;
            for(int i = 0; i < KnownSpells.Count; i++)
            {
                if(FindSpellFromID(KnownSpells[i]) != null && FindSpellFromID(KnownSpells[i]).Level == currentSpellLevel)
                {
                    //labels
                    castTimelabel.Enabled = true;
                    rangelabel.Enabled = true;
                    durationlabel.Enabled = true;
                    componentlabel.Enabled = true;
                    SpellDescriptionButton.Enabled = true;
                    //add new control
                    CustomControls.CustomRadioButton newButton = new CustomControls.CustomRadioButton();
                    newButton.Text = FindSpellFromID(KnownSpells[i]).Name;
                    newButton.Height = 18;
                    newButton.Width = 300;
                    newButton.Tag = Spells.IndexOf(FindSpellFromID(KnownSpells[i]));   //adds the spells index in spells to the tag
                    int xPos = 8;
                    if (currentSpellLevel > 0 && prepareSpells[classSpellType - 1])
                        xPos = 22;
                    newButton.Location = new Point(xPos, spellsDisplayed * 20 + 5);
                    newButton.CheckedChanged += SpellSelected;
                    //add to lists
                    spellListPanel.Controls.Add(newButton);
                    spellRadioButtons.Add(newButton);
                    //add checkbox if spells need to be prepared
                    if(currentSpellLevel > 0 && prepareSpells[classSpellType - 1])
                    {
                        //create checkBox
                        CustomControls.CustomPreparedCheck check = new CustomControls.CustomPreparedCheck();
                        check.Tag = KnownSpells[i];
                        if(preparedSpells.Contains(KnownSpells[i]))
                            check.SetState(CheckState.Checked);
                        else if (alwaysPreparedSpells.Contains(KnownSpells[i]))
                            check.SetState(CheckState.Indeterminate);
                        else
                            check.SetState(CheckState.Unchecked);
                        check.TabIndexChanged += ChangePrepared;
                        check.Location = new Point(2, spellsDisplayed * 20 + 6);
                        spellListPanel.Controls.Add(check);
                    }
                    spellsDisplayed++;
                }
            }
            if(spellRadioButtons.Count > 0)
                spellRadioButtons[0].Checked = true;
            forgetSpellButton.Visible = spellRadioButtons.Count > 0;
            spellsPreparedAmountlabel.Text = $"Prepared: {preparedSpells.Count}/";

            //disable spell slot buttons if cantrip
            warlockMinusCurrentSlotButton.Enabled = currentSpellLevel > 0;
            warlockPlusCurrentSlotButton.Enabled = currentSpellLevel > 0;
            warlockMinusSlotButton.Enabled = currentSpellLevel > 0;
            warlockPlusSlotButton.Enabled = currentSpellLevel > 0;

            minusMaxSlotbutton.Enabled = currentSpellLevel > 0;
            MinusCurrentSlotbutton.Enabled = currentSpellLevel > 0;
            plusCurrentSlotbutton.Enabled = currentSpellLevel > 0;
            PlusMaxSLotbutton.Enabled = currentSpellLevel > 0;

        }

        //when a spell display radio button is checked
        private void SpellSelected(object sender, EventArgs e)
        {
            forgetSpellButton.Visible = true;
            if (((RadioButton)sender).Checked)
            {
                currentSpell = int.Parse(((RadioButton)sender).Tag.ToString());
                forgetSpellButton.Location = new Point(forgetSpellButton.Location.X, (sender as RadioButton).Location.Y);
            }
            UpdateSpellInfo();
        }

        //add or remove the id from preparedSpells when the checkbox is clicked
        private void ChangePrepared(object sender, EventArgs e)
        {
            int id = int.Parse(((CustomControls.CustomPreparedCheck)sender).Tag.ToString());
            if (((CustomControls.CustomPreparedCheck)sender).State == 1)
            {
                preparedSpells.Add(id);
                alwaysPreparedSpells.Remove(id);
            }
            else if (((CustomControls.CustomPreparedCheck)sender).State == 2)
            {
                preparedSpells.Remove(id);
                alwaysPreparedSpells.Add(id);
            }
            else
            {
                preparedSpells.Remove(id);
                alwaysPreparedSpells.Remove(id);
            }
            spellsPreparedAmountlabel.Text = $"Prepared: {preparedSpells.Count}/";
            SetUnsaved();
        }



        //set spell info to currently selected spell
        private void UpdateSpellInfo()
        {
            if (Spells is null)
                return;
            Spell s = Spells[currentSpell];
            //spell info
            spellnamelabel.Text = s.Name;
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
            //enable/disable buttons
            spellAttackButton.Enabled = s.UsesAttack;
            SpellMiscRollButton.Enabled = s.Rolls.Count > 0;
            spellrolldropdown.Enabled = s.Rolls.Count > 0;
            addModcheckBox.Enabled = s.Rolls.Count > 0;
            addModDisplayLabel.Enabled = s.Rolls.Count > 0;
            mullabel.Enabled = s.Rolls.Count > 0 && s.Rolls[spellrolldropdown.SelectedIndex].UsesMul;
            MultipliernumericUpDown.Enabled = s.Rolls.Count > 0 && s.Rolls[spellrolldropdown.SelectedIndex].UsesMul;
            multiplierDicedisplaylabel.Enabled = s.Rolls.Count > 0 && s.Rolls[spellrolldropdown.SelectedIndex].UsesMul;
            if (s.Rolls.Count == 0 || !s.Rolls[spellrolldropdown.SelectedIndex].UsesMul)
                multiplierDicedisplaylabel.Text = " n/a";
            miscBonuslabel.Enabled = s.Rolls.Count > 0;
            otherBonusnumericUpDown.Enabled = s.Rolls.Count > 0;
        }

        public void SetSpell(Spell s, int id)
        {
            Spells[Spells.IndexOf(FindSpellFromID(id))] = s;
            SaveSpells();
            SelectSpellLevel(spellLevelButtons[currentSpellLevel], null);
        }

        public void AddSpell(Spell s)
        {
            Spells.Add(s);
            SaveSpells();
        }

        //change display label of multiplier
        private void UpdateMultiplierLabel(object sender, EventArgs e)
        {
            //loop through rolls in spell to find selected roll
            foreach (Roll r in Spells[currentSpell].Rolls)
            {
                if (r.Name == spellrolldropdown.Text)
                {
                    multiplierDicedisplaylabel.Text = r.Multiplier.DieNum[0] + "d" + r.Multiplier.DieAmount[0];
                }
            }
        }

        //delete spell from list at index
        public void DeleteSpell(int id)
        {
            Spells.Remove(FindSpellFromID(id));
            SaveSpells();
            //remove spell from known spells
            if (KnownSpells.Contains(id))
                KnownSpells.Remove(id);
        }

        #region spell slot buttons

        //add or subract one from the current level spell slots
        private void AddMaxSlot(object sender, EventArgs e)
        {
            if (currentSpellLevel > 0)
            {
                spellSlots[currentSpellLevel - 1, 1]++;
                spellSlotsLabels[currentSpellLevel - 1].Text =
                    spellSlots[currentSpellLevel - 1, 0] + "/" + spellSlots[currentSpellLevel - 1, 1];
            }
            SetUnsaved();
        }
        private void MinusMaxSlot(object sender, EventArgs e)
        {
            if (currentSpellLevel > 0)
            {
                spellSlots[currentSpellLevel - 1, 1] = Math.Max(spellSlots[currentSpellLevel - 1, 1] - 1, 0);
                spellSlotsLabels[currentSpellLevel - 1].Text =
                    spellSlots[currentSpellLevel - 1, 0] + "/" + spellSlots[currentSpellLevel - 1, 1];
            }
            SetUnsaved();
        }
        private void AddCurrentSlot(object sender, EventArgs e)
        {
            if (currentSpellLevel > 0)
            {
                spellSlots[currentSpellLevel - 1, 0] = 
                    Math.Min(spellSlots[currentSpellLevel - 1, 0] + 1, spellSlots[currentSpellLevel - 1, 1]);
                spellSlotsLabels[currentSpellLevel - 1].Text =
                    spellSlots[currentSpellLevel - 1, 0] + "/" + spellSlots[currentSpellLevel - 1, 1];
            }
            SetUnsaved();
        }
        private void MinusCurrentSlot(object sender, EventArgs e)
        {
            if (currentSpellLevel > 0)
            {
                spellSlots[currentSpellLevel - 1, 0] = Math.Max(spellSlots[currentSpellLevel - 1, 0] - 1, 0);
                spellSlotsLabels[currentSpellLevel - 1].Text =
                    spellSlots[currentSpellLevel - 1, 0] + "/" + spellSlots[currentSpellLevel - 1, 1];
            }
            SetUnsaved();
        }
        #endregion

        #region warlock slot Buttons

        //max
        private void warlockPlusSlotButton_Click(object sender, EventArgs e)
        {
            warlockSpellSlots[1]++;
            warlockSLotsDisplayLabel.Text = $"{warlockSpellSlots[0]}/{warlockSpellSlots[1]}";
            SetUnsaved();
        }
        //max
        private void warlockMinusSlotButton_Click(object sender, EventArgs e)
        {
            warlockSpellSlots[1] = Math.Max(warlockSpellSlots[1] - 1, 0);
            warlockSpellSlots[0] = Math.Min(warlockSpellSlots[0], warlockSpellSlots[1]); //move current slot down if higher than max
            warlockSLotsDisplayLabel.Text = $"{warlockSpellSlots[0]}/{warlockSpellSlots[1]}";
            SetUnsaved();
        }

        private void warlockPlusCurrentSlotButton_Click(object sender, EventArgs e)
        {
            warlockSpellSlots[0] = Math.Min(warlockSpellSlots[0] + 1, warlockSpellSlots[1]);
            warlockSLotsDisplayLabel.Text = $"{warlockSpellSlots[0]}/{warlockSpellSlots[1]}";
            SetUnsaved();
        }

        private void warlockMinusCurrentSlotButton_Click(object sender, EventArgs e)
        {
            warlockSpellSlots[0] = Math.Max(warlockSpellSlots[0] - 1, 0);
            warlockSLotsDisplayLabel.Text = $"{warlockSpellSlots[0]}/{warlockSpellSlots[1]}";
            SetUnsaved();
        }
        #endregion

        private void RefillSpellSlots(object sender, EventArgs e)
        {
            for(int i = 0; i < 9; i++)
            {
                spellSlots[i, 0] = spellSlots[i, 1];
                spellSlotsLabels[i].Text = spellSlots[i, 0] + "/" + spellSlots[i, 1];
                SetUnsaved();
            }
        }

        private void WarlockRefillSlotsButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
                usedArcanums[i] = false;
            warlockSpellSlots[0] = warlockSpellSlots[1];
            warlockSLotsDisplayLabel.Text = $"{warlockSpellSlots[0]}/{warlockSpellSlots[1]}";
            Arcanum6checkBox.Checked = false;
            Arcanum7checkBox.Checked = false;
            Arcanum8checkBox.Checked = false;
            Arcanum9checkBox.Checked = false;
            SetUnsaved();
        }

        private void ArcanumChecKChanged(object sender, EventArgs e)
        {
            int index = int.Parse((sender as CheckBox).Tag.ToString());
            usedArcanums[index] = (sender as CheckBox).Checked;
            SetUnsaved();
        }

        private void forgetSpellButton_Click(object sender, EventArgs e)
        {
            KnownSpells.Remove(Spells[currentSpell].ID);
            SelectSpellLevel(spellLevelButtons[currentSpellLevel], null);
            SetUnsaved();
        }

        private void ShowPreparedSpellHelpPanel(object sender, EventArgs e)
        {
            preparedHelppanel.Visible = true;
        }

        private void preparedhelpLabel_MouseLeave(object sender, EventArgs e)
        {
            preparedHelppanel.Visible = false;
        }


        //inputs spells from text file into a list on load
        private void LoadSpells()
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            if (!File.Exists(directory + "\\spellData"))
            {
                //create initial spell spellData file
                Stream outStream = File.OpenWrite(directory + "\\spellData");
                BinaryWriter output = new BinaryWriter(outStream);
                output.Write(0);
                output.Write(0);
                output.Close();
            }
            Stream inStream = File.OpenRead(directory + "\\spellData");
            BinaryReader reader = new BinaryReader(inStream);
            nextSpellId = reader.ReadInt32();
            int numOfSpells = reader.ReadInt32();
            for (int i = 0; i < numOfSpells; i++)
            {
                string name = reader.ReadString();
                int lvl = reader.ReadInt32();
                int id = reader.ReadInt32();
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
                Spells.Add(new Spell(name, castTime, range, duration, components, rolls, lvl, description, useAtk, id));
            }
        }


        //writes all spells in list to text file
        private void SaveSpells()
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (!File.Exists(directory + "\\spellData"))
            {
                File.Create(directory + "\\spellData");
            }

            //open writer
            string saveFilePath = directory + "\\spellData";
            Stream outStream = File.OpenWrite(saveFilePath);
            BinaryWriter output = new BinaryWriter(outStream);
            //write spells
            output.Write(nextSpellId);
            output.Write(Spells.Count);
            foreach(Spell s in Spells)
            {
                output.Write(s.Name);
                output.Write(s.Level);
                output.Write(s.ID);
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

        //takes a spell ID and finds the spell from the spells list
        public Spell FindSpellFromID(int id)
        {
            foreach(Spell s in Spells)
            {
                if (s.ID == id)
                    return s;
            }
            return null;
        }

        //updates spell level label when warlock panel hides/shows
        private void warlockSpellPanel_VisibleChanged(object sender, EventArgs e)
        {
            warlockSpellButton1.Checked = true;
            if(spellLevelButtons != null)
                spellLevelButtons[1].Checked = true;
            spellListLabel.Text = "Level 1 spells";
        }

        //open file dialog to import .pc file
        private void importButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog importFileDialog = new OpenFileDialog();
            importFileDialog.Title = "Import a Character";
            importFileDialog.Filter = "Player Character| *.pc";
            DialogResult result = importFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fileName = importFileDialog.FileName;
                loadFile(fileName);
                saveButton.Enabled = false;
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog exportFileDialog = new SaveFileDialog();
            exportFileDialog.Title = "Export a Character";
            exportFileDialog.Filter = "Player Character| *.pc";
            DialogResult result = exportFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fileName = exportFileDialog.FileName;
                saveFile(fileName);
                saveButton.Enabled = false;
            }
        }



        #endregion

        #region Death Saves

        // make death save
        private void deathSaveRollButton_Click(object sender, EventArgs e)
        {
            int roll = Roll.RollSingleDie(20);

            UpdateOutput("Death save roll: " + roll);
            UpdateOutput(Environment.NewLine); UpdateOutput(Environment.NewLine);

            if (roll >= 10)
            {
                if (!DeathPass1.Visible)
                {
                    DeathPass1.Visible = true;
                }
                else if (!DeathPass2.Visible)
                {
                    DeathPass2.Visible = true;
                }
                else
                {
                    DeathPass3.Visible = true;
                    deathSaveRollButton.Enabled = false;
                }
                if (roll == 20)
                {
                    if (!DeathPass2.Visible)
                    {
                        DeathPass2.Visible = true;
                    }
                    else
                    {
                        DeathPass3.Visible = true;
                        deathSaveRollButton.Enabled = false;
                    }
                }
            }
            else
            {
                if (!DeathFail1.Visible)
                {
                    DeathFail1.Visible = true;
                }
                else if (!DeathFail2.Visible)
                {
                    DeathFail2.Visible = true;
                }
                else
                {
                    DeathFail3.Visible = true;
                    deathSaveRollButton.Enabled = false;
                }
                if (roll == 1)
                {
                    if (!DeathFail2.Visible)
                    {
                        DeathFail2.Visible = true;
                    }
                    else
                    {
                        DeathFail3.Visible = true;
                        deathSaveRollButton.Enabled = false;
                    }
                }
            }
            SetUnsaved();
        }

        // enable roll button and hide pictures
        private void deathSaveResetButton_Click(object sender, EventArgs e)
        {
            DeathPass1.Visible = false;
            DeathPass2.Visible = false;
            DeathPass3.Visible = false;
            DeathFail1.Visible = false;
            DeathFail2.Visible = false;
            DeathFail3.Visible = false;
            deathSaveRollButton.Enabled = true;
            SetUnsaved();
        }
        #endregion

        #region Misc Rolls

        private void miscRollbutton_Click(object sender, EventArgs e)
        {
            Roll r = new Roll(new List<int> { (int)miscRollAmountnumericUpDown.Value }, 
                new List<int> { (int)miscRollNumnumericUpDown.Value }, (int)MiscRollflatnumericUpDown.Value);
            int roll = r.RollDice();
            int roll2 = r.RollDice();
            if (miscRollDropDown.SelectedIndex == 1)
                roll = Math.Max(roll, roll2);
            if (miscRollDropDown.SelectedIndex == 2)
                roll = Math.Min(roll, roll2);
            UpdateOutput($"Misc Roll ({r.ToString()}): {roll}");
            UpdateOutput(Environment.NewLine); UpdateOutput(Environment.NewLine);
        }

        //When enter key is pressed while focusing numUpDOwns
        private void MiscRollKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                miscRollbutton_Click(miscRollbutton, new EventArgs());
                // stop ding sound
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        //selects text when the control becomes focused
        private void miscRollAmountnumericUpDown_Enter(object sender, EventArgs e)
        {
            ((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Value.ToString().Length);
        }

        #endregion

    }
}
