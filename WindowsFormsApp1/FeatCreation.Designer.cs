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
            this.editDamageButton = new CustomButtons.ButtonNoPadding();
            this.rollNameTextBox = new System.Windows.Forms.TextBox();
            this.propertiesTextBox = new System.Windows.Forms.TextBox();
            this.propertiesLabel = new System.Windows.Forms.Label();
            this.finessCheckBox = new System.Windows.Forms.CheckBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // editDamageButton
            // 
            this.editDamageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.editDamageButton.Location = new System.Drawing.Point(105, 158);
            this.editDamageButton.Name = "editDamageButton";
            this.editDamageButton.Size = new System.Drawing.Size(47, 18);
            this.editDamageButton.TabIndex = 40;
            this.editDamageButton.Text = "set roll";
            this.editDamageButton.UseVisualStyleBackColor = true;
            // 
            // rollNameTextBox
            // 
            this.rollNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rollNameTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.rollNameTextBox.Location = new System.Drawing.Point(10, 182);
            this.rollNameTextBox.Name = "rollNameTextBox";
            this.rollNameTextBox.Size = new System.Drawing.Size(141, 20);
            this.rollNameTextBox.TabIndex = 36;
            this.rollNameTextBox.Text = "roll name";
            // 
            // propertiesTextBox
            // 
            this.propertiesTextBox.Location = new System.Drawing.Point(10, 44);
            this.propertiesTextBox.Multiline = true;
            this.propertiesTextBox.Name = "propertiesTextBox";
            this.propertiesTextBox.Size = new System.Drawing.Size(265, 108);
            this.propertiesTextBox.TabIndex = 32;
            // 
            // propertiesLabel
            // 
            this.propertiesLabel.AutoSize = true;
            this.propertiesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.propertiesLabel.Location = new System.Drawing.Point(112, 28);
            this.propertiesLabel.Name = "propertiesLabel";
            this.propertiesLabel.Size = new System.Drawing.Size(55, 13);
            this.propertiesLabel.TabIndex = 31;
            this.propertiesLabel.Text = "Abilities:";
            // 
            // finessCheckBox
            // 
            this.finessCheckBox.AutoSize = true;
            this.finessCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finessCheckBox.Location = new System.Drawing.Point(11, 157);
            this.finessCheckBox.Name = "finessCheckBox";
            this.finessCheckBox.Size = new System.Drawing.Size(95, 20);
            this.finessCheckBox.TabIndex = 28;
            this.finessCheckBox.Text = "Uses Roll";
            this.finessCheckBox.UseVisualStyleBackColor = true;
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
            this.saveButton.Location = new System.Drawing.Point(165, 165);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(108, 52);
            this.saveButton.TabIndex = 24;
            this.saveButton.Text = "Create Feat";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(115, 206);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(34, 20);
            this.numericUpDown1.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Number of Uses:";
            // 
            // FeatCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 236);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.editDamageButton);
            this.Controls.Add(this.rollNameTextBox);
            this.Controls.Add(this.propertiesTextBox);
            this.Controls.Add(this.propertiesLabel);
            this.Controls.Add(this.finessCheckBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveButton);
            this.Name = "FeatCreation";
            this.Text = "New Feat";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomButtons.ButtonNoPadding editDamageButton;
        private System.Windows.Forms.TextBox rollNameTextBox;
        private System.Windows.Forms.TextBox propertiesTextBox;
        private System.Windows.Forms.Label propertiesLabel;
        private System.Windows.Forms.CheckBox finessCheckBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
    }
}