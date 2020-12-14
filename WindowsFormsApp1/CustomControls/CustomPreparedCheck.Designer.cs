namespace WindowsFormsApp1.CustomControls
{
    partial class CustomPreparedCheck
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
            this.notPreparedButton = new CustomButtons.ButtonNoPadding();
            this.preparedButton = new CustomButtons.ButtonNoPadding();
            this.lockedButton = new CustomButtons.ButtonNoPadding();
            this.SuspendLayout();
            // 
            // notPreparedButton
            // 
            this.notPreparedButton.BackgroundImage = global::InteractiveCharacterSheet.Properties.Resources.X;
            this.notPreparedButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.notPreparedButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.notPreparedButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.notPreparedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.notPreparedButton.Location = new System.Drawing.Point(-1, -1);
            this.notPreparedButton.Name = "notPreparedButton";
            this.notPreparedButton.Size = new System.Drawing.Size(20, 20);
            this.notPreparedButton.TabIndex = 1;
            this.notPreparedButton.TabStop = false;
            this.notPreparedButton.Text = null;
            this.notPreparedButton.UseVisualStyleBackColor = true;
            this.notPreparedButton.Click += new System.EventHandler(this.notPreparedButton_Click);
            // 
            // preparedButton
            // 
            this.preparedButton.BackgroundImage = global::InteractiveCharacterSheet.Properties.Resources.check;
            this.preparedButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.preparedButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.preparedButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.preparedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.preparedButton.Location = new System.Drawing.Point(-1, -1);
            this.preparedButton.Name = "preparedButton";
            this.preparedButton.Size = new System.Drawing.Size(20, 20);
            this.preparedButton.TabIndex = 0;
            this.preparedButton.TabStop = false;
            this.preparedButton.Text = null;
            this.preparedButton.UseVisualStyleBackColor = true;
            this.preparedButton.Click += new System.EventHandler(this.preparedButton_Click);
            // 
            // lockedButton
            // 
            this.lockedButton.BackgroundImage = global::InteractiveCharacterSheet.Properties.Resources.LockIcon;
            this.lockedButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lockedButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.lockedButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lockedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lockedButton.Location = new System.Drawing.Point(-1, -1);
            this.lockedButton.Name = "lockedButton";
            this.lockedButton.Size = new System.Drawing.Size(20, 20);
            this.lockedButton.TabIndex = 2;
            this.lockedButton.TabStop = false;
            this.lockedButton.Text = null;
            this.lockedButton.UseVisualStyleBackColor = true;
            this.lockedButton.Click += new System.EventHandler(this.lockedButton_Click);
            // 
            // CustomPreparedCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.notPreparedButton);
            this.Controls.Add(this.preparedButton);
            this.Controls.Add(this.lockedButton);
            this.Name = "CustomPreparedCheck";
            this.Size = new System.Drawing.Size(18, 18);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomButtons.ButtonNoPadding preparedButton;
        private CustomButtons.ButtonNoPadding notPreparedButton;
        private CustomButtons.ButtonNoPadding lockedButton;
    }
}
