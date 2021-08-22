using System;
using System.Windows.Forms;
using System.Runtime.InteropServices; // Move window
using ClassLibrary;

namespace AsterixDecoder
{
    public partial class Exit : Form
    {
        public string message;
        public AsterixData data; 
        public AsterixFile file;
        public Boolean yesPressed = false;

        public Exit(string message)
        {
            InitializeComponent();
            // Remove form border so the Resize function is not lost
            this.Text = string.Empty; this.ControlBox = false;
            this.message = message;
            if (message == "Exit Program")
                ExitLabel.Text = "Are you sure you want to exit?";
            else if (message == "Clear Files")
            { ExitLabel.Text = "Are you sure you want to clear all files?"; ExitLabel.Left -= 40; }
        }


        // Move window
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void YesExitButton_Click(object sender, EventArgs e)
        {
            if (message == "Exit Program")
                Application.Exit(); 
            else if (message == "Clear Files")
            { this.yesPressed = true; this.Close(); }
        }

        private void NoExitButton_Click(object sender, EventArgs e)
        { this.Close(); }

        private void CloseButton_Click(object sender, EventArgs e)
        { this.Close(); }

        // Move window
        private void HeaderBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
