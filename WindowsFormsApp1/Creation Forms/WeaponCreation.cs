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
    public partial class WeaponCreation : Form
    {
        Roll damageRoll;
        List<Roll> bonusRolls;
        List<Button> rollButtons;
        List<Label> rollLabels;
        System.Windows.Controls.TextBox propBox;
        System.Windows.Controls.TextBox rollBox;
        System.Windows.Controls.TextBox nameBox;

        Weapon selectedWeapon;
        int index;

        public WeaponCreation(Weapon w = null, int index = 0)
        {
            bonusRolls = new List<Roll>();
            rollButtons = new List<Button>();
            rollLabels = new List<Label>();
            selectedWeapon = w;
            this.index = index;
            InitializeComponent();
        }

        //save/create weapon
        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedWeapon == null)
            {
                ((Form1)Owner).AddWeapon(new Weapon(nameBox.Text, bonusRolls, propBox.Text,
                    finessCheckBox.Checked, profCheckBox.Checked, damageRoll));
            }
            else
            {
                ((Form1)Owner).SetWeapon(new Weapon(nameBox.Text, bonusRolls, propBox.Text,
                    finessCheckBox.Checked, profCheckBox.Checked, damageRoll), index);
            }
            this.Close();
        }

        //display new roll form
        private void button2_Click(object sender, EventArgs e)
        {
            CustomRollForm rollPage = new CustomRollForm(1,1);
            rollPage.ShowDialog(this);
        }

        //add the roll to the lists
        public void AddBonusRolls(List<int> nums, List<int> dice, int flat, 
            string _name = "", int _type = -1, bool _optional = false)
        {
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
                bonusRolls.Add(new Roll(nums, dice, flat, type, rollBox.Text, rollOptionalCheckBox.Checked));
                newBox.Text = rollBox.Text;
            }
            rollBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(105, 105, 105));
            rollBox.Text = "roll name";
            this.Controls.Add(newBox);
            this.Controls.Add(newButton);
            rollButtons.Add(newButton);
            rollLabels.Add(newBox);

            bonusRollsLabel.Location = new Point(bonusRollsLabel.Location.X, bonusRollsLabel.Location.Y - 20);

        }

        private void WeaponCreation_Load(object sender, EventArgs e)
        {
            nameBox = (nameControl.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;
            propBox = (props.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;
            rollBox = (rollNameTextBox.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;
            rollBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(105, 105, 105));
            rollBox.Text = "roll name";

            bothRadioButton.Checked = true;
            if(selectedWeapon != null)
            {
                //enter in weapon stats to controls
                nameBox.Text = selectedWeapon.Name;
                propBox.Text = selectedWeapon.Properties;
                profCheckBox.Checked = selectedWeapon.Proficient;
                finessCheckBox.Checked = selectedWeapon.Finesse;
                damageRoll = selectedWeapon.Damage;
                damageRollDisplay.Text = damageRoll.ToString();
                saveButton.Text = "Save Weapon";
                titleLabel.Text = "Edit Weapon";
                foreach (Roll r in selectedWeapon.BonusRolls)
                {
                    AddBonusRolls(r.DieNum, r.DieAmount, r.Flat, r.Name, r.Type, r.Optional);
                }
            }
            else
            {
                this.ActiveControl = nameControl;
            }
        }

        //clear text of roll name
        private void rollNameTextBox_Enter(object sender, EventArgs e)
        {
            if (rollBox.Text == "roll name")
            {
                rollBox.Text = "";
                rollBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0));
            }
        }
        private void rollNameTextBox_Leave(object sender, EventArgs e)
        {
            if (rollBox.Text == "")
            {
                rollBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(105,105,105));
                rollBox.Text = "roll name";
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
            damageRoll = r;
            damageRollDisplay.Text = r.ToString();
        }
    }
}
