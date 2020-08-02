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
            this.textBox = new WindowsFormsApp1.CustomControls.CustomTextBoxCentered();
            this.downButton = new CustomButtons.ButtonNoPadding();
            this.upButton = new CustomButtons.ButtonNoPadding();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(2, 3);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(22, 19);
            this.textBox.TabIndex = 230;
            // 
            // downButton
            // 
            this.downButton.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.downArrow;
            this.downButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.downButton.FlatAppearance.BorderSize = 0;
            this.downButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downButton.Location = new System.Drawing.Point(29, 14);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(16, 10);
            this.downButton.TabIndex = 229;
            this.downButton.Text = null;
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downBox_Click);
            // 
            // upButton
            // 
            this.upButton.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.upArrow;
            this.upButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.upButton.FlatAppearance.BorderSize = 0;
            this.upButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.upButton.Location = new System.Drawing.Point(29, 1);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(16, 10);
            this.upButton.TabIndex = 228;
            this.upButton.Text = null;
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upBox_Click);
            // 
            // CustomUpDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.upButton);
            this.Name = "CustomUpDown";
            this.Size = new System.Drawing.Size(48, 25);
            this.ResumeLayout(false);

        }

        #endregion
        private CustomButtons.ButtonNoPadding upButton;
        private CustomButtons.ButtonNoPadding downButton;
        private CustomTextBoxCentered textBox;
    }
}
