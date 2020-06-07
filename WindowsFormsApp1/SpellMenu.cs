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
        List<Spell> searchSpells;


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
        public void RefreshSpells(string search = "")
        {
            //clear list, then get spells from form1 then add to list
            spellListBox.Items.Clear();
            spells = ((Form1)Owner).Spells;
            List<int> knownSpells = ((Form1)Owner).KnownSpells;
            //make list and add spells being searched for to the list
            searchSpells = new List<Spell>();
            if (search == "null")
                search = searchBox.Text;
            foreach(Spell s in spells)
            {
                if(int.TryParse(search, out int result))
                {
                    //search by level
                    if(result == s.Level)
                        searchSpells.Add(s);
                }
                //search by name
                else if (s.Name.ToUpper().Contains(search.ToUpper()))
                    searchSpells.Add(s);
            }
            foreach (Spell s in searchSpells)
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
            deleteSpellButton.Enabled = searchSpells.Count > 0;
            learnSpellbutton.Enabled = searchSpells.Count > 0;
            editSpellButton.Enabled = searchSpells.Count > 0;
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
                    ((Form1)Owner).DeleteSpell(searchSpells[i - count].ID);
                    count++;
                }
                RefreshSpells("null");
                if (searchSpells.Count > 0)
                    spellListBox.SetSelected(Math.Max(0, index - 1), true);
            }
            if (searchSpells.Count == 0)
                deleteSpellButton.Enabled = false;
        }

        //when a spell is selected
        private void spellListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (spellListBox.SelectedIndex < 0)
                spellListBox.SetSelected(lastIndexSelected, true);
            else
                lastIndexSelected = spellListBox.SelectedIndex;
            Spell s = searchSpells[spellListBox.SelectedIndex];
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
                ((Form1)Owner).LearnSpell(searchSpells[i].ID);
            }
            RefreshSpells("null");
        }

        //open spell creation form editing selected spell
        private void editSpellButton_Click(object sender, EventArgs e)
        {
            int index = spellListBox.SelectedIndex;
            if (index >= 0)
            {
                SpellCreationForm spellCreation = new SpellCreationForm(searchSpells[index], searchSpells[index].ID);
                spellCreation.ShowDialog(this);
            }
        }

        //when the search bar enter/loses focus
        private void SearchBox_Enter(object sender, EventArgs e)
        {
            if (searchBox.Text == "search by name or level")
            {
                searchBox.Text = "";
                searchBox.ForeColor = DefaultForeColor;
            }
        }
        private void SearchBox_Leave(object sender, EventArgs e)
        {
            if (searchBox.Text == "")
            {
                searchBox.ForeColor = Color.DimGray;
                searchBox.Text = "search by name or level";
            }
        }

        //sort spell list box
        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            string search = ((TextBox)sender).Text;
            if (search == "search by name or level")
                search = "";
            RefreshSpells(search);
        }

        //clear spell search box
        private void xSearchButton_Click(object sender, EventArgs e)
        {
            searchBox.ForeColor = Color.DimGray;
            searchBox.Text = "search by name or level";
        }
    }
}
