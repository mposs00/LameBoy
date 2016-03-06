using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace LameBoy.Graphics
{
    class SDLThread
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr child, IntPtr newParent);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string className, string windowName);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool ShowWindow(IntPtr handle, uint command);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetWindowPos(IntPtr handle, IntPtr handleAfter, int x, int y, int cx, int cy, uint flags);

        SDLRuntime rt = new SDLRuntime();

        public SDLThread(IntPtr Handle, IntPtr pgHandle)
        {
            rt = new Graphics.SDLRuntime();
            rt.Initialize();

            IntPtr rtHandle = rt.Handle;
            //Debug.WriteLine(rtHandle);

            SetWindowPos(rtHandle, Handle, 0, 0, 0, 0, 0x0401); //0x400 = SHOWWINDOW
            SetParent(rtHandle, pgHandle);
            ShowWindow(rtHandle, 1);
        }

        public void Render()
        {
            Stopwatch time = new Stopwatch();
            int extraTime = 0;
            while (true)
            {
                time.Start();
                rt.Render();
                time.Stop();
                extraTime = (int) (16 - time.ElapsedMilliseconds);
                if (extraTime > 0)
                    Thread.Sleep(extraTime);
                time.Reset();
                //Console.WriteLine(extraTime);
            }
        }
    }
}
