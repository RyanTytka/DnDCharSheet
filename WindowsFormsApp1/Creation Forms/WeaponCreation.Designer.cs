namespace WindowsFormsApp1
{
    partial class WeaponCreation
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.propertiesLabel = new System.Windows.Forms.Label();
            this.bonusRollsLabel = new System.Windows.Forms.Label();
            this.damageRollLabel = new System.Windows.Forms.Label();
            this.damageRollDisplay = new System.Windows.Forms.Label();
            this.finessCheckBox = new WindowsFormsApp1.CustomControls.CustomCheckBox();
            this.profCheckBox = new WindowsFormsApp1.CustomControls.CustomCheckBox();
            this.editDamageButton = new CustomButtons.ButtonNoPadding();
            this.props = new WindowsFormsApp1.CustomControls.CustomTextBoxLeftTop();
            this.atkRadioButton = new WindowsFormsApp1.CustomControls.CustomRadioButton();
            this.dmgRadioButton = new WindowsFormsApp1.CustomControls.CustomRadioButton();
            this.bothRadioButton = new WindowsFormsApp1.CustomControls.CustomRadioButton();
            this.rollOptionalCheckBox = new WindowsFormsApp1.CustomControls.CustomCheckBox();
            this.saveButton = new CustomButtons.ButtonNoPadding();
            this.button2 = new CustomButtons.ButtonNoPadding();
            this.rollNameTextBox = new WindowsFormsApp1.CustomControls.CustomTextBoxLeft();
            this.nameControl = new WindowsFormsApp1.CustomControls.CustomTextBoxLeft();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(14, 2);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(200, 36);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "New Weapon";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(15, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            // 
            // propertiesLabel
            // 
            this.propertiesLabel.AutoSize = true;
            this.propertiesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.propertiesLabel.Location = new System.Drawing.Point(29, 113);
            this.propertiesLabel.Name = "propertiesLabel";
            this.propertiesLabel.Size = new System.Drawing.Size(76, 13);
            this.propertiesLabel.TabIndex = 13;
            this.propertiesLabel.Text = "Properties:  ";
            // 
            // bonusRollsLabel
            // 
            this.bonusRollsLabel.AutoSize = true;
            this.bonusRollsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bonusRollsLabel.Location = new System.Drawing.Point(132, 188);
            this.bonusRollsLabel.Name = "bonusRollsLabel";
            this.bonusRollsLabel.Size = new System.Drawing.Size(78, 13);
            this.bonusRollsLabel.TabIndex = 20;
            this.bonusRollsLabel.Text = "Bonus Rolls:";
            // 
            // damageRollLabel
            // 
            this.damageRollLabel.AutoSize = true;
            this.damageRollLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.damageRollLabel.Location = new System.Drawing.Point(11, 240);
            this.damageRollLabel.Name = "damageRollLabel";
            this.damageRollLabel.Size = new System.Drawing.Size(72, 34);
            this.damageRollLabel.TabIndex = 21;
            this.damageRollLabel.Text = "Damage \r\nRoll:";
            // 
            // damageRollDisplay
            // 
            this.damageRollDisplay.AutoSize = true;
            this.damageRollDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.damageRollDisplay.Location = new System.Drawing.Point(52, 259);
            this.damageRollDisplay.Name = "damageRollDisplay";
            this.damageRollDisplay.Size = new System.Drawing.Size(0, 13);
            this.damageRollDisplay.TabIndex = 23;
            // 
            // finessCheckBox
            // 
            this.finessCheckBox.AutoSize = true;
            this.finessCheckBox.Location = new System.Drawing.Point(18, 93);
            this.finessCheckBox.Name = "finessCheckBox";
            this.finessCheckBox.Size = new System.Drawing.Size(62, 17);
            this.finessCheckBox.TabIndex = 25;
            this.finessCheckBox.TabStop = false;
            this.finessCheckBox.Text = "Finesse";
            this.finessCheckBox.UseVisualStyleBackColor = true;
            // 
            // profCheckBox
            // 
            this.profCheckBox.AutoSize = true;
            this.profCheckBox.Location = new System.Drawing.Point(19, 69);
            this.profCheckBox.Name = "profCheckBox";
            this.profCheckBox.Size = new System.Drawing.Size(70, 17);
            this.profCheckBox.TabIndex = 24;
            this.profCheckBox.TabStop = false;
            this.profCheckBox.Text = "Proficient";
            this.profCheckBox.UseVisualStyleBackColor = true;
            // 
            // editDamageButton
            // 
            this.editDamageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editDamageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.editDamageButton.Location = new System.Drawing.Point(81, 240);
            this.editDamageButton.Name = "editDamageButton";
            this.editDamageButton.Size = new System.Drawing.Size(29, 18);
            this.editDamageButton.TabIndex = 22;
            this.editDamageButton.TabStop = false;
            this.editDamageButton.Text = "set";
            this.editDamageButton.UseVisualStyleBackColor = true;
            this.editDamageButton.Click += new System.EventHandler(this.editDamageButton_Click);
            // 
            // props
            // 
            this.props.Location = new System.Drawing.Point(11, 129);
            this.props.Name = "props";
            this.props.Size = new System.Drawing.Size(99, 105);
            this.props.TabIndex = 2;
            // 
            // atkRadioButton
            // 
            this.atkRadioButton.AutoSize = true;
            this.atkRadioButton.Location = new System.Drawing.Point(122, 226);
            this.atkRadioButton.Name = "atkRadioButton";
            this.atkRadioButton.Size = new System.Drawing.Size(82, 17);
            this.atkRadioButton.TabIndex = 27;
            this.atkRadioButton.Text = "Attack Rolls";
            this.atkRadioButton.UseVisualStyleBackColor = true;
            // 
            // dmgRadioButton
            // 
            this.dmgRadioButton.AutoSize = true;
            this.dmgRadioButton.Location = new System.Drawing.Point(122, 245);
            this.dmgRadioButton.Name = "dmgRadioButton";
            this.dmgRadioButton.Size = new System.Drawing.Size(91, 17);
            this.dmgRadioButton.TabIndex = 28;
            this.dmgRadioButton.Text = "Damage Rolls";
            this.dmgRadioButton.UseVisualStyleBackColor = true;
            // 
            // bothRadioButton
            // 
            this.bothRadioButton.AutoSize = true;
            this.bothRadioButton.Location = new System.Drawing.Point(122, 265);
            this.bothRadioButton.Name = "bothRadioButton";
            this.bothRadioButton.Size = new System.Drawing.Size(47, 17);
            this.bothRadioButton.TabIndex = 29;
            this.bothRadioButton.Text = "Both";
            this.bothRadioButton.UseVisualStyleBackColor = true;
            // 
            // rollOptionalCheckBox
            // 
            this.rollOptionalCheckBox.AutoSize = true;
            this.rollOptionalCheckBox.Location = new System.Drawing.Point(122, 286);
            this.rollOptionalCheckBox.Name = "rollOptionalCheckBox";
            this.rollOptionalCheckBox.Size = new System.Drawing.Size(65, 17);
            this.rollOptionalCheckBox.TabIndex = 30;
            this.rollOptionalCheckBox.TabStop = false;
            this.rollOptionalCheckBox.Text = "Optional";
            this.rollOptionalCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.saveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(14, 282);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(96, 46);
            this.saveButton.TabIndex = 31;
            this.saveButton.TabStop = false;
            this.saveButton.Text = "Create Weapon";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(121, 308);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 20);
            this.button2.TabIndex = 32;
            this.button2.TabStop = false;
            this.button2.Text = "Add Bonus Roll";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // rollNameTextBox
            // 
            this.rollNameTextBox.Location = new System.Drawing.Point(122, 203);
            this.rollNameTextBox.Name = "rollNameTextBox";
            this.rollNameTextBox.Size = new System.Drawing.Size(97, 20);
            this.rollNameTextBox.TabIndex = 3;
            this.rollNameTextBox.Enter += new System.EventHandler(this.rollNameTextBox_Enter);
            this.rollNameTextBox.Leave += new System.EventHandler(this.rollNameTextBox_Leave);
            // 
            // nameControl
            // 
            this.nameControl.Location = new System.Drawing.Point(90, 47);
            this.nameControl.Name = "nameControl";
            this.nameControl.Size = new System.Drawing.Size(120, 20);
            this.nameControl.TabIndex = 1;
            // 
            // WeaponCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 340);
            this.Controls.Add(this.nameControl);
            this.Controls.Add(this.rollNameTextBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.rollOptionalCheckBox);
            this.Controls.Add(this.bothRadioButton);
            this.Controls.Add(this.dmgRadioButton);
            this.Controls.Add(this.atkRadioButton);
            this.Controls.Add(this.props);
            this.Controls.Add(this.finessCheckBox);
            this.Controls.Add(this.profCheckBox);
            this.Controls.Add(this.damageRollDisplay);
            this.Controls.Add(this.editDamageButton);
            this.Controls.Add(this.damageRollLabel);
            this.Controls.Add(this.bonusRollsLabel);
            this.Controls.Add(this.propertiesLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "WeaponCreation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.WeaponCreation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label propertiesLabel;
        private System.Windows.Forms.Label bonusRollsLabel;
        private System.Windows.Forms.Label damageRollLabel;
        private CustomButtons.ButtonNoPadding editDamageButton;
        private System.Windows.Forms.Label damageRollDisplay;
        private CustomControls.CustomCheckBox profCheckBox;
        private CustomControls.CustomCheckBox finessCheckBox;
        private CustomControls.CustomTextBoxLeftTop props;
        private CustomControls.CustomRadioButton atkRadioButton;
        private CustomControls.CustomRadioButton dmgRadioButton;
        private CustomControls.CustomRadioButton bothRadioButton;
        private CustomControls.CustomCheckBox rollOptionalCheckBox;
        private CustomButtons.ButtonNoPadding saveButton;
        private CustomButtons.ButtonNoPadding button2;
        private CustomControls.CustomTextBoxLeft rollNameTextBox;
        private CustomControls.CustomTextBoxLeft nameControl;
    }
}