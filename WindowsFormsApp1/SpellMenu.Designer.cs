﻿namespace WindowsFormsApp1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.castTimelabel = new System.Windows.Forms.Label();
            this.rangelabel = new System.Windows.Forms.Label();
            this.durationlabel = new System.Windows.Forms.Label();
            this.componentslabel = new System.Windows.Forms.Label();
            this.desc = new WindowsFormsApp1.CustomControls.CustomTextBoxLeftTop();
            this.search = new WindowsFormsApp1.CustomControls.CustomTextBoxLeft();
            this.xSearchButton = new CustomButtons.ButtonNoPadding();
            this.learnSpellbutton = new CustomButtons.ButtonNoPadding();
            this.editSpellButton = new CustomButtons.ButtonNoPadding();
            this.deleteSpellButton = new CustomButtons.ButtonNoPadding();
            this.buttonNoPadding1 = new CustomButtons.ButtonNoPadding();
            this.SuspendLayout();
            // 
            // spellListBox
            // 
            this.spellListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.spellListBox.FormattingEnabled = true;
            this.spellListBox.ItemHeight = 20;
            this.spellListBox.Location = new System.Drawing.Point(12, 25);
            this.spellListBox.Name = "spellListBox";
            this.spellListBox.ScrollAlwaysVisible = true;
            this.spellListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.spellListBox.Size = new System.Drawing.Size(357, 184);
            this.spellListBox.TabIndex = 1;
            this.spellListBox.SelectedIndexChanged += new System.EventHandler(this.spellListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Spell Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(315, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Level";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(368, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Cast Time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(368, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Range";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(368, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Duration";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(368, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Components";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(498, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(260, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "Description";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // castTimelabel
            // 
            this.castTimelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.castTimelabel.Location = new System.Drawing.Point(370, 42);
            this.castTimelabel.MaximumSize = new System.Drawing.Size(128, 30);
            this.castTimelabel.Name = "castTimelabel";
            this.castTimelabel.Size = new System.Drawing.Size(111, 18);
            this.castTimelabel.TabIndex = 13;
            // 
            // rangelabel
            // 
            this.rangelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rangelabel.Location = new System.Drawing.Point(370, 91);
            this.rangelabel.MaximumSize = new System.Drawing.Size(128, 30);
            this.rangelabel.Name = "rangelabel";
            this.rangelabel.Size = new System.Drawing.Size(113, 18);
            this.rangelabel.TabIndex = 14;
            // 
            // durationlabel
            // 
            this.durationlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.durationlabel.Location = new System.Drawing.Point(370, 138);
            this.durationlabel.MaximumSize = new System.Drawing.Size(128, 30);
            this.durationlabel.Name = "durationlabel";
            this.durationlabel.Size = new System.Drawing.Size(113, 18);
            this.durationlabel.TabIndex = 15;
            // 
            // componentslabel
            // 
            this.componentslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.componentslabel.Location = new System.Drawing.Point(370, 186);
            this.componentslabel.MaximumSize = new System.Drawing.Size(128, 30);
            this.componentslabel.Name = "componentslabel";
            this.componentslabel.Size = new System.Drawing.Size(113, 18);
            this.componentslabel.TabIndex = 16;
            // 
            // desc
            // 
            this.desc.Location = new System.Drawing.Point(498, 25);
            this.desc.Name = "desc";
            this.desc.Size = new System.Drawing.Size(262, 238);
            this.desc.TabIndex = 21;
            this.desc.TabStop = false;
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(142, 5);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(142, 17);
            this.search.TabIndex = 0;
            this.search.Enter += new System.EventHandler(this.SearchBox_Enter);
            this.search.Leave += new System.EventHandler(this.SearchBox_Leave);
            // 
            // xSearchButton
            // 
            this.xSearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xSearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F);
            this.xSearchButton.Location = new System.Drawing.Point(287, 5);
            this.xSearchButton.Name = "xSearchButton";
            this.xSearchButton.Size = new System.Drawing.Size(17, 17);
            this.xSearchButton.TabIndex = 19;
            this.xSearchButton.TabStop = false;
            this.xSearchButton.Text = "X";
            this.xSearchButton.UseVisualStyleBackColor = true;
            this.xSearchButton.Click += new System.EventHandler(this.xSearchButton_Click);
            // 
            // learnSpellbutton
            // 
            this.learnSpellbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.learnSpellbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.learnSpellbutton.Location = new System.Drawing.Point(255, 218);
            this.learnSpellbutton.Name = "learnSpellbutton";
            this.learnSpellbutton.Size = new System.Drawing.Size(114, 45);
            this.learnSpellbutton.TabIndex = 17;
            this.learnSpellbutton.TabStop = false;
            this.learnSpellbutton.Text = "Learn\r\nSpell";
            this.learnSpellbutton.UseVisualStyleBackColor = true;
            this.learnSpellbutton.Click += new System.EventHandler(this.learnSpellbutton_Click);
            // 
            // editSpellButton
            // 
            this.editSpellButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editSpellButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editSpellButton.Location = new System.Drawing.Point(376, 218);
            this.editSpellButton.Name = "editSpellButton";
            this.editSpellButton.Size = new System.Drawing.Size(113, 45);
            this.editSpellButton.TabIndex = 3;
            this.editSpellButton.TabStop = false;
            this.editSpellButton.Text = "Edit\r\nSpell";
            this.editSpellButton.UseVisualStyleBackColor = true;
            this.editSpellButton.Click += new System.EventHandler(this.editSpellButton_Click);
            // 
            // deleteSpellButton
            // 
            this.deleteSpellButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteSpellButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteSpellButton.Location = new System.Drawing.Point(134, 218);
            this.deleteSpellButton.Name = "deleteSpellButton";
            this.deleteSpellButton.Size = new System.Drawing.Size(114, 45);
            this.deleteSpellButton.TabIndex = 2;
            this.deleteSpellButton.TabStop = false;
            this.deleteSpellButton.Text = "Delete\r\nSpell";
            this.deleteSpellButton.UseVisualStyleBackColor = true;
            this.deleteSpellButton.Click += new System.EventHandler(this.deleteSpellButton_Click);
            // 
            // buttonNoPadding1
            // 
            this.buttonNoPadding1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNoPadding1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNoPadding1.Location = new System.Drawing.Point(12, 218);
            this.buttonNoPadding1.Name = "buttonNoPadding1";
            this.buttonNoPadding1.Size = new System.Drawing.Size(115, 45);
            this.buttonNoPadding1.TabIndex = 1;
            this.buttonNoPadding1.TabStop = false;
            this.buttonNoPadding1.Text = "Create\r\nSpell";
            this.buttonNoPadding1.UseVisualStyleBackColor = true;
            this.buttonNoPadding1.Click += new System.EventHandler(this.CreateSpell_ButtonClick);
            // 
            // SpellMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 273);
            this.Controls.Add(this.spellListBox);
            this.Controls.Add(this.desc);
            this.Controls.Add(this.search);
            this.Controls.Add(this.xSearchButton);
            this.Controls.Add(this.learnSpellbutton);
            this.Controls.Add(this.componentslabel);
            this.Controls.Add(this.durationlabel);
            this.Controls.Add(this.rangelabel);
            this.Controls.Add(this.castTimelabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.editSpellButton);
            this.Controls.Add(this.deleteSpellButton);
            this.Controls.Add(this.buttonNoPadding1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SpellMenu";
            this.Text = "Spells";
            this.Load += new System.EventHandler(this.SpellMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox spellListBox;
        private CustomButtons.ButtonNoPadding buttonNoPadding1;
        private CustomButtons.ButtonNoPadding deleteSpellButton;
        private CustomButtons.ButtonNoPadding editSpellButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label castTimelabel;
        private System.Windows.Forms.Label rangelabel;
        private System.Windows.Forms.Label durationlabel;
        private System.Windows.Forms.Label componentslabel;
        private CustomButtons.ButtonNoPadding learnSpellbutton;
        private CustomButtons.ButtonNoPadding xSearchButton;
        private CustomControls.CustomTextBoxLeft search;
        private CustomControls.CustomTextBoxLeftTop desc;
    }
}