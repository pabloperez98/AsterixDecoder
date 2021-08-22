namespace AsterixDecoder
{
    partial class DataView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.moreInfoLabel = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.SearchPacket = new System.Windows.Forms.Label();
            this.SearchInTable = new FontAwesome.Sharp.IconPictureBox();
            this.FilterPacketCheckList = new System.Windows.Forms.CheckedListBox();
            this.SearchInfoLabel = new System.Windows.Forms.Label();
            this.resetDataGrid = new FontAwesome.Sharp.IconPictureBox();
            this.totalPacketsLabel = new System.Windows.Forms.Label();
            this.ChainFiltersCheckBox = new System.Windows.Forms.CheckedListBox();
            this.CSV_Button = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchInTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resetDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CSV_Button)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.Location = new System.Drawing.Point(12, 66);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.ShowCellToolTips = false;
            this.dataGridView.Size = new System.Drawing.Size(1058, 600);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // moreInfoLabel
            // 
            this.moreInfoLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.moreInfoLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moreInfoLabel.ForeColor = System.Drawing.Color.Black;
            this.moreInfoLabel.Location = new System.Drawing.Point(29, 10);
            this.moreInfoLabel.Name = "moreInfoLabel";
            this.moreInfoLabel.Size = new System.Drawing.Size(108, 42);
            this.moreInfoLabel.TabIndex = 1;
            this.moreInfoLabel.Text = "* Click to see \n more information";
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SearchTextBox.Location = new System.Drawing.Point(573, 22);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(131, 24);
            this.SearchTextBox.TabIndex = 2;
            this.SearchTextBox.Visible = false;
            this.SearchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchTextBox_KeyPress);
            // 
            // SearchPacket
            // 
            this.SearchPacket.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SearchPacket.Font = new System.Drawing.Font("Bahnschrift Condensed", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchPacket.ForeColor = System.Drawing.Color.Black;
            this.SearchPacket.Location = new System.Drawing.Point(172, 21);
            this.SearchPacket.Name = "SearchPacket";
            this.SearchPacket.Size = new System.Drawing.Size(71, 21);
            this.SearchPacket.TabIndex = 3;
            this.SearchPacket.Text = "Search by :";
            // 
            // SearchInTable
            // 
            this.SearchInTable.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SearchInTable.BackColor = System.Drawing.SystemColors.Control;
            this.SearchInTable.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SearchInTable.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.SearchInTable.IconColor = System.Drawing.SystemColors.ControlText;
            this.SearchInTable.Location = new System.Drawing.Point(724, 26);
            this.SearchInTable.Name = "SearchInTable";
            this.SearchInTable.Size = new System.Drawing.Size(32, 32);
            this.SearchInTable.TabIndex = 4;
            this.SearchInTable.TabStop = false;
            this.SearchInTable.Click += new System.EventHandler(this.SearchInTable_Click);
            // 
            // FilterPacketCheckList
            // 
            this.FilterPacketCheckList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.FilterPacketCheckList.BackColor = System.Drawing.SystemColors.Control;
            this.FilterPacketCheckList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FilterPacketCheckList.CheckOnClick = true;
            this.FilterPacketCheckList.ColumnWidth = 100;
            this.FilterPacketCheckList.Font = new System.Drawing.Font("Bahnschrift Light", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterPacketCheckList.ForeColor = System.Drawing.Color.Black;
            this.FilterPacketCheckList.FormattingEnabled = true;
            this.FilterPacketCheckList.Items.AddRange(new object[] {
            "CAT",
            "SAC/SIC",
            "CallSign",
            "Track Nº",
            "ICAO Adress",
            "Mode 3/A"});
            this.FilterPacketCheckList.Location = new System.Drawing.Point(255, 14);
            this.FilterPacketCheckList.MultiColumn = true;
            this.FilterPacketCheckList.Name = "FilterPacketCheckList";
            this.FilterPacketCheckList.Size = new System.Drawing.Size(311, 36);
            this.FilterPacketCheckList.TabIndex = 1;
            this.FilterPacketCheckList.SelectedIndexChanged += new System.EventHandler(this.FilterPacketCheckList_SelectedIndexChanged);
            // 
            // SearchInfoLabel
            // 
            this.SearchInfoLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SearchInfoLabel.AutoSize = true;
            this.SearchInfoLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchInfoLabel.ForeColor = System.Drawing.Color.Black;
            this.SearchInfoLabel.Location = new System.Drawing.Point(877, 32);
            this.SearchInfoLabel.Name = "SearchInfoLabel";
            this.SearchInfoLabel.Size = new System.Drawing.Size(72, 21);
            this.SearchInfoLabel.TabIndex = 5;
            this.SearchInfoLabel.Text = "Search Info";
            this.SearchInfoLabel.Visible = false;
            // 
            // resetDataGrid
            // 
            this.resetDataGrid.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.resetDataGrid.BackColor = System.Drawing.SystemColors.Control;
            this.resetDataGrid.ForeColor = System.Drawing.SystemColors.ControlText;
            this.resetDataGrid.IconChar = FontAwesome.Sharp.IconChar.Redo;
            this.resetDataGrid.IconColor = System.Drawing.SystemColors.ControlText;
            this.resetDataGrid.Location = new System.Drawing.Point(762, 26);
            this.resetDataGrid.Name = "resetDataGrid";
            this.resetDataGrid.Size = new System.Drawing.Size(32, 32);
            this.resetDataGrid.TabIndex = 6;
            this.resetDataGrid.TabStop = false;
            this.resetDataGrid.Click += new System.EventHandler(this.resetDataGrid_Click);
            // 
            // totalPacketsLabel
            // 
            this.totalPacketsLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.totalPacketsLabel.AutoSize = true;
            this.totalPacketsLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPacketsLabel.ForeColor = System.Drawing.Color.Black;
            this.totalPacketsLabel.Location = new System.Drawing.Point(877, 9);
            this.totalPacketsLabel.Name = "totalPacketsLabel";
            this.totalPacketsLabel.Size = new System.Drawing.Size(86, 21);
            this.totalPacketsLabel.TabIndex = 7;
            this.totalPacketsLabel.Text = "Total Packets:";
            // 
            // ChainFiltersCheckBox
            // 
            this.ChainFiltersCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ChainFiltersCheckBox.BackColor = System.Drawing.SystemColors.Control;
            this.ChainFiltersCheckBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ChainFiltersCheckBox.CheckOnClick = true;
            this.ChainFiltersCheckBox.ColumnWidth = 100;
            this.ChainFiltersCheckBox.Font = new System.Drawing.Font("Bahnschrift Light", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChainFiltersCheckBox.ForeColor = System.Drawing.Color.Black;
            this.ChainFiltersCheckBox.FormattingEnabled = true;
            this.ChainFiltersCheckBox.Items.AddRange(new object[] {
            "Chain filters"});
            this.ChainFiltersCheckBox.Location = new System.Drawing.Point(723, 2);
            this.ChainFiltersCheckBox.MultiColumn = true;
            this.ChainFiltersCheckBox.Name = "ChainFiltersCheckBox";
            this.ChainFiltersCheckBox.Size = new System.Drawing.Size(103, 18);
            this.ChainFiltersCheckBox.TabIndex = 8;
            this.ChainFiltersCheckBox.SelectedIndexChanged += new System.EventHandler(this.ChainFiltersCheckBox_SelectedIndexChanged);
            // 
            // CSV_Button
            // 
            this.CSV_Button.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CSV_Button.BackColor = System.Drawing.SystemColors.Control;
            this.CSV_Button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CSV_Button.IconChar = FontAwesome.Sharp.IconChar.FileCsv;
            this.CSV_Button.IconColor = System.Drawing.SystemColors.ControlText;
            this.CSV_Button.Location = new System.Drawing.Point(800, 26);
            this.CSV_Button.Name = "CSV_Button";
            this.CSV_Button.Size = new System.Drawing.Size(32, 32);
            this.CSV_Button.TabIndex = 9;
            this.CSV_Button.TabStop = false;
            this.CSV_Button.Click += new System.EventHandler(this.CSV_Button_Click);
            // 
            // DataView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1082, 672);
            this.Controls.Add(this.CSV_Button);
            this.Controls.Add(this.ChainFiltersCheckBox);
            this.Controls.Add(this.totalPacketsLabel);
            this.Controls.Add(this.resetDataGrid);
            this.Controls.Add(this.SearchInfoLabel);
            this.Controls.Add(this.FilterPacketCheckList);
            this.Controls.Add(this.SearchInTable);
            this.Controls.Add(this.SearchPacket);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.moreInfoLabel);
            this.Controls.Add(this.dataGridView);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DataView";
            this.Text = "DATA VIEW";
            this.Load += new System.EventHandler(this.DataView_Load);
            this.Shown += new System.EventHandler(this.DataView_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchInTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resetDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CSV_Button)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label moreInfoLabel;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Label SearchPacket;
        private FontAwesome.Sharp.IconPictureBox SearchInTable;
        private System.Windows.Forms.CheckedListBox FilterPacketCheckList;
        private System.Windows.Forms.Label SearchInfoLabel;
        private FontAwesome.Sharp.IconPictureBox resetDataGrid;
        private System.Windows.Forms.Label totalPacketsLabel;
        private System.Windows.Forms.CheckedListBox ChainFiltersCheckBox;
        private FontAwesome.Sharp.IconPictureBox CSV_Button;
    }
}