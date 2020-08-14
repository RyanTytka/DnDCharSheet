namespace WindowsFormsApp1
{
    partial class CharacterInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.portrait = new System.Windows.Forms.PictureBox();
            this.setPicButton = new CustomButtons.ButtonNoPadding();
            this.label2 = new System.Windows.Forms.Label();
            this.prof = new WindowsFormsApp1.CustomControls.CustomTextBoxLeftTop();
            this.personalityTraits = new WindowsFormsApp1.CustomControls.CustomTextBoxLeftTop();
            this.ideals = new WindowsFormsApp1.CustomControls.CustomTextBoxLeftTop();
            this.bonds = new WindowsFormsApp1.CustomControls.CustomTextBoxLeftTop();
            this.flaws = new WindowsFormsApp1.CustomControls.CustomTextBoxLeftTop();
            this.backstory = new WindowsFormsApp1.CustomControls.CustomTextBoxLeftTop();
            this.allies = new WindowsFormsApp1.CustomControls.CustomTextBoxLeftTop();
            this.notes = new WindowsFormsApp1.CustomControls.CustomTextBoxLeftTop();
            ((System.ComponentModel.ISupportInitialize)(this.portrait)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(14, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Proficiencies / Languages";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(211, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Personality Traits";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(211, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ideals";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(211, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "Bonds";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(211, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "Flaws";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(401, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(182, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Allies / Organizations";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(401, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(182, 16);
            this.label10.TabIndex = 12;
            this.label10.Text = "Backstory";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // portrait
            // 
            this.portrait.Location = new System.Drawing.Point(17, 22);
            this.portrait.Name = "portrait";
            this.portrait.Size = new System.Drawing.Size(179, 167);
            this.portrait.TabIndex = 17;
            this.portrait.TabStop = false;
            // 
            // setPicButton
            // 
            this.setPicButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setPicButton.Location = new System.Drawing.Point(69, 191);
            this.setPicButton.Name = "setPicButton";
            this.setPicButton.Size = new System.Drawing.Size(75, 18);
            this.setPicButton.TabIndex = 18;
            this.setPicButton.Text = "Set Picture";
            this.setPicButton.UseVisualStyleBackColor = true;
            this.setPicButton.Click += new System.EventHandler(this.setPicButton_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(596, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Notes / Misc.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // prof
            // 
            this.prof.Location = new System.Drawing.Point(17, 236);
            this.prof.Name = "prof";
            this.prof.Size = new System.Drawing.Size(179, 129);
            this.prof.TabIndex = 21;
            // 
            // personalityTraits
            // 
            this.personalityTraits.Location = new System.Drawing.Point(214, 24);
            this.personalityTraits.Name = "personalityTraits";
            this.personalityTraits.Size = new System.Drawing.Size(179, 109);
            this.personalityTraits.TabIndex = 22;
            // 
            // ideals
            // 
            this.ideals.Location = new System.Drawing.Point(214, 153);
            this.ideals.Name = "ideals";
            this.ideals.Size = new System.Drawing.Size(179, 57);
            this.ideals.TabIndex = 23;
            // 
            // bonds
            // 
            this.bonds.Location = new System.Drawing.Point(214, 231);
            this.bonds.Name = "bonds";
            this.bonds.Size = new System.Drawing.Size(179, 57);
            this.bonds.TabIndex = 24;
            // 
            // flaws
            // 
            this.flaws.Location = new System.Drawing.Point(214, 308);
            this.flaws.Name = "flaws";
            this.flaws.Size = new System.Drawing.Size(179, 57);
            this.flaws.TabIndex = 25;
            // 
            // backstory
            // 
            this.backstory.Location = new System.Drawing.Point(404, 24);
            this.backstory.Name = "backstory";
            this.backstory.Size = new System.Drawing.Size(179, 186);
            this.backstory.TabIndex = 26;
            // 
            // allies
            // 
            this.allies.Location = new System.Drawing.Point(404, 231);
            this.allies.Name = "allies";
            this.allies.Size = new System.Drawing.Size(179, 134);
            this.allies.TabIndex = 27;
            // 
            // notes
            // 
            this.notes.Location = new System.Drawing.Point(601, 24);
            this.notes.Name = "notes";
            this.notes.Size = new System.Drawing.Size(179, 341);
            this.notes.TabIndex = 28;
            // 
            // CharacterInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 377);
            this.Controls.Add(this.notes);
            this.Controls.Add(this.allies);
            this.Controls.Add(this.backstory);
            this.Controls.Add(this.flaws);
            this.Controls.Add(this.bonds);
            this.Controls.Add(this.ideals);
            this.Controls.Add(this.personalityTraits);
            this.Controls.Add(this.prof);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.setPicButton);
            this.Controls.Add(this.portrait);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CharacterInfo";
            this.Text = "Character Info";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CharacterInfo_FormClosed);
            this.Load += new System.EventHandler(this.CharacterInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.portrait)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox portrait;
        private CustomButtons.ButtonNoPadding setPicButton;
        private System.Windows.Forms.Label label2;
        private CustomControls.CustomTextBoxLeftTop prof;
        private CustomControls.CustomTextBoxLeftTop personalityTraits;
        private CustomControls.CustomTextBoxLeftTop ideals;
        private CustomControls.CustomTextBoxLeftTop bonds;
        private CustomControls.CustomTextBoxLeftTop flaws;
        private CustomControls.CustomTextBoxLeftTop backstory;
        private CustomControls.CustomTextBoxLeftTop allies;
        private CustomControls.CustomTextBoxLeftTop notes;
    }
}