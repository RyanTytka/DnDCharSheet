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

    public partial class SpellMenu : Form
    {
        //global brushes with ordinary/selected colors
        private SolidBrush reportsForegroundBrushSelected = new SolidBrush(Color.White);
        private SolidBrush reportsForegroundBrush = new SolidBrush(Color.Black);
        private SolidBrush reportsBackgroundBrushSelected = new SolidBrush(Color.Maroon);
        private SolidBrush reportsBackgroundBrush1 = new SolidBrush(Color.White);

        List<Spell> spells;
        List<Spell> searchSpells;
        object lastSelectedSpell;

        System.Windows.Controls.TextBox searchBox, descBox;


        public SpellMenu(List<Spell> spells)
        {
            this.spells = spells;

            InitializeComponent();
        }

        private void SpellMenu_Load(object sender, EventArgs e)
        {
            searchBox = (search.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;
            descBox = (desc.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;
            searchBox.TextChanged += searchBox_TextChanged;
            searchBox.Text = "search by name or level";
            searchBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(105, 105, 105));
            searchBox.FontSize = 10;

            spellListBox.DrawMode = DrawMode.OwnerDrawFixed;
            spellListBox.DrawItem += listbox_DrawItem;

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
            if (search == "search by name or level")
                search = "";
            if (search == "")
                //sort by level
                for(int i = 0; i < 10; i++)
                {
                    //create list of spells of level i
                    List<Spell> levelISpells = new List<Spell>();
                    foreach(Spell s in spells)
                    {
                        if (s.Level == i)
                            levelISpells.Add(s);
                    }
                    //sort spells
                    levelISpells.Sort(delegate (Spell s1, Spell s2)
                    {
                        return s1.Name.CompareTo(s2.Name);
                    });
                    //add spells to searchSpells
                    searchSpells.AddRange(levelISpells);
                }
            else
                //sort by search filter
                foreach (Spell s in spells)
                {
                    if (int.TryParse(search, out int result))
                    {
                        //search by level
                        if (result == s.Level)
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
                while(MessageSize.Width > 245)
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
                while (MessageSize.Width < 245 && !tooLong)
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
            string text;
            if (spellListBox.SelectedIndices.Count > 1)
                text = "Are you sure you want to delete these spells?";
            else
                text = "Are you sure you want to delete this spell?";
            DialogResult result = MessageBox.Show(this, text, "Confirmation", MessageBoxButtons.YesNo, 
                MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                int index = spellListBox.SelectedIndex;
                foreach (int i in spellListBox.SelectedIndices)
                {
                    ((Form1)Owner).DeleteSpell(searchSpells[i].ID);
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
            if (spellListBox.Items.Count == 0)
            {
                castTimelabel.Text = "";
                rangelabel.Text = "";
                durationlabel.Text = "";
                componentslabel.Text = "";
                descBox.Text = "";
                return;
            }

            if (spellListBox.SelectedIndex < 0)
            {
                if (spellListBox.Items.IndexOf(lastSelectedSpell?? new object()) < 0)
                    spellListBox.SetSelected(0, true);
                else
                    spellListBox.SetSelected(spellListBox.Items.IndexOf(lastSelectedSpell), true);
            }
            else
                lastSelectedSpell = spellListBox.SelectedItem;
            Spell s = searchSpells[spellListBox.SelectedIndex];
            castTimelabel.Text = s.CastTime;
            rangelabel.Text = s.Range;
            durationlabel.Text = s.Duration;
            componentslabel.Text = s.Components;
            descBox.Text = s.Description;
            //if multiple items are selected
            if(spellListBox.SelectedIndices.Count > 1)
            {
                deleteSpellButton.Text = "Delete\nSpells";
                learnSpellbutton.Text = "Learn\nSpells";
                editSpellButton.Enabled = false;
            }
            else
            {
                deleteSpellButton.Text = "Delete\nSpell";
                learnSpellbutton.Text = "Learn\nSpell";
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
                searchBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0));
            }
        }
        private void SearchBox_Leave(object sender, EventArgs e)
        {
            if (searchBox.Text == "")
            {
                searchBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(105, 105, 105));
                searchBox.Text = "search by name or level";
            }
        }

        //sort spell list box
        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            string s = searchBox.Text;
            if (s == "search by name or level")
                s = "";
            RefreshSpells(s);
            spellListBox_SelectedIndexChanged(null, null);
        }

        //clear spell search box
        private void xSearchButton_Click(object sender, EventArgs e)
        {
            searchBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(105, 105, 105));
            searchBox.Text = "search by name or level";
        }

        //custom method to draw the items
        private void listbox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            bool selected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);

            int index = e.Index;
            if (index >= 0 && index < spellListBox.Items.Count)
            {
                string text = spellListBox.Items[index].ToString();
                Graphics g = e.Graphics;

                //background:
                SolidBrush backgroundBrush;   
                if (selected)
                    backgroundBrush = reportsBackgroundBrushSelected;
                else
                    backgroundBrush = reportsBackgroundBrush1;
                g.FillRectangle(backgroundBrush, e.Bounds);

                //text:
                SolidBrush foregroundBrush = (selected) ? reportsForegroundBrushSelected : reportsForegroundBrush;
                g.DrawString(text, e.Font, foregroundBrush, spellListBox.GetItemRectangle(index).Location);
            }

            e.DrawFocusRectangle();
        }

    }
}
