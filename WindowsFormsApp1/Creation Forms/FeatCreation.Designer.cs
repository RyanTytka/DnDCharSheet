namespace WindowsFormsApp1
{
    partial class FeatCreation
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
            this.setRollButton = new CustomButtons.ButtonNoPadding();
            this.propertiesLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rollDisplayTextBox = new System.Windows.Forms.Label();
            this.longRestradioButton = new WindowsFormsApp1.CustomControls.CustomRadioButton();
            this.OtherradioButton = new WindowsFormsApp1.CustomControls.CustomRadioButton();
            this.saveButton = new CustomButtons.ButtonNoPadding();
            this.nameTextBox = new WindowsFormsApp1.CustomControls.CustomTextBoxLeft();
            this.abilitiesTextBox = new WindowsFormsApp1.CustomControls.CustomTextBoxLeftTop();
            this.shortRestRadioButton = new WindowsFormsApp1.CustomControls.CustomRadioButton();
            this.numUsesBox = new WindowsFormsApp1.CustomControls.CustomUpDown();
            this.usesRollCheckBox = new WindowsFormsApp1.CustomControls.CustomCheckBox();
            this.LimitedUsecheckBox = new WindowsFormsApp1.CustomControls.CustomCheckBox();
            this.SuspendLayout();
            // 
            // setRollButton
            // 
            this.setRollButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setRollButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.setRollButton.Location = new System.Drawing.Point(121, 212);
            this.setRollButton.Name = "setRollButton";
            this.setRollButton.Size = new System.Drawing.Size(47, 18);
            this.setRollButton.TabIndex = 40;
            this.setRollButton.TabStop = false;
            this.setRollButton.Text = "set roll";
            this.setRollButton.UseVisualStyleBackColor = true;
            this.setRollButton.Click += new System.EventHandler(this.newRoll);
            // 
            // propertiesLabel
            // 
            this.propertiesLabel.AutoSize = true;
            this.propertiesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.propertiesLabel.Location = new System.Drawing.Point(96, 29);
            this.propertiesLabel.Name = "propertiesLabel";
            this.propertiesLabel.Size = new System.Drawing.Size(75, 13);
            this.propertiesLabel.TabIndex = 31;
            this.propertiesLabel.Text = "Description:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(7, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 26);
            this.label2.TabIndex = 26;
            this.label2.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, -42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 36);
            this.label1.TabIndex = 25;
            this.label1.Text = "New Weapon";
            // 
            // rollDisplayTextBox
            // 
            this.rollDisplayTextBox.AutoSize = true;
            this.rollDisplayTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rollDisplayTextBox.Location = new System.Drawing.Point(5, 235);
            this.rollDisplayTextBox.Name = "rollDisplayTextBox";
            this.rollDisplayTextBox.Size = new System.Drawing.Size(40, 16);
            this.rollDisplayTextBox.TabIndex = 44;
            this.rollDisplayTextBox.Text = "Roll:";
            // 
            // longRestradioButton
            // 
            this.longRestradioButton.AutoSize = true;
            this.longRestradioButton.Enabled = false;
            this.longRestradioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.longRestradioButton.Location = new System.Drawing.Point(81, 160);
            this.longRestradioButton.Name = "longRestradioButton";
            this.longRestradioButton.Size = new System.Drawing.Size(65, 17);
            this.longRestradioButton.TabIndex = 46;
            this.longRestradioButton.TabStop = true;
            this.longRestradioButton.Text = "long rest";
            this.longRestradioButton.UseVisualStyleBackColor = true;
            // 
            // OtherradioButton
            // 
            this.OtherradioButton.AutoSize = true;
            this.OtherradioButton.Enabled = false;
            this.OtherradioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.OtherradioButton.Location = new System.Drawing.Point(21, 160);
            this.OtherradioButton.Name = "OtherradioButton";
            this.OtherradioButton.Size = new System.Drawing.Size(49, 17);
            this.OtherradioButton.TabIndex = 48;
            this.OtherradioButton.TabStop = true;
            this.OtherradioButton.Text = "other";
            this.OtherradioButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(173, 183);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(94, 47);
            this.saveButton.TabIndex = 49;
            this.saveButton.TabStop = false;
            this.saveButton.Text = "Create Feat";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.CreateFeat);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.Location = new System.Drawing.Point(81, 8);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(185, 19);
            this.nameTextBox.TabIndex = 50;
            // 
            // abilitiesTextBox
            // 
            this.abilitiesTextBox.Location = new System.Drawing.Point(7, 44);
            this.abilitiesTextBox.Name = "abilitiesTextBox";
            this.abilitiesTextBox.Size = new System.Drawing.Size(259, 113);
            this.abilitiesTextBox.TabIndex = 51;
            // 
            // shortRestRadioButton
            // 
            this.shortRestRadioButton.AutoSize = true;
            this.shortRestRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.shortRestRadioButton.Location = new System.Drawing.Point(156, 160);
            this.shortRestRadioButton.Name = "shortRestRadioButton";
            this.shortRestRadioButton.Size = new System.Drawing.Size(112, 17);
            this.shortRestRadioButton.TabIndex = 52;
            this.shortRestRadioButton.TabStop = true;
            this.shortRestRadioButton.Text = "short and long rest";
            this.shortRestRadioButton.UseVisualStyleBackColor = true;
            // 
            // numUsesBox
            // 
            this.numUsesBox.BackColor = System.Drawing.SystemColors.Control;
            this.numUsesBox.Enabled = false;
            this.numUsesBox.Location = new System.Drawing.Point(123, 185);
            this.numUsesBox.Name = "numUsesBox";
            this.numUsesBox.Size = new System.Drawing.Size(46, 23);
            this.numUsesBox.TabIndex = 53;
            this.numUsesBox.Value = 1;
            // 
            // usesRollCheckBox
            // 
            this.usesRollCheckBox.AutoSize = true;
            this.usesRollCheckBox.Checked = true;
            this.usesRollCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.usesRollCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.usesRollCheckBox.Location = new System.Drawing.Point(7, 212);
            this.usesRollCheckBox.Name = "usesRollCheckBox";
            this.usesRollCheckBox.Size = new System.Drawing.Size(95, 20);
            this.usesRollCheckBox.TabIndex = 54;
            this.usesRollCheckBox.Text = "Uses Roll";
            this.usesRollCheckBox.UseVisualStyleBackColor = true;
            this.usesRollCheckBox.CheckedChanged += new System.EventHandler(this.usesRollCheckBox_CheckedChanged);
            // 
            // LimitedUsecheckBox
            // 
            this.LimitedUsecheckBox.AutoSize = true;
            this.LimitedUsecheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.LimitedUsecheckBox.Location = new System.Drawing.Point(7, 187);
            this.LimitedUsecheckBox.Name = "LimitedUsecheckBox";
            this.LimitedUsecheckBox.Size = new System.Drawing.Size(117, 20);
            this.LimitedUsecheckBox.TabIndex = 55;
            this.LimitedUsecheckBox.Text = "Limited Uses";
            this.LimitedUsecheckBox.UseVisualStyleBackColor = true;
            this.LimitedUsecheckBox.CheckedChanged += new System.EventHandler(this.LimitedUsecheckBox_CheckedChanged);
            // 
            // FeatCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 259);
            this.Controls.Add(this.LimitedUsecheckBox);
            this.Controls.Add(this.usesRollCheckBox);
            this.Controls.Add(this.numUsesBox);
            this.Controls.Add(this.shortRestRadioButton);
            this.Controls.Add(this.abilitiesTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.longRestradioButton);
            this.Controls.Add(this.rollDisplayTextBox);
            this.Controls.Add(this.setRollButton);
            this.Controls.Add(this.propertiesLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OtherradioButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FeatCreation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Feat";
            this.Load += new System.EventHandler(this.FeatCreation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomButtons.ButtonNoPadding setRollButton;
        private System.Windows.Forms.Label propertiesLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label rollDisplayTextBox;
        private CustomControls.CustomRadioButton longRestradioButton;
        private CustomControls.CustomRadioButton OtherradioButton;
        private CustomButtons.ButtonNoPadding saveButton;
        private CustomControls.CustomTextBoxLeft nameTextBox;
        private CustomControls.CustomTextBoxLeftTop abilitiesTextBox;
        private CustomControls.CustomRadioButton shortRestRadioButton;
        private CustomControls.CustomUpDown numUsesBox;
        private CustomControls.CustomCheckBox usesRollCheckBox;
        private CustomControls.CustomCheckBox LimitedUsecheckBox;
    }
}