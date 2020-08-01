namespace WindowsFormsApp1.CustomControls
{
    partial class CustomUpDown
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.settingsButton = new CustomButtons.ButtonNoPadding();
            this.buttonNoPadding1 = new CustomButtons.ButtonNoPadding();
            this.textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // settingsButton
            // 
            this.settingsButton.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.upArrow;
            this.settingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.settingsButton.FlatAppearance.BorderSize = 0;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.Location = new System.Drawing.Point(25, 5);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(16, 10);
            this.settingsButton.TabIndex = 228;
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.upBox_Click);
            // 
            // buttonNoPadding1
            // 
            this.buttonNoPadding1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.downArrow;
            this.buttonNoPadding1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonNoPadding1.FlatAppearance.BorderSize = 0;
            this.buttonNoPadding1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNoPadding1.Location = new System.Drawing.Point(25, 18);
            this.buttonNoPadding1.Name = "buttonNoPadding1";
            this.buttonNoPadding1.Size = new System.Drawing.Size(16, 10);
            this.buttonNoPadding1.TabIndex = 229;
            this.buttonNoPadding1.UseVisualStyleBackColor = true;
            this.buttonNoPadding1.Click += new System.EventHandler(this.downBox_Click);
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.SystemColors.Control;
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.ForeColor = System.Drawing.Color.Maroon;
            this.textBox.Location = new System.Drawing.Point(0, 7);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(22, 19);
            this.textBox.TabIndex = 230;
            this.textBox.Text = "10";
            this.textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textBox.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // CustomUpDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.buttonNoPadding1);
            this.Controls.Add(this.settingsButton);
            this.Name = "CustomUpDown";
            this.Size = new System.Drawing.Size(43, 34);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomButtons.ButtonNoPadding settingsButton;
        private CustomButtons.ButtonNoPadding buttonNoPadding1;
        private System.Windows.Forms.TextBox textBox;
    }
}
