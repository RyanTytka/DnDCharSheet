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
    public partial class SpellCreationForm : Form
    {
        public SpellCreationForm(Spell s = null, int index = 0)
        {

            InitializeComponent();
        }

        //save/create weapon
        private void button1_Click(object sender, EventArgs e)
        {
            /*
            if (selectedWeapon == null)
            {
                ((Form1)Owner).AddWeapon(new Weapon(nameTextBox.Text, bonusRolls, propertiesTextBox.Lines,
                    finessCheckBox.Checked, profCheckBox.Checked, damageRoll));
            }
            else
            {
                ((Form1)Owner).SetWeapon(new Weapon(nameTextBox.Text, bonusRolls, propertiesTextBox.Lines,
                    finessCheckBox.Checked, profCheckBox.Checked, damageRoll), index);
            }
            */
            this.Close();
        }

        //display new roll form
        private void button2_Click(object sender, EventArgs e)
        {
            CustomRollForm rollPage = new CustomRollForm(1,1);
            rollPage.ShowDialog(this);
        }

        //add the roll to the lists
        public void AddRoll(List<int> nums, List<int> dice, int flat, 
            string _name = "", int _type = -1, bool _optional = false)
        {
            /*
            int type = 0;
            if (atkRadioButton.Checked)
                type = 1;
            else if (dmgRadioButton.Checked)
                type = 2;
            else
            {
                type = 3;
            }

            //add bonus roll textbox
            Button newButton = new Button();
            Label newBox = new Label();
            newBox.Location = new Point(bonusRollsLabel.Location.X + 8, bonusRollsLabel.Location.Y - 4);
            newButton.Location = new Point(bonusRollsLabel.Location.X - 8, bonusRollsLabel.Location.Y - 4);
            newButton.Size = new Size(16,16);
            newButton.Font = new Font("Arial", 5.25f, FontStyle.Regular);
            newButton.Tag = "" + rollButtons.Count;
            newButton.Text = "x";
            rollNameTextBox.ForeColor = Color.DimGray;
            newButton.Click += new EventHandler(XButtonClick);
            if (_type != -1)
            {
                //editing weapon
                bonusRolls.Add(new Roll(nums, dice, flat, _type, _name, _optional));
                newBox.Text = _name;
            }
            else
            {
                //creating weapon
                bonusRolls.Add(new Roll(nums, dice, flat, type, rollNameTextBox.Text, rollOptionalCheckBox.Checked));
                newBox.Text = rollNameTextBox.Text;
            }
            rollNameTextBox.Text = "roll name";
            this.Controls.Add(newBox);
            this.Controls.Add(newButton);
            rollButtons.Add(newButton);
            rollLabels.Add(newBox);

            bonusRollsLabel.Location = new Point(bonusRollsLabel.Location.X, bonusRollsLabel.Location.Y - 20);
            */
        }

        private void SpellCreation_Load(object sender, EventArgs e)
        {
            AttackRollDropdown.Text = "None";
            /*
            bothRadioButton.Checked = true;
            if(selectedWeapon != null)
            {
                //enter in weapon stats to controls
                nameTextBox.Text = selectedWeapon.Name;
                propertiesTextBox.Text = selectedWeapon.Properties;
                profCheckBox.Checked = selectedWeapon.Proficient;
                finessCheckBox.Checked = selectedWeapon.Finesse;
                damageRoll = selectedWeapon.Damage;
                damageRollDisplay.Text = damageRoll.ToString();
                saveButton.Text = "Save Weapon";
                foreach(Roll r in selectedWeapon.BonusRolls)
                {
                    AddBonusRolls(r.DieNum, r.DieAmount, r.Flat, r.Name, r.Type, r.Optional);
                }
            }
            else
            {
                this.ActiveControl = nameTextBox;
            }
            */
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

        //get rid of bonus roll
        private void XButtonClick(object sender, System.EventArgs e)
        {
            /*
            int ID = int.Parse((string)((Button)sender).Tag);
            this.Controls.Remove(rollButtons[ID]);
            this.Controls.Remove(rollLabels[ID]);
            rollButtons.RemoveAt(ID);
            rollLabels.RemoveAt(ID);
            bonusRolls.RemoveAt(ID);
            //adjust tags
            for (int i = ID; i < rollButtons.Count; i++)
            {
                rollButtons[i].Tag = "" + (int.Parse((string)(rollButtons[i]).Tag) - 1);
            }
            //adjust locations
            for (int i = ID; i < rollButtons.Count; i++)
            {
                rollButtons[i].Location = new Point(rollButtons[i].Location.X, rollButtons[i].Location.Y + 20);
                rollLabels[i].Location = new Point(rollLabels[i].Location.X, rollLabels[i].Location.Y + 20);
            }
            bonusRollsLabel.Location = new Point(bonusRollsLabel.Location.X, bonusRollsLabel.Location.Y + 20);
            */
        }

        //create damage roll
        private void editDamageButton_Click(object sender, EventArgs e)
        {
            //display new roll form
            CustomRollForm rollPage = new CustomRollForm(2,6);
            rollPage.ShowDialog(this);
            
        }

        //set damage roll
        public void SetDamageRoll(Roll r)
        {
            //damageRoll = r;
            //damageRollDisplay.Text = r.ToString();
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
    }
}
