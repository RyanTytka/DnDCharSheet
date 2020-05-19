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
            this.saveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.addRollButton = new System.Windows.Forms.Button();
            this.propertiesLabel = new System.Windows.Forms.Label();
            this.propertiesTextBox = new System.Windows.Forms.TextBox();
            this.rollNameTextBox = new System.Windows.Forms.TextBox();
            this.bonusRollsLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CastTimetextBox = new System.Windows.Forms.TextBox();
            this.RangetextBox = new System.Windows.Forms.TextBox();
            this.DurationtextBox = new System.Windows.Forms.TextBox();
            this.ComponentsTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.AttackRollDropdown = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(232, 21);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(108, 52);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Create Spell";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "New Spell";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.nameTextBox.Location = new System.Drawing.Point(5, 50);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(216, 23);
            this.nameTextBox.TabIndex = 3;
            // 
            // addRollButton
            // 
            this.addRollButton.Location = new System.Drawing.Point(233, 183);
            this.addRollButton.Name = "addRollButton";
            this.addRollButton.Size = new System.Drawing.Size(108, 23);
            this.addRollButton.TabIndex = 12;
            this.addRollButton.Text = "Add Roll";
            this.addRollButton.UseVisualStyleBackColor = true;
            this.addRollButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // propertiesLabel
            // 
            this.propertiesLabel.AutoSize = true;
            this.propertiesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.propertiesLabel.Location = new System.Drawing.Point(74, 146);
            this.propertiesLabel.Name = "propertiesLabel";
            this.propertiesLabel.Size = new System.Drawing.Size(79, 13);
            this.propertiesLabel.TabIndex = 13;
            this.propertiesLabel.Text = "Description  ";
            // 
            // propertiesTextBox
            // 
            this.propertiesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.propertiesTextBox.Location = new System.Drawing.Point(5, 160);
            this.propertiesTextBox.Multiline = true;
            this.propertiesTextBox.Name = "propertiesTextBox";
            this.propertiesTextBox.Size = new System.Drawing.Size(216, 318);
            this.propertiesTextBox.TabIndex = 14;
            this.propertiesTextBox.Text = resources.GetString("propertiesTextBox.Text");
            // 
            // rollNameTextBox
            // 
            this.rollNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rollNameTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.rollNameTextBox.Location = new System.Drawing.Point(235, 160);
            this.rollNameTextBox.Name = "rollNameTextBox";
            this.rollNameTextBox.Size = new System.Drawing.Size(105, 20);
            this.rollNameTextBox.TabIndex = 18;
            this.rollNameTextBox.Text = "roll name";
            this.rollNameTextBox.Enter += new System.EventHandler(this.rollNameTextBox_Enter);
            this.rollNameTextBox.Leave += new System.EventHandler(this.rollNameTextBox_Leave);
            // 
            // bonusRollsLabel
            // 
            this.bonusRollsLabel.AutoSize = true;
            this.bonusRollsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bonusRollsLabel.Location = new System.Drawing.Point(266, 144);
            this.bonusRollsLabel.Name = "bonusRollsLabel";
            this.bonusRollsLabel.Size = new System.Drawing.Size(39, 13);
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
            // CastTimetextBox
            // 
            this.CastTimetextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CastTimetextBox.ForeColor = System.Drawing.Color.DimGray;
            this.CastTimetextBox.Location = new System.Drawing.Point(6, 89);
            this.CastTimetextBox.Name = "CastTimetextBox";
            this.CastTimetextBox.Size = new System.Drawing.Size(83, 20);
            this.CastTimetextBox.TabIndex = 22;
            // 
            // RangetextBox
            // 
            this.RangetextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RangetextBox.ForeColor = System.Drawing.Color.DimGray;
            this.RangetextBox.Location = new System.Drawing.Point(6, 123);
            this.RangetextBox.Name = "RangetextBox";
            this.RangetextBox.Size = new System.Drawing.Size(105, 20);
            this.RangetextBox.TabIndex = 23;
            // 
            // DurationtextBox
            // 
            this.DurationtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DurationtextBox.ForeColor = System.Drawing.Color.DimGray;
            this.DurationtextBox.Location = new System.Drawing.Point(94, 88);
            this.DurationtextBox.Name = "DurationtextBox";
            this.DurationtextBox.Size = new System.Drawing.Size(90, 20);
            this.DurationtextBox.TabIndex = 24;
            // 
            // ComponentsTextBox
            // 
            this.ComponentsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComponentsTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.ComponentsTextBox.Location = new System.Drawing.Point(116, 125);
            this.ComponentsTextBox.Name = "ComponentsTextBox";
            this.ComponentsTextBox.Size = new System.Drawing.Size(105, 20);
            this.ComponentsTextBox.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Casting Time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Range";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(112, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Duration";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(131, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Components";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(187, 88);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(34, 20);
            this.numericUpDown1.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(185, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Level";
            // 
            // AttackRollDropdown
            // 
            this.AttackRollDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AttackRollDropdown.FormattingEnabled = true;
            this.AttackRollDropdown.Items.AddRange(new object[] {
            "None",
            "Strength",
            "Dexterity",
            "Constitution",
            "Intelligence",
            "Wisdom",
            "Charisma"});
            this.AttackRollDropdown.Location = new System.Drawing.Point(233, 103);
            this.AttackRollDropdown.Name = "AttackRollDropdown";
            this.AttackRollDropdown.Size = new System.Drawing.Size(107, 21);
            this.AttackRollDropdown.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(250, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Attack Roll";
            // 
            // SpellCreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 480);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.AttackRollDropdown);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ComponentsTextBox);
            this.Controls.Add(this.DurationtextBox);
            this.Controls.Add(this.RangetextBox);
            this.Controls.Add(this.CastTimetextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bonusRollsLabel);
            this.Controls.Add(this.rollNameTextBox);
            this.Controls.Add(this.propertiesTextBox);
            this.Controls.Add(this.propertiesLabel);
            this.Controls.Add(this.addRollButton);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveButton);
            this.Name = "SpellCreationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Spell";
            this.Load += new System.EventHandler(this.SpellCreation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button addRollButton;
        private System.Windows.Forms.Label propertiesLabel;
        private System.Windows.Forms.TextBox propertiesTextBox;
        private System.Windows.Forms.TextBox rollNameTextBox;
        private System.Windows.Forms.Label bonusRollsLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CastTimetextBox;
        private System.Windows.Forms.TextBox RangetextBox;
        private System.Windows.Forms.TextBox DurationtextBox;
        private System.Windows.Forms.TextBox ComponentsTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox AttackRollDropdown;
        private System.Windows.Forms.Label label8;
    }
}