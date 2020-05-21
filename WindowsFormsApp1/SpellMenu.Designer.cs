namespace WindowsFormsApp1
{
    partial class SpellMenu
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
            this.spellListBox = new System.Windows.Forms.ListBox();
            this.buttonNoPadding1 = new CustomButtons.ButtonNoPadding();
            this.deleteSpellButton = new CustomButtons.ButtonNoPadding();
            this.editSpellButton = new CustomButtons.ButtonNoPadding();
            this.spellLevellistBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // spellListBox
            // 
            this.spellListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.spellListBox.FormattingEnabled = true;
            this.spellListBox.ItemHeight = 20;
            this.spellListBox.Location = new System.Drawing.Point(12, 12);
            this.spellListBox.Name = "spellListBox";
            this.spellListBox.Size = new System.Drawing.Size(261, 184);
            this.spellListBox.TabIndex = 0;
            // 
            // buttonNoPadding1
            // 
            this.buttonNoPadding1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNoPadding1.Location = new System.Drawing.Point(12, 205);
            this.buttonNoPadding1.Name = "buttonNoPadding1";
            this.buttonNoPadding1.Size = new System.Drawing.Size(83, 45);
            this.buttonNoPadding1.TabIndex = 1;
            this.buttonNoPadding1.Text = "Create Spell";
            this.buttonNoPadding1.UseVisualStyleBackColor = true;
            this.buttonNoPadding1.Click += new System.EventHandler(this.CreateSpell_ButtonClick);
            // 
            // deleteSpellButton
            // 
            this.deleteSpellButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteSpellButton.Location = new System.Drawing.Point(101, 205);
            this.deleteSpellButton.Name = "deleteSpellButton";
            this.deleteSpellButton.Size = new System.Drawing.Size(83, 45);
            this.deleteSpellButton.TabIndex = 2;
            this.deleteSpellButton.Text = "Delete Spell";
            this.deleteSpellButton.UseVisualStyleBackColor = true;
            this.deleteSpellButton.Click += new System.EventHandler(this.deleteSpellButton_Click);
            // 
            // editSpellButton
            // 
            this.editSpellButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editSpellButton.Location = new System.Drawing.Point(190, 205);
            this.editSpellButton.Name = "editSpellButton";
            this.editSpellButton.Size = new System.Drawing.Size(83, 45);
            this.editSpellButton.TabIndex = 3;
            this.editSpellButton.Text = "Edit    Spell";
            this.editSpellButton.UseVisualStyleBackColor = true;
            // 
            // spellLevellistBox
            // 
            this.spellLevellistBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.spellLevellistBox.FormattingEnabled = true;
            this.spellLevellistBox.ItemHeight = 20;
            this.spellLevellistBox.Location = new System.Drawing.Point(279, 12);
            this.spellLevellistBox.Name = "spellLevellistBox";
            this.spellLevellistBox.Size = new System.Drawing.Size(86, 184);
            this.spellLevellistBox.TabIndex = 4;
            // 
            // SpellMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 261);
            this.Controls.Add(this.spellLevellistBox);
            this.Controls.Add(this.editSpellButton);
            this.Controls.Add(this.deleteSpellButton);
            this.Controls.Add(this.buttonNoPadding1);
            this.Controls.Add(this.spellListBox);
            this.Name = "SpellMenu";
            this.Text = "SpellMenu";
            this.Load += new System.EventHandler(this.SpellMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox spellListBox;
        private CustomButtons.ButtonNoPadding buttonNoPadding1;
        private CustomButtons.ButtonNoPadding deleteSpellButton;
        private CustomButtons.ButtonNoPadding editSpellButton;
        private System.Windows.Forms.ListBox spellLevellistBox;
    }
}