using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;


namespace ControlMach3
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            activateMach3Window();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = false;

            // Process input if the user clicked OK.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Open the selected file to read.
                string fn = openFileDialog1.FileName;
                loadAndRunGCode(fn);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            stopActiveGCode();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please provide Saieed with Keyboard shortcut for Homing function to include it. Thank you!");
        }
        static void activateMach3Window()
        {
            Process[] p = Process.GetProcessesByName("Mach3");
            // Activate the first application we find with this name
            SetForegroundWindow(p[0].MainWindowHandle); // Go to Mach3 Window
        }

        static void loadAndRunGCode(string GcodeFilePath_s)
        {
            activateMach3Window();
            Thread.Sleep(100);
            InputSimulator IS = new InputSimulator();
            IS.Keyboard.ModifiedKeyStroke(WindowsInput.Native.VirtualKeyCode.MENU, WindowsInput.Native.VirtualKeyCode.VK_F);
            //IS.Keyboard.KeyPress(VirtualKeyCode.DOWN);
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);

            // Load G-Code file located at GcodeFilePath_s
            Thread.Sleep(300);
            //IS.Keyboard.TextEntry("C:\\Mach3\\GCode\\shapes.tap");
            IS.Keyboard.TextEntry(GcodeFilePath_s);
            Thread.Sleep(100);
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
        }

        static void runActiveGCode()
        {
            activateMach3Window();
            InputSimulator IS = new InputSimulator();
            // Run G-Code
            Thread.Sleep(150);
            IS.Keyboard.ModifiedKeyStroke(WindowsInput.Native.VirtualKeyCode.MENU, WindowsInput.Native.VirtualKeyCode.VK_R);
        }

        static void stopActiveGCode()
        {
            activateMach3Window();
            InputSimulator IS = new InputSimulator();
            // Stop G-Code
            Thread.Sleep(150);
            IS.Keyboard.ModifiedKeyStroke(WindowsInput.Native.VirtualKeyCode.MENU, WindowsInput.Native.VirtualKeyCode.VK_S);
        }
    }
}
