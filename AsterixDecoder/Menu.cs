using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices; // Move window
using FontAwesome.Sharp; // Icon library
using ClassLibrary;
using FlightDataItems;


namespace AsterixDecoder
{
    public partial class Menu : Form
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        IconButton currentButtonActivated;
        Form currentFormActivated;
        AsterixData data = new AsterixData();
        AsterixFile file; 
        Boolean fileMore30min = false;

        public Menu()
        {
            InitializeComponent();
            // Remove border from the form so the Resize function is not lost
            this.Text = string.Empty;
            this.ControlBox = false;
            // When maximizing it does not occupy the entire screen including the Windows taskbar
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            data.decodeRadarCSV(Properties.Resources.Radares_España);
        }
        
        // Move window
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        // Method of highlighting vertical menu button once pressed
        private void ActivateButton(object senderBtn)
        { 
            if (senderBtn != null)
            {
                if (this.currentButtonActivated != (IconButton)senderBtn)
                {
                    DisableButton();
                    this.currentButtonActivated = (IconButton) senderBtn;
                    this.currentButtonActivated.BackColor = Color.FromArgb(1, 180, 250);
                    this.currentButtonActivated.ForeColor = Color.White;
                    this.currentButtonActivated.Font = new Font("Bahnschrift Condensed", 19.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    this.currentButtonActivated.Padding = new Padding(15, 0, 0, 0);
                    HeaderBar.BackColor= Color.FromArgb(1, 180, 250);
                    CurrentFormIcon.IconChar = this.currentButtonActivated.IconChar;
                    CurrentFormTitle.Text = this.currentButtonActivated.Text;
                }
            }
        }

        // Method to stop highlighting the vertical menu button after pressing other
        private void DisableButton()
        {
            foreach (Control previousButton in MenuVertical.Controls)
            {
                if (previousButton.GetType() == typeof(IconButton))
                {
                    previousButton.BackColor = Color.FromArgb(0,122,204);
                    previousButton.ForeColor = Color.Gainsboro;
                    previousButton.Font = new Font("Bahnschrift Condensed", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    if (previousButton.Text == "SELECT TIME")
                        previousButton.Padding = new Padding(10, 0, 0, 0);
                    else
                        previousButton.Padding = new Padding(10, 0, 20, 0);
                }
            }
        }

        // Method to open forms in container panel
        private void OpenChildForm(Form childForm, object senderButton)
        {
            if (currentFormActivated != null)
                currentFormActivated.Close();
            ActivateButton(senderButton);
            currentFormActivated = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.PanelContenedor.Controls.Add(childForm);
            this.PanelContenedor.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // Header Bar buttons functions
        private void SlideButton_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 200)
                MenuVertical.Width = 70;
            else
                MenuVertical.Width = 200;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        { Exit ExitForm = new Exit("Exit Program"); ExitForm.ShowDialog(); }

        private void MaximizeRestoreButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
            { this.WindowState = FormWindowState.Normal; this.StartPosition = FormStartPosition.CenterScreen; }   
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        { this.WindowState = FormWindowState.Minimized; }

        // Move Window
        private void HeaderBar_MouseDown(object sender, MouseEventArgs e)
        { ReleaseCapture(); SendMessage(this.Handle, 0x112, 0xf012, 0); }

        // Button functions Vertical Menu
        private void LoadFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                ExitPanel.Visible = false; LogoInicial.Visible = false;
                AsterixInicialLabel.Visible = false; DecoderInicialLabel.Visible = false;
                PacketsDecodedLabel.Visible = false; LongInfoMessageLabel.Visible = false; ShortInfoMessageLabel.Visible = false;
                InitialTimeLabel.Visible = false; FinalTimeLabel.Visible = false;
                InitialTimeTextBox.Visible = false; FinalTimeTextBox.Visible = false; SearchInFile.Visible = false;
                InfoPeriodTimeLabel.Visible = false; SelectionTimeLabel.Visible = false;
                if (currentFormActivated != null)
                    currentFormActivated.Close();
                ActivateButton(sender);
                
                if (data.AsterixFiles.Count < 2 && !fileMore30min) //Less than 2 files loaded
                {
                    openFileDialog.Filter = "All files (*.*)|*.*|gps files (*.gps)|*.gps|ast files (*.ast)|*.ast";
                    openFileDialog.FilterIndex = 1;
                    if (openFileDialog.ShowDialog() == DialogResult.OK) // Selected file OK!
                    {
                        file = new AsterixFile(openFileDialog.FileName, data);
                        file.obtainInitialFinalTime(file.fileBytes);
                        if (data.AsterixFiles.Count != 0 && file.fileName == data.AsterixFiles[0].fileName)
                        { ShortInfoMessageLabel.Visible = true; ShortInfoMessageLabel.Text = "FILE ALREADY LOADED!"; }
                        if (data.AsterixFiles.Count != 0 && (file.initialSecondsFile > data.AsterixFiles[0].initialSecondsSelected || file.finalSecondsFile < data.AsterixFiles[0].finalSecondsSelected))
                        { LongInfoMessageLabel.Visible = true; LongInfoMessageLabel.Text = "Initial and final time of the file: " + TimeOfDay.obtainTimeUTC(file.initialSecondsFile) + " - " + TimeOfDay.obtainTimeUTC(file.finalSecondsFile) + "\nFILE DOES NOT HAVE SAME PERIOD TIME AS THE PREVIOUS ONE!"; file = data.AsterixFiles[0]; }
                        else
                            SelectTimeButton.PerformClick();
                    }
                    else // The FileDialog is opened but no file is selected
                    { ShortInfoMessageLabel.Visible = true; ShortInfoMessageLabel.Text = "FILE NOT SELECTED"; }
                    
                }
                else { LongInfoMessageLabel.Visible = true; LongInfoMessageLabel.Text = "MAXIMUM NUMBER OF FILES HAS ALREADY BEEN LOADED"; }

            }
            catch
            {
                LongInfoMessageLabel.Text = "THE FILE COULD NOT BE LOADED, PLEASE SELECT ANOTHER";
                LongInfoMessageLabel.Visible = true; ShortInfoMessageLabel.Visible = false;
            }
        }

