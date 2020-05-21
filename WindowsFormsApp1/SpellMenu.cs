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
            spellLevellistBox.Items.Clear();
            spells = ((Form1)Owner).Spells;
            foreach (Spell s in spells)
            {
                spellListBox.Items.Add(s.Name);
                spellLevellistBox.Items.Add(s.Level);
            }
        }

        private void deleteSpellButton_Click(object sender, EventArgs e)
        {
            ((Form1)Owner).DeleteSpell(spellListBox.SelectedIndex);
            RefreshSpells();
        }
    }
}
