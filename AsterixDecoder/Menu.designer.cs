namespace AsterixDecoder
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.MenuVertical = new System.Windows.Forms.Panel();
            this.SelectTimeButton = new FontAwesome.Sharp.IconButton();
            this.LoadFileButton = new FontAwesome.Sharp.IconButton();
            this.ExitPanel = new System.Windows.Forms.Panel();
            this.NoExitButton = new FontAwesome.Sharp.IconButton();
            this.ExitLabel2 = new System.Windows.Forms.Label();
            this.YesExitButton = new FontAwesome.Sharp.IconButton();
            this.ExitLabel1 = new System.Windows.Forms.Label();
            this.ExitButton = new FontAwesome.Sharp.IconButton();
            this.ClearFileButton = new FontAwesome.Sharp.IconButton();
            this.MapViewButton = new FontAwesome.Sharp.IconButton();
            this.DataViewButton = new FontAwesome.Sharp.IconButton();
            this.LogoPanel = new System.Windows.Forms.Panel();
            this.LogoIcon = new System.Windows.Forms.PictureBox();
            this.DecoderLabel = new System.Windows.Forms.Label();
            this.AsterixLabel = new System.Windows.Forms.Label();
            this.HeaderBar = new System.Windows.Forms.Panel();
            this.CurrentFileLabel = new System.Windows.Forms.Label();
            this.CurrentFormTitle = new System.Windows.Forms.Label();
            this.CurrentFormIcon = new FontAwesome.Sharp.IconPictureBox();
            this.MinimizeButton = new FontAwesome.Sharp.IconPictureBox();
            this.MaximizeRestoreButton = new FontAwesome.Sharp.IconPictureBox();
            this.CloseButton = new FontAwesome.Sharp.IconPictureBox();
            this.SlideButton = new FontAwesome.Sharp.IconPictureBox();
            this.PanelContenedor = new System.Windows.Forms.Panel();
            this.timePeriodSelectedLabel = new System.Windows.Forms.Label();
            this.SearchInFile = new FontAwesome.Sharp.IconPictureBox();
            this.InfoPeriodTimeLabel = new System.Windows.Forms.Label();
            this.SelectionTimeLabel = new System.Windows.Forms.Label();
            this.FinalTimeLabel = new System.Windows.Forms.Label();
            this.InitialTimeLabel = new System.Windows.Forms.Label();
            this.FinalTimeTextBox = new System.Windows.Forms.TextBox();
            this.InitialTimeTextBox = new System.Windows.Forms.TextBox();
            this.LongInfoMessageLabel = new System.Windows.Forms.Label();
            this.PacketsDecodedLabel = new System.Windows.Forms.Label();
            this.ShortInfoMessageLabel = new System.Windows.Forms.Label();
            this.DecoderInicialLabel = new System.Windows.Forms.Label();
            this.LogoInicial = new System.Windows.Forms.PictureBox();
            this.AsterixInicialLabel = new System.Windows.Forms.Label();
            this.MenuVertical.SuspendLayout();
            this.ExitPanel.SuspendLayout();
            this.LogoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoIcon)).BeginInit();
            this.HeaderBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentFormIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximizeRestoreButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlideButton)).BeginInit();
            this.PanelContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchInFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoInicial)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuVertical
            // 
            this.MenuVertical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.MenuVertical.Controls.Add(this.SelectTimeButton);
            this.MenuVertical.Controls.Add(this.LoadFileButton);
            this.MenuVertical.Controls.Add(this.ExitPanel);
            this.MenuVertical.Controls.Add(this.ExitButton);
            this.MenuVertical.Controls.Add(this.ClearFileButton);
            this.MenuVertical.Controls.Add(this.MapViewButton);
            this.MenuVertical.Controls.Add(this.DataViewButton);
            this.MenuVertical.Controls.Add(this.LogoPanel);
            this.MenuVertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuVertical.Location = new System.Drawing.Point(0, 0);
            this.MenuVertical.Name = "MenuVertical";
            this.MenuVertical.Size = new System.Drawing.Size(200, 703);
            this.MenuVertical.TabIndex = 2;
            // 
            // SelectTimeButton
            // 
            this.SelectTimeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SelectTimeButton.FlatAppearance.BorderSize = 0;
            this.SelectTimeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectTimeButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.SelectTimeButton.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectTimeButton.IconChar = FontAwesome.Sharp.IconChar.Clock;
            this.SelectTimeButton.IconColor = System.Drawing.Color.Gainsboro;
            this.SelectTimeButton.IconSize = 40;
            this.SelectTimeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SelectTimeButton.Location = new System.Drawing.Point(0, 195);
            this.SelectTimeButton.Margin = new System.Windows.Forms.Padding(0);
            this.SelectTimeButton.Name = "SelectTimeButton";
            this.SelectTimeButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.SelectTimeButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SelectTimeButton.Rotation = 0D;
            this.SelectTimeButton.Size = new System.Drawing.Size(200, 75);
            this.SelectTimeButton.TabIndex = 10;
            this.SelectTimeButton.Text = "SELECT TIME";
            this.SelectTimeButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SelectTimeButton.UseVisualStyleBackColor = true;
            this.SelectTimeButton.Click += new System.EventHandler(this.SelectTimeButton_Click);
            // 
            // LoadFileButton
            // 
            this.LoadFileButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LoadFileButton.FlatAppearance.BorderSize = 0;
            this.LoadFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadFileButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.LoadFileButton.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadFileButton.IconChar = FontAwesome.Sharp.IconChar.FileDownload;
            this.LoadFileButton.IconColor = System.Drawing.Color.Gainsboro;
            this.LoadFileButton.IconSize = 40;
            this.LoadFileButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LoadFileButton.Location = new System.Drawing.Point(0, 120);
            this.LoadFileButton.Margin = new System.Windows.Forms.Padding(4);
            this.LoadFileButton.Name = "LoadFileButton";
            this.LoadFileButton.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.LoadFileButton.Rotation = 0D;
            this.LoadFileButton.Size = new System.Drawing.Size(200, 75);
            this.LoadFileButton.TabIndex = 11;
            this.LoadFileButton.Text = "LOAD FILE";
            this.LoadFileButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LoadFileButton.UseVisualStyleBackColor = true;
            this.LoadFileButton.Click += new System.EventHandler(this.LoadFileButton_Click);
            // 
            // ExitPanel
            // 
            this.ExitPanel.Controls.Add(this.NoExitButton);
            this.ExitPanel.Controls.Add(this.ExitLabel2);
            this.ExitPanel.Controls.Add(this.YesExitButton);
            this.ExitPanel.Controls.Add(this.ExitLabel1);
            this.ExitPanel.Location = new System.Drawing.Point(0, 570);
            this.ExitPanel.Name = "ExitPanel";
            this.ExitPanel.Size = new System.Drawing.Size(200, 115);
            this.ExitPanel.TabIndex = 10;
            this.ExitPanel.Visible = false;
            // 
            // NoExitButton
            // 
            this.NoExitButton.FlatAppearance.BorderSize = 0;
            this.NoExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NoExitButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.NoExitButton.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoExitButton.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.NoExitButton.IconColor = System.Drawing.Color.Gainsboro;
            this.NoExitButton.IconSize = 32;
            this.NoExitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NoExitButton.Location = new System.Drawing.Point(101, 63);
            this.NoExitButton.Margin = new System.Windows.Forms.Padding(4);
            this.NoExitButton.Name = "NoExitButton";
            this.NoExitButton.Rotation = 0D;
            this.NoExitButton.Size = new System.Drawing.Size(90, 55);
            this.NoExitButton.TabIndex = 12;
            this.NoExitButton.Text = "No";
            this.NoExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.NoExitButton.UseVisualStyleBackColor = true;
            this.NoExitButton.Click += new System.EventHandler(this.NoExitButton_Click);
            // 
            // ExitLabel2
            // 
            this.ExitLabel2.AutoSize = true;
            this.ExitLabel2.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitLabel2.Location = new System.Drawing.Point(24, 30);
            this.ExitLabel2.Name = "ExitLabel2";
            this.ExitLabel2.Size = new System.Drawing.Size(149, 29);
            this.ExitLabel2.TabIndex = 1;
            this.ExitLabel2.Text = "you want to exit?";
            // 
            // YesExitButton
            // 
            this.YesExitButton.FlatAppearance.BorderSize = 0;
            this.YesExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.YesExitButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.YesExitButton.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YesExitButton.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.YesExitButton.IconColor = System.Drawing.Color.Gainsboro;
            this.YesExitButton.IconSize = 32;
            this.YesExitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.YesExitButton.Location = new System.Drawing.Point(4, 63);
            this.YesExitButton.Margin = new System.Windows.Forms.Padding(4);
            this.YesExitButton.Name = "YesExitButton";
            this.YesExitButton.Rotation = 0D;
            this.YesExitButton.Size = new System.Drawing.Size(90, 55);
            this.YesExitButton.TabIndex = 11;
            this.YesExitButton.Text = "Yes";
            this.YesExitButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.YesExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.YesExitButton.UseVisualStyleBackColor = true;
            this.YesExitButton.Click += new System.EventHandler(this.YesExitButton_Click);
            // 
            // ExitLabel1
            // 
            this.ExitLabel1.AutoSize = true;
            this.ExitLabel1.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitLabel1.Location = new System.Drawing.Point(37, 1);
            this.ExitLabel1.Name = "ExitLabel1";
            this.ExitLabel1.Size = new System.Drawing.Size(115, 29);
            this.ExitLabel1.TabIndex = 0;
            this.ExitLabel1.Text = "Are you sure";
            // 
            // ExitButton
            // 
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.ExitButton.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.ExitButton.IconColor = System.Drawing.Color.Gainsboro;
            this.ExitButton.IconSize = 40;
            this.ExitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExitButton.Location = new System.Drawing.Point(0, 495);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(4);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.ExitButton.Rotation = 0D;
            this.ExitButton.Size = new System.Drawing.Size(200, 75);
            this.ExitButton.TabIndex = 9;
            this.ExitButton.Text = "EXIT";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ClearFileButton
            // 
            this.ClearFileButton.FlatAppearance.BorderSize = 0;
            this.ClearFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearFileButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.ClearFileButton.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearFileButton.IconChar = FontAwesome.Sharp.IconChar.AddressCard;
            this.ClearFileButton.IconColor = System.Drawing.Color.Gainsboro;
            this.ClearFileButton.IconSize = 40;
            this.ClearFileButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ClearFileButton.Location = new System.Drawing.Point(0, 420);
            this.ClearFileButton.Margin = new System.Windows.Forms.Padding(4);
            this.ClearFileButton.Name = "ClearFileButton";
            this.ClearFileButton.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.ClearFileButton.Rotation = 0D;
            this.ClearFileButton.Size = new System.Drawing.Size(200, 75);
            this.ClearFileButton.TabIndex = 8;
            this.ClearFileButton.Text = "CLEAR FILE";
            this.ClearFileButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ClearFileButton.UseVisualStyleBackColor = true;
            this.ClearFileButton.Click += new System.EventHandler(this.ClearFileButton_Click);
            // 
            // MapViewButton
            // 
            this.MapViewButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MapViewButton.FlatAppearance.BorderSize = 0;
            this.MapViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MapViewButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.MapViewButton.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MapViewButton.IconChar = FontAwesome.Sharp.IconChar.MapMarkedAlt;
            this.MapViewButton.IconColor = System.Drawing.Color.Gainsboro;
            this.MapViewButton.IconSize = 40;
            this.MapViewButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MapViewButton.Location = new System.Drawing.Point(0, 345);
            this.MapViewButton.Margin = new System.Windows.Forms.Padding(4);
            this.MapViewButton.Name = "MapViewButton";
            this.MapViewButton.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.MapViewButton.Rotation = 0D;
            this.MapViewButton.Size = new System.Drawing.Size(200, 75);
            this.MapViewButton.TabIndex = 7;
            this.MapViewButton.Text = "MAP VIEW";
            this.MapViewButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MapViewButton.UseVisualStyleBackColor = true;
            this.MapViewButton.Click += new System.EventHandler(this.MapViewButton_Click);
            // 
            // DataViewButton
            // 
            this.DataViewButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DataViewButton.FlatAppearance.BorderSize = 0;
            this.DataViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DataViewButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.DataViewButton.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataViewButton.IconChar = FontAwesome.Sharp.IconChar.Table;
            this.DataViewButton.IconColor = System.Drawing.Color.Gainsboro;
            this.DataViewButton.IconSize = 40;
            this.DataViewButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DataViewButton.Location = new System.Drawing.Point(0, 270);
            this.DataViewButton.Margin = new System.Windows.Forms.Padding(4);
            this.DataViewButton.Name = "DataViewButton";
            this.DataViewButton.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.DataViewButton.Rotation = 0D;
            this.DataViewButton.Size = new System.Drawing.Size(200, 75);
            this.DataViewButton.TabIndex = 6;
            this.DataViewButton.Text = "DATA VIEW";
            this.DataViewButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DataViewButton.UseVisualStyleBackColor = true;
            this.DataViewButton.Click += new System.EventHandler(this.DataViewButton_Click);
            // 
            // LogoPanel
            // 
            this.LogoPanel.Controls.Add(this.LogoIcon);
            this.LogoPanel.Controls.Add(this.DecoderLabel);
            this.LogoPanel.Controls.Add(this.AsterixLabel);
            this.LogoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.LogoPanel.Location = new System.Drawing.Point(0, 0);
            this.LogoPanel.Margin = new System.Windows.Forms.Padding(4);
            this.LogoPanel.Name = "LogoPanel";
            this.LogoPanel.Size = new System.Drawing.Size(200, 121);
            this.LogoPanel.TabIndex = 1;
            // 
            // LogoIcon
            // 
            this.LogoIcon.Image = ((System.Drawing.Image)(resources.GetObject("LogoIcon.Image")));
            this.LogoIcon.Location = new System.Drawing.Point(2, 13);
            this.LogoIcon.Name = "LogoIcon";
            this.LogoIcon.Size = new System.Drawing.Size(65, 65);
            this.LogoIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoIcon.TabIndex = 0;
            this.LogoIcon.TabStop = false;
            // 
            // DecoderLabel
            // 
            this.DecoderLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DecoderLabel.ForeColor = System.Drawing.Color.Black;
            this.DecoderLabel.Location = new System.Drawing.Point(65, 54);
            this.DecoderLabel.Name = "DecoderLabel";
            this.DecoderLabel.Size = new System.Drawing.Size(136, 48);
            this.DecoderLabel.TabIndex = 2;
            this.DecoderLabel.Text = "DECODER";
            // 
            // AsterixLabel
            // 
            this.AsterixLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AsterixLabel.ForeColor = System.Drawing.Color.Black;
            this.AsterixLabel.Location = new System.Drawing.Point(68, 9);
            this.AsterixLabel.Name = "AsterixLabel";
            this.AsterixLabel.Size = new System.Drawing.Size(125, 48);
            this.AsterixLabel.TabIndex = 1;
            this.AsterixLabel.Text = "ASTERIX";
            // 
            // HeaderBar
            // 
            this.HeaderBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.HeaderBar.Controls.Add(this.CurrentFileLabel);
            this.HeaderBar.Controls.Add(this.CurrentFormTitle);
            this.HeaderBar.Controls.Add(this.CurrentFormIcon);
            this.HeaderBar.Controls.Add(this.MinimizeButton);
            this.HeaderBar.Controls.Add(this.MaximizeRestoreButton);
            this.HeaderBar.Controls.Add(this.CloseButton);
            this.HeaderBar.Controls.Add(this.SlideButton);
            this.HeaderBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderBar.Location = new System.Drawing.Point(200, 0);
            this.HeaderBar.Name = "HeaderBar";
            this.HeaderBar.Size = new System.Drawing.Size(1082, 50);
            this.HeaderBar.TabIndex = 3;
            this.HeaderBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HeaderBar_MouseDown);
            // 
            // CurrentFileLabel
            // 
            this.CurrentFileLabel.AutoSize = true;
            this.CurrentFileLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentFileLabel.ForeColor = System.Drawing.Color.Black;
            this.CurrentFileLabel.Location = new System.Drawing.Point(238, 4);
            this.CurrentFileLabel.Name = "CurrentFileLabel";
            this.CurrentFileLabel.Size = new System.Drawing.Size(115, 23);
            this.CurrentFileLabel.TabIndex = 7;
            this.CurrentFileLabel.Text = "CURRENT FILE(S):";
            this.CurrentFileLabel.Visible = false;
            // 
            // CurrentFormTitle
            // 
            this.CurrentFormTitle.AutoSize = true;
            this.CurrentFormTitle.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentFormTitle.ForeColor = System.Drawing.Color.Black;
            this.CurrentFormTitle.Location = new System.Drawing.Point(120, 11);
            this.CurrentFormTitle.Name = "CurrentFormTitle";
            this.CurrentFormTitle.Size = new System.Drawing.Size(56, 29);
            this.CurrentFormTitle.TabIndex = 6;
            this.CurrentFormTitle.Text = "HOME";
            // 
            // CurrentFormIcon
            // 
            this.CurrentFormIcon.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CurrentFormIcon.ForeColor = System.Drawing.Color.Black;
            this.CurrentFormIcon.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.CurrentFormIcon.IconColor = System.Drawing.Color.Black;
            this.CurrentFormIcon.IconSize = 35;
            this.CurrentFormIcon.Location = new System.Drawing.Point(82, 9);
            this.CurrentFormIcon.Name = "CurrentFormIcon";
            this.CurrentFormIcon.Size = new System.Drawing.Size(35, 35);
            this.CurrentFormIcon.TabIndex = 5;
            this.CurrentFormIcon.TabStop = false;
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimizeButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MinimizeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinimizeButton.ForeColor = System.Drawing.Color.Black;
            this.MinimizeButton.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.MinimizeButton.IconColor = System.Drawing.Color.Black;
            this.MinimizeButton.IconSize = 30;
            this.MinimizeButton.Location = new System.Drawing.Point(967, 3);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(30, 30);
            this.MinimizeButton.TabIndex = 4;
            this.MinimizeButton.TabStop = false;
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // MaximizeRestoreButton
            // 
            this.MaximizeRestoreButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MaximizeRestoreButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MaximizeRestoreButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MaximizeRestoreButton.ForeColor = System.Drawing.Color.Black;
            this.MaximizeRestoreButton.IconChar = FontAwesome.Sharp.IconChar.WindowRestore;
            this.MaximizeRestoreButton.IconColor = System.Drawing.Color.Black;
            this.MaximizeRestoreButton.IconSize = 30;
            this.MaximizeRestoreButton.Location = new System.Drawing.Point(1004, 9);
            this.MaximizeRestoreButton.Name = "MaximizeRestoreButton";
            this.MaximizeRestoreButton.Size = new System.Drawing.Size(30, 30);
            this.MaximizeRestoreButton.TabIndex = 2;
            this.MaximizeRestoreButton.TabStop = false;
            this.MaximizeRestoreButton.Click += new System.EventHandler(this.MaximizeRestoreButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseButton.ForeColor = System.Drawing.Color.Black;
            this.CloseButton.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.CloseButton.IconColor = System.Drawing.Color.Black;
            this.CloseButton.IconSize = 30;
            this.CloseButton.Location = new System.Drawing.Point(1040, 9);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(30, 30);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.TabStop = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // SlideButton
            // 
            this.SlideButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SlideButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SlideButton.ForeColor = System.Drawing.Color.Black;
            this.SlideButton.IconChar = FontAwesome.Sharp.IconChar.Bars;
            this.SlideButton.IconColor = System.Drawing.Color.Black;
            this.SlideButton.IconSize = 35;
            this.SlideButton.Location = new System.Drawing.Point(7, 9);
            this.SlideButton.Name = "SlideButton";
            this.SlideButton.Size = new System.Drawing.Size(35, 35);
            this.SlideButton.TabIndex = 0;
            this.SlideButton.TabStop = false;
            this.SlideButton.Click += new System.EventHandler(this.SlideButton_Click);
            // 
            // PanelContenedor
            // 
            this.PanelContenedor.Controls.Add(this.timePeriodSelectedLabel);
            this.PanelContenedor.Controls.Add(this.SearchInFile);
            this.PanelContenedor.Controls.Add(this.InfoPeriodTimeLabel);
            this.PanelContenedor.Controls.Add(this.SelectionTimeLabel);
            this.PanelContenedor.Controls.Add(this.FinalTimeLabel);
            this.PanelContenedor.Controls.Add(this.InitialTimeLabel);
            this.PanelContenedor.Controls.Add(this.FinalTimeTextBox);
            this.PanelContenedor.Controls.Add(this.InitialTimeTextBox);
            this.PanelContenedor.Controls.Add(this.LongInfoMessageLabel);
            this.PanelContenedor.Controls.Add(this.PacketsDecodedLabel);
            this.PanelContenedor.Controls.Add(this.ShortInfoMessageLabel);
            this.PanelContenedor.Controls.Add(this.DecoderInicialLabel);
            this.PanelContenedor.Controls.Add(this.LogoInicial);
            this.PanelContenedor.Controls.Add(this.AsterixInicialLabel);
            this.PanelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContenedor.Location = new System.Drawing.Point(200, 50);
            this.PanelContenedor.Name = "PanelContenedor";
            this.PanelContenedor.Size = new System.Drawing.Size(1082, 653);
            this.PanelContenedor.TabIndex = 4;
            // 
            // timePeriodSelectedLabel
            // 
            this.timePeriodSelectedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timePeriodSelectedLabel.AutoSize = true;
            this.timePeriodSelectedLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timePeriodSelectedLabel.ForeColor = System.Drawing.Color.Black;
            this.timePeriodSelectedLabel.Location = new System.Drawing.Point(780, 16);
            this.timePeriodSelectedLabel.Name = "timePeriodSelectedLabel";
            this.timePeriodSelectedLabel.Size = new System.Drawing.Size(290, 23);
            this.timePeriodSelectedLabel.TabIndex = 8;
            this.timePeriodSelectedLabel.Text = "TIME PERIOD SELECTED: HH:MM:SS - HH:MM:SS";
            this.timePeriodSelectedLabel.Visible = false;
            // 
            // SearchInFile
            // 
            this.SearchInFile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SearchInFile.BackColor = System.Drawing.SystemColors.Control;
            this.SearchInFile.ForeColor = System.Drawing.Color.Black;
            this.SearchInFile.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.SearchInFile.IconColor = System.Drawing.Color.Black;
            this.SearchInFile.IconSize = 40;
            this.SearchInFile.Location = new System.Drawing.Point(696, 223);
            this.SearchInFile.Name = "SearchInFile";
            this.SearchInFile.Size = new System.Drawing.Size(40, 40);
            this.SearchInFile.TabIndex = 14;
            this.SearchInFile.TabStop = false;
            this.SearchInFile.Visible = false;
            this.SearchInFile.Click += new System.EventHandler(this.SearchInFile_Click);
            // 
            // InfoPeriodTimeLabel
            // 
            this.InfoPeriodTimeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.InfoPeriodTimeLabel.AutoSize = true;
            this.InfoPeriodTimeLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoPeriodTimeLabel.ForeColor = System.Drawing.Color.Black;
            this.InfoPeriodTimeLabel.Location = new System.Drawing.Point(234, 113);
            this.InfoPeriodTimeLabel.Name = "InfoPeriodTimeLabel";
            this.InfoPeriodTimeLabel.Size = new System.Drawing.Size(339, 29);
            this.InfoPeriodTimeLabel.TabIndex = 13;
            this.InfoPeriodTimeLabel.Text = "Initial and final time of the selected file: ";
            this.InfoPeriodTimeLabel.Visible = false;
            // 
            // SelectionTimeLabel
            // 
            this.SelectionTimeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SelectionTimeLabel.AutoSize = true;
            this.SelectionTimeLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectionTimeLabel.ForeColor = System.Drawing.Color.Black;
            this.SelectionTimeLabel.Location = new System.Drawing.Point(233, 143);
            this.SelectionTimeLabel.Name = "SelectionTimeLabel";
            this.SelectionTimeLabel.Size = new System.Drawing.Size(631, 29);
            this.SelectionTimeLabel.TabIndex = 12;
            this.SelectionTimeLabel.Text = "Please, select the time period of interest (maximum 30 min, format HH:MM:SS)";
            this.SelectionTimeLabel.Visible = false;
            // 
            // FinalTimeLabel
            // 
            this.FinalTimeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FinalTimeLabel.AutoSize = true;
            this.FinalTimeLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinalTimeLabel.ForeColor = System.Drawing.Color.Black;
            this.FinalTimeLabel.Location = new System.Drawing.Point(553, 200);
            this.FinalTimeLabel.Name = "FinalTimeLabel";
            this.FinalTimeLabel.Size = new System.Drawing.Size(99, 29);
            this.FinalTimeLabel.TabIndex = 11;
            this.FinalTimeLabel.Text = "Final Time:";
            this.FinalTimeLabel.Visible = false;
            // 
            // InitialTimeLabel
            // 
            this.InitialTimeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.InitialTimeLabel.AutoSize = true;
            this.InitialTimeLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InitialTimeLabel.ForeColor = System.Drawing.Color.Black;
            this.InitialTimeLabel.Location = new System.Drawing.Point(382, 200);
            this.InitialTimeLabel.Name = "InitialTimeLabel";
            this.InitialTimeLabel.Size = new System.Drawing.Size(106, 29);
            this.InitialTimeLabel.TabIndex = 8;
            this.InitialTimeLabel.Text = "Initial Time:";
            this.InitialTimeLabel.Visible = false;
            // 
            // FinalTimeTextBox
            // 
            this.FinalTimeTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FinalTimeTextBox.Location = new System.Drawing.Point(551, 236);
            this.FinalTimeTextBox.Name = "FinalTimeTextBox";
            this.FinalTimeTextBox.Size = new System.Drawing.Size(100, 27);
            this.FinalTimeTextBox.TabIndex = 10;
            this.FinalTimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FinalTimeTextBox.Visible = false;
            this.FinalTimeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FinalTimeTextBox_KeyPress);
            // 
            // InitialTimeTextBox
            // 
            this.InitialTimeTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.InitialTimeTextBox.Location = new System.Drawing.Point(384, 236);
            this.InitialTimeTextBox.Name = "InitialTimeTextBox";
            this.InitialTimeTextBox.Size = new System.Drawing.Size(100, 27);
            this.InitialTimeTextBox.TabIndex = 9;
            this.InitialTimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.InitialTimeTextBox.Visible = false;
            this.InitialTimeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InitialTimeTextBox_KeyPress);
            // 
            // LongInfoMessageLabel
            // 
            this.LongInfoMessageLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LongInfoMessageLabel.AutoSize = true;
            this.LongInfoMessageLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LongInfoMessageLabel.ForeColor = System.Drawing.Color.Black;
            this.LongInfoMessageLabel.Location = new System.Drawing.Point(268, 281);
            this.LongInfoMessageLabel.Name = "LongInfoMessageLabel";
            this.LongInfoMessageLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LongInfoMessageLabel.Size = new System.Drawing.Size(584, 48);
            this.LongInfoMessageLabel.TabIndex = 8;
            this.LongInfoMessageLabel.Text = "THE FILE HAS BEEN SUCCESSFULLY DECODED!";
            this.LongInfoMessageLabel.Visible = false;
            // 
            // PacketsDecodedLabel
            // 
            this.PacketsDecodedLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PacketsDecodedLabel.AutoSize = true;
            this.PacketsDecodedLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PacketsDecodedLabel.ForeColor = System.Drawing.Color.Black;
            this.PacketsDecodedLabel.Location = new System.Drawing.Point(333, 329);
            this.PacketsDecodedLabel.Name = "PacketsDecodedLabel";
            this.PacketsDecodedLabel.Size = new System.Drawing.Size(419, 48);
            this.PacketsDecodedLabel.TabIndex = 7;
            this.PacketsDecodedLabel.Text = "Nº PACKETS READY TO ANALYZE";
            this.PacketsDecodedLabel.Visible = false;
            // 
            // ShortInfoMessageLabel
            // 
            this.ShortInfoMessageLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ShortInfoMessageLabel.AutoSize = true;
            this.ShortInfoMessageLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShortInfoMessageLabel.ForeColor = System.Drawing.Color.Black;
            this.ShortInfoMessageLabel.Location = new System.Drawing.Point(395, 272);
            this.ShortInfoMessageLabel.Name = "ShortInfoMessageLabel";
            this.ShortInfoMessageLabel.Size = new System.Drawing.Size(252, 48);
            this.ShortInfoMessageLabel.TabIndex = 6;
            this.ShortInfoMessageLabel.Text = "FIRST LOAD A FILE";
            this.ShortInfoMessageLabel.Visible = false;
            // 
            // DecoderInicialLabel
            // 
            this.DecoderInicialLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DecoderInicialLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DecoderInicialLabel.ForeColor = System.Drawing.Color.Black;
            this.DecoderInicialLabel.Location = new System.Drawing.Point(444, 303);
            this.DecoderInicialLabel.Name = "DecoderInicialLabel";
            this.DecoderInicialLabel.Size = new System.Drawing.Size(407, 144);
            this.DecoderInicialLabel.TabIndex = 5;
            this.DecoderInicialLabel.Text = "DECODER";
            // 
            // LogoInicial
            // 
            this.LogoInicial.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LogoInicial.Image = ((System.Drawing.Image)(resources.GetObject("LogoInicial.Image")));
            this.LogoInicial.Location = new System.Drawing.Point(238, 214);
            this.LogoInicial.Name = "LogoInicial";
            this.LogoInicial.Size = new System.Drawing.Size(200, 200);
            this.LogoInicial.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoInicial.TabIndex = 3;
            this.LogoInicial.TabStop = false;
            // 
            // AsterixInicialLabel
            // 
            this.AsterixInicialLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AsterixInicialLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AsterixInicialLabel.ForeColor = System.Drawing.Color.Black;
            this.AsterixInicialLabel.Location = new System.Drawing.Point(453, 176);
            this.AsterixInicialLabel.Name = "AsterixInicialLabel";
            this.AsterixInicialLabel.Size = new System.Drawing.Size(372, 144);
            this.AsterixInicialLabel.TabIndex = 4;
            this.AsterixInicialLabel.Text = "ASTERIX";
            // 
            // Menu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1282, 703);
            this.Controls.Add(this.PanelContenedor);
            this.Controls.Add(this.HeaderBar);
            this.Controls.Add(this.MenuVertical);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1300, 750);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Resize += new System.EventHandler(this.Menu_Resize);
            this.MenuVertical.ResumeLayout(false);
            this.ExitPanel.ResumeLayout(false);
            this.ExitPanel.PerformLayout();
            this.LogoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LogoIcon)).EndInit();
            this.HeaderBar.ResumeLayout(false);
            this.HeaderBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentFormIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximizeRestoreButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlideButton)).EndInit();
            this.PanelContenedor.ResumeLayout(false);
            this.PanelContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchInFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoInicial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MenuVertical;
        private FontAwesome.Sharp.IconButton ExitButton;
        private FontAwesome.Sharp.IconButton ClearFileButton;
        private FontAwesome.Sharp.IconButton MapViewButton;
        private FontAwesome.Sharp.IconButton DataViewButton;
        private System.Windows.Forms.Panel LogoPanel;
        private System.Windows.Forms.PictureBox LogoIcon;
        private System.Windows.Forms.Panel HeaderBar;
        private FontAwesome.Sharp.IconPictureBox SlideButton;
        private System.Windows.Forms.Panel PanelContenedor;
        private System.Windows.Forms.Label DecoderLabel;
        private System.Windows.Forms.Label AsterixLabel;
        private FontAwesome.Sharp.IconPictureBox CloseButton;
        private FontAwesome.Sharp.IconPictureBox MinimizeButton;
        private FontAwesome.Sharp.IconPictureBox MaximizeRestoreButton;
        private System.Windows.Forms.Panel ExitPanel;
        private System.Windows.Forms.Label ExitLabel2;
        private System.Windows.Forms.Label ExitLabel1;
        private FontAwesome.Sharp.IconButton YesExitButton;
        private FontAwesome.Sharp.IconButton NoExitButton;
        private System.Windows.Forms.Label CurrentFormTitle;
        private FontAwesome.Sharp.IconPictureBox CurrentFormIcon;
        private System.Windows.Forms.Label DecoderInicialLabel;
        private System.Windows.Forms.PictureBox LogoInicial;
        private System.Windows.Forms.Label AsterixInicialLabel;
        private FontAwesome.Sharp.IconButton LoadFileButton;
        private System.Windows.Forms.Label CurrentFileLabel;
        private System.Windows.Forms.Label ShortInfoMessageLabel;
        private System.Windows.Forms.Label PacketsDecodedLabel;
        private System.Windows.Forms.Label LongInfoMessageLabel;
        private System.Windows.Forms.Label InitialTimeLabel;
        private System.Windows.Forms.TextBox FinalTimeTextBox;
        private System.Windows.Forms.TextBox InitialTimeTextBox;
        private System.Windows.Forms.Label InfoPeriodTimeLabel;
        private System.Windows.Forms.Label SelectionTimeLabel;
        private System.Windows.Forms.Label FinalTimeLabel;
        private FontAwesome.Sharp.IconPictureBox SearchInFile;
        private FontAwesome.Sharp.IconButton SelectTimeButton;
        private System.Windows.Forms.Label timePeriodSelectedLabel;
    }
}