using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices; // Move Window

namespace AsterixDecoder
{
    public partial class MoreInformation : Form
    {
        public DataTable MoreInfoTable;
        public List<double> TableDimensions;
        public int selectedDataItem;

        public MoreInformation()
        {
            InitializeComponent();
            // Remove border from the form so the Resize function is not lost
            this.Text = string.Empty;
            this.ControlBox = false;
        }
        // Move Window
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public void setMoreInfoTabla(DataTable MoreInfoTable, List<double> TableDimensions, int selectedDataItem)
        { this.MoreInfoTable = MoreInfoTable; this.TableDimensions = TableDimensions; this.selectedDataItem = selectedDataItem; }

        private void MoreInformation_Load(object sender, EventArgs e)
        {
            try 
            {
                if (TableDimensions.Count != 0)
                    Size = new Size(Convert.ToInt32(TableDimensions[0]), Convert.ToInt32(TableDimensions[1]));
                dataGridViewMoreInfo.DataSource = MoreInfoTable;
                dataGridViewMoreInfo.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
                dataGridViewMoreInfo.ColumnHeadersDefaultCellStyle.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular);
                dataGridViewMoreInfo.DefaultCellStyle.Font = new Font("Bahnschrift Light", 10F, FontStyle.Regular);
                dataGridViewMoreInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewMoreInfo.DefaultCellStyle.ForeColor = Color.Black;
                dataGridViewMoreInfo.EnableHeadersVisualStyles = false;
                dataGridViewMoreInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                
                foreach (DataGridViewColumn column in dataGridViewMoreInfo.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                if (selectedDataItem == 54) // Mode S MB Data
                {
                    foreach (DataGridViewRow row in dataGridViewMoreInfo.Rows)
                    {
                        if (row.Cells[0].Value.ToString().Contains("BDS"))
                            row.DefaultCellStyle.Font = new Font("Bahnschrift Condensed", 10F, FontStyle.Regular);
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        { this.Close(); }

        // Move Window
        private void HeaderBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void MoreInformation_Shown(object sender, EventArgs e)
        { dataGridViewMoreInfo.ClearSelection();}
    }
}
