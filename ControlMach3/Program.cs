using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;



static class Program
{


    //[DllImport("user32.dll")]
    //static extern bool SwitchToThisWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    static extern bool SetForegroundWindow(IntPtr hWnd);

  

    /// <summary>
    /// The main entry point for the application.
    /// </summary>

    [STAThread]
    static void Main()
    {

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new ControlMach3.Form1());


    }

}
