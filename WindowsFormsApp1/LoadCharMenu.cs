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
                chars.Add(reader.ReadString());
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
                chars.Add(nametextBox.Text + " - " + descriptiontextBox.Text);
                ((Form1)Owner).saveFile(directory + "\\" + nametextBox.Text + " - " + descriptiontextBox.Text);
                saveCharData();
            }
            else
                ((Form1)Owner).loadFile(directory + "\\" + chars[characterListBox.SelectedIndex]);
            this.Close();
        }
    }
}
