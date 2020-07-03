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
            this.saveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.finessCheckBox = new System.Windows.Forms.CheckBox();
            this.profCheckBox = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.propertiesLabel = new System.Windows.Forms.Label();
            this.propertiesTextBox = new System.Windows.Forms.TextBox();
            this.atkRadioButton = new System.Windows.Forms.RadioButton();
            this.dmgRadioButton = new System.Windows.Forms.RadioButton();
            this.bothRadioButton = new System.Windows.Forms.RadioButton();
            this.rollNameTextBox = new System.Windows.Forms.TextBox();
            this.rollOptionalCheckBox = new System.Windows.Forms.CheckBox();
            this.bonusRollsLabel = new System.Windows.Forms.Label();
            this.damageRollLabel = new System.Windows.Forms.Label();
            this.editDamageButton = new CustomButtons.ButtonNoPadding();
            this.damageRollDisplay = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(11, 279);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(108, 52);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Create Weapon";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "New Weapon";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(26, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.nameTextBox.Location = new System.Drawing.Point(101, 43);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(112, 23);
            this.nameTextBox.TabIndex = 3;
            // 
            // finessCheckBox
            // 
            this.finessCheckBox.AutoSize = true;
            this.finessCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finessCheckBox.Location = new System.Drawing.Point(23, 91);
            this.finessCheckBox.Name = "finessCheckBox";
            this.finessCheckBox.Size = new System.Drawing.Size(82, 20);
            this.finessCheckBox.TabIndex = 10;
            this.finessCheckBox.Text = "Finesse";
            this.finessCheckBox.UseVisualStyleBackColor = true;
            // 
            // profCheckBox
            // 
            this.profCheckBox.AutoSize = true;
            this.profCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profCheckBox.Location = new System.Drawing.Point(23, 70);
            this.profCheckBox.Name = "profCheckBox";
            this.profCheckBox.Size = new System.Drawing.Size(92, 20);
            this.profCheckBox.TabIndex = 11;
            this.profCheckBox.Text = "Proficient";
            this.profCheckBox.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(123, 308);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Add Bonus Roll";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            // propertiesTextBox
            // 
            this.propertiesTextBox.Location = new System.Drawing.Point(12, 129);
            this.propertiesTextBox.Multiline = true;
            this.propertiesTextBox.Name = "propertiesTextBox";
            this.propertiesTextBox.Size = new System.Drawing.Size(107, 108);
            this.propertiesTextBox.TabIndex = 14;
            // 
            // atkRadioButton
            // 
            this.atkRadioButton.AutoSize = true;
            this.atkRadioButton.Location = new System.Drawing.Point(125, 227);
            this.atkRadioButton.Name = "atkRadioButton";
            this.atkRadioButton.Size = new System.Drawing.Size(82, 17);
            this.atkRadioButton.TabIndex = 15;
            this.atkRadioButton.TabStop = true;
            this.atkRadioButton.Text = "Attack Rolls";
            this.atkRadioButton.UseVisualStyleBackColor = true;
            // 
            // dmgRadioButton
            // 
            this.dmgRadioButton.AutoSize = true;
            this.dmgRadioButton.Location = new System.Drawing.Point(125, 246);
            this.dmgRadioButton.Name = "dmgRadioButton";
            this.dmgRadioButton.Size = new System.Drawing.Size(91, 17);
            this.dmgRadioButton.TabIndex = 16;
            this.dmgRadioButton.TabStop = true;
            this.dmgRadioButton.Text = "Damage Rolls";
            this.dmgRadioButton.UseVisualStyleBackColor = true;
            // 
            // bothRadioButton
            // 
            this.bothRadioButton.AutoSize = true;
            this.bothRadioButton.Location = new System.Drawing.Point(125, 265);
            this.bothRadioButton.Name = "bothRadioButton";
            this.bothRadioButton.Size = new System.Drawing.Size(47, 17);
            this.bothRadioButton.TabIndex = 17;
            this.bothRadioButton.TabStop = true;
            this.bothRadioButton.Text = "Both";
            this.bothRadioButton.UseVisualStyleBackColor = true;
            // 
            // rollNameTextBox
            // 
            this.rollNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rollNameTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.rollNameTextBox.Location = new System.Drawing.Point(125, 203);
            this.rollNameTextBox.Name = "rollNameTextBox";
            this.rollNameTextBox.Size = new System.Drawing.Size(98, 20);
            this.rollNameTextBox.TabIndex = 18;
            this.rollNameTextBox.Text = "roll name";
            this.rollNameTextBox.Enter += new System.EventHandler(this.rollNameTextBox_Enter);
            this.rollNameTextBox.Leave += new System.EventHandler(this.rollNameTextBox_Leave);
            // 
            // rollOptionalCheckBox
            // 
            this.rollOptionalCheckBox.AutoSize = true;
            this.rollOptionalCheckBox.Location = new System.Drawing.Point(125, 287);
            this.rollOptionalCheckBox.Name = "rollOptionalCheckBox";
            this.rollOptionalCheckBox.Size = new System.Drawing.Size(65, 17);
            this.rollOptionalCheckBox.TabIndex = 19;
            this.rollOptionalCheckBox.Text = "Optional";
            this.rollOptionalCheckBox.UseVisualStyleBackColor = true;
            // 
            // bonusRollsLabel
            // 
            this.bonusRollsLabel.AutoSize = true;
            this.bonusRollsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bonusRollsLabel.Location = new System.Drawing.Point(134, 188);
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
            // editDamageButton
            // 
            this.editDamageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.editDamageButton.Location = new System.Drawing.Point(81, 240);
            this.editDamageButton.Name = "editDamageButton";
            this.editDamageButton.Size = new System.Drawing.Size(29, 18);
            this.editDamageButton.TabIndex = 22;
            this.editDamageButton.Text = "set";
            this.editDamageButton.UseVisualStyleBackColor = true;
            this.editDamageButton.Click += new System.EventHandler(this.editDamageButton_Click);
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
            // WeaponCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 340);
            this.Controls.Add(this.damageRollDisplay);
            this.Controls.Add(this.editDamageButton);
            this.Controls.Add(this.damageRollLabel);
            this.Controls.Add(this.bonusRollsLabel);
            this.Controls.Add(this.rollOptionalCheckBox);
            this.Controls.Add(this.rollNameTextBox);
            this.Controls.Add(this.bothRadioButton);
            this.Controls.Add(this.dmgRadioButton);
            this.Controls.Add(this.atkRadioButton);
            this.Controls.Add(this.propertiesTextBox);
            this.Controls.Add(this.propertiesLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.profCheckBox);
            this.Controls.Add(this.finessCheckBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveButton);
            this.Name = "WeaponCreation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Weapon";
            this.Load += new System.EventHandler(this.WeaponCreation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.CheckBox finessCheckBox;
        private System.Windows.Forms.CheckBox profCheckBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label propertiesLabel;
        private System.Windows.Forms.TextBox propertiesTextBox;
        private System.Windows.Forms.RadioButton atkRadioButton;
        private System.Windows.Forms.RadioButton dmgRadioButton;
        private System.Windows.Forms.RadioButton bothRadioButton;
        private System.Windows.Forms.TextBox rollNameTextBox;
        private System.Windows.Forms.CheckBox rollOptionalCheckBox;
        private System.Windows.Forms.Label bonusRollsLabel;
        private System.Windows.Forms.Label damageRollLabel;
        private CustomButtons.ButtonNoPadding editDamageButton;
        private System.Windows.Forms.Label damageRollDisplay;
    }
}