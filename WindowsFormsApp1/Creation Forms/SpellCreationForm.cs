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
    public partial class SpellCreationForm : Form
    {
        List<Roll> rolls;
        Spell selectedSpell;
        int index;
        List<Control> rollButtons, rollLabels;
        System.Windows.Controls.TextBox spellNameBox;
        System.Windows.Controls.TextBox rangeBox;
        System.Windows.Controls.TextBox castTimeBox;
        System.Windows.Controls.TextBox durationBox;
        System.Windows.Controls.TextBox componentsBox;
        System.Windows.Controls.TextBox rollNameBox;
        System.Windows.Controls.TextBox descriptionBox;

        public SpellCreationForm(Spell s = null, int index = 0)
        {
            rolls = new List<Roll>();
            selectedSpell = s;
            this.index = index;
            rollButtons = new List<Control>();
            rollLabels = new List<Control>();
            InitializeComponent();
        }

        //save/create spell
        private void SaveSpell(object sender, EventArgs e)
        {
            
            if (selectedSpell == null)
            {
                Form1.nextSpellId++;
                ((Form1)Owner.Owner).AddSpell(new Spell(spellNameBox.Text, castTimeBox.Text, rangeBox.Text, 
                    durationBox.Text, componentsBox.Text, rolls, (int)LevelnumericUpDown.Value, 
                    descriptionBox.Text, AttackRollcheckBox.Checked, Form1.nextSpellId));
            }
            else
            {
                ((Form1)Owner.Owner).SetSpell(new Spell(spellNameBox.Text, castTimeBox.Text, rangeBox.Text,
                    durationBox.Text, componentsBox.Text, rolls, (int)LevelnumericUpDown.Value,
                    descriptionBox.Text, AttackRollcheckBox.Checked, selectedSpell.ID), index);
            }
            ((SpellMenu)Owner).RefreshSpells("null");
            this.Close();
        }

        //display new roll form
        private void AddRollButton_click(object sender, EventArgs e)
        {
            CustomRollForm rollPage = new CustomRollForm(4, (int)DieNumnumericUpDown.Value);
            rollPage.ShowDialog(this);
        }
        

        //add the roll to the lists
        public void AddRoll(List<int> nums, List<int> dice, int flat)
        {
            Roll r = new Roll(nums, dice, flat, rollNameBox.Text, (int)DieAmountnumericUpDown.Value, 
                (int)DieNumnumericUpDown.Value, multipliercheckBox.Checked);
            rolls.Add(r);
            //add bonus roll textbox
            Button newButton = new Button();
            Label newLabel = new Label();
            newLabel.Location = new Point(250, 240 + rolls.Count * 25);
            newButton.Location = new Point(232, 240 + rolls.Count * 25);
            newButton.Size = new Size(16,16);
            newButton.Font = new Font("Arial", 5.25f, FontStyle.Regular);
            newButton.Text = "x";
            newButton.Click += new EventHandler(XButtonClick);
            newLabel.Text = rollNameBox.Text;
            newLabel.BringToFront();
            newButton.Tag = "" + rollButtons.Count;
            rollButtons.Add(newButton);
            rollLabels.Add(newLabel);
            rollNameBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(105, 105, 105));
            rollNameBox.Text = "roll name";
            this.Controls.Add(newLabel);
            this.Controls.Add(newButton);
        }

        private void SpellCreation_Load(object sender, EventArgs e)
        {
            spellNameBox = (spellNameTextbox.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;
            rangeBox = (RangeTextbox.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;
            castTimeBox = (castTimeTextbox.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;
            durationBox = (durationTextbox.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;
            rollNameBox = (rollNameTextbox.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;
            componentsBox = (componentsTextBox.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;
            descriptionBox = (descriptionTextbox.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;

            rollNameBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(105, 105, 105));
            rollNameBox.Text = "roll name";

            if (selectedSpell != null)
            {
                //enter in spell stats to controls
                spellNameBox.Text = selectedSpell.Name;
                SaveButton.Text = "Save Spell";
                headerLabel.Text = "Edit Spell";
                castTimeBox.Text = selectedSpell.CastTime;
                rangeBox.Text = selectedSpell.Range;
                durationBox.Text = selectedSpell.Duration;
                componentsBox.Text = selectedSpell.Components;
                descriptionBox.Text = selectedSpell.Description;
                LevelnumericUpDown.Value = selectedSpell.Level;
                AttackRollcheckBox.Checked = selectedSpell.UsesAttack;
                foreach(Roll r in selectedSpell.Rolls)
                {
                    AddRoll(r.DieNum, r.DieAmount, r.Flat);
                }
            }
            else
            {
                this.ActiveControl = spellNameTextbox;
            }
            
        }

        //clear text of roll name
        private void rollNameTextBox_Enter(object sender, EventArgs e)
        {
            if (rollNameBox.Text == "roll name")
            {
                rollNameBox.Text = "";
                rollNameBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0));
            }
        }
        private void rollNameTextBox_Leave(object sender, EventArgs e)
        {
            if (rollNameBox.Text == "")
            {
                rollNameBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(105, 105, 105));
                rollNameBox.Text = "roll name";
            }
        }

        //get rid of bonus roll
        private void XButtonClick(object sender, System.EventArgs e)
        {
            int ID = int.Parse((string)((Button)sender).Tag);
            this.Controls.Remove(rollButtons[ID]);
            this.Controls.Remove(rollLabels[ID]);
            rollButtons.RemoveAt(ID);
            rollLabels.RemoveAt(ID);
            rolls.RemoveAt(ID);
            //adjust tags
            for (int i = ID; i < rollButtons.Count; i++)
            {
                rollButtons[i].Tag = "" + (int.Parse((string)(rollButtons[i]).Tag) - 1);
            }
            //adjust locations
            for (int i = ID; i < rollButtons.Count; i++)
            {
                rollButtons[i].Location = new Point(rollButtons[i].Location.X, rollButtons[i].Location.Y - 25);
                rollLabels[i].Location = new Point(rollLabels[i].Location.X, rollLabels[i].Location.Y - 25);
            }            
        }


        private void ShowHelp(object sender, EventArgs e)
        {
            helpDisplaylabel.BringToFront();
            helpDisplaylabel.Visible = true;
        }

        private void HideHelp(object sender, EventArgs e)
        {
            helpDisplaylabel.Visible = false;
        }

        private void multipliercheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(((CheckBox)sender).Checked)
            {
                DieNumnumericUpDown.Enabled = true;
                DieAmountnumericUpDown.Enabled = true;
            }
            else
            {
                DieNumnumericUpDown.Enabled = false;
                DieAmountnumericUpDown.Enabled = false;
            }
        }
    }
}
