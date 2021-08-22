namespace AsterixDecoder
{
    partial class Exit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Exit));
            this.YesExitButton = new FontAwesome.Sharp.IconButton();
            this.NoExitButton = new FontAwesome.Sharp.IconButton();
            this.ExitLabel = new System.Windows.Forms.Label();
            this.HeaderBar = new System.Windows.Forms.Panel();
            this.CloseButton = new FontAwesome.Sharp.IconPictureBox();
            this.HeaderBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            this.SuspendLayout();
            // 
            // YesExitButton
            // 
            this.YesExitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.YesExitButton.AutoSize = true;
            this.YesExitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.YesExitButton.FlatAppearance.BorderSize = 0;
            this.YesExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.YesExitButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.YesExitButton.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YesExitButton.ForeColor = System.Drawing.Color.White;
            this.YesExitButton.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.YesExitButton.IconColor = System.Drawing.Color.Gainsboro;
            this.YesExitButton.IconSize = 32;
            this.YesExitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.YesExitButton.Location = new System.Drawing.Point(135, 141);
            this.YesExitButton.Margin = new System.Windows.Forms.Padding(4);
            this.YesExitButton.Name = "YesExitButton";
            this.YesExitButton.Rotation = 0D;
            this.YesExitButton.Size = new System.Drawing.Size(88, 52);
            this.YesExitButton.TabIndex = 13;
            this.YesExitButton.Text = "Yes";
            this.YesExitButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.YesExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.YesExitButton.UseVisualStyleBackColor = false;
            this.YesExitButton.Click += new System.EventHandler(this.YesExitButton_Click);
            // 
            // NoExitButton
            // 
            this.NoExitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NoExitButton.AutoSize = true;
            this.NoExitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.NoExitButton.FlatAppearance.BorderSize = 0;
            this.NoExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NoExitButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.NoExitButton.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoExitButton.ForeColor = System.Drawing.Color.White;
            this.NoExitButton.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.NoExitButton.IconColor = System.Drawing.Color.Gainsboro;
            this.NoExitButton.IconSize = 32;
            this.NoExitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NoExitButton.Location = new System.Drawing.Point(254, 141);
            this.NoExitButton.Margin = new System.Windows.Forms.Padding(4);
            this.NoExitButton.Name = "NoExitButton";
            this.NoExitButton.Rotation = 0D;
            this.NoExitButton.Size = new System.Drawing.Size(88, 53);
            this.NoExitButton.TabIndex = 14;
            this.NoExitButton.Text = "No";
            this.NoExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.NoExitButton.UseVisualStyleBackColor = false;
            this.NoExitButton.Click += new System.EventHandler(this.NoExitButton_Click);
            // 
            // ExitLabel
            // 
            this.ExitLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ExitLabel.AutoSize = true;
            this.ExitLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitLabel.ForeColor = System.Drawing.Color.Black;
            this.ExitLabel.Location = new System.Drawing.Point(115, 94);
            this.ExitLabel.Name = "ExitLabel";
            this.ExitLabel.Size = new System.Drawing.Size(256, 29);
            this.ExitLabel.TabIndex = 1;
            this.ExitLabel.Text = "Are you sure you want to exit?";
            this.ExitLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // HeaderBar
            // 
            this.HeaderBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.HeaderBar.Controls.Add(this.CloseButton);
            this.HeaderBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderBar.Location = new System.Drawing.Point(0, 0);
            this.HeaderBar.Name = "HeaderBar";
            this.HeaderBar.Size = new System.Drawing.Size(469, 39);
            this.HeaderBar.TabIndex = 15;
            this.HeaderBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HeaderBar_MouseDown);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseButton.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.CloseButton.IconColor = System.Drawing.Color.White;
            this.CloseButton.IconSize = 30;
            this.CloseButton.Location = new System.Drawing.Point(436, 6);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(30, 30);
            this.CloseButton.TabIndex = 16;
            this.CloseButton.TabStop = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // Exit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(469, 281);
            this.Controls.Add(this.ExitLabel);
            this.Controls.Add(this.NoExitButton);
            this.Controls.Add(this.HeaderBar);
            this.Controls.Add(this.YesExitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Exit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EXIT";
            this.HeaderBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton YesExitButton;
        private FontAwesome.Sharp.IconButton NoExitButton;
        private System.Windows.Forms.Label ExitLabel;
        private System.Windows.Forms.Panel HeaderBar;
        private FontAwesome.Sharp.IconPictureBox CloseButton;
    }
}