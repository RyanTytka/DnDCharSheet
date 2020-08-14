using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms.Integration;

namespace WindowsFormsApp1
{
    public partial class CharacterInfo : Form
    {
        byte[] portraitBytes = null;

        System.Windows.Controls.TextBox profBox, personalityTraitsBox, idealsBox, bondsBox, flawsBox, backstoryBox, alliesBox, notesBox;

        public CharacterInfo()
        {
            InitializeComponent();
        }

        private void setPicButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadPicDialog = new OpenFileDialog();
            loadPicDialog.Title = "Load Picture";
            loadPicDialog.Filter = "";
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            string sep = string.Empty;
            loadPicDialog.DefaultExt = ".png"; // Default file extension 
            foreach (var c in codecs)
            {
                string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                loadPicDialog.Filter = String.Format("{0}{1}{2} ({3})|{3}", loadPicDialog.Filter, sep, codecName, c.FilenameExtension);
                sep = "|";
            }
            loadPicDialog.Filter += "|HEIC Files|*.HEIC";
            var codecFilter = "";
            foreach (var codec in codecs)
            {
                codecFilter += codec.FilenameExtension + ";";
            }
            codecFilter += "*.HEIC";
            loadPicDialog.Filter = String.Format("{0}{1}{2}|{3}", loadPicDialog.Filter, sep, "All Image Files", codecFilter);
            loadPicDialog.Filter = String.Format("{0}{1}{2}|{3}", loadPicDialog.Filter, sep, "All Files", "*.*");
            loadPicDialog.FilterIndex = 7;
            portrait.SizeMode = PictureBoxSizeMode.StretchImage;
            DialogResult result = loadPicDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                portrait.ImageLocation = loadPicDialog.FileName;

                // save image to byte array
                using (Image image = Image.FromFile(portrait.ImageLocation))
                {
                    using (MemoryStream m = new MemoryStream())
                    {
                        image.Save(m, image.RawFormat);
                        portraitBytes = m.ToArray();
                    }
                }

            }
        }

        //sends data to the main form to save info
        private void CharacterInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form1 = this.Owner as Form1;
            form1.portrait = portraitBytes;
            form1.charInfo[0] = profBox.Text;
            form1.charInfo[1] = personalityTraitsBox.Text;
            form1.charInfo[2] = idealsBox.Text;
            form1.charInfo[3] = bondsBox.Text;
            form1.charInfo[4] = flawsBox.Text;
            form1.charInfo[5] = backstoryBox.Text;
            form1.charInfo[6] = alliesBox.Text;
            form1.charInfo[7] = notesBox.Text;
        }

        private void CharacterInfo_Load(object sender, EventArgs e)
        {
            profBox = (prof.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;
            personalityTraitsBox = (personalityTraits.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;
            idealsBox = (ideals.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;
            bondsBox = (bonds.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;
            flawsBox = (flaws.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;
            backstoryBox = (backstory.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;
            alliesBox = (allies.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;
            notesBox = (notes.Controls[0] as ElementHost).Child as System.Windows.Controls.TextBox;


            Form1 form1 = this.Owner as Form1;
            if (form1.portrait != null)
            {
                portraitBytes = ((Form1)this.Owner).portrait;
                portrait.Image = (Bitmap)((new ImageConverter()).ConvertFrom(portraitBytes));
                portrait.SizeMode = PictureBoxSizeMode.StretchImage; 
            }
            profBox.Text = form1.charInfo[0];
            personalityTraitsBox.Text = form1.charInfo[1];
            idealsBox.Text = form1.charInfo[2];
            bondsBox.Text = form1.charInfo[3];
            flawsBox.Text = form1.charInfo[4];
            backstoryBox.Text = form1.charInfo[5];
            alliesBox.Text = form1.charInfo[6];
            notesBox.Text = form1.charInfo[7];
            profBox.Select(prof.Text.Length, 0);
        }
    }
}
