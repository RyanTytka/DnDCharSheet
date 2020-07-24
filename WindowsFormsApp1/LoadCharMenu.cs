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

namespace WindowsFormsApp1
{
    public partial class LoadCharMenu : Form
    {
        List<string> chars = new List<string>();
        int saveOrLoad;
        string directory = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\DnD Data";

        /// <param name="saveOrLoad">1=save, 2=load</param>
        public LoadCharMenu(int _saveOrLoad, string _name = "", string _description = "")
        {
            saveOrLoad = _saveOrLoad;
            if(_name != "")
            {
                nametextBox.Text = _name;
                descriptiontextBox.Text = _description;
            }

            InitializeComponent();
        }

        //on load
        private void LoadCharMenu_Load(object sender, EventArgs e)
        {
            if (saveOrLoad == 1)
            {
                SubmitButton.Text = "Save";
            }
            else
            {
                SubmitButton.Text = "Load";
                SubmitButton.Enabled = false;
            }

            loadCharData();
        }

        // gets characters from file and inputs to form
        public void loadCharData()
        {
            chars.Clear();
            if(!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (!File.Exists(directory + "\\charData"))
            {
                Stream outStream = File.OpenWrite(directory + "\\charData");
                BinaryWriter output = new BinaryWriter(outStream);
                output.Write(0);
                output.Close();
            }

            Stream inStream = File.OpenRead(directory + "\\charData");
            BinaryReader reader = new BinaryReader(inStream);
            int numChars = reader.ReadInt32();
            for (int i = 0; i < numChars; i++)
            {
                string name = reader.ReadString();
                chars.Add(name);
                if (File.Exists(directory + "\\" + name))
                    characterListBox.Items.Add(chars[i]);
            }
            reader.Close();

        }

        // saves characters into file
        public void saveCharData()
        {
            Stream outStream = File.OpenWrite(directory + "\\charData");
            BinaryWriter output = new BinaryWriter(outStream);
            //save data into file
            output.Write(chars.Count);
            for (int i = 0; i < chars.Count; i++)
            {
                output.Write(chars[i]);
            }
            output.Close();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (SubmitButton.Text == "Save")
            {
                if (!chars.Contains(nametextBox.Text + "   -   " + descriptiontextBox.Text))
                    chars.Add(nametextBox.Text + "   -   " + descriptiontextBox.Text);
                ((Form1)Owner).saveFile(directory + "\\" + nametextBox.Text + "   -   " + descriptiontextBox.Text);
                saveCharData();
            }
            else
            {
                ((Form1)Owner).loadFile(directory + "\\" + chars[characterListBox.SelectedIndex]);
            }
            this.Close();
        }

        // sets save info to selected item
        private void characterListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (characterListBox.SelectedIndex < 0)
                return;

            SubmitButton.Enabled = true;

            string fullStr = characterListBox.SelectedItem.ToString();
            nametextBox.Text =  fullStr.Substring(0, fullStr.IndexOf("   -   "));
            descriptiontextBox.Text =  fullStr.Substring(fullStr.IndexOf("   -   ") + 7);
        }

        // save char from text file
        private void importbutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog importFileDialog = new OpenFileDialog();
            importFileDialog.Title = "Import a Character";
            importFileDialog.Filter = "Player Character| *.pc";
            DialogResult result = importFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fileName = importFileDialog.FileName;
                ((Form1)Owner).loadFile(fileName);
                this.Close();
            }
        }

        private void Exportbutton_Click(object sender, EventArgs e)
        {
            SaveFileDialog exportFileDialog = new SaveFileDialog();
            exportFileDialog.Title = "Export a Character";
            exportFileDialog.Filter = "Player Character| *.pc";
            DialogResult result = exportFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fileName = exportFileDialog.FileName;
                ((Form1)Owner).saveFile(fileName);
                this.Close();
            }
        }

        // submit when double clicked
        private void characterListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(characterListBox.SelectedIndex >= 0)
                SubmitButton_Click(SubmitButton, new EventArgs());
        }

        // delete selected char from memory
        private void deletebutton_Click(object sender, EventArgs e)
        {
            if (characterListBox.SelectedIndex < 0)
                return;

            //confirmation
            string message = $"You are about to delete {characterListBox.SelectedItem.ToString()}.  Are you sure?";
            DialogResult result = MessageBox.Show(message, "Delete Character", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
                return;

            //delete
            File.Delete(directory + "\\" + characterListBox.SelectedItem.ToString());
            chars.Remove(characterListBox.SelectedItem.ToString());
            characterListBox.Items.Remove(characterListBox.SelectedItem);
            saveCharData();
                nametextBox.Text = "";
                descriptiontextBox.Text = "";
            if (saveOrLoad == 2)
            {
                SubmitButton.Enabled = false;
            }
        }
    }
}
