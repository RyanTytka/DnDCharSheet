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
            this.addButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.totalRollLabel = new System.Windows.Forms.Label();
            this.dieAmountBox = new System.Windows.Forms.NumericUpDown();
            this.dieNumBox = new System.Windows.Forms.NumericUpDown();
            this.flatNumBox = new System.Windows.Forms.NumericUpDown();
            this.flatLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dieAmountBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dieNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flatNumBox)).BeginInit();
            this.SuspendLayout();
            // 
            // dLabel
            // 
            this.dLabel.AutoSize = true;
            this.dLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dLabel.Location = new System.Drawing.Point(104, 30);
            this.dLabel.Name = "dLabel";
            this.dLabel.Size = new System.Drawing.Size(22, 24);
            this.dLabel.TabIndex = 1;
            this.dLabel.Text = "d";
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(6, 32);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(53, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add Dice";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(6, 62);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(54, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.button2_Click);
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
            // dieAmountBox
            // 
            this.dieAmountBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dieAmountBox.Location = new System.Drawing.Point(65, 33);
            this.dieAmountBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dieAmountBox.Name = "dieAmountBox";
            this.dieAmountBox.Size = new System.Drawing.Size(38, 22);
            this.dieAmountBox.TabIndex = 6;
            this.dieAmountBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dieNumBox
            // 
            this.dieNumBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dieNumBox.Location = new System.Drawing.Point(126, 33);
            this.dieNumBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dieNumBox.Name = "dieNumBox";
            this.dieNumBox.Size = new System.Drawing.Size(38, 22);
            this.dieNumBox.TabIndex = 7;
            this.dieNumBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // flatNumBox
            // 
            this.flatNumBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatNumBox.Location = new System.Drawing.Point(65, 62);
            this.flatNumBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.flatNumBox.Name = "flatNumBox";
            this.flatNumBox.Size = new System.Drawing.Size(38, 22);
            this.flatNumBox.TabIndex = 8;
            this.flatNumBox.ValueChanged += new System.EventHandler(this.flatNumBox_ValueChanged);
            // 
            // flatLabel
            // 
            this.flatLabel.AutoSize = true;
            this.flatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.flatLabel.Location = new System.Drawing.Point(103, 65);
            this.flatLabel.Name = "flatLabel";
            this.flatLabel.Size = new System.Drawing.Size(71, 16);
            this.flatLabel.TabIndex = 9;
            this.flatLabel.Text = "Flat Bonus";
            // 
            // CustomRollForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(171, 91);
            this.Controls.Add(this.flatNumBox);
            this.Controls.Add(this.dieNumBox);
            this.Controls.Add(this.dieAmountBox);
            this.Controls.Add(this.totalRollLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.dLabel);
            this.Controls.Add(this.flatLabel);
            this.Name = "CustomRollForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Custom Roll";
            this.Load += new System.EventHandler(this.CustomRollForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dieAmountBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dieNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flatNumBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label dLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label totalRollLabel;
        private System.Windows.Forms.NumericUpDown dieAmountBox;
        private System.Windows.Forms.NumericUpDown dieNumBox;
        private System.Windows.Forms.NumericUpDown flatNumBox;
        private System.Windows.Forms.Label flatLabel;
    }
}