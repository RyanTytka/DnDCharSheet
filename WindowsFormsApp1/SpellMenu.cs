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
    public partial class SpellMenu : Form
    {
        List<Spell> spells;
        int lastIndexSelected;

        public SpellMenu(List<Spell> spells)
        {
            this.spells = spells;

            InitializeComponent();
        }

        private void SpellMenu_Load(object sender, EventArgs e)
        {
            RefreshSpells();
            if (spellListBox.Items.Count > 0)
                spellListBox.SetSelected(0, true);
        }

        //clicked create spell button
        private void CreateSpell_ButtonClick(object sender, EventArgs e)
        {
            SpellCreationForm spellCreation = new SpellCreationForm();
            spellCreation.ShowDialog(this);
        }

        //refresh spell list after spell has been edited/added/deleted
        public void RefreshSpells()
        {
            //clear list, then get spells from form1 then add to list
            spellListBox.Items.Clear();
            spells = ((Form1)Owner).Spells;
            List<int> knownSpells = ((Form1)Owner).KnownSpells;
            foreach (Spell s in spells)
            {
                //adds name, then enough spaces to make level on the right of the string
                string line = "";
                if (knownSpells.Contains(s.ID)) //show what spells are already known
                    line = "(Learned) ";
                line += s.Name;
                int startPoint = line.Length;
                int numOfDashes = line.Length;
                bool tooLong = false;
                SizeF MessageSize = spellListBox.CreateGraphics().MeasureString(line, spellListBox.Font);
                while(MessageSize.Width > 265)
                {
                    //trim down names that are too long
                    line = line.Substring(0, line.Length - 1);
                    MessageSize = spellListBox.CreateGraphics().MeasureString(line, spellListBox.Font);
                    numOfDashes--;
                    tooLong = true;
                }
                if (tooLong)
                {
                    //add ...
                    line = line.Substring(0, line.Length - 2);
                    line += "...";
                }
                //create space on right side
                while (MessageSize.Width < 265 && !tooLong)
                {
                    //add i's until the string is a certain length
                    line += "i";
                    MessageSize = spellListBox.CreateGraphics().MeasureString(line, spellListBox.Font);
                    numOfDashes++;
                }
                line += "\t";
                //replace i's with spaces
                StringBuilder sb = new StringBuilder(line);
                for(int i = startPoint; i < numOfDashes;  i++)
                {
                    sb[i] = ' ';
                }
                line = sb.ToString();
                line += s.Level;
                spellListBox.Items.Add(line);
            }
            deleteSpellButton.Enabled = spells.Count > 0;
            learnSpellbutton.Enabled = spells.Count > 0;
            editSpellButton.Enabled = spells.Count > 0;
        }

        private void deleteSpellButton_Click(object sender, EventArgs e)
        {
            string text = "";
            if (spellListBox.SelectedIndices.Count > 1)
                text = "Are you sure you want to delete these spells?";
            else
                text = "Are you sure you want to delete this spell?";
            DialogResult result = MessageBox.Show(this, text, "Confirmation", MessageBoxButtons.YesNo, 
                MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                int count = 0;      //used to offset the indices while deleting multiple spells
                int index = spellListBox.SelectedIndex;
                foreach (int i in spellListBox.SelectedIndices)
                {
                    ((Form1)Owner).DeleteSpell(spells[i - count].ID);
                    count++;
                }
                RefreshSpells();
                if (spells.Count > 0)
                    spellListBox.SetSelected(Math.Max(0, index - 1), true);
            }
            if (spells.Count == 0)
                deleteSpellButton.Enabled = false;
        }

        //when a spell is selected
        private void spellListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (spellListBox.SelectedIndex < 0)
                spellListBox.SetSelected(lastIndexSelected, true);
            else
                lastIndexSelected = spellListBox.SelectedIndex;
            Spell s = spells[spellListBox.SelectedIndex];
            castTimelabel.Text = s.CastTime;
            rangelabel.Text = s.Range;
            durationlabel.Text = s.Duration;
            componentslabel.Text = s.Components;
            descriptionlabel.Text = s.Description;
            //if multiple items are selected
            if(spellListBox.SelectedIndices.Count > 1)
            {
                deleteSpellButton.Text = "Delete  Spells";
                learnSpellbutton.Text = "Learn  Spells";
                editSpellButton.Enabled = false;
            }
            else
            {
                deleteSpellButton.Text = "Delete  Spell";
                learnSpellbutton.Text = "Learn    Spell";
                editSpellButton.Enabled = true;

            }
        }

        //add selected spell to knownSpells in form1
        private void learnSpellbutton_Click(object sender, EventArgs e)
        {
            foreach (int i in spellListBox.SelectedIndices)
            {
                ((Form1)Owner).LearnSpell(spells[i].ID);
            }
            RefreshSpells();
        }

        //open spell creation form editing selected spell
        private void editSpellButton_Click(object sender, EventArgs e)
        {
            int index = spellListBox.SelectedIndex;
            if (index >= 0)
            {
                SpellCreationForm spellCreation = new SpellCreationForm(spells[index], spells[index].ID);
                spellCreation.ShowDialog(this);
            }
        }
    }
}
