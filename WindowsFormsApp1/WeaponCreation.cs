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
    public partial class WeaponCreation : Form
    {
        Roll damageRoll;
        List<Roll> bonusRolls;
        List<Button> rollButtons;
        List<Label> rollLabels;

        public WeaponCreation()
        {
            bonusRolls = new List<Roll>();
            rollButtons = new List<Button>();
            rollLabels = new List<Label>();
            InitializeComponent();
        }

        //save/create weapon
        private void button1_Click(object sender, EventArgs e)
        {
            ((Form1)Owner).AddWeapon(new Weapon(nameTextBox.Text, bonusRolls, propertiesTextBox.Lines, 
                finessCheckBox.Checked, profCheckBox.Checked,damageRoll));
            this.Close();
        }

        //display new roll form
        private void button2_Click(object sender, EventArgs e)
        {
            CustomRollForm rollPage = new CustomRollForm(1,1);
            rollPage.ShowDialog(this);
        }

        //add the roll to the lists
        public void AddBonusRolls(List<int> nums, List<int> dice, int flat)
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

            bonusRolls.Add(new Roll(nums, dice, flat, type, rollNameTextBox.Text, rollOptionalCheckBox.Checked));
            TextBox box = new TextBox();
            box.Location = new Point(1, 1);
            box.Text = nameTextBox.Text;

            //add bonus roll textbox
            Button newButton = new Button();
            Label newBox = new Label();
            newBox.Location = new Point(bonusRollsLabel.Location.X + 8, bonusRollsLabel.Location.Y - 4);
            newButton.Location = new Point(bonusRollsLabel.Location.X - 8, bonusRollsLabel.Location.Y - 4);
            newBox.Text = rollNameTextBox.Text;
            newButton.Size = new Size(16,16);
            newButton.Font = new Font("Arial", 5.25f, FontStyle.Regular);
            newButton.Tag = "" + rollButtons.Count;
            newButton.Text = "x";
            rollNameTextBox.Text = "roll name";
            rollNameTextBox.ForeColor = Color.DimGray;
            newButton.Click += new EventHandler(XButtonClick);
            this.Controls.Add(newBox);
            this.Controls.Add(newButton);
            rollButtons.Add(newButton);
            rollLabels.Add(newBox);

            bonusRollsLabel.Location = new Point(bonusRollsLabel.Location.X, bonusRollsLabel.Location.Y - 20);

        }

        private void WeaponCreation_Load(object sender, EventArgs e)
        {
            bothRadioButton.Checked = true;
            this.ActiveControl = nameTextBox;
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
