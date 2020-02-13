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
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }
    }
}
/*
//load file and open editor
OpenFileDialog loadFile = new OpenFileDialog();
loadFile.Title = "Open a level file";
    loadFile.Filter = "Level Files| *.level";
    DialogResult result = loadFile.ShowDialog();
    if (result == DialogResult.OK)
    {
        Editor editor = new Editor(loadFile.FileName);
editor.ShowDialog();
    }




string filePath = null;
    SaveFileDialog saveFile = new SaveFileDialog();
    saveFile.Title = "Save a level file";
    saveFile.Filter = "Level Files| *.level";
    DialogResult result = saveFile.ShowDialog();
    if (result == DialogResult.OK && saveFile.FileName != null)
    {
        filePath = saveFile.FileNames[0];
        Stream outStream = File.OpenWrite(filePath);
        BinaryWriter output = new BinaryWriter(outStream);
        //save data into file
        output.Write(MAP_WIDTH);
        output.Write(MAP_HEIGHT);
        foreach (PictureBox pic in pics)
        {
            if(pic.BackColor == Color.Black)
            {
                output.Write(1);
            }
            else
            {
                output.Write(0);
            }
        }
        output.Close();
        MessageBox.Show("File saved successfully", "Save loaded");
        if (!saved)
            this.Text = "Editor - " + filePath;
        saved = true;
    }



                //open file stream
            OpenFileDialog loadFile = new OpenFileDialog();
            loadFile.Title = "Load a level file";
            loadFile.Filter = "Level Files| *.level";
            DialogResult result = loadFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filePath = loadFile.FileNames[0];
                loadMap(filePath);
                MessageBox.Show("File loaded successfully", "File loaded");
            }





    Stream inStream = File.OpenRead(filePath);
            BinaryReader reader = new BinaryReader(inStream);
            MAP_WIDTH = reader.ReadInt32();
            MAP_HEIGHT = reader.ReadInt32();
            //reset map editor
            foreach (PictureBox pic in pics)
            {
                mapBox.Controls.Remove(pic);
            }
            pics.Clear();
            int buttonSize = 480 / MAP_HEIGHT;
            this.Size = new Size(187 + (buttonSize * MAP_WIDTH), 570);
            //create new boxes
            for (int i = 0; i < MAP_WIDTH * MAP_HEIGHT; i++)
            {
                PictureBox box = new PictureBox();
                box.BackColor = Color.Gray;
                box.Size = new Size(buttonSize, buttonSize);
                box.Location = new Point(10 + ((i % MAP_WIDTH) * buttonSize), 20 + (i / MAP_WIDTH) * buttonSize);
                mapBox.Size = new Size((buttonSize * MAP_HEIGHT) + 20, 510);
                box.MouseDown += paint;
                box.MouseEnter += paint;
                box.MouseLeave += noHover;
                box.Click += switchColor;
                mapBox.Controls.Add(box);
                pics.Add(box);
            }
            //load in colors
            foreach (PictureBox pic in pics)
            {
                PictureBox newBox = pic;
                if (reader.ReadInt32()== 1)
                    newBox.BackColor = Color.Black;
                else
                    newBox.BackColor = Color.Gray;
            }
            saved = true;
            this.Text = "Editor - " + filePath;
            reader.Close();


    */
