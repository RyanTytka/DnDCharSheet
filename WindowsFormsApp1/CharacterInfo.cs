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

namespace WindowsFormsApp1
{
    public partial class CharacterInfo : Form
    {
        byte[] portraitBytes = null;
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
            form1.charInfo[0] = ProftextBox.Text;
            form1.charInfo[1] = personalitytextBox.Text;
            form1.charInfo[2] = idealstextBox.Text;
            form1.charInfo[3] = bondstextBox.Text;
            form1.charInfo[4] = flawstextBox.Text;
            form1.charInfo[5] = backstorytextBox.Text;
            form1.charInfo[6] = alliestextBox.Text;
            form1.charInfo[7] = misctextBox.Text;
        }

        private void CharacterInfo_Load(object sender, EventArgs e)
        {
            Form1 form1 = this.Owner as Form1;
            if (form1.portrait != null)
            {
                portraitBytes = ((Form1)this.Owner).portrait;
                portrait.Image = (Bitmap)((new ImageConverter()).ConvertFrom(portraitBytes));
                portrait.SizeMode = PictureBoxSizeMode.StretchImage; 
            }
            ProftextBox.Text = form1.charInfo[0];
            personalitytextBox.Text = form1.charInfo[1];
            idealstextBox.Text = form1.charInfo[2];
            bondstextBox.Text = form1.charInfo[3];
            flawstextBox.Text = form1.charInfo[4];
            backstorytextBox.Text = form1.charInfo[5];
            alliestextBox.Text = form1.charInfo[6];
            misctextBox.Text = form1.charInfo[7];
            ProftextBox.Select(ProftextBox.Text.Length, 0);
        }
    }
}
