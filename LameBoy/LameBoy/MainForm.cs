using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LameBoy
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr child, IntPtr newParent);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string className, string windowName);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool ShowWindow(IntPtr handle, uint command);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetWindowPos(IntPtr handle, IntPtr handleAfter, int x, int y, int cx, int cy, uint flags);

        Graphics.SDLRuntime rt;

        public MainForm()
        {
            InitializeComponent();
            Application.Idle += Application_Idle;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            rt = new Graphics.SDLRuntime();
            rt.Initialize();

            IntPtr rtHandle = rt.Handle;
            Debug.WriteLine(rtHandle);

            SetWindowPos(rtHandle, Handle, 0, 0, 0, 0, 0x0401); //0x400 = SHOWWINDOW
            SetParent(rtHandle, panelGraphics.Handle);
            ShowWindow(rtHandle, 1);
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            rt.Render();
        }
    }
}
