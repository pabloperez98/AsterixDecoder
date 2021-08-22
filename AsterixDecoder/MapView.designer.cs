namespace AsterixDecoder
{
    partial class MapView
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.timeUTCLabel = new System.Windows.Forms.Label();
            this.TimeScaleLabel = new System.Windows.Forms.Label();
            this.VelocityLabel = new System.Windows.Forms.Label();
            this.selectFlightLabel = new System.Windows.Forms.Label();
            this.FlightGridView = new System.Windows.Forms.DataGridView();
            this.UTCgridView = new System.Windows.Forms.DataGridView();
            this.gMap = new GMap.NET.WindowsForms.GMapControl();
            this.timerMap = new System.Windows.Forms.Timer(this.components);
            this.endSimulationInfoLabel = new System.Windows.Forms.Label();
            this.startSimulationLabel = new System.Windows.Forms.Label();
            this.endSimulationLabel = new System.Windows.Forms.Label();
            this.infoSimulationGridView = new System.Windows.Forms.DataGridView();
            this.CATsLabel = new System.Windows.Forms.Label();
            this.CATgridView = new System.Windows.Forms.DataGridView();
            this.DSIgridView = new System.Windows.Forms.DataGridView();
            this.flightTrailLabel = new System.Windows.Forms.Label();
            this.trackZoomBar = new System.Windows.Forms.TrackBar();
            this.zoomLabel = new System.Windows.Forms.Label();
            this.timerZoom = new System.Windows.Forms.Timer(this.components);
            this.ClickOnTableLabel = new System.Windows.Forms.Label();
            this.trailNumberLabel = new System.Windows.Forms.Label();
            this.AirTrafficLayersCheckList = new System.Windows.Forms.CheckedListBox();
            this.clearSelectionButton = new FontAwesome.Sharp.IconButton();
            this.KMLbutton = new FontAwesome.Sharp.IconButton();
            this.plotAllFileButton = new FontAwesome.Sharp.IconButton();
            this.reduceTrail = new FontAwesome.Sharp.IconPictureBox();
            this.incrementTrail = new FontAwesome.Sharp.IconPictureBox();
            this.orangePointIcon = new FontAwesome.Sharp.IconPictureBox();
            this.greenPointIcon = new FontAwesome.Sharp.IconPictureBox();
            this.blackPointIcon = new FontAwesome.Sharp.IconPictureBox();
            this.bluePointIcon = new FontAwesome.Sharp.IconPictureBox();
            this.redPointIcon = new FontAwesome.Sharp.IconPictureBox();
            this.AllFlightsButton = new FontAwesome.Sharp.IconButton();
            this.LayoutButton = new FontAwesome.Sharp.IconButton();
            this.StopButton = new FontAwesome.Sharp.IconPictureBox();
            this.PauseButton = new FontAwesome.Sharp.IconPictureBox();
            this.PlayButton = new FontAwesome.Sharp.IconPictureBox();
            this.SlowDownButton = new FontAwesome.Sharp.IconPictureBox();
            this.AccelerateButton = new FontAwesome.Sharp.IconPictureBox();
            this.pinkPointIcon = new FontAwesome.Sharp.IconPictureBox();
            this.brownPointIcon = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FlightGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UTCgridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoSimulationGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CATgridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSIgridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackZoomBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reduceTrail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.incrementTrail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orangePointIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenPointIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blackPointIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bluePointIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redPointIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StopButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PauseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlowDownButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccelerateButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pinkPointIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brownPointIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // timeUTCLabel
            // 
            this.timeUTCLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeUTCLabel.ForeColor = System.Drawing.Color.Black;
            this.timeUTCLabel.Location = new System.Drawing.Point(66, 10);
            this.timeUTCLabel.Name = "timeUTCLabel";
            this.timeUTCLabel.Size = new System.Drawing.Size(171, 57);
            this.timeUTCLabel.TabIndex = 6;
            this.timeUTCLabel.Text = "HH:MM:SS";
            this.timeUTCLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimeScaleLabel
            // 
            this.TimeScaleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TimeScaleLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeScaleLabel.ForeColor = System.Drawing.Color.Black;
            this.TimeScaleLabel.Location = new System.Drawing.Point(17, 568);
            this.TimeScaleLabel.Name = "TimeScaleLabel";
            this.TimeScaleLabel.Size = new System.Drawing.Size(113, 33);
            this.TimeScaleLabel.TabIndex = 9;
            this.TimeScaleLabel.Text = "TIME SCALE";
            this.TimeScaleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VelocityLabel
            // 
            this.VelocityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.VelocityLabel.AutoSize = true;
            this.VelocityLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VelocityLabel.ForeColor = System.Drawing.Color.Black;
            this.VelocityLabel.Location = new System.Drawing.Point(115, 608);
            this.VelocityLabel.Name = "VelocityLabel";
            this.VelocityLabel.Size = new System.Drawing.Size(28, 29);
            this.VelocityLabel.TabIndex = 12;
            this.VelocityLabel.Text = "x1";
            // 
            // selectFlightLabel
            // 
            this.selectFlightLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.selectFlightLabel.AutoSize = true;
            this.selectFlightLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectFlightLabel.ForeColor = System.Drawing.Color.Black;
            this.selectFlightLabel.Location = new System.Drawing.Point(13, 107);
            this.selectFlightLabel.Name = "selectFlightLabel";
            this.selectFlightLabel.Size = new System.Drawing.Size(357, 33);
            this.selectFlightLabel.TabIndex = 16;
            this.selectFlightLabel.Text = "FIRST SELECT SIMULATION PARAMETERS";
            this.selectFlightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FlightGridView
            // 
            this.FlightGridView.AllowUserToAddRows = false;
            this.FlightGridView.AllowUserToDeleteRows = false;
            this.FlightGridView.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FlightGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.FlightGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.FlightGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FlightGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.FlightGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FlightGridView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FlightGridView.EnableHeadersVisualStyles = false;
            this.FlightGridView.Location = new System.Drawing.Point(22, 353);
            this.FlightGridView.Name = "FlightGridView";
            this.FlightGridView.ReadOnly = true;
            this.FlightGridView.RowHeadersVisible = false;
            this.FlightGridView.RowHeadersWidth = 51;
            this.FlightGridView.RowTemplate.Height = 24;
            this.FlightGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FlightGridView.ShowCellToolTips = false;
            this.FlightGridView.Size = new System.Drawing.Size(135, 155);
            this.FlightGridView.TabIndex = 18;
            this.FlightGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FlightGridView_CellContentClick);
            // 
            // UTCgridView
            // 
            this.UTCgridView.AllowUserToAddRows = false;
            this.UTCgridView.AllowUserToDeleteRows = false;
            this.UTCgridView.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.UTCgridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.UTCgridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UTCgridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.UTCgridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UTCgridView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UTCgridView.EnableHeadersVisualStyles = false;
            this.UTCgridView.Location = new System.Drawing.Point(235, 351);
            this.UTCgridView.MultiSelect = false;
            this.UTCgridView.Name = "UTCgridView";
            this.UTCgridView.ReadOnly = true;
            this.UTCgridView.RowHeadersVisible = false;
            this.UTCgridView.RowHeadersWidth = 51;
            this.UTCgridView.RowTemplate.Height = 24;
            this.UTCgridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UTCgridView.ShowCellToolTips = false;
            this.UTCgridView.Size = new System.Drawing.Size(141, 155);
            this.UTCgridView.TabIndex = 19;
            this.UTCgridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UTCgridView_CellClick);
            // 
            // gMap
            // 
            this.gMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMap.AutoScroll = true;
            this.gMap.BackColor = System.Drawing.SystemColors.Control;
            this.gMap.Bearing = 0F;
            this.gMap.CanDragMap = true;
            this.gMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMap.GrayScaleMode = false;
            this.gMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMap.LevelsKeepInMemmory = 5;
            this.gMap.Location = new System.Drawing.Point(461, 98);
            this.gMap.MarkersEnabled = true;
            this.gMap.MaxZoom = 2;
            this.gMap.MinZoom = 2;
            this.gMap.MouseWheelZoomEnabled = true;
            this.gMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMap.Name = "gMap";
            this.gMap.NegativeMode = false;
            this.gMap.PolygonsEnabled = true;
            this.gMap.RetryLoadTile = 0;
            this.gMap.RoutesEnabled = true;
            this.gMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMap.ShowTileGridLines = false;
            this.gMap.Size = new System.Drawing.Size(619, 475);
            this.gMap.TabIndex = 22;
            this.gMap.Zoom = 0D;
            this.gMap.OnRouteClick += new GMap.NET.WindowsForms.RouteClick(this.gMap_OnRouteClick);
            // 
            // timerMap
            // 
            this.timerMap.Interval = 1000;
            this.timerMap.Tick += new System.EventHandler(this.timerMap_Tick);
            // 
            // endSimulationInfoLabel
            // 
            this.endSimulationInfoLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endSimulationInfoLabel.ForeColor = System.Drawing.Color.Black;
            this.endSimulationInfoLabel.Location = new System.Drawing.Point(63, 69);
            this.endSimulationInfoLabel.Name = "endSimulationInfoLabel";
            this.endSimulationInfoLabel.Size = new System.Drawing.Size(184, 33);
            this.endSimulationInfoLabel.TabIndex = 26;
            this.endSimulationInfoLabel.Text = "END OF SIMULATION";
            this.endSimulationInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.endSimulationInfoLabel.Visible = false;
            // 
            // startSimulationLabel
            // 
            this.startSimulationLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.startSimulationLabel.AutoSize = true;
            this.startSimulationLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startSimulationLabel.ForeColor = System.Drawing.Color.Black;
            this.startSimulationLabel.Location = new System.Drawing.Point(925, 23);
            this.startSimulationLabel.Name = "startSimulationLabel";
            this.startSimulationLabel.Size = new System.Drawing.Size(119, 21);
            this.startSimulationLabel.TabIndex = 27;
            this.startSimulationLabel.Text = "START SIMULATION: ";
            this.startSimulationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.startSimulationLabel.Visible = false;
            // 
            // endSimulationLabel
            // 
            this.endSimulationLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.endSimulationLabel.AutoSize = true;
            this.endSimulationLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endSimulationLabel.ForeColor = System.Drawing.Color.Black;
            this.endSimulationLabel.Location = new System.Drawing.Point(925, 45);
            this.endSimulationLabel.Name = "endSimulationLabel";
            this.endSimulationLabel.Size = new System.Drawing.Size(105, 21);
            this.endSimulationLabel.TabIndex = 28;
            this.endSimulationLabel.Text = "END SIMULATION: ";
            this.endSimulationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.endSimulationLabel.Visible = false;
            // 
            // infoSimulationGridView
            // 
            this.infoSimulationGridView.AllowUserToAddRows = false;
            this.infoSimulationGridView.AllowUserToDeleteRows = false;
            this.infoSimulationGridView.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.infoSimulationGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.infoSimulationGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.infoSimulationGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.infoSimulationGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.infoSimulationGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.infoSimulationGridView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.infoSimulationGridView.EnableHeadersVisualStyles = false;
            this.infoSimulationGridView.Location = new System.Drawing.Point(9, 143);
            this.infoSimulationGridView.Name = "infoSimulationGridView";
            this.infoSimulationGridView.ReadOnly = true;
            this.infoSimulationGridView.RowHeadersVisible = false;
            this.infoSimulationGridView.RowHeadersWidth = 51;
            this.infoSimulationGridView.RowTemplate.Height = 24;
            this.infoSimulationGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.infoSimulationGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.infoSimulationGridView.ShowCellToolTips = false;
            this.infoSimulationGridView.Size = new System.Drawing.Size(444, 365);
            this.infoSimulationGridView.TabIndex = 29;
            this.infoSimulationGridView.Visible = false;
            this.infoSimulationGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.infoSimulationGridView_CellClick);
            // 
            // CATsLabel
            // 
            this.CATsLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CATsLabel.AutoSize = true;
            this.CATsLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CATsLabel.ForeColor = System.Drawing.Color.Black;
            this.CATsLabel.Location = new System.Drawing.Point(391, 18);
            this.CATsLabel.Name = "CATsLabel";
            this.CATsLabel.Size = new System.Drawing.Size(111, 63);
            this.CATsLabel.TabIndex = 34;
            this.CATsLabel.Text = "CAT01           CAT21\r\nSMR              CAT48\r\nMLAT            CAT62\r\n";
            this.CATsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CATgridView
            // 
            this.CATgridView.AllowUserToAddRows = false;
            this.CATgridView.AllowUserToDeleteRows = false;
            this.CATgridView.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CATgridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.CATgridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.CATgridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CATgridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.CATgridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CATgridView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CATgridView.EnableHeadersVisualStyles = false;
            this.CATgridView.Location = new System.Drawing.Point(23, 154);
            this.CATgridView.MultiSelect = false;
            this.CATgridView.Name = "CATgridView";
            this.CATgridView.ReadOnly = true;
            this.CATgridView.RowHeadersVisible = false;
            this.CATgridView.RowHeadersWidth = 51;
            this.CATgridView.RowTemplate.Height = 24;
            this.CATgridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CATgridView.ShowCellToolTips = false;
            this.CATgridView.Size = new System.Drawing.Size(119, 178);
            this.CATgridView.TabIndex = 38;
            this.CATgridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CATgridView_CellClick);
            // 
            // DSIgridView
            // 
            this.DSIgridView.AllowUserToAddRows = false;
            this.DSIgridView.AllowUserToDeleteRows = false;
            this.DSIgridView.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DSIgridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.DSIgridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DSIgridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DSIgridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DSIgridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DSIgridView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DSIgridView.EnableHeadersVisualStyles = false;
            this.DSIgridView.Location = new System.Drawing.Point(152, 154);
            this.DSIgridView.MultiSelect = false;
            this.DSIgridView.Name = "DSIgridView";
            this.DSIgridView.ReadOnly = true;
            this.DSIgridView.RowHeadersVisible = false;
            this.DSIgridView.RowHeadersWidth = 51;
            this.DSIgridView.RowTemplate.Height = 24;
            this.DSIgridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DSIgridView.ShowCellToolTips = false;
            this.DSIgridView.Size = new System.Drawing.Size(298, 178);
            this.DSIgridView.TabIndex = 39;
            this.DSIgridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DSIgridView_CellClick);
            // 
            // flightTrailLabel
            // 
            this.flightTrailLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flightTrailLabel.AutoSize = true;
            this.flightTrailLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flightTrailLabel.ForeColor = System.Drawing.Color.Black;
            this.flightTrailLabel.Location = new System.Drawing.Point(266, 26);
            this.flightTrailLabel.Name = "flightTrailLabel";
            this.flightTrailLabel.Size = new System.Drawing.Size(81, 21);
            this.flightTrailLabel.TabIndex = 44;
            this.flightTrailLabel.Text = "FLIGHT TRAIL";
            this.flightTrailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // trackZoomBar
            // 
            this.trackZoomBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trackZoomBar.Location = new System.Drawing.Point(778, 607);
            this.trackZoomBar.Maximum = 18;
            this.trackZoomBar.Minimum = 6;
            this.trackZoomBar.Name = "trackZoomBar";
            this.trackZoomBar.Size = new System.Drawing.Size(176, 56);
            this.trackZoomBar.TabIndex = 45;
            this.trackZoomBar.Value = 14;
            this.trackZoomBar.ValueChanged += new System.EventHandler(this.trackZoomBar_ValueChanged);
            // 
            // zoomLabel
            // 
            this.zoomLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zoomLabel.ForeColor = System.Drawing.Color.Black;
            this.zoomLabel.Location = new System.Drawing.Point(841, 579);
            this.zoomLabel.Name = "zoomLabel";
            this.zoomLabel.Size = new System.Drawing.Size(41, 21);
            this.zoomLabel.TabIndex = 46;
            this.zoomLabel.Text = "ZOOM";
            this.zoomLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerZoom
            // 
            this.timerZoom.Enabled = true;
            this.timerZoom.Interval = 10;
            this.timerZoom.Tick += new System.EventHandler(this.timerZoom_Tick);
            // 
            // ClickOnTableLabel
            // 
            this.ClickOnTableLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ClickOnTableLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClickOnTableLabel.ForeColor = System.Drawing.Color.Black;
            this.ClickOnTableLabel.Location = new System.Drawing.Point(41, 524);
            this.ClickOnTableLabel.Name = "ClickOnTableLabel";
            this.ClickOnTableLabel.Size = new System.Drawing.Size(378, 33);
            this.ClickOnTableLabel.TabIndex = 50;
            this.ClickOnTableLabel.Text = "CLICK ON THE TABLE TO SEE A TRACK TRAIL";
            this.ClickOnTableLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ClickOnTableLabel.Visible = false;
            // 
            // trailNumberLabel
            // 
            this.trailNumberLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.trailNumberLabel.AutoSize = true;
            this.trailNumberLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trailNumberLabel.ForeColor = System.Drawing.Color.Black;
            this.trailNumberLabel.Location = new System.Drawing.Point(330, 52);
            this.trailNumberLabel.Name = "trailNumberLabel";
            this.trailNumberLabel.Size = new System.Drawing.Size(18, 24);
            this.trailNumberLabel.TabIndex = 53;
            this.trailNumberLabel.Text = "3";
            // 
            // AirTrafficLayersCheckList
            // 
            this.AirTrafficLayersCheckList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AirTrafficLayersCheckList.BackColor = System.Drawing.SystemColors.Control;
            this.AirTrafficLayersCheckList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AirTrafficLayersCheckList.CheckOnClick = true;
            this.AirTrafficLayersCheckList.ColumnWidth = 138;
            this.AirTrafficLayersCheckList.Font = new System.Drawing.Font("Bahnschrift Light", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AirTrafficLayersCheckList.ForeColor = System.Drawing.Color.Black;
            this.AirTrafficLayersCheckList.FormattingEnabled = true;
            this.AirTrafficLayersCheckList.Items.AddRange(new object[] {
            "Aerodromes",
            "ATZ, CTR, CTA",
            "TMA BCN",
            "TMA VAL",
            "Sacta Sectors",
            "Airways",
            "SID Procedures",
            "STAR Procedures",
            "Sacta Contour",
            "Tags",
            "Select all",
            "Clear all"});
            this.AirTrafficLayersCheckList.Location = new System.Drawing.Point(513, 11);
            this.AirTrafficLayersCheckList.MultiColumn = true;
            this.AirTrafficLayersCheckList.Name = "AirTrafficLayersCheckList";
            this.AirTrafficLayersCheckList.Size = new System.Drawing.Size(416, 72);
            this.AirTrafficLayersCheckList.TabIndex = 1;
            this.AirTrafficLayersCheckList.SelectedIndexChanged += new System.EventHandler(this.AirTrafficLayersCheckList_SelectedIndexChanged);
            // 
            // clearSelectionButton
            // 
            this.clearSelectionButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.clearSelectionButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.clearSelectionButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearSelectionButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.clearSelectionButton.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearSelectionButton.ForeColor = System.Drawing.Color.Black;
            this.clearSelectionButton.IconChar = FontAwesome.Sharp.IconChar.Eraser;
            this.clearSelectionButton.IconColor = System.Drawing.Color.Black;
            this.clearSelectionButton.IconSize = 24;
            this.clearSelectionButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.clearSelectionButton.Location = new System.Drawing.Point(64, 69);
            this.clearSelectionButton.Name = "clearSelectionButton";
            this.clearSelectionButton.Rotation = 0D;
            this.clearSelectionButton.Size = new System.Drawing.Size(179, 37);
            this.clearSelectionButton.TabIndex = 42;
            this.clearSelectionButton.Text = "CLEAR SELECTION";
            this.clearSelectionButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.clearSelectionButton.UseVisualStyleBackColor = true;
            this.clearSelectionButton.Visible = false;
            this.clearSelectionButton.Click += new System.EventHandler(this.clearSelectionButton_Click);
            // 
            // KMLbutton
            // 
            this.KMLbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.KMLbutton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.KMLbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.KMLbutton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.KMLbutton.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KMLbutton.ForeColor = System.Drawing.Color.Black;
            this.KMLbutton.IconChar = FontAwesome.Sharp.IconChar.GlobeAmericas;
            this.KMLbutton.IconColor = System.Drawing.Color.Black;
            this.KMLbutton.IconSize = 34;
            this.KMLbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.KMLbutton.Location = new System.Drawing.Point(661, 586);
            this.KMLbutton.Name = "KMLbutton";
            this.KMLbutton.Rotation = 0D;
            this.KMLbutton.Size = new System.Drawing.Size(95, 56);
            this.KMLbutton.TabIndex = 55;
            this.KMLbutton.Text = "KML";
            this.KMLbutton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.KMLbutton.UseVisualStyleBackColor = true;
            this.KMLbutton.Click += new System.EventHandler(this.KMLbutton_Click);
            // 
            // plotAllFileButton
            // 
            this.plotAllFileButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.plotAllFileButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.plotAllFileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plotAllFileButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.plotAllFileButton.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plotAllFileButton.ForeColor = System.Drawing.Color.Black;
            this.plotAllFileButton.IconChar = FontAwesome.Sharp.IconChar.Plane;
            this.plotAllFileButton.IconColor = System.Drawing.Color.Black;
            this.plotAllFileButton.IconSize = 24;
            this.plotAllFileButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.plotAllFileButton.Location = new System.Drawing.Point(188, 527);
            this.plotAllFileButton.Name = "plotAllFileButton";
            this.plotAllFileButton.Rotation = 0D;
            this.plotAllFileButton.Size = new System.Drawing.Size(112, 37);
            this.plotAllFileButton.TabIndex = 54;
            this.plotAllFileButton.Text = "PLOT ALL";
            this.plotAllFileButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.plotAllFileButton.UseVisualStyleBackColor = true;
            this.plotAllFileButton.Click += new System.EventHandler(this.plotAllFileButton_Click);
            // 
            // reduceTrail
            // 
            this.reduceTrail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.reduceTrail.BackColor = System.Drawing.SystemColors.Control;
            this.reduceTrail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reduceTrail.ForeColor = System.Drawing.Color.Black;
            this.reduceTrail.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.reduceTrail.IconColor = System.Drawing.Color.Black;
            this.reduceTrail.IconSize = 22;
            this.reduceTrail.Location = new System.Drawing.Point(267, 55);
            this.reduceTrail.Name = "reduceTrail";
            this.reduceTrail.Size = new System.Drawing.Size(22, 22);
            this.reduceTrail.TabIndex = 52;
            this.reduceTrail.TabStop = false;
            this.reduceTrail.Click += new System.EventHandler(this.reduceTrail_Click);
            // 
            // incrementTrail
            // 
            this.incrementTrail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.incrementTrail.BackColor = System.Drawing.SystemColors.Control;
            this.incrementTrail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.incrementTrail.ForeColor = System.Drawing.Color.Black;
            this.incrementTrail.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.incrementTrail.IconColor = System.Drawing.Color.Black;
            this.incrementTrail.IconSize = 22;
            this.incrementTrail.Location = new System.Drawing.Point(299, 55);
            this.incrementTrail.Name = "incrementTrail";
            this.incrementTrail.Size = new System.Drawing.Size(22, 22);
            this.incrementTrail.TabIndex = 51;
            this.incrementTrail.TabStop = false;
            this.incrementTrail.Click += new System.EventHandler(this.incrementTrail_Click);
            // 
            // orangePointIcon
            // 
            this.orangePointIcon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.orangePointIcon.BackColor = System.Drawing.SystemColors.Control;
            this.orangePointIcon.ForeColor = System.Drawing.Color.DarkOrange;
            this.orangePointIcon.IconChar = FontAwesome.Sharp.IconChar.Circle;
            this.orangePointIcon.IconColor = System.Drawing.Color.DarkOrange;
            this.orangePointIcon.IconSize = 16;
            this.orangePointIcon.Location = new System.Drawing.Point(442, 65);
            this.orangePointIcon.Name = "orangePointIcon";
            this.orangePointIcon.Size = new System.Drawing.Size(16, 16);
            this.orangePointIcon.TabIndex = 43;
            this.orangePointIcon.TabStop = false;
            // 
            // greenPointIcon
            // 
            this.greenPointIcon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.greenPointIcon.BackColor = System.Drawing.SystemColors.Control;
            this.greenPointIcon.ForeColor = System.Drawing.Color.Green;
            this.greenPointIcon.IconChar = FontAwesome.Sharp.IconChar.Circle;
            this.greenPointIcon.IconColor = System.Drawing.Color.Green;
            this.greenPointIcon.IconSize = 16;
            this.greenPointIcon.Location = new System.Drawing.Point(443, 44);
            this.greenPointIcon.Name = "greenPointIcon";
            this.greenPointIcon.Size = new System.Drawing.Size(16, 16);
            this.greenPointIcon.TabIndex = 33;
            this.greenPointIcon.TabStop = false;
            // 
            // blackPointIcon
            // 
            this.blackPointIcon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.blackPointIcon.BackColor = System.Drawing.SystemColors.Control;
            this.blackPointIcon.ForeColor = System.Drawing.Color.Black;
            this.blackPointIcon.IconChar = FontAwesome.Sharp.IconChar.Circle;
            this.blackPointIcon.IconColor = System.Drawing.Color.Black;
            this.blackPointIcon.IconSize = 16;
            this.blackPointIcon.Location = new System.Drawing.Point(377, 21);
            this.blackPointIcon.Name = "blackPointIcon";
            this.blackPointIcon.Size = new System.Drawing.Size(16, 16);
            this.blackPointIcon.TabIndex = 32;
            this.blackPointIcon.TabStop = false;
            // 
            // bluePointIcon
            // 
            this.bluePointIcon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bluePointIcon.BackColor = System.Drawing.SystemColors.Control;
            this.bluePointIcon.ForeColor = System.Drawing.Color.Blue;
            this.bluePointIcon.IconChar = FontAwesome.Sharp.IconChar.Circle;
            this.bluePointIcon.IconColor = System.Drawing.Color.Blue;
            this.bluePointIcon.IconSize = 16;
            this.bluePointIcon.Location = new System.Drawing.Point(248, 28);
            this.bluePointIcon.Name = "bluePointIcon";
            this.bluePointIcon.Size = new System.Drawing.Size(16, 16);
            this.bluePointIcon.TabIndex = 31;
            this.bluePointIcon.TabStop = false;
            // 
            // redPointIcon
            // 
            this.redPointIcon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.redPointIcon.BackColor = System.Drawing.SystemColors.Control;
            this.redPointIcon.ForeColor = System.Drawing.Color.Red;
            this.redPointIcon.IconChar = FontAwesome.Sharp.IconChar.Circle;
            this.redPointIcon.IconColor = System.Drawing.Color.Red;
            this.redPointIcon.IconSize = 16;
            this.redPointIcon.Location = new System.Drawing.Point(443, 22);
            this.redPointIcon.Name = "redPointIcon";
            this.redPointIcon.Size = new System.Drawing.Size(16, 16);
            this.redPointIcon.TabIndex = 30;
            this.redPointIcon.TabStop = false;
            // 
            // AllFlightsButton
            // 
            this.AllFlightsButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AllFlightsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AllFlightsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AllFlightsButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.AllFlightsButton.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllFlightsButton.ForeColor = System.Drawing.Color.Black;
            this.AllFlightsButton.IconChar = FontAwesome.Sharp.IconChar.Plane;
            this.AllFlightsButton.IconColor = System.Drawing.Color.Black;
            this.AllFlightsButton.IconSize = 24;
            this.AllFlightsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AllFlightsButton.Location = new System.Drawing.Point(22, 527);
            this.AllFlightsButton.Name = "AllFlightsButton";
            this.AllFlightsButton.Rotation = 0D;
            this.AllFlightsButton.Size = new System.Drawing.Size(140, 37);
            this.AllFlightsButton.TabIndex = 25;
            this.AllFlightsButton.Text = "ALL FLIGHTS";
            this.AllFlightsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AllFlightsButton.UseVisualStyleBackColor = true;
            this.AllFlightsButton.Click += new System.EventHandler(this.AllFlightsButton_Click);
            // 
            // LayoutButton
            // 
            this.LayoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LayoutButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LayoutButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LayoutButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.LayoutButton.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LayoutButton.ForeColor = System.Drawing.Color.Black;
            this.LayoutButton.IconChar = FontAwesome.Sharp.IconChar.LayerGroup;
            this.LayoutButton.IconColor = System.Drawing.Color.Black;
            this.LayoutButton.IconSize = 34;
            this.LayoutButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LayoutButton.Location = new System.Drawing.Point(960, 584);
            this.LayoutButton.Name = "LayoutButton";
            this.LayoutButton.Rotation = 0D;
            this.LayoutButton.Size = new System.Drawing.Size(120, 56);
            this.LayoutButton.TabIndex = 24;
            this.LayoutButton.Text = "LAYOUT";
            this.LayoutButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LayoutButton.UseVisualStyleBackColor = true;
            this.LayoutButton.Click += new System.EventHandler(this.LayoutButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StopButton.BackColor = System.Drawing.SystemColors.Control;
            this.StopButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StopButton.ForeColor = System.Drawing.Color.Black;
            this.StopButton.IconChar = FontAwesome.Sharp.IconChar.StopCircle;
            this.StopButton.IconColor = System.Drawing.Color.Black;
            this.StopButton.IconSize = 70;
            this.StopButton.Location = new System.Drawing.Point(254, 581);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(70, 70);
            this.StopButton.TabIndex = 21;
            this.StopButton.TabStop = false;
            this.StopButton.Visible = false;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PauseButton.BackColor = System.Drawing.SystemColors.Control;
            this.PauseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PauseButton.ForeColor = System.Drawing.Color.Black;
            this.PauseButton.IconChar = FontAwesome.Sharp.IconChar.PauseCircle;
            this.PauseButton.IconColor = System.Drawing.Color.Black;
            this.PauseButton.IconSize = 70;
            this.PauseButton.Location = new System.Drawing.Point(178, 581);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(70, 70);
            this.PauseButton.TabIndex = 20;
            this.PauseButton.TabStop = false;
            this.PauseButton.Visible = false;
            this.PauseButton.WaitOnLoad = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PlayButton.BackColor = System.Drawing.SystemColors.Control;
            this.PlayButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PlayButton.ForeColor = System.Drawing.Color.Black;
            this.PlayButton.IconChar = FontAwesome.Sharp.IconChar.PlayCircle;
            this.PlayButton.IconColor = System.Drawing.Color.Black;
            this.PlayButton.IconSize = 70;
            this.PlayButton.Location = new System.Drawing.Point(178, 578);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(70, 70);
            this.PlayButton.TabIndex = 17;
            this.PlayButton.TabStop = false;
            this.PlayButton.Visible = false;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // SlowDownButton
            // 
            this.SlowDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SlowDownButton.BackColor = System.Drawing.SystemColors.Control;
            this.SlowDownButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SlowDownButton.ForeColor = System.Drawing.Color.Black;
            this.SlowDownButton.IconChar = FontAwesome.Sharp.IconChar.Backward;
            this.SlowDownButton.IconColor = System.Drawing.Color.Black;
            this.SlowDownButton.IconSize = 30;
            this.SlowDownButton.Location = new System.Drawing.Point(19, 610);
            this.SlowDownButton.Name = "SlowDownButton";
            this.SlowDownButton.Size = new System.Drawing.Size(30, 30);
            this.SlowDownButton.TabIndex = 11;
            this.SlowDownButton.TabStop = false;
            this.SlowDownButton.Visible = false;
            this.SlowDownButton.Click += new System.EventHandler(this.SlowDownButton_Click);
            // 
            // AccelerateButton
            // 
            this.AccelerateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AccelerateButton.BackColor = System.Drawing.SystemColors.Control;
            this.AccelerateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AccelerateButton.ForeColor = System.Drawing.Color.Black;
            this.AccelerateButton.IconChar = FontAwesome.Sharp.IconChar.Forward;
            this.AccelerateButton.IconColor = System.Drawing.Color.Black;
            this.AccelerateButton.IconSize = 30;
            this.AccelerateButton.Location = new System.Drawing.Point(67, 610);
            this.AccelerateButton.Name = "AccelerateButton";
            this.AccelerateButton.Size = new System.Drawing.Size(30, 30);
            this.AccelerateButton.TabIndex = 10;
            this.AccelerateButton.TabStop = false;
            this.AccelerateButton.Click += new System.EventHandler(this.AccelerateButton_Click);
            // 
            // pinkPointIcon
            // 
            this.pinkPointIcon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pinkPointIcon.BackColor = System.Drawing.SystemColors.Control;
            this.pinkPointIcon.ForeColor = System.Drawing.Color.Purple;
            this.pinkPointIcon.IconChar = FontAwesome.Sharp.IconChar.Circle;
            this.pinkPointIcon.IconColor = System.Drawing.Color.Purple;
            this.pinkPointIcon.IconSize = 16;
            this.pinkPointIcon.Location = new System.Drawing.Point(377, 65);
            this.pinkPointIcon.Name = "pinkPointIcon";
            this.pinkPointIcon.Size = new System.Drawing.Size(16, 16);
            this.pinkPointIcon.TabIndex = 57;
            this.pinkPointIcon.TabStop = false;
            // 
            // brownPointIcon
            // 
            this.brownPointIcon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.brownPointIcon.BackColor = System.Drawing.SystemColors.Control;
            this.brownPointIcon.ForeColor = System.Drawing.Color.Olive;
            this.brownPointIcon.IconChar = FontAwesome.Sharp.IconChar.Circle;
            this.brownPointIcon.IconColor = System.Drawing.Color.Olive;
            this.brownPointIcon.IconSize = 16;
            this.brownPointIcon.Location = new System.Drawing.Point(377, 43);
            this.brownPointIcon.Name = "brownPointIcon";
            this.brownPointIcon.Size = new System.Drawing.Size(16, 16);
            this.brownPointIcon.TabIndex = 58;
            this.brownPointIcon.TabStop = false;
            // 
            // MapView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1092, 653);
            this.Controls.Add(this.brownPointIcon);
            this.Controls.Add(this.pinkPointIcon);
            this.Controls.Add(this.clearSelectionButton);
            this.Controls.Add(this.selectFlightLabel);
            this.Controls.Add(this.AirTrafficLayersCheckList);
            this.Controls.Add(this.KMLbutton);
            this.Controls.Add(this.plotAllFileButton);
            this.Controls.Add(this.trailNumberLabel);
            this.Controls.Add(this.reduceTrail);
            this.Controls.Add(this.incrementTrail);
            this.Controls.Add(this.zoomLabel);
            this.Controls.Add(this.trackZoomBar);
            this.Controls.Add(this.flightTrailLabel);
            this.Controls.Add(this.orangePointIcon);
            this.Controls.Add(this.DSIgridView);
            this.Controls.Add(this.CATgridView);
            this.Controls.Add(this.greenPointIcon);
            this.Controls.Add(this.blackPointIcon);
            this.Controls.Add(this.bluePointIcon);
            this.Controls.Add(this.redPointIcon);
            this.Controls.Add(this.endSimulationLabel);
            this.Controls.Add(this.startSimulationLabel);
            this.Controls.Add(this.endSimulationInfoLabel);
            this.Controls.Add(this.AllFlightsButton);
            this.Controls.Add(this.LayoutButton);
            this.Controls.Add(this.gMap);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.UTCgridView);
            this.Controls.Add(this.FlightGridView);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.VelocityLabel);
            this.Controls.Add(this.SlowDownButton);
            this.Controls.Add(this.AccelerateButton);
            this.Controls.Add(this.TimeScaleLabel);
            this.Controls.Add(this.timeUTCLabel);
            this.Controls.Add(this.CATsLabel);
            this.Controls.Add(this.ClickOnTableLabel);
            this.Controls.Add(this.infoSimulationGridView);
            this.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MapView";
            this.Text = "MAP VIEW";
            this.Load += new System.EventHandler(this.MapView_Load);
            this.Shown += new System.EventHandler(this.MapView_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.FlightGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UTCgridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoSimulationGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CATgridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSIgridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackZoomBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reduceTrail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.incrementTrail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orangePointIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenPointIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blackPointIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bluePointIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redPointIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StopButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PauseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlowDownButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccelerateButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pinkPointIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brownPointIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label timeUTCLabel;
        private System.Windows.Forms.Label TimeScaleLabel;
        private FontAwesome.Sharp.IconPictureBox AccelerateButton;
        private FontAwesome.Sharp.IconPictureBox SlowDownButton;
        private System.Windows.Forms.Label VelocityLabel;
        private FontAwesome.Sharp.IconPictureBox PlayButton;
        private System.Windows.Forms.DataGridView FlightGridView;
        private System.Windows.Forms.DataGridView UTCgridView;
        private FontAwesome.Sharp.IconPictureBox PauseButton;
        private FontAwesome.Sharp.IconPictureBox StopButton;
        private GMap.NET.WindowsForms.GMapControl gMap;
        private FontAwesome.Sharp.IconButton LayoutButton;
        private System.Windows.Forms.Timer timerMap;
        private FontAwesome.Sharp.IconButton AllFlightsButton;
        private System.Windows.Forms.Label endSimulationInfoLabel;
        private System.Windows.Forms.Label selectFlightLabel;
        private System.Windows.Forms.Label startSimulationLabel;
        private System.Windows.Forms.Label endSimulationLabel;
        private System.Windows.Forms.DataGridView infoSimulationGridView;
        private FontAwesome.Sharp.IconPictureBox redPointIcon;
        private FontAwesome.Sharp.IconPictureBox bluePointIcon;
        private FontAwesome.Sharp.IconPictureBox blackPointIcon;
        private FontAwesome.Sharp.IconPictureBox greenPointIcon;
        private System.Windows.Forms.Label CATsLabel;
        private System.Windows.Forms.DataGridView CATgridView;
        private System.Windows.Forms.DataGridView DSIgridView;
        private FontAwesome.Sharp.IconButton clearSelectionButton;
        private FontAwesome.Sharp.IconPictureBox orangePointIcon;
        private System.Windows.Forms.Label flightTrailLabel;
        private System.Windows.Forms.TrackBar trackZoomBar;
        private System.Windows.Forms.Label zoomLabel;
        private System.Windows.Forms.Timer timerZoom;
        private System.Windows.Forms.Label ClickOnTableLabel;
        private System.Windows.Forms.Label trailNumberLabel;
        private FontAwesome.Sharp.IconPictureBox reduceTrail;
        private FontAwesome.Sharp.IconPictureBox incrementTrail;
        private FontAwesome.Sharp.IconButton plotAllFileButton;
        private FontAwesome.Sharp.IconButton KMLbutton;
        private System.Windows.Forms.CheckedListBox AirTrafficLayersCheckList;
        private FontAwesome.Sharp.IconPictureBox pinkPointIcon;
        private FontAwesome.Sharp.IconPictureBox brownPointIcon;
    }
}