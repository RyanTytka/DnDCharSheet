namespace WindowsFormsApp1
{
    partial class SpellCreationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpellCreationForm));
            this.headerLabel = new System.Windows.Forms.Label();
            this.propertiesLabel = new System.Windows.Forms.Label();
            this.bonusRollsLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.multiplierLabel = new System.Windows.Forms.Label();
            this.helpLabel = new System.Windows.Forms.Label();
            this.helpDisplaylabel = new System.Windows.Forms.Label();
            this.SaveButton = new CustomButtons.ButtonNoPadding();
            this.spellNameTextbox = new WindowsFormsApp1.CustomControls.CustomTextBoxLeft();
            this.castTimeTextbox = new WindowsFormsApp1.CustomControls.CustomTextBoxLeft();
            this.durationTextbox = new WindowsFormsApp1.CustomControls.CustomTextBoxLeft();
            this.RangeTextbox = new WindowsFormsApp1.CustomControls.CustomTextBoxLeft();
            this.componentsTextBox = new WindowsFormsApp1.CustomControls.CustomTextBoxLeft();
            this.descriptionTextbox = new WindowsFormsApp1.CustomControls.CustomTextBoxLeftTop();
            this.rollNameTextbox = new WindowsFormsApp1.CustomControls.CustomTextBoxLeft();
            this.addRollButton = new CustomButtons.ButtonNoPadding();
            this.AttackRollcheckBox = new WindowsFormsApp1.CustomControls.CustomCheckBox();
            this.multipliercheckBox = new WindowsFormsApp1.CustomControls.CustomCheckBox();
            this.DieAmountnumericUpDown = new WindowsFormsApp1.CustomControls.CustomUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.DieNumnumericUpDown = new WindowsFormsApp1.CustomControls.CustomUpDown();
            this.LevelnumericUpDown = new WindowsFormsApp1.CustomControls.CustomUpDown();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.Location = new System.Drawing.Point(5, 0);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(335, 36);
            this.headerLabel.TabIndex = 1;
            this.headerLabel.Text = "New Spell";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // propertiesLabel
            // 
            this.propertiesLabel.AutoSize = true;
            this.propertiesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.propertiesLabel.Location = new System.Drawing.Point(74, 148);
            this.propertiesLabel.Name = "propertiesLabel";
            this.propertiesLabel.Size = new System.Drawing.Size(79, 13);
            this.propertiesLabel.TabIndex = 13;
            this.propertiesLabel.Text = "Description  ";
            // 
            // bonusRollsLabel
            // 
            this.bonusRollsLabel.AutoSize = true;
            this.bonusRollsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.bonusRollsLabel.Location = new System.Drawing.Point(261, 108);
            this.bonusRollsLabel.Name = "bonusRollsLabel";
            this.bonusRollsLabel.Size = new System.Drawing.Size(48, 16);
            this.bonusRollsLabel.TabIndex = 20;
            this.bonusRollsLabel.Text = "Rolls:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(74, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Spell Name ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Casting Time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Range";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(112, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Duration";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(122, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Components";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(183, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Level";
            // 
            // multiplierLabel
            // 
            this.multiplierLabel.AutoSize = true;
            this.multiplierLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold);
            this.multiplierLabel.Location = new System.Drawing.Point(240, 168);
            this.multiplierLabel.Name = "multiplierLabel";
            this.multiplierLabel.Size = new System.Drawing.Size(87, 13);
            this.multiplierLabel.TabIndex = 37;
            this.multiplierLabel.Text = "Multiplier Dice";
            // 
            // helpLabel
            // 
            this.helpLabel.AutoSize = true;
            this.helpLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.helpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.75F, System.Drawing.FontStyle.Bold);
            this.helpLabel.Location = new System.Drawing.Point(317, 151);
            this.helpLabel.Name = "helpLabel";
            this.helpLabel.Size = new System.Drawing.Size(12, 11);
            this.helpLabel.TabIndex = 41;
            this.helpLabel.Text = "?";
            this.helpLabel.MouseEnter += new System.EventHandler(this.ShowHelp);
            this.helpLabel.MouseLeave += new System.EventHandler(this.HideHelp);
            // 
            // helpDisplaylabel
            // 
            this.helpDisplaylabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.helpDisplaylabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.helpDisplaylabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.helpDisplaylabel.Location = new System.Drawing.Point(170, 299);
            this.helpDisplaylabel.Name = "helpDisplaylabel";
            this.helpDisplaylabel.Size = new System.Drawing.Size(177, 172);
            this.helpDisplaylabel.TabIndex = 42;
            this.helpDisplaylabel.Text = resources.GetString("helpDisplaylabel.Text");
            this.helpDisplaylabel.Visible = false;
            // 
            // SaveButton
            // 
            this.SaveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.SaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(232, 50);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(106, 20);
            this.SaveButton.TabIndex = 45;
            this.SaveButton.Text = "Create Spell";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveSpell);
            // 
            // spellNameTextbox
            // 
            this.spellNameTextbox.Location = new System.Drawing.Point(5, 50);
            this.spellNameTextbox.Name = "spellNameTextbox";
            this.spellNameTextbox.Size = new System.Drawing.Size(216, 19);
            this.spellNameTextbox.TabIndex = 46;
            // 
            // castTimeTextbox
            // 
            this.castTimeTextbox.Location = new System.Drawing.Point(5, 87);
            this.castTimeTextbox.Name = "castTimeTextbox";
            this.castTimeTextbox.Size = new System.Drawing.Size(82, 19);
            this.castTimeTextbox.TabIndex = 47;
            // 
            // durationTextbox
            // 
            this.durationTextbox.Location = new System.Drawing.Point(93, 87);
            this.durationTextbox.Name = "durationTextbox";
            this.durationTextbox.Size = new System.Drawing.Size(82, 19);
            this.durationTextbox.TabIndex = 48;
            // 
            // RangeTextbox
            // 
            this.RangeTextbox.Location = new System.Drawing.Point(5, 125);
            this.RangeTextbox.Name = "RangeTextbox";
            this.RangeTextbox.Size = new System.Drawing.Size(82, 19);
            this.RangeTextbox.TabIndex = 49;
            // 
            // componentsTextBox
            // 
            this.componentsTextBox.Location = new System.Drawing.Point(93, 125);
            this.componentsTextBox.Name = "componentsTextBox";
            this.componentsTextBox.Size = new System.Drawing.Size(128, 19);
            this.componentsTextBox.TabIndex = 50;
            // 
            // descriptionTextbox
            // 
            this.descriptionTextbox.Location = new System.Drawing.Point(5, 165);
            this.descriptionTextbox.Name = "descriptionTextbox";
            this.descriptionTextbox.Size = new System.Drawing.Size(216, 307);
            this.descriptionTextbox.TabIndex = 51;
            // 
            // rollNameTextbox
            // 
            this.rollNameTextbox.Location = new System.Drawing.Point(230, 125);
            this.rollNameTextbox.Name = "rollNameTextbox";
            this.rollNameTextbox.Size = new System.Drawing.Size(108, 19);
            this.rollNameTextbox.TabIndex = 52;
            this.rollNameTextbox.Enter += new System.EventHandler(this.rollNameTextBox_Enter);
            this.rollNameTextbox.Leave += new System.EventHandler(this.rollNameTextBox_Leave);
            // 
            // addRollButton
            // 
            this.addRollButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.addRollButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.addRollButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addRollButton.Location = new System.Drawing.Point(230, 213);
            this.addRollButton.Name = "addRollButton";
            this.addRollButton.Size = new System.Drawing.Size(108, 20);
            this.addRollButton.TabIndex = 53;
            this.addRollButton.Text = "Add Roll";
            this.addRollButton.UseVisualStyleBackColor = true;
            this.addRollButton.Click += new System.EventHandler(this.AddRollButton_click);
            // 
            // AttackRollcheckBox
            // 
            this.AttackRollcheckBox.AutoSize = true;
            this.AttackRollcheckBox.Checked = true;
            this.AttackRollcheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AttackRollcheckBox.Location = new System.Drawing.Point(233, 86);
            this.AttackRollcheckBox.Name = "AttackRollcheckBox";
            this.AttackRollcheckBox.Size = new System.Drawing.Size(105, 17);
            this.AttackRollcheckBox.TabIndex = 54;
            this.AttackRollcheckBox.Text = "Uses Attack Roll";
            this.AttackRollcheckBox.UseVisualStyleBackColor = true;
            // 
            // multipliercheckBox
            // 
            this.multipliercheckBox.AutoSize = true;
            this.multipliercheckBox.Checked = true;
            this.multipliercheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.multipliercheckBox.Location = new System.Drawing.Point(250, 149);
            this.multipliercheckBox.Name = "multipliercheckBox";
            this.multipliercheckBox.Size = new System.Drawing.Size(67, 17);
            this.multipliercheckBox.TabIndex = 55;
            this.multipliercheckBox.Text = "Multiplier";
            this.multipliercheckBox.UseVisualStyleBackColor = true;
            this.multipliercheckBox.CheckedChanged += new System.EventHandler(this.multipliercheckBox_CheckedChanged);
            // 
            // DieAmountnumericUpDown
            // 
            this.DieAmountnumericUpDown.BackColor = System.Drawing.SystemColors.Control;
            this.DieAmountnumericUpDown.Location = new System.Drawing.Point(231, 184);
            this.DieAmountnumericUpDown.Name = "DieAmountnumericUpDown";
            this.DieAmountnumericUpDown.Size = new System.Drawing.Size(46, 23);
            this.DieAmountnumericUpDown.TabIndex = 56;
            this.DieAmountnumericUpDown.Value = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(276, 186);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 16);
            this.label9.TabIndex = 38;
            this.label9.Text = "d";
            // 
            // DieNumnumericUpDown
            // 
            this.DieNumnumericUpDown.BackColor = System.Drawing.SystemColors.Control;
            this.DieNumnumericUpDown.Location = new System.Drawing.Point(295, 184);
            this.DieNumnumericUpDown.Name = "DieNumnumericUpDown";
            this.DieNumnumericUpDown.Size = new System.Drawing.Size(46, 23);
            this.DieNumnumericUpDown.TabIndex = 57;
            this.DieNumnumericUpDown.Value = 6;
            // 
            // LevelnumericUpDown
            // 
            this.LevelnumericUpDown.BackColor = System.Drawing.SystemColors.Control;
            this.LevelnumericUpDown.Location = new System.Drawing.Point(181, 86);
            this.LevelnumericUpDown.Name = "LevelnumericUpDown";
            this.LevelnumericUpDown.Size = new System.Drawing.Size(46, 23);
            this.LevelnumericUpDown.TabIndex = 58;
            this.LevelnumericUpDown.Value = 0;
            // 
            // SpellCreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 480);
            this.Controls.Add(this.LevelnumericUpDown);
            this.Controls.Add(this.DieNumnumericUpDown);
            this.Controls.Add(this.DieAmountnumericUpDown);
            this.Controls.Add(this.multipliercheckBox);
            this.Controls.Add(this.AttackRollcheckBox);
            this.Controls.Add(this.addRollButton);
            this.Controls.Add(this.rollNameTextbox);
            this.Controls.Add(this.descriptionTextbox);
            this.Controls.Add(this.componentsTextBox);
            this.Controls.Add(this.RangeTextbox);
            this.Controls.Add(this.durationTextbox);
            this.Controls.Add(this.castTimeTextbox);
            this.Controls.Add(this.spellNameTextbox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.helpLabel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.multiplierLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bonusRollsLabel);
            this.Controls.Add(this.propertiesLabel);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.helpDisplaylabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SpellCreationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Spell";
            this.Load += new System.EventHandler(this.SpellCreation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label propertiesLabel;
        private System.Windows.Forms.Label bonusRollsLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label multiplierLabel;
        private System.Windows.Forms.Label helpLabel;
        private System.Windows.Forms.Label helpDisplaylabel;
        private CustomButtons.ButtonNoPadding SaveButton;
        private CustomControls.CustomTextBoxLeft spellNameTextbox;
        private CustomControls.CustomTextBoxLeft castTimeTextbox;
        private CustomControls.CustomTextBoxLeft durationTextbox;
        private CustomControls.CustomTextBoxLeft RangeTextbox;
        private CustomControls.CustomTextBoxLeft componentsTextBox;
        private CustomControls.CustomTextBoxLeftTop descriptionTextbox;
        private CustomControls.CustomTextBoxLeft rollNameTextbox;
        private CustomButtons.ButtonNoPadding addRollButton;
        private CustomControls.CustomCheckBox AttackRollcheckBox;
        private CustomControls.CustomCheckBox multipliercheckBox;
        private CustomControls.CustomUpDown DieAmountnumericUpDown;
        private System.Windows.Forms.Label label9;
        private CustomControls.CustomUpDown DieNumnumericUpDown;
        private CustomControls.CustomUpDown LevelnumericUpDown;
    }
}