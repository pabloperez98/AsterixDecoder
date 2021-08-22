using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ClassLibrary;
using System.IO;
using System.Text;
using Microsoft.Win32;

namespace AsterixDecoder
{
    public partial class DataView : Form
    {
        public AsterixData data;
        public DataTable filteredTable;
        public Boolean moreInfoNeeded = false;
        public int selectedRow;  public Boolean checkedItem = false;

        public DataView()
        { InitializeComponent(); dataGridView.AllowUserToAddRows = false; }

        // Uncheck the first cell of the gridView that is selected by default
        private void DataView_Shown(object sender, EventArgs e)
        { dataGridView.ClearSelection(); }

        // Center gridView cells
        public void centerDataGridView()
        {
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        // It is responsible for displaying the corresponding table when loading the Form DataView
        private void DataView_Load(object sender, EventArgs e)
        {
            try 
            {
                // DataGridView Design
                dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
                dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Bahnschrift Condensed", 14F, FontStyle.Regular);
                dataGridView.DefaultCellStyle.Font = new Font("Bahnschrift Light", 10F, FontStyle.Regular);
                dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView.DefaultCellStyle.ForeColor = Color.Black;
                // Asignation of datatable in datagrid
                dataGridView.DataSource = data.tablaCATs; filteredTable = data.tablaCATs;
                for (int i = 0; i < data.tablaCATs.Columns.Count; i++) //hide colums with no information
                {
                    if (!data.filledDataItems[i])
                        dataGridView.Columns[i].Visible = false;
                }
                centerDataGridView();
                totalPacketsLabel.Text = "Total Packets: " + dataGridView.RowCount;
                SearchTextBox.Visible = true;
                dataGridView.ClearSelection();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        // Function that fill moreInfo Table with the information of the data item selected
        void fillMoreInfoTable(List<string> selectedDataItemTable, DataTable moreInfoTable)
        {
            moreInfoNeeded = true;
            for (int i = 0; i < selectedDataItemTable.Count; i += 2)
                moreInfoTable.Rows.Add(selectedDataItemTable[i], selectedDataItemTable[i + 1]);
        }

        // Function executed when clicking a cell in the dataGridView
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SearchTextBox.BackColor = Color.White;
                dataGridView.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
                dataGridView.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
                this.selectedRow = this.data.listaCATs.FindIndex(r => r.packetNumber == dataGridView.Rows[e.RowIndex].Cells["Packet\nNº"].Value.ToString());
                dataGridView.Rows[e.RowIndex].Selected = true;
                int selectedDataItem = data.FRNinfoCATs.IndexOf(dataGridView.Columns[e.ColumnIndex].Name);
                int CAT = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[1].Value);
                // Showing the new form of more information when pressing the corresponding cells
                if (dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "N/A")
                {
                    MoreInformation MoreInfoForm = new MoreInformation();
                    moreInfoNeeded = false;
                    DataTable moreInfoTable = new DataTable();
                    if (selectedDataItem == 44)
                    { moreInfoTable.Columns.Add("Start Range [NM]"); moreInfoTable.Columns.Add("End Range [NM]"); moreInfoTable.Columns.Add("Azimuth [º]"); }
                    else if (selectedDataItem == 69 && CAT == 2)
                    { moreInfoTable.Columns.Add("A"); moreInfoTable.Columns.Add("IDENT"); moreInfoTable.Columns.Add("COUNTER"); }
                    else if (selectedDataItem == 69 && CAT == 34)
                    { moreInfoTable.Columns.Add("TYP"); moreInfoTable.Columns.Add("COUNTER"); }
                    else if (selectedDataItem == 72)
                    { moreInfoTable.Columns.Add("X-COMPONENT [NM]"); moreInfoTable.Columns.Add("Y-COMPONENT [NM]"); moreInfoTable.Columns.Add("LENGTH [NM]"); }
                    else if (selectedDataItem == 74)
                    { moreInfoTable.Columns.Add("X(1) [NM]"); moreInfoTable.Columns.Add("Y(1) [NM]"); }
                    else if (selectedDataItem == 75)
                    { moreInfoTable.Columns.Add("X1 Component [NM]"); moreInfoTable.Columns.Add("Y1 Component [NM]"); moreInfoTable.Columns.Add("X2 Component [NM]"); moreInfoTable.Columns.Add("Y2 Component [NM]"); }
                    else if (selectedDataItem == 79)
                    { moreInfoTable.Columns.Add("DRHO [m]"); moreInfoTable.Columns.Add("DTHETA [º]"); }
                    else if (selectedDataItem == 101)
                    { moreInfoTable.Columns.Add("System Unit Identification"); moreInfoTable.Columns.Add("System Track Number"); }
                    else
                    { moreInfoTable.Columns.Add("Field"); moreInfoTable.Columns.Add("Value"); }
                    List<double> TableDimensions = new List<double>();
                    
                    if (selectedDataItem == 10) // Target Report Descriptor
                    {
                        if (CAT == 1)
                        { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].targetReportDescriptorCAT01.TableTRD, moreInfoTable); TableDimensions.Add(383); TableDimensions.Add(304); }
                        else if (CAT == 10)
                        {
                            fillMoreInfoTable(this.data.listaCATs[this.selectedRow].targetReportDescriptorCAT10.TableTRD, moreInfoTable);
                            if (this.data.listaCATs[this.selectedRow].dataSourceIdentifier == "000/007") //SMR
                            { TableDimensions.Add(339); TableDimensions.Add(184); }
                            else //MLAT
                            { TableDimensions.Add(396); TableDimensions.Add(328); }
                        }
                        else if (CAT == 21)
                        {
                            if (this.data.listaCATs[this.selectedRow].V023)
                            { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].targetReportDescriptorCAT21V023.TableTRD, moreInfoTable); TableDimensions.Add(458); TableDimensions.Add(280); }
                            else if (this.data.listaCATs[this.selectedRow].V21)
                            { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].targetReportDescriptorCAT21V21.TableTRD, moreInfoTable); TableDimensions.Add(302); TableDimensions.Add(160); }
                        }
                        else if (CAT == 48)
                        { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].targetReportDescriptorCAT48.TableTRD, moreInfoTable); TableDimensions.Add(396); TableDimensions.Add(184); }
                    }
                    else if (selectedDataItem == 17 && (CAT == 1 || CAT == 10 || CAT == 48)) // Flight Level
                    {
                        if (CAT == 01) { TableDimensions.Add(203); TableDimensions.Add(112); }
                        else { TableDimensions.Add(174); TableDimensions.Add(112); }
                        fillMoreInfoTable(this.data.listaCATs[this.selectedRow].flightLevel.TableFL, moreInfoTable);
                    }
                    else if(selectedDataItem == 20 && CAT == 21) // Selected Altitude
                    { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].selectedAltitude.TableSA, moreInfoTable); TableDimensions.Add(291); TableDimensions.Add(112); }
                    else if (selectedDataItem == 8 && (CAT == 01 || CAT == 10 || CAT == 48 || CAT == 62)) // Mode 3/A
                    {
                        if (CAT == 62) { TableDimensions.Add(200); TableDimensions.Add(136); }
                        else { TableDimensions.Add(494); TableDimensions.Add(136); }
                        
                        fillMoreInfoTable(this.data.listaCATs[this.selectedRow].mode3A.TableM3A, moreInfoTable);
                    }
                    else if (selectedDataItem == 27 && CAT == 48) // Radar Plot Characteristics
                    { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].radarPlotCharacteristics.TableRPC, moreInfoTable); TableDimensions.Add(50); TableDimensions.Add(232); }
                    else if (selectedDataItem == 30 && CAT == 08) // Vector Qualifier
                    { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].vectorQualifier.TableVQ, moreInfoTable); TableDimensions.Add(199); TableDimensions.Add(88); }
                    else if (selectedDataItem == 42) // Track Status
                    {
                        if (CAT == 10)
                        {
                            fillMoreInfoTable(this.data.listaCATs[this.selectedRow].trackStatusCAT10.TableTS, moreInfoTable);
                            if (this.data.listaCATs[this.selectedRow].dataSourceIdentifier == "000/007") //SMR
                            { TableDimensions.Add(803); TableDimensions.Add(280); }
                            else //MLAT
                            { TableDimensions.Add(1285); TableDimensions.Add(304); }
                        }
                        else if (CAT == 48)
                        { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].trackStatusCAT48.TableTS, moreInfoTable); TableDimensions.Add(994); TableDimensions.Add(280); }
                        else if (CAT == 62)
                        { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].trackStatusCAT62.TableTS, moreInfoTable); TableDimensions.Add(663); TableDimensions.Add(640);}
                    }
                    else if (selectedDataItem == 43 && CAT == 10) // System Status
                    { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].systemStatus.TableSS, moreInfoTable); TableDimensions.Add(231); TableDimensions.Add(184); }
                    else if (selectedDataItem == 44 && CAT == 8) // Sequence of Polar Vectors
                    {
                        TableDimensions.Add(250); TableDimensions.Add(664);
                        moreInfoNeeded = true;
                        for (int i = 0; i < this.data.listaCATs[this.selectedRow].sequencePolarVectors.TableSPV.Count; i += 3)
                            moreInfoTable.Rows.Add(this.data.listaCATs[this.selectedRow].sequencePolarVectors.TableSPV[i], this.data.listaCATs[this.selectedRow].sequencePolarVectors.TableSPV[i + 1], this.data.listaCATs[this.selectedRow].sequencePolarVectors.TableSPV[i + 2]);
                    }
                    else if (selectedDataItem == 45 && CAT == 21 && this.data.listaCATs[this.selectedRow].V023) // Link Technology
                    { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].linkTechnology.TableLT, moreInfoTable); TableDimensions.Add(100); TableDimensions.Add(184); }
                    else if (selectedDataItem == 46 && CAT == 21 && this.data.listaCATs[this.selectedRow].V21) // Quality Indicators
                    { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].qualityIndicators.TableQI, moreInfoTable); TableDimensions.Add(321); TableDimensions.Add(280); }
                    else if (selectedDataItem == 47 && CAT == 21 && this.data.listaCATs[this.selectedRow].V21) // MOPS version
                    { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].MOPSversion.TableMOPS, moreInfoTable); TableDimensions.Add(375); TableDimensions.Add(136); }
                    else if (selectedDataItem == 48 && CAT == 21 && this.data.listaCATs[this.selectedRow].V21) // Target Status
                    { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].targetStatusV21.TableTargetStatus, moreInfoTable); TableDimensions.Add(276); TableDimensions.Add(160); }
                    else if (selectedDataItem == 49 && CAT == 21 && this.data.listaCATs[this.selectedRow].V21) // Aircraft Operational Status
                    { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].aircraftOperationalStatus.TableAOS, moreInfoTable); TableDimensions.Add(437); TableDimensions.Add(232); }
                    else if (selectedDataItem == 50 && CAT == 21 && this.data.listaCATs[this.selectedRow].V21) // Surface Capabilities & Characteristics
                    { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].surfaceCapabilitiesAndCharacteristics.TableSCC, moreInfoTable); TableDimensions.Add(526); TableDimensions.Add(232); }
                    else if (selectedDataItem == 51 && ((CAT == 21 && this.data.listaCATs[this.selectedRow].V21) || CAT == 62)) // Data Ages
                    {
                        if (CAT == 21) { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].dataAges.TableDA, moreInfoTable); TableDimensions.Add(50); TableDimensions.Add(376); }
                        else if (CAT == 62) { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].trackDataAges.TableTDA, moreInfoTable); TableDimensions.Add(285); TableDimensions.Add(208); }
                    }
                    else if (selectedDataItem == 52 && CAT == 34) // System Configuration and Status   
                    { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].systemConfigurationStatus.TableSCS, moreInfoTable); TableDimensions.Add(419); TableDimensions.Add(520); }
                    else if (selectedDataItem == 53 && CAT == 34) // System Processing Mode   
                    { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].systemProcessingMode.TableSPM, moreInfoTable); TableDimensions.Add(284); TableDimensions.Add(232); }
                    else if (selectedDataItem == 54 && (CAT == 10 || (CAT == 21 && this.data.listaCATs[this.selectedRow].V21) || CAT == 48)) // Mode S MB Data  
                    {
                        if (CAT == 10) { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].modeS_MBData.TableMBD, moreInfoTable); TableDimensions.Add(536); TableDimensions.Add(448);}
                        else if (CAT == 48) { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].modeS_MBData.TableMBD, moreInfoTable); TableDimensions.Add(752); TableDimensions.Add(592); }
                    }
                    else if (selectedDataItem == 55 && CAT == 48) // ACAS Capability & Flight Status
                    { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].ACAS_CapabilitiesFlightStatus.TableACAS_CFS, moreInfoTable); TableDimensions.Add(469); TableDimensions.Add(304); }
                    else if (selectedDataItem == 56 && CAT == 62) // Aircraft Derived Data
                    { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].aircraftDerivedData.TableADD, moreInfoTable); TableDimensions.Add(339); TableDimensions.Add(232); }
                    else if (selectedDataItem == 57 && CAT == 62) // System Track Update Ages
                    { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].systemTrackUpdateAges.TableSTUA, moreInfoTable); TableDimensions.Add(145); TableDimensions.Add(112); }
                    else if (selectedDataItem == 58 && CAT == 62) // Mode of Movement
                    { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].modeOfMovement.TableMoM, moreInfoTable); TableDimensions.Add(254); TableDimensions.Add(160); }
                    else if (selectedDataItem == 59 && CAT == 62) // Flight Plan Related Data
                    { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].flightPlanRelatedData.TableFPRD, moreInfoTable); TableDimensions.Add(467); TableDimensions.Add(160); }
                    else if (selectedDataItem == 60 && CAT == 62) // Measured Information
                    { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].measuredInformation.TableMI, moreInfoTable); TableDimensions.Add(265); TableDimensions.Add(136); }
                    else if (selectedDataItem == 61 && CAT == 21 && this.data.listaCATs[this.selectedRow].V023) // Figure of Merit      
                    { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].figureOfMerit.TableFM, moreInfoTable); TableDimensions.Add(100); TableDimensions.Add(160); }
                    else if (selectedDataItem == 62 && (CAT == 1 || CAT == 48 || CAT == 62)) // Mode 2   
                    { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].mode2.TableM2, moreInfoTable); }
                    else if (selectedDataItem == 63 && CAT == 48) // Radial Doppler Speed  
                    { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].radialDopplerSpeed.TableSCS, moreInfoTable); }
                    else if (selectedDataItem == 66 && CAT == 1) // Presence of X-Pulse   
                    { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].presenceX_Pulse.TablePXP, moreInfoTable); }
                    else if (selectedDataItem == 69) // Message Count Values     
                    {
                        if (CAT == 2)
                        {
                            moreInfoNeeded = true;
                            for (int i = 0; i < this.data.listaCATs[this.selectedRow].plotCountValues.TablePCV.Count; i += 3)
                                moreInfoTable.Rows.Add(this.data.listaCATs[this.selectedRow].plotCountValues.TablePCV[i], this.data.listaCATs[this.selectedRow].messageCountValues.TableMCV[i + 1], this.data.listaCATs[this.selectedRow].messageCountValues.TableMCV[i + 2]);
                        }
                        else if (CAT == 34)
                        { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].messageCountValues.TableMCV, moreInfoTable); }
                    }
                    else if (selectedDataItem == 72 && CAT == 8) // Sequence of Cartesian Vectors 
                    {
                        moreInfoNeeded = true;
                        for (int i = 0; i < this.data.listaCATs[this.selectedRow].sequenceCartesianVectors.TableSQV.Count; i += 3)
                            moreInfoTable.Rows.Add(this.data.listaCATs[this.selectedRow].sequenceCartesianVectors.TableSQV[i], this.data.listaCATs[this.selectedRow].sequenceCartesianVectors.TableSQV[i + 1], this.data.listaCATs[this.selectedRow].sequenceCartesianVectors.TableSQV[i + 2]);
                    }
                    else if (selectedDataItem == 73 && CAT == 8) // Contour Identifier   
                    { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].contourIdentifier.TableCI, moreInfoTable); }
                    else if (selectedDataItem == 74 && CAT == 8) // Sequence of Contour Points
                    {
                        moreInfoNeeded = true;
                        for (int i = 0; i < this.data.listaCATs[this.selectedRow].sequenceContourPoints.TableSCP.Count; i += 2)
                            moreInfoTable.Rows.Add(this.data.listaCATs[this.selectedRow].sequenceContourPoints.TableSCP[i], this.data.listaCATs[this.selectedRow].sequenceContourPoints.TableSCP[i + 1]);
                    }
                    else if (selectedDataItem == 75 && CAT == 8) // Sequence of Weather Vectors
                    {
                        moreInfoNeeded = true;
                        for (int i = 0; i < this.data.listaCATs[this.selectedRow].sequenceWeatherVectors.TableSWV.Count; i += 4)
                            moreInfoTable.Rows.Add(this.data.listaCATs[this.selectedRow].sequenceWeatherVectors.TableSWV[i], this.data.listaCATs[this.selectedRow].sequenceWeatherVectors.TableSWV[i + 1], this.data.listaCATs[this.selectedRow].sequenceWeatherVectors.TableSWV[i + 2], this.data.listaCATs[this.selectedRow].sequenceWeatherVectors.TableSWV[i + 3]);
                    }
                    else if (selectedDataItem == 79 && CAT == 10) // Presence
                    {
                        moreInfoNeeded = true;
                        for (int i = 0; i < this.data.listaCATs[this.selectedRow].presence.TableP.Count; i += 2)
                            moreInfoTable.Rows.Add(this.data.listaCATs[this.selectedRow].presence.TableP[i], this.data.listaCATs[this.selectedRow].presence.TableP[i + 1]);
                    }
                    else if (selectedDataItem == 87 && CAT == 21) // Met Information  
                    { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].metInformation.TableMI, moreInfoTable); }
                    else if (selectedDataItem == 88 && CAT == 21) // Final Selected Altitude 
                    { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].finalSelectedAltitude.TableFSA, moreInfoTable); }
                    else if (selectedDataItem == 89 && CAT == 21) // Trajectory Intent
                    { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].trajectoryIntentData.TableTID, moreInfoTable); }
                    else if (selectedDataItem == 93 && CAT == 21 && this.data.listaCATs[this.selectedRow].V21) // ACAS Resolution Advisory Report
                     {fillMoreInfoTable(this.data.listaCATs[this.selectedRow].ACAS_ResolutionAdvisoryReport.TableACAS_RAR, moreInfoTable); }
                    else if (selectedDataItem == 98 && CAT == 48) // Mode 1
                    { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].mode1.TableM1, moreInfoTable); }
                    else if (selectedDataItem == 100 && CAT == 62) // Mode 5 Data Reports
                    { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].mode5DataReports.TableM5DR, moreInfoTable); }
                    else if (selectedDataItem == 101 && CAT == 62) // Composed Track Number
                    {
                        moreInfoNeeded = true;
                        for (int i = 0; i < this.data.listaCATs[this.selectedRow].composedTrackNumber.TableCTN.Count; i += 2)
                            moreInfoTable.Rows.Add(this.data.listaCATs[this.selectedRow].composedTrackNumber.TableCTN[i], this.data.listaCATs[this.selectedRow].composedTrackNumber.TableCTN[i + 1]);
                    }
                    else if (selectedDataItem == 102 && CAT == 62) // Estimated Accuracies
                    { fillMoreInfoTable(this.data.listaCATs[this.selectedRow].estimatedAccuracies.TableEA, moreInfoTable); }
                    if (moreInfoNeeded)
                    {
                        MoreInfoForm.setMoreInfoTabla(moreInfoTable, TableDimensions, selectedDataItem);
                        MoreInfoForm.ShowDialog();
                    }
                    if (dataGridView.Columns[e.ColumnIndex].Name == "Category" || dataGridView.Columns[e.ColumnIndex].Name == "SAC/SIC" || dataGridView.Columns[e.ColumnIndex].Name == "Call\n    Sign    " || dataGridView.Columns[e.ColumnIndex].Name == "ICAO\nAddress" || dataGridView.Columns[e.ColumnIndex].Name == "Track\nNumber")
                    {
                        this.Cursor = Cursors.WaitCursor;
                        SearchTextBox.Text = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        int selectedCheckBox = 0; // CAT
                        if (dataGridView.Columns[e.ColumnIndex].Name == "SAC/SIC")
                            selectedCheckBox = 1;
                        else if (dataGridView.Columns[e.ColumnIndex].Name == "Call\n    Sign    ")
                            selectedCheckBox = 2;
                        else if (dataGridView.Columns[e.ColumnIndex].Name == "Track\nNumber")
                            selectedCheckBox = 3;
                        else if (dataGridView.Columns[e.ColumnIndex].Name == "ICAO\nAddress")
                            selectedCheckBox = 4;
                        for (int i = 0; i < FilterPacketCheckList.Items.Count; i++)
                            FilterPacketCheckList.SetItemChecked(i, false);
                        FilterPacketCheckList.SetItemChecked(selectedCheckBox, true);
                        FilterPacketCheckList.SetSelected(selectedCheckBox, true);
                        filterDataItems();
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        // Function executed when writing to the filter TextBox
        private void SearchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                SearchTextBox.BackColor = Color.White;
                if (e.KeyChar == '\r') // Pressing enter key
                {
                    e.Handled = true;
                    this.Cursor = Cursors.WaitCursor;
                    filterDataItems();
                    this.Cursor = Cursors.Default;
                }
                else if (Char.IsLetter(e.KeyChar) || e.KeyChar == '/' || Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar)) // permite letras y / (para SAC/SIC), números y teclas de control de retroceso
                    e.Handled = false;
                else // Disallow other keys
                    e.Handled = true;
            }
            catch
            { SearchTextBox.BackColor = Color.Red; }
        }

        // Selecting an item from the check list unchecks the previous one
        private void FilterPacketCheckList_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < FilterPacketCheckList.Items.Count; i++)
                FilterPacketCheckList.SetItemChecked(i, false);
            if (FilterPacketCheckList.SelectedIndex >= 0)
                FilterPacketCheckList.SetItemChecked(FilterPacketCheckList.SelectedIndex, true);
        }
        private void SearchInTable_Click(object sender, EventArgs e)
        { 
            this.Cursor = Cursors.WaitCursor; 
            filterDataItems();
            this.Cursor = Cursors.Default; 
        }
        private void resetDataGrid_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            SearchInfoLabel.Visible = false;
            SearchTextBox.Clear();
            SearchTextBox.BackColor = Color.White;
            dataGridView.DefaultCellStyle.SelectionBackColor = dataGridView.DefaultCellStyle.BackColor;
            dataGridView.DefaultCellStyle.SelectionForeColor = dataGridView.DefaultCellStyle.ForeColor;
            for (int i = 0; i < FilterPacketCheckList.Items.Count; i++)
            { 
                FilterPacketCheckList.SetItemChecked(i, false); 
                FilterPacketCheckList.SetSelected(i, false); }
            resetTable();
            centerDataGridView();
            dataGridView.FirstDisplayedScrollingRowIndex = dataGridView.Rows[0].Index;
            this.Cursor = Cursors.Default;
        }

        // Get the filtered table
        private void obtainFilteredTable(string DataItemFilter, DataTable Tabla)
        {
            filteredTable = new DataTable();
            for (int i = 0; i < Tabla.Columns.Count; i++)
                filteredTable.Columns.Add(Tabla.Columns[i].ColumnName);
            for (int i = 0; i < Tabla.Rows.Count; i++)
            {
                string item = Tabla.Rows[i][DataItemFilter].ToString();
                if (item.Contains("*"))
                    item = item.Substring(0, item.Length - 2);
                if (item == SearchTextBox.Text)
                {
                    DataRow filteredRow = filteredTable.NewRow();
                    for (int j = 0; j < Tabla.Columns.Count; j++)
                        filteredRow[j] = Tabla.Rows[i][j];
                    filteredTable.Rows.Add(filteredRow);
                }
            }
        }

        // Reload the table without any filter
        private void resetTable()
        {
            dataGridView.ClearSelection();
            dataGridView.DataSource = null;
            // Asignation datatable in the datagrid
            dataGridView.DataSource = data.tablaCATs; filteredTable = data.tablaCATs;
            for (int i = 0; i < data.tablaCATs.Columns.Count; i++) //hide colums with no information
            {
                if (!data.filledDataItems[i])
                    dataGridView.Columns[i].Visible = false;
            }
            centerDataGridView(); 
        }

        // Hide the columns that have all their cells with no information
        public void hideColumnsNA(DataTable tabla)
        {
            dataGridView.DataSource = tabla;
            for (int i = 0; i < filteredTable.Columns.Count; i++)
            {
                if (data.filledDataItems[i])
                {
                    dataGridView.Columns[i].Visible = true;
                    Boolean hideColumn = true;
                    for (int j = 0; j < filteredTable.Rows.Count; j++)
                    {
                        string cellValue = filteredTable.Rows[j][i].ToString();
                        if (cellValue != "N/A")
                        { hideColumn = false; break; }
                    }
                    if (hideColumn)
                        dataGridView.Columns[i].Visible = false;
                }
            }
        }

        // Filter the displayed table according to the desired dataItem
        private void filterDataItems()
        {
            try
            {
                SearchInfoLabel.Text = "";
                SearchInfoLabel.Visible = true;
                if (FilterPacketCheckList.SelectedIndices.Count != 0)
                {
                    if (FilterPacketCheckList.SelectedItem.ToString() == "CAT")
                    {
                        if (data.listaCATs.Exists(r => r.category == SearchTextBox.Text))
                        {
                            if (ChainFiltersCheckBox.CheckedItems.Count != 0)
                                obtainFilteredTable("Category", filteredTable);
                            else
                                obtainFilteredTable("Category", data.tablaCATs);
                            dataGridView.DataSource = filteredTable;
                            hideColumnsNA(filteredTable);
                            SearchInfoLabel.Text = "Filter packets: " + Convert.ToString(dataGridView.RowCount);
                        }
                        else
                        { SearchTextBox.BackColor = Color.Red; SearchInfoLabel.Text = "Category not available"; }
                    }
                    else if (FilterPacketCheckList.SelectedItem.ToString() == "SAC/SIC")
                    {
                        if (data.listaCATs.Exists(r => r.dataSourceIdentifier == SearchTextBox.Text))
                        {
                            if (ChainFiltersCheckBox.CheckedItems.Count != 0)
                                obtainFilteredTable("SAC/SIC", filteredTable);
                            else
                                obtainFilteredTable("SAC/SIC", data.tablaCATs);
                            dataGridView.DataSource = filteredTable; hideColumnsNA(filteredTable);
                            SearchInfoLabel.Text = "Filter packets: " + Convert.ToString(dataGridView.RowCount);
                        }
                        else
                        { SearchTextBox.BackColor = Color.Red; SearchInfoLabel.Text = "DSI not available"; }
                    }
                    else if (FilterPacketCheckList.SelectedItem.ToString() == "CallSign")
                    {
                        if (data.listaCATs.Exists(r => r.callsign.TargetID == SearchTextBox.Text))
                        {
                            if (ChainFiltersCheckBox.CheckedItems.Count != 0)
                                obtainFilteredTable("Call\n    Sign    ", filteredTable);
                            else
                                obtainFilteredTable("Call\n    Sign    ", data.tablaCATs);
                            dataGridView.DataSource = filteredTable; hideColumnsNA(filteredTable);
                            SearchInfoLabel.Text = "Filter packets: " + Convert.ToString(dataGridView.RowCount);
                        }
                        else
                        { SearchTextBox.BackColor = Color.Red; SearchInfoLabel.Text = "No Callsign available"; }
                    }
                    else if (FilterPacketCheckList.SelectedItem.ToString() == "Track Nº") // Filtro Track Number
                    {
                        if (data.listaCATs.Exists(r => r.trackNumber == SearchTextBox.Text))
                        {
                            if (ChainFiltersCheckBox.CheckedItems.Count != 0)
                                obtainFilteredTable("Track\nNumber", filteredTable);
                            else
                                obtainFilteredTable("Track\nNumber", data.tablaCATs);
                            dataGridView.DataSource = filteredTable; hideColumnsNA(filteredTable);
                            SearchInfoLabel.Text = "Filter packets: " + Convert.ToString(dataGridView.RowCount);
                        }
                        else
                        { SearchTextBox.BackColor = Color.Red; SearchInfoLabel.Text = "No Track Number available"; }
                    }
                    else if (FilterPacketCheckList.SelectedItem.ToString() == "ICAO Adress") // Filtro ICAO Adress
                    {
                        if (data.listaCATs.Exists(r => r.ICAOAdress == SearchTextBox.Text))
                        {
                            if (ChainFiltersCheckBox.CheckedItems.Count != 0)
                                obtainFilteredTable("ICAO\nAddress", filteredTable);
                            else
                                obtainFilteredTable("ICAO\nAddress", data.tablaCATs);
                            dataGridView.DataSource = filteredTable; hideColumnsNA(filteredTable);
                            SearchInfoLabel.Text = "Filter packets: " + Convert.ToString(dataGridView.RowCount);
                        }
                        else
                        { SearchTextBox.BackColor = Color.Red; SearchInfoLabel.Text = "No ICAO Adress available"; }
                    }
                    else if (FilterPacketCheckList.SelectedItem.ToString() == "Mode 3/A")
                    {
                        if (data.listaCATs.Exists(r => r.mode3A.Reply == SearchTextBox.Text))
                        {
                            if (ChainFiltersCheckBox.CheckedItems.Count != 0)
                                obtainFilteredTable("Mode\n  3/A  ", filteredTable);
                            else
                                obtainFilteredTable("Mode\n  3/A  ", data.tablaCATs);
                            dataGridView.DataSource = filteredTable; hideColumnsNA(filteredTable);
                            SearchInfoLabel.Text = "Filter packets: " + Convert.ToString(dataGridView.RowCount);
                        }
                        else
                        { SearchTextBox.BackColor = Color.Red; SearchInfoLabel.Text = "No Mode 3/A available"; }
                    }
                }
                else // If no check box has been selected
                { SearchInfoLabel.Text = "Select a filter item"; SearchTextBox.BackColor = Color.Red; }
            }
            catch
            { SearchTextBox.BackColor = Color.Red; }
        }

        private void ChainFiltersCheckBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ChainFiltersCheckBox.GetItemChecked(0) && checkedItem)
            {checkedItem = false; ChainFiltersCheckBox.SetSelected(0, false); }
            else
                checkedItem = true;
        }

        public string moreInfoCSV(List<string> selectedDataItemTable, string value)
        {
            for (int i = 0; i < selectedDataItemTable.Count; i += 2)
            {
                value += selectedDataItemTable[i] + ": " + selectedDataItemTable[i + 1];
                if (i < selectedDataItemTable.Count - 2)
                    value += "; ";
            }
            return value;
        }
        public string fillMoreInfoCSV(CATs packet, string value, int dataItem)
        {
            if (value == "Click to see info")
                value = "";
            else if (value.Contains("*"))
                value = value.Substring(0, value.Length - 2) + "; ";
            else if (value == "N/A")
                return value;
            if (dataItem == 10) // Target Report Descriptor
            {
                if (packet.category == "01")
                    value = moreInfoCSV(packet.targetReportDescriptorCAT01.TableTRD, value);
                else if (packet.category == "10")
                    value = moreInfoCSV(packet.targetReportDescriptorCAT10.TableTRD, value);
                else if (packet.category == "21")
                {
                    if (packet.V023)
                        value = moreInfoCSV(packet.targetReportDescriptorCAT21V023.TableTRD, value);
                    else if (packet.V21)
                        value = moreInfoCSV(packet.targetReportDescriptorCAT21V21.TableTRD, value);
                }
                else if (packet.category == "48")
                    value = moreInfoCSV(packet.targetReportDescriptorCAT48.TableTRD, value);
            }
            else if (dataItem == 17 && (packet.category == "01" || packet.category == "10" || packet.category == "48")) // Flight Level
                value = moreInfoCSV(packet.flightLevel.TableFL, value);
            else if(dataItem == 20 && packet.category == "21") // Selected Altitude
                value = moreInfoCSV(packet.selectedAltitude.TableSA, value);
            else if(dataItem == 8 && (packet.category == "01" || packet.category == "10" || packet.category == "48" || packet.category == "62")) // Mode 3/A
                value = moreInfoCSV(packet.mode3A.TableM3A, value);
            else if (dataItem == 27 && packet.category == "48") // Radar Plot Characteristics
                value = moreInfoCSV(packet.radarPlotCharacteristics.TableRPC, value);
            else if (dataItem == 30 && packet.category == "08") // Vector Qualifier
                value = moreInfoCSV(packet.vectorQualifier.TableVQ, value);
            else if (dataItem == 42) // Track Status
            {
                if (packet.category == "10")
                    value = moreInfoCSV(packet.trackStatusCAT10.TableTS, value);
                else if (packet.category == "48")
                    value = moreInfoCSV(packet.trackStatusCAT48.TableTS, value);
                else if (packet.category == "62")
                    value = moreInfoCSV(packet.trackStatusCAT62.TableTS, value);
            }
            else if (dataItem == 43 && packet.category == "10") // System Status
                value = moreInfoCSV(packet.systemStatus.TableSS, value);
            else if (dataItem == 44 && packet.category == "08") // Sequence of Polar Vectors
            {
                for (int i = 0; i < packet.sequencePolarVectors.TableSPV.Count; i += 3)
                { 
                    value += "Start Range: " + packet.sequencePolarVectors.TableSPV[i] + "; End Range: " + packet.sequencePolarVectors.TableSPV[i + 1] + "; Azimuth: " + packet.sequencePolarVectors.TableSPV[i + 2];
                    if (i < packet.sequencePolarVectors.TableSPV.Count - 3)
                        value += "; ";
                } 
            }
            else if (dataItem == 45 && packet.category == "21" && packet.V023) // Link Technology
                value = moreInfoCSV(packet.linkTechnology.TableLT, value);
            else if (dataItem == 46 && packet.category == "21" && packet.V21) // Quality Indicators
                value = moreInfoCSV(packet.qualityIndicators.TableQI, value);
            else if (dataItem == 47 && packet.category == "21" && packet.V21) // MOPS version
                value = moreInfoCSV(packet.MOPSversion.TableMOPS, value);
            else if (dataItem == 48 && packet.category == "21" && packet.V21) // Target Status
                value = moreInfoCSV(packet.targetStatusV21.TableTargetStatus, value);
            else if (dataItem == 49 && packet.category == "21" && packet.V21) // Aircraft Operational Status
                value = moreInfoCSV(packet.aircraftOperationalStatus.TableAOS, value);
            else if (dataItem == 50 && packet.category == "21" && packet.V21) // Surface Capabilities & Characteristics
                value = moreInfoCSV(packet.surfaceCapabilitiesAndCharacteristics.TableSCC, value);
            else if (dataItem == 51 && ((packet.category == "21" && packet.V21) || packet.category == "62")) // Data Ages
            {
                if (packet.category == "21") { value = moreInfoCSV(packet.dataAges.TableDA, value); }
                if (packet.category == "62") { value = moreInfoCSV(packet.trackDataAges.TableTDA, value); }
            }
            else if (dataItem == 52 && packet.category == "34") // System Configuration and Status   
                value = moreInfoCSV(packet.systemConfigurationStatus.TableSCS, value);
            else if (dataItem == 53 && packet.category == "34") // System Processing Mode   
                value = moreInfoCSV(packet.systemProcessingMode.TableSPM, value);
            else if (dataItem == 54 && (packet.category == "10" || (packet.category == "21" && packet.V21) || packet.category == "48")) // Mode S MB Data  
                value = moreInfoCSV(packet.modeS_MBData.TableMBD, value);
            else if (dataItem == 55 && packet.category == "48") // ACAS Capability & Flight Status
                value = moreInfoCSV(packet.ACAS_CapabilitiesFlightStatus.TableACAS_CFS, value);
            else if (dataItem == 56 && packet.category == "62") // Aircraft Derived Data
                value = moreInfoCSV(packet.aircraftDerivedData.TableADD, value);
            else if (dataItem == 57 && packet.category == "62") // System Track Update Ages
                value = moreInfoCSV(packet.systemTrackUpdateAges.TableSTUA, value);
            else if (dataItem == 58 && packet.category == "62") // Mode of Movement
                value = moreInfoCSV(packet.modeOfMovement.TableMoM, value);
            else if (dataItem == 59 && packet.category == "62") // Flight Plan Related Data
                value = moreInfoCSV(packet.flightPlanRelatedData.TableFPRD, value);
            else if (dataItem == 60 && packet.category == "62") // Measured Information
                value = moreInfoCSV(packet.measuredInformation.TableMI, value);
            else if (dataItem == 61 && packet.category == "21" && packet.V023) // Figure of Merit      
                value = moreInfoCSV(packet.figureOfMerit.TableFM, value);
            else if (dataItem == 62 && (packet.category == "01" || packet.category == "48" || packet.category == "62")) // Mode 2   
                value = moreInfoCSV(packet.mode2.TableM2, value);
            else if (dataItem == 63 && packet.category == "48") // Radial Doppler Speed  
                value = moreInfoCSV(packet.radialDopplerSpeed.TableSCS, value);
            else if (dataItem == 66 && packet.category == "01") // Presence of X-Pulse   
                value = moreInfoCSV(packet.presenceX_Pulse.TablePXP, value);
            else if (dataItem == 69 && packet.category == "02") // Message Count Values     
            {
                if (packet.category == "02")
                {
                    for (int i = 0; i < packet.plotCountValues.TablePCV.Count; i += 3)
                    {
                        value += "A: " + packet.plotCountValues.TablePCV[i] + "; IDENT: " + packet.plotCountValues.TablePCV[i + 1] + "; COUNTER: " + packet.plotCountValues.TablePCV[i + 2];
                        if (i < packet.plotCountValues.TablePCV.Count - 3)
                            value += "; ";
                    }
                }
                else if (packet.category == "34")
                    value = moreInfoCSV(packet.plotCountValues.TablePCV, value);
            }
            else if (dataItem == 72 && packet.category == "08") // Sequence of Cartesian Vectors 
            {
                for (int i = 0; i < packet.sequenceCartesianVectors.TableSQV.Count; i += 3)
                {
                    value += "X-COMPONENT: " + packet.sequenceCartesianVectors.TableSQV[i] + "; Y-COMPONENT: " + packet.sequenceCartesianVectors.TableSQV[i + 1] + "; LENGTH: " + packet.sequenceCartesianVectors.TableSQV[i + 2];
                    if (i < packet.sequenceCartesianVectors.TableSQV.Count - 3)
                        value += "; ";
                }
            }
            else if (dataItem == 73 && packet.category == "8") // Contour Identifier   
                value = moreInfoCSV(packet.contourIdentifier.TableCI, value);
            else if (dataItem == 74 && packet.category == "08") // Sequence of Contour Points
            {
                for (int i = 0; i < packet.sequenceContourPoints.TableSCP.Count; i += 2)
                {
                    value += "X(1): " + packet.sequenceContourPoints.TableSCP[i] + "; Y(1): " + packet.sequenceContourPoints.TableSCP[i + 1];
                    if (i < packet.sequenceContourPoints.TableSCP.Count - 2)
                        value += "; ";
                }
            }
            else if (dataItem == 75 && packet.category == "08") // Sequence of Weather Vectors
            {
                for (int i = 0; i < packet.sequenceWeatherVectors.TableSWV.Count; i += 4)
                {
                    value += "X1: " + packet.sequenceWeatherVectors.TableSWV[i] + "; Y1: " + packet.sequenceWeatherVectors.TableSWV[i + 1] + "; X2: " + packet.sequenceWeatherVectors.TableSWV[i + 2] + "; Y2: " + packet.sequenceWeatherVectors.TableSWV[i + 3];
                    if (i < packet.sequenceWeatherVectors.TableSWV.Count - 4)
                        value += "; ";
                }
            }
            else if (dataItem == 79 && packet.category == "10") // Presence
            {
                for (int i = 0; i < packet.presence.TableP.Count; i += 2)
                {
                    value += "DRHO: " + packet.presence.TableP[i] + "; DTHETA: " + packet.presence.TableP[i + 1];
                    if (i < packet.presence.TableP.Count - 2)
                        value += "; ";
                }
            }
            else if (dataItem == 87 && packet.category == "21") // Met Information  
                value = moreInfoCSV(packet.metInformation.TableMI, value);
            else if (dataItem == 88 && packet.category == "21") // Final Selected Altitude 
                value = moreInfoCSV(packet.finalSelectedAltitude.TableFSA, value);
            else if (dataItem == 89 && packet.category == "21") // Trajectory Intent
                value = moreInfoCSV(packet.trajectoryIntentData.TableTID, value);
            else if (dataItem == 93 && packet.category == "21" && packet.V21) // ACAS Resolution Advisory Report
                value = moreInfoCSV(packet.ACAS_ResolutionAdvisoryReport.TableACAS_RAR, value);
            else if (dataItem == 98 && packet.category == "48") // Mode 1
                value = moreInfoCSV(packet.mode1.TableM1, value);
            else if (dataItem == 100 && packet.category == "62") // Mode 5 Data Reports
                value = moreInfoCSV(packet.mode5DataReports.TableM5DR, value);
            else if (dataItem == 101 && packet.category == "62") // Composed Track Number
            {
                for (int i = 0; i < packet.composedTrackNumber.TableCTN.Count; i += 2)
                {
                    value += "System Unit Identification: " + packet.composedTrackNumber.TableCTN[i] + "; System Track Number: " + packet.composedTrackNumber.TableCTN[i + 1];
                    if (i < packet.composedTrackNumber.TableCTN.Count - 2)
                        value += "; ";
                }
            }
            else if (dataItem == 102 && packet.category == "62") // Estimated Accuracies
                value = moreInfoCSV(packet.estimatedAccuracies.TableEA, value);
            value = String.Format("\"{0}\"", value);
            return value;
        }

        private void CSV_Button_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DateTime date = DateTime.Now;
            string downloadFolderPath = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "{374DE290-123F-4565-9164-39C4925E467B}", String.Empty).ToString();
            if (downloadFolderPath.Contains("Pablo Pérez"))
                downloadFolderPath = downloadFolderPath.Replace(" Pérez", "");
            string[] fileNameSplit = data.AsterixFiles[0].fileName.Split('.');
            string nameCSV = date.Year + "-" + date.Month.ToString().PadLeft(2, '0') + "-" + date.Day.ToString().PadLeft(2, '0') + "_" + date.Hour.ToString().PadLeft(2, '0') + "-" + date.Minute.ToString().PadLeft(2, '0') + "-" + date.Second.ToString().PadLeft(2, '0') + "_" + fileNameSplit[0] + ".csv";
            string pathCSV = downloadFolderPath + "\\" + nameCSV;
            StreamWriter sw = new StreamWriter(pathCSV, false, Encoding.UTF8);
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                if (dataGridView.Columns[i].Visible)
                {
                    string header = filteredTable.Columns[i].ColumnName;
                    if (header.Contains("\n"))
                        header = header.Replace("\n", " ");
                    sw.Write(header);
                    if (i < filteredTable.Columns.Count - 1)
                        sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow row in filteredTable.Rows)
            {
                int rowNumber = this.data.listaCATs.FindIndex(r => r.packetNumber == row["Packet\nNº"].ToString());
                CATs packet = this.data.listaCATs[rowNumber];
                for (int dataItem = 0; dataItem < dataGridView.Columns.Count; dataItem++)
                {
                    if (dataGridView.Columns[dataItem].Visible)
                    {
                        string value = fillMoreInfoCSV(packet, row[dataItem].ToString(), data.FRNinfoCATs.IndexOf(dataGridView.Columns[dataItem].Name));
                        sw.Write(value);
                        if (dataItem < dataGridView.Columns.Count - 1)
                            sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
            this.Cursor = Cursors.Default;
            string message = "CSV generated at Download Folder!\nWould you like to open the file?";
            string caption = "Open CSV";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                System.Diagnostics.Process.Start(pathCSV);
        }
    }
}