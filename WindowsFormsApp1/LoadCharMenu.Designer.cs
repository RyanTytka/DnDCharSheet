namespace WindowsFormsApp1
{
    partial class LoadCharMenu
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
            this.characterListBox = new System.Windows.Forms.ListBox();
            this.SubmitButton = new CustomButtons.ButtonNoPadding();
            this.nametextBox = new System.Windows.Forms.TextBox();
            this.descriptiontextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.deletebutton = new CustomButtons.ButtonNoPadding();
            this.SuspendLayout();
            // 
            // characterListBox
            // 
            this.characterListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.characterListBox.FormattingEnabled = true;
            this.characterListBox.ItemHeight = 20;
            this.characterListBox.Location = new System.Drawing.Point(12, 12);
            this.characterListBox.Name = "characterListBox";
            this.characterListBox.ScrollAlwaysVisible = true;
            this.characterListBox.Size = new System.Drawing.Size(321, 184);
            this.characterListBox.TabIndex = 1;
            this.characterListBox.SelectedIndexChanged += new System.EventHandler(this.characterListBox_SelectedIndexChanged);
            this.characterListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.characterListBox_MouseDoubleClick);
            // 
            // SubmitButton
            // 
            this.SubmitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.SubmitButton.Location = new System.Drawing.Point(341, 169);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(67, 27);
            this.SubmitButton.TabIndex = 2;
            this.SubmitButton.Text = "Save";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // nametextBox
            // 
            this.nametextBox.Location = new System.Drawing.Point(337, 31);
            this.nametextBox.Name = "nametextBox";
            this.nametextBox.Size = new System.Drawing.Size(145, 20);
            this.nametextBox.TabIndex = 3;
            // 
            // descriptiontextBox
            // 
            this.descriptiontextBox.Location = new System.Drawing.Point(338, 76);
            this.descriptiontextBox.Name = "descriptiontextBox";
            this.descriptiontextBox.Size = new System.Drawing.Size(144, 20);
            this.descriptiontextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(339, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(339, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Description";
            // 
            // deletebutton
            // 
            this.deletebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.deletebutton.Location = new System.Drawing.Point(415, 169);
            this.deletebutton.Name = "deletebutton";
            this.deletebutton.Size = new System.Drawing.Size(67, 27);
            this.deletebutton.TabIndex = 7;
            this.deletebutton.Text = "Delete";
            this.deletebutton.UseVisualStyleBackColor = true;
            this.deletebutton.Click += new System.EventHandler(this.deletebutton_Click);
            // 
            // LoadCharMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 202);
            this.Controls.Add(this.deletebutton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.descriptiontextBox);
            this.Controls.Add(this.nametextBox);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.characterListBox);
            this.Name = "LoadCharMenu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LoadCharMenu";
            this.Load += new System.EventHandler(this.LoadCharMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox characterListBox;
        private CustomButtons.ButtonNoPadding SubmitButton;
        private System.Windows.Forms.TextBox nametextBox;
        private System.Windows.Forms.TextBox descriptiontextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CustomButtons.ButtonNoPadding deletebutton;
    }
}