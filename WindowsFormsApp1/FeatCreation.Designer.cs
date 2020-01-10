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
            this.rollNameTextBox = new System.Windows.Forms.TextBox();
            this.abilitiesTextBox = new System.Windows.Forms.TextBox();
            this.propertiesLabel = new System.Windows.Forms.Label();
            this.usesRollCheckBox = new System.Windows.Forms.CheckBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.numUsesBox = new System.Windows.Forms.NumericUpDown();
            this.rollDisplayTextBox = new System.Windows.Forms.Label();
            this.LimitedUsecheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numUsesBox)).BeginInit();
            this.SuspendLayout();
            // 
            // setRollButton
            // 
            this.setRollButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.setRollButton.Location = new System.Drawing.Point(105, 159);
            this.setRollButton.Name = "setRollButton";
            this.setRollButton.Size = new System.Drawing.Size(47, 18);
            this.setRollButton.TabIndex = 40;
            this.setRollButton.Text = "set roll";
            this.setRollButton.UseVisualStyleBackColor = true;
            this.setRollButton.Click += new System.EventHandler(this.newRoll);
            // 
            // rollNameTextBox
            // 
            this.rollNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rollNameTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.rollNameTextBox.Location = new System.Drawing.Point(10, 184);
            this.rollNameTextBox.Name = "rollNameTextBox";
            this.rollNameTextBox.Size = new System.Drawing.Size(141, 20);
            this.rollNameTextBox.TabIndex = 36;
            this.rollNameTextBox.Text = "roll name";
            this.rollNameTextBox.Leave += new System.EventHandler(this.rollNameTextBox_Leave);
            // 
            // abilitiesTextBox
            // 
            this.abilitiesTextBox.Location = new System.Drawing.Point(10, 44);
            this.abilitiesTextBox.Multiline = true;
            this.abilitiesTextBox.Name = "abilitiesTextBox";
            this.abilitiesTextBox.Size = new System.Drawing.Size(258, 108);
            this.abilitiesTextBox.TabIndex = 32;
            // 
            // propertiesLabel
            // 
            this.propertiesLabel.AutoSize = true;
            this.propertiesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.propertiesLabel.Location = new System.Drawing.Point(109, 28);
            this.propertiesLabel.Name = "propertiesLabel";
            this.propertiesLabel.Size = new System.Drawing.Size(55, 13);
            this.propertiesLabel.TabIndex = 31;
            this.propertiesLabel.Text = "Abilities:";
            // 
            // usesRollCheckBox
            // 
            this.usesRollCheckBox.AutoSize = true;
            this.usesRollCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usesRollCheckBox.Location = new System.Drawing.Point(11, 158);
            this.usesRollCheckBox.Name = "usesRollCheckBox";
            this.usesRollCheckBox.Size = new System.Drawing.Size(95, 20);
            this.usesRollCheckBox.TabIndex = 28;
            this.usesRollCheckBox.Text = "Uses Roll";
            this.usesRollCheckBox.UseVisualStyleBackColor = true;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.nameTextBox.Location = new System.Drawing.Point(77, 3);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(198, 23);
            this.nameTextBox.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(7, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 24);
            this.label2.TabIndex = 26;
            this.label2.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, -42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 35);
            this.label1.TabIndex = 25;
            this.label1.Text = "New Weapon";
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(160, 181);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(108, 49);
            this.saveButton.TabIndex = 24;
            this.saveButton.Text = "Create Feat";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // numUsesBox
            // 
            this.numUsesBox.Location = new System.Drawing.Point(116, 208);
            this.numUsesBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUsesBox.Name = "numUsesBox";
            this.numUsesBox.Size = new System.Drawing.Size(34, 20);
            this.numUsesBox.TabIndex = 42;
            this.numUsesBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rollDisplayTextBox
            // 
            this.rollDisplayTextBox.AutoSize = true;
            this.rollDisplayTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rollDisplayTextBox.Location = new System.Drawing.Point(158, 158);
            this.rollDisplayTextBox.Name = "rollDisplayTextBox";
            this.rollDisplayTextBox.Size = new System.Drawing.Size(40, 16);
            this.rollDisplayTextBox.TabIndex = 44;
            this.rollDisplayTextBox.Text = "Roll:";
            // 
            // LimitedUsecheckBox
            // 
            this.LimitedUsecheckBox.AutoSize = true;
            this.LimitedUsecheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LimitedUsecheckBox.Location = new System.Drawing.Point(10, 210);
            this.LimitedUsecheckBox.Name = "LimitedUsecheckBox";
            this.LimitedUsecheckBox.Size = new System.Drawing.Size(98, 17);
            this.LimitedUsecheckBox.TabIndex = 45;
            this.LimitedUsecheckBox.Text = "Limited Uses";
            this.LimitedUsecheckBox.UseVisualStyleBackColor = true;
            // 
            // FeatCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 236);
            this.Controls.Add(this.LimitedUsecheckBox);
            this.Controls.Add(this.rollDisplayTextBox);
            this.Controls.Add(this.numUsesBox);
            this.Controls.Add(this.setRollButton);
            this.Controls.Add(this.rollNameTextBox);
            this.Controls.Add(this.abilitiesTextBox);
            this.Controls.Add(this.propertiesLabel);
            this.Controls.Add(this.usesRollCheckBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveButton);
            this.Name = "FeatCreation";
            this.Text = "New Feat";
            this.Load += new System.EventHandler(this.FeatCreation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUsesBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomButtons.ButtonNoPadding setRollButton;
        private System.Windows.Forms.TextBox rollNameTextBox;
        private System.Windows.Forms.TextBox abilitiesTextBox;
        private System.Windows.Forms.Label propertiesLabel;
        private System.Windows.Forms.CheckBox usesRollCheckBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.NumericUpDown numUsesBox;
        private System.Windows.Forms.Label rollDisplayTextBox;
        private System.Windows.Forms.CheckBox LimitedUsecheckBox;
    }
}