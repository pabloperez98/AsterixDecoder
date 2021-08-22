namespace AsterixDecoder
{
    partial class MoreInformation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.HeaderBar = new System.Windows.Forms.Panel();
            this.CloseButton = new FontAwesome.Sharp.IconPictureBox();
            this.dataGridViewMoreInfo = new System.Windows.Forms.DataGridView();
            this.HeaderBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMoreInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // HeaderBar
            // 
            this.HeaderBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.HeaderBar.Controls.Add(this.CloseButton);
            this.HeaderBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderBar.Location = new System.Drawing.Point(0, 0);
            this.HeaderBar.Margin = new System.Windows.Forms.Padding(2);
            this.HeaderBar.Name = "HeaderBar";
            this.HeaderBar.Size = new System.Drawing.Size(438, 33);
            this.HeaderBar.TabIndex = 1;
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
            this.CloseButton.Location = new System.Drawing.Point(404, 5);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(30, 30);
            this.CloseButton.TabIndex = 17;
            this.CloseButton.TabStop = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // dataGridViewMoreInfo
            // 
            this.dataGridViewMoreInfo.AllowUserToAddRows = false;
            this.dataGridViewMoreInfo.AllowUserToDeleteRows = false;
            this.dataGridViewMoreInfo.AllowUserToResizeColumns = false;
            this.dataGridViewMoreInfo.AllowUserToResizeRows = false;
            this.dataGridViewMoreInfo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewMoreInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMoreInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewMoreInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMoreInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMoreInfo.EnableHeadersVisualStyles = false;
            this.dataGridViewMoreInfo.Location = new System.Drawing.Point(0, 33);
            this.dataGridViewMoreInfo.MultiSelect = false;
            this.dataGridViewMoreInfo.Name = "dataGridViewMoreInfo";
            this.dataGridViewMoreInfo.ReadOnly = true;
            this.dataGridViewMoreInfo.RowHeadersVisible = false;
            this.dataGridViewMoreInfo.RowHeadersWidth = 51;
            this.dataGridViewMoreInfo.RowTemplate.Height = 24;
            this.dataGridViewMoreInfo.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewMoreInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMoreInfo.ShowCellToolTips = false;
            this.dataGridViewMoreInfo.Size = new System.Drawing.Size(438, 266);
            this.dataGridViewMoreInfo.TabIndex = 2;
            // 
            // MoreInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 299);
            this.Controls.Add(this.dataGridViewMoreInfo);
            this.Controls.Add(this.HeaderBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MoreInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MORE INFORMATION";
            this.Load += new System.EventHandler(this.MoreInformation_Load);
            this.Shown += new System.EventHandler(this.MoreInformation_Shown);
            this.HeaderBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMoreInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel HeaderBar;
        private FontAwesome.Sharp.IconPictureBox CloseButton;
        private System.Windows.Forms.DataGridView dataGridViewMoreInfo;
    }
}