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
            foreach (Spell s in spells)
            {
                //adds name, then enough spaces to make level on the right of the string
                string line = s.Name;
                int numOfDashes = s.Name.Length;
                SizeF MessageSize = spellListBox.CreateGraphics().MeasureString(line, spellListBox.Font);
                while (MessageSize.Width < 265)
                {
                    //add i's until the string is a certain length
                    line += "i";
                    MessageSize = spellListBox.CreateGraphics().MeasureString(line, spellListBox.Font);
                    numOfDashes++;
                }
                line += "\t";
                //replace i's with spaces
                StringBuilder sb = new StringBuilder(line);
                for(int i = s.Name.Length; i < numOfDashes;  i++)
                {
                    sb[i] = ' ';
                }
                line = sb.ToString();
                line += s.Level;
                spellListBox.Items.Add(line);
            }
        }

        private void deleteSpellButton_Click(object sender, EventArgs e)
        {
            int index = spellListBox.SelectedIndex;
            ((Form1)Owner).DeleteSpell(index);
            RefreshSpells();
            if(spells.Count > 0)
                spellListBox.SetSelected(Math.Max(0, index - 1), true);
        }

        //when a spell is selected
        private void spellListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Spell s = spells[spellListBox.SelectedIndex];
            castTimelabel.Text = s.CastTime;
            rangelabel.Text = s.Range;
            durationlabel.Text = s.Duration;
            componentslabel.Text = s.Components;
            durationlabel.Text = s.Description;
        }

        //add selected spell to knownSpells in form1
        private void learnSpellbutton_Click(object sender, EventArgs e)
        {
            ((Form1)Owner).LearnSpell(spellListBox.SelectedIndex);
        }

        //open spell creation form editing selected spell
        private void editSpellButton_Click(object sender, EventArgs e)
        {
            int index = spellListBox.SelectedIndex;
            SpellCreationForm spellCreation = new SpellCreationForm(spells[index], index);
            spellCreation.ShowDialog(this);
        }
    }
}
