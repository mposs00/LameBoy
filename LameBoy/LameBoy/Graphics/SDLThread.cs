using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace LameBoy.Graphics
{
    class SDLThread : IRenderThread
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr child, IntPtr newParent);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string className, string windowName);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool ShowWindow(IntPtr handle, uint command);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetWindowPos(IntPtr handle, IntPtr handleAfter, int x, int y, int cx, int cy, uint flags);

        GameBoy owner;
        bool running;

        private SDLRuntime _runtime;
        private Thread _thread;
        public SDLRuntime Runtime { get { return _runtime; } private set { _runtime = value; } }
        IRenderRuntime IRenderThread.Runtime { get { return _runtime; } }

        public SDLThread(IntPtr Handle, IntPtr pgHandle, GameBoy owner)
        {
            this.owner = owner;
            Runtime = new SDLRuntime(owner);

            _thread = new Thread(new ThreadStart(Runtime.Initialize));
            _thread.Start();

            IntPtr rtHandle = Runtime.Handle;
            //Debug.WriteLine(rtHandle);

            SetWindowPos(rtHandle, Handle, 0, 0, 0, 0, 0x0401); //0x400 = SHOWWINDOW
            SetParent(rtHandle, pgHandle);
            ShowWindow(rtHandle, 1);
            running = true;
        }

        public void Render()
        {
            Stopwatch time = new Stopwatch();
            int extraTime = 0;
            while (running)
            {
                time.Start();
                Runtime.Render();
                time.Stop();
                extraTime = (int) (16 - time.ElapsedMilliseconds);
                if (extraTime > 0)
                    Thread.Sleep(extraTime);
                time.Reset();
                //Console.WriteLine(extraTime);
            }
        }

        public void Terminate()
        {
            running = false;
            Runtime.Destroy();
        }
    }
}
