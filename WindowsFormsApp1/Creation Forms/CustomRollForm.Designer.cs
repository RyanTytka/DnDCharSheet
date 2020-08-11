namespace WindowsFormsApp1
{
    partial class CustomRollForm
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
            this.dLabel = new System.Windows.Forms.Label();
            this.totalRollLabel = new System.Windows.Forms.Label();
            this.flatLabel = new System.Windows.Forms.Label();
            this.flatNumBox = new WindowsFormsApp1.CustomControls.CustomUpDown();
            this.dieNumBox = new WindowsFormsApp1.CustomControls.CustomUpDown();
            this.dieAmountBox = new WindowsFormsApp1.CustomControls.CustomUpDown();
            this.saveButton = new CustomButtons.ButtonNoPadding();
            this.addButton = new CustomButtons.ButtonNoPadding();
            this.SuspendLayout();
            // 
            // dLabel
            // 
            this.dLabel.AutoSize = true;
            this.dLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dLabel.ForeColor = System.Drawing.Color.Maroon;
            this.dLabel.Location = new System.Drawing.Point(108, 30);
            this.dLabel.Name = "dLabel";
            this.dLabel.Size = new System.Drawing.Size(22, 24);
            this.dLabel.TabIndex = 1;
            this.dLabel.Text = "d";
            // 
            // totalRollLabel
            // 
            this.totalRollLabel.AutoSize = true;
            this.totalRollLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalRollLabel.Location = new System.Drawing.Point(2, 9);
            this.totalRollLabel.Name = "totalRollLabel";
            this.totalRollLabel.Size = new System.Drawing.Size(38, 16);
            this.totalRollLabel.TabIndex = 5;
            this.totalRollLabel.Text = "Roll: ";
            // 
            // flatLabel
            // 
            this.flatLabel.AutoSize = true;
            this.flatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel.ForeColor = System.Drawing.Color.Maroon;
            this.flatLabel.Location = new System.Drawing.Point(108, 56);
            this.flatLabel.Name = "flatLabel";
            this.flatLabel.Size = new System.Drawing.Size(47, 30);
            this.flatLabel.TabIndex = 9;
            this.flatLabel.Text = "Flat\r\nBonus";
            // 
            // flatNumBox
            // 
            this.flatNumBox.BackColor = System.Drawing.SystemColors.Control;
            this.flatNumBox.Location = new System.Drawing.Point(65, 61);
            this.flatNumBox.Name = "flatNumBox";
            this.flatNumBox.Size = new System.Drawing.Size(46, 23);
            this.flatNumBox.TabIndex = 14;
            this.flatNumBox.Value = 0;
            // 
            // dieNumBox
            // 
            this.dieNumBox.BackColor = System.Drawing.SystemColors.Control;
            this.dieNumBox.Location = new System.Drawing.Point(129, 33);
            this.dieNumBox.Name = "dieNumBox";
            this.dieNumBox.Size = new System.Drawing.Size(46, 23);
            this.dieNumBox.TabIndex = 13;
            this.dieNumBox.Value = 1;
            // 
            // dieAmountBox
            // 
            this.dieAmountBox.BackColor = System.Drawing.SystemColors.Control;
            this.dieAmountBox.Location = new System.Drawing.Point(65, 33);
            this.dieAmountBox.Name = "dieAmountBox";
            this.dieAmountBox.Size = new System.Drawing.Size(46, 23);
            this.dieAmountBox.TabIndex = 12;
            this.dieAmountBox.Value = 1;
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.saveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(5, 61);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(56, 23);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // addButton
            // 
            this.addButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.addButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Location = new System.Drawing.Point(5, 33);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(56, 23);
            this.addButton.TabIndex = 10;
            this.addButton.Text = "Add Dice";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // CustomRollForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(179, 91);
            this.Controls.Add(this.flatNumBox);
            this.Controls.Add(this.dieNumBox);
            this.Controls.Add(this.dieAmountBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.totalRollLabel);
            this.Controls.Add(this.dLabel);
            this.Controls.Add(this.flatLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CustomRollForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Custom Roll";
            this.Load += new System.EventHandler(this.CustomRollForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label dLabel;
        private System.Windows.Forms.Label totalRollLabel;
        private System.Windows.Forms.Label flatLabel;
        private CustomButtons.ButtonNoPadding addButton;
        private CustomButtons.ButtonNoPadding saveButton;
        private CustomControls.CustomUpDown dieAmountBox;
        private CustomControls.CustomUpDown dieNumBox;
        private CustomControls.CustomUpDown flatNumBox;
    }
}