        private void SelectTimeButton_Click(object sender, EventArgs e)
        {
            try
            {
                ShortInfoMessageLabel.Visible = false; LongInfoMessageLabel.Visible = false; PacketsDecodedLabel.Visible = false;
                if (currentFormActivated != null)
                    currentFormActivated.Close();
                ActivateButton(sender);
                if (file != null)
                {
                    string selectionTimeLabel;
                    if (file.finalSecondsFile - file.initialSecondsFile < 2.1 * 3600 && data.AsterixFiles.Count < 2)
                        selectionTimeLabel = "Please, select the time period of interest (format HH:MM:SS)";
                    else
                        selectionTimeLabel = "Please, select the time period of interest (maximum 30 min, format HH:MM:SS)";
                    InitialTimeLabel.Visible = true; FinalTimeLabel.Visible = true; SearchInFile.Visible = true;
                    if (data.AsterixFiles.Count < 2)
                    { InfoPeriodTimeLabel.Visible = true; InfoPeriodTimeLabel.Text = "Initial and final time of " + file.fileName + " file: " + TimeOfDay.obtainTimeUTC(file.initialSecondsFile) + " - " + TimeOfDay.obtainTimeUTC(file.finalSecondsFile); }
                    SelectionTimeLabel.Visible = true; InitialTimeTextBox.Visible = true; FinalTimeTextBox.Visible = true;
                    SelectionTimeLabel.Text = selectionTimeLabel;
                    // Possible erros introducing files
                    if (data.AsterixFiles.Count != 0 && data.AsterixFiles[0].fileName == file.fileName)
                    { ShortInfoMessageLabel.Visible = true; ShortInfoMessageLabel.Text = "FILE ALREADY LOADED!"; }
                    if (data.AsterixFiles.Count == 0) // Any file loaded
                    {
                        InitialTimeTextBox.Text = TimeOfDay.obtainTimeUTC(file.initialSecondsFile);
                        FinalTimeTextBox.Text = TimeOfDay.obtainTimeUTC(file.initialSecondsFile + 60);
                    }
                    else if (data.AsterixFiles.Count == 1)
                    {
                        InitialTimeTextBox.Text = TimeOfDay.obtainTimeUTC(data.AsterixFiles[0].initialSecondsSelected);
                        FinalTimeTextBox.Text = TimeOfDay.obtainTimeUTC(data.AsterixFiles[0].finalSecondsSelected);
                        if (data.AsterixFiles[0].fileName == file.fileName)
                        { SelectionTimeLabel.Text = "File already loaded. Would you like to change the period time?\n" + selectionTimeLabel; }
                    }
                    else if (data.AsterixFiles.Count == 2)
                    {
                        InitialTimeTextBox.Text = TimeOfDay.obtainTimeUTC(data.AsterixFiles[0].initialSecondsSelected);
                        FinalTimeTextBox.Text = TimeOfDay.obtainTimeUTC(data.AsterixFiles[0].finalSecondsSelected);
                        InfoPeriodTimeLabel.Visible = true; InfoPeriodTimeLabel.Text = "";
                        foreach (AsterixFile ast in data.AsterixFiles)
                        { InfoPeriodTimeLabel.Text += "Initial and final time of " + ast.fileName + " file: " + TimeOfDay.obtainTimeUTC(ast.initialSecondsFile) + " - " + TimeOfDay.obtainTimeUTC(ast.finalSecondsFile) + "\n"; }
                        SelectionTimeLabel.Text = "Both files already loaded. Would you like to change the period time?\n" + selectionTimeLabel;
                    }
                }
                else
                {
                    LogoInicial.Visible = false; AsterixInicialLabel.Visible = false; DecoderInicialLabel.Visible = false;
                    ShortInfoMessageLabel.Text = "FIRST LOAD A FILE"; ShortInfoMessageLabel.Visible = true;
                    LongInfoMessageLabel.Visible = false;
                }
        }
            catch
            {
                LongInfoMessageLabel.Text = "THE FILE COULD NOT BE LOADED, PLEASE SELECT ANOTHER";
                LongInfoMessageLabel.Visible = true; ShortInfoMessageLabel.Visible = false;
            }

        }

        private void InitialTimeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                InitialTimeTextBox.BackColor = Color.White; LongInfoMessageLabel.Visible = false; PacketsDecodedLabel.Visible = false; ShortInfoMessageLabel.Visible = false;
                if (Char.IsDigit(e.KeyChar) || e.KeyChar == ':' || Char.IsControl(e.KeyChar)) // numbers and : allowed
                    e.Handled = false;
                else // Other characters not allowed
                    e.Handled = true;
            }
            catch
            { InitialTimeTextBox.BackColor = Color.Red; }
        }

        private void FinalTimeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                FinalTimeTextBox.BackColor = Color.White; LongInfoMessageLabel.Visible = false; PacketsDecodedLabel.Visible = false; ShortInfoMessageLabel.Visible = false;
                if (Char.IsDigit(e.KeyChar) || e.KeyChar == ':' || Char.IsControl(e.KeyChar)) // numbers and : allowed
                    e.Handled = false;
                else // Other characters not allowed
                    e.Handled = true;
            }
            catch
            { FinalTimeTextBox.BackColor = Color.Red; }
        }

        public Boolean analyzingTimeFormat(TextBox time)
        {
            Boolean correctTimeFormat = true;
            if (time.Text.Split(':').Length != 3)
            { correctTimeFormat = false; time.BackColor = Color.Red; }
            else
            {
                for (int i = 0; i < time.Text.Split(':').Length; i++)
                {
                    if (time.Text.Split(':')[i].Length != 2 || Convert.ToInt32(time.Text.Split(':')[0]) > 23 || Convert.ToInt32(time.Text.Split(':')[1]) > 59 || Convert.ToInt32(time.Text.Split(':')[2]) > 59)
                    { correctTimeFormat = false; time.BackColor = Color.Red; break; }
                }
            }
            return correctTimeFormat;
        }

        private void SearchInFile_Click(object sender, EventArgs e)
        {
            try
            {
                LongInfoMessageLabel.Visible = false; PacketsDecodedLabel.Visible = false; ShortInfoMessageLabel.Visible = false;
                Boolean correctInitialTimeFormat = analyzingTimeFormat(InitialTimeTextBox); // Analyzing time format of initial time
                Boolean correctFinalTimeFormat = analyzingTimeFormat(FinalTimeTextBox); // Analyzing time format of final time
                if (correctInitialTimeFormat && correctFinalTimeFormat)
                {
                    int initialSecondsSelected = Convert.ToInt32(InitialTimeTextBox.Text.Split(':')[0]) * 3600 + Convert.ToInt32(InitialTimeTextBox.Text.Split(':')[1]) * 60 + Convert.ToInt32(InitialTimeTextBox.Text.Split(':')[2]);
                    int finalSecondsSelected = Convert.ToInt32(FinalTimeTextBox.Text.Split(':')[0]) * 3600 + Convert.ToInt32(FinalTimeTextBox.Text.Split(':')[1]) * 60 + Convert.ToInt32(FinalTimeTextBox.Text.Split(':')[2]);
                    // Possible erros introducing time period to be analyzed
                    if (initialSecondsSelected < file.initialSecondsFile || initialSecondsSelected > file.finalSecondsFile)
                    { LongInfoMessageLabel.Visible = true; LongInfoMessageLabel.Text = "INITIAL TIME OUT OF RANGE!"; }
                    else if (finalSecondsSelected > file.finalSecondsFile || finalSecondsSelected < file.initialSecondsFile)
                    { LongInfoMessageLabel.Visible = true; LongInfoMessageLabel.Text = "FINAL TIME OUT OF RANGE!"; }
                    else if (finalSecondsSelected - initialSecondsSelected > 30 * 60 && file.finalSecondsFile - file.initialSecondsFile > 2.1*3600)
                    { LongInfoMessageLabel.Visible = true; LongInfoMessageLabel.Text = "TIME INTERVAL BIGGER THAN 30 MIN!"; }
                    else if (finalSecondsSelected < initialSecondsSelected)
                    { LongInfoMessageLabel.Visible = true; LongInfoMessageLabel.Text = "INITIAL TIME BIGGER THAN FINAL TIME!"; }
                    else if (finalSecondsSelected - initialSecondsSelected == 0)
                    { ShortInfoMessageLabel.Visible = true; ShortInfoMessageLabel.Text = "TIME PERIOD EQUAL TO ZERO!"; }
                    // Possible erros introducing files
                    else if (data.AsterixFiles.Count == 1 && data.AsterixFiles[0].fileName == file.fileName && initialSecondsSelected == data.AsterixFiles[0].initialSecondsSelected && finalSecondsSelected == data.AsterixFiles[0].finalSecondsSelected)
                    { ShortInfoMessageLabel.Visible = true; ShortInfoMessageLabel.Text = "FILE ALREADY LOADED!"; }
                    else if (data.AsterixFiles.Count == 1 && data.AsterixFiles[0].fileName != file.fileName && (initialSecondsSelected != data.AsterixFiles[0].initialSecondsSelected || finalSecondsSelected != data.AsterixFiles[0].finalSecondsSelected))
                    { LongInfoMessageLabel.Visible = true; LongInfoMessageLabel.Text = "PERIOD TIME SELECTED IS DIFFERENT FROM THE ONE LOADED.\nPLEASE SELECT THE SAME ONE!"; }
                    else if (data.AsterixFiles.Count == 2 && (initialSecondsSelected < data.AsterixFiles[0].initialSecondsFile || initialSecondsSelected < data.AsterixFiles[1].initialSecondsFile))
                    { LongInfoMessageLabel.Visible = true; LongInfoMessageLabel.Text = "INITIAL TIME OUT OF RANGE!"; }
                    else if (data.AsterixFiles.Count == 2 && (finalSecondsSelected > data.AsterixFiles[0].finalSecondsFile || finalSecondsSelected > data.AsterixFiles[1].finalSecondsFile))
                    { LongInfoMessageLabel.Visible = true; LongInfoMessageLabel.Text = "FINAL TIME OUT OF RANGE!"; }
                    else if (data.AsterixFiles.Count == 2 && data.AsterixFiles[1].fileName == file.fileName && initialSecondsSelected == data.AsterixFiles[1].initialSecondsSelected && finalSecondsSelected == data.AsterixFiles[1].finalSecondsSelected)
                    { ShortInfoMessageLabel.Visible = true; ShortInfoMessageLabel.Text = "FILE ALREADY LOADED!"; }
                    else // Correct time period
                    {
                        ShortInfoMessageLabel.Visible = true;
                        ShortInfoMessageLabel.Text = "LOADING...";
                        file.initialSecondsSelected = initialSecondsSelected; file.finalSecondsSelected = finalSecondsSelected;
                        this.Cursor = Cursors.WaitCursor;
                        Boolean fileFounded = false;
                        foreach (AsterixFile asterixfile in data.AsterixFiles)
                        {
                            if (asterixfile.fileName == file.fileName) // A loaded file(s) required to change time interval
                            {
                                data.Clear(); fileFounded = true; fileMore30min = false;
                                foreach (AsterixFile ast in data.AsterixFiles)
                                { ast.initialSecondsSelected = initialSecondsSelected; ast.finalSecondsSelected = finalSecondsSelected; ast.readAsterixFile(ast.fileBytes);}
                            }
                        }
                        if (!fileFounded) // Load a new file
                        { data.AsterixFiles.Add(file); file.readAsterixFile(file.fileBytes); }
                        // Deleting columns of the datatable with no information
                        if (data.AsterixFiles.Count == 2)
                        {
                            for (int k = data.tablaCATs.Columns.Count - 1; k > 0; k--)
                            {
                                if (!data.filledDataItems[k])
                                    data.tablaCATs.Columns.RemoveAt(k);
                            }
                        }
                        if (file.finalSecondsSelected - file.initialSecondsSelected > 30 * 60)
                            fileMore30min = true;
                        timePeriodSelectedLabel.Text = "TIME PERIOD SELECTED: " + InitialTimeTextBox.Text + " - " + FinalTimeTextBox.Text; timePeriodSelectedLabel.Visible = true;
                        this.Cursor = Cursors.Default; ShortInfoMessageLabel.Visible = false;
                    
                        if (data.listaCATs.Count != 0)
                        {
                            LongInfoMessageLabel.Text = "THE FILE HAS BEEN SUCCESSFULLY DECODED!"; LongInfoMessageLabel.Visible = true;
                            string filesLoaded = "";
                            foreach (AsterixFile file in data.AsterixFiles)
                            { filesLoaded += file.fileName + "\n"; }
                            CurrentFileLabel.Text = "CURRENT FILE (S): " + filesLoaded; CurrentFileLabel.Visible = true;
                            PacketsDecodedLabel.Text = Convert.ToString(data.listaCATs.Count) + " PACKETS READY TO ANALYZE"; PacketsDecodedLabel.Visible = true;
                        }
                        else
                        { LongInfoMessageLabel.Text = "SORRY, THE FILE IS DIFFERENT FROM LOGGED CATEGORIES, PLEASE SELECT ANOTHER"; LongInfoMessageLabel.Visible = true; }
                    }   
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); this.Cursor = Cursors.Default; ShortInfoMessageLabel.Visible = false; }
        }

        private void DataViewButton_Click(object sender, EventArgs e)
        {
            try 
            {
                ExitPanel.Visible = false;
                if (data.CATsList.Count != 0)
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataView DataViewForm = new DataView();
                    DataViewForm.data = data;
                    OpenChildForm(DataViewForm, sender);
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    if (currentFormActivated != null)
                        currentFormActivated.Close();
                    ActivateButton(sender);
                    LogoInicial.Visible = false; AsterixInicialLabel.Visible = false; DecoderInicialLabel.Visible = false;
                    InitialTimeLabel.Visible = false; FinalTimeLabel.Visible = false;
                    InitialTimeTextBox.Visible = false; FinalTimeTextBox.Visible = false; SearchInFile.Visible = false;
                    InfoPeriodTimeLabel.Visible = false; SelectionTimeLabel.Visible = false;
                    LongInfoMessageLabel.Visible = false; PacketsDecodedLabel.Visible = false;
                    if (file == null)
                        ShortInfoMessageLabel.Text = "FIRST LOAD A FILE";
                    else
                        ShortInfoMessageLabel.Text = "FIRST SELECT TIME PERIOD";
                    ShortInfoMessageLabel.Visible = true;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void MapViewButton_Click(object sender, EventArgs e)
        {
            try
            {
                ExitPanel.Visible = false;
                if (data.CATsList.Count != 0)
                {
                    MapView MapViewForm = new MapView();
                    MapViewForm.data = data;
                    OpenChildForm(MapViewForm, sender);
                }
                else
                {
                    if (currentFormActivated != null)
                        currentFormActivated.Close();
                    ActivateButton(sender);
                    LogoInicial.Visible = false; AsterixInicialLabel.Visible = false; DecoderInicialLabel.Visible = false;
                    InitialTimeLabel.Visible = false; FinalTimeLabel.Visible = false;
                    InitialTimeTextBox.Visible = false; FinalTimeTextBox.Visible = false; SearchInFile.Visible = false;
                    InfoPeriodTimeLabel.Visible = false; SelectionTimeLabel.Visible = false;
                    LongInfoMessageLabel.Visible = false; PacketsDecodedLabel.Visible = false;
                    if (file == null)
                        ShortInfoMessageLabel.Text = "FIRST LOAD A FILE";
                    else
                        ShortInfoMessageLabel.Text = "FIRST SELECT TIME PERIOD";
                    ShortInfoMessageLabel.Visible = true;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void ClearFileButton_Click(object sender, EventArgs e)
        {
            try 
            {
                ExitPanel.Visible = false;
                ActivateButton(sender);
                Exit ExitForm = new Exit("Clear Files");
                ExitForm.ShowDialog();
                if (ExitForm.yesPressed)
                { 
                    data.Clear(); data.AsterixFiles.Clear(); file = null; fileMore30min = false;
                    if (currentFormActivated != null)
                        currentFormActivated.Close();
                    // Hided items
                    ShortInfoMessageLabel.Visible = false; LongInfoMessageLabel.Visible = false; PacketsDecodedLabel.Visible = false; InfoPeriodTimeLabel.Visible = false; SelectionTimeLabel.Visible = false; CurrentFileLabel.Visible = false; timePeriodSelectedLabel.Visible = false;
                    InitialTimeLabel.Visible = false; FinalTimeLabel.Visible = false; SearchInFile.Visible = false; InitialTimeTextBox.Visible = false; FinalTimeTextBox.Visible = false;
                    // Initial Logo showed
                    AsterixInicialLabel.Visible = true; DecoderInicialLabel.Visible = true;  LogoInicial.Visible = true;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            try
            {
                ActivateButton(sender);
                MenuVertical.Width = 200;
                if (ExitPanel.Visible == false)
                    ExitPanel.Visible = true;
                else
                    ExitPanel.Visible = false;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void YesExitButton_Click(object sender, EventArgs e)
        { Application.Exit(); }
        private void NoExitButton_Click(object sender, EventArgs e)
        { ExitPanel.Visible = false; }

        private void Menu_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                 this.FormBorderStyle = FormBorderStyle.None;
            else
                this.FormBorderStyle = FormBorderStyle.Sizable;
        }
    }
}