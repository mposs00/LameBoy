using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using static SDL2.SDL;

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

        public IntPtr Window { get; private set; }
        public IntPtr Surface { get; private set; }
        public IntPtr Handle
        {
            get
            {
                SDL_SysWMinfo wminfo = new SDL_SysWMinfo();
                SDL_GetWindowWMInfo(Window, ref wminfo);

                return wminfo.info.win.window;
            }
        }
        public IntPtr Renderer;
        public byte[,] Pixels { get; set; }
        public int Scale { get; set; } = 5;

        public SDLThread(IntPtr Handle, IntPtr pgHandle, GameBoy owner)
        {
            this.owner = owner;

            int success = SDL_Init(SDL_INIT_VIDEO);
            if (success < 0)
                throw new SDLException();

            Window = SDL_CreateWindow("LameBoy", SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, 800, 720, SDL_WindowFlags.SDL_WINDOW_BORDERLESS);
            if (Window == null)
                throw new SDLException();

            IntPtr rtHandle = this.Handle;

            Surface = SDL_GetWindowSurface(Window);
            Renderer = SDL_GetRenderer(Window);

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
                Draw();
                time.Stop();
                extraTime = (int) (16 - time.ElapsedMilliseconds);
                if (extraTime > 0)
                    Thread.Sleep(extraTime);
                time.Reset();
                //Console.WriteLine(extraTime);
            }
            CleanupSDL();
        }

        void Draw()
        {
            //while(CPUexecuting){ }
            while (owner.GPU.drawing) { }

            SDL_Surface surf = (SDL_Surface)Marshal.PtrToStructure(Surface, typeof(SDL_Surface));

            if (Pixels == null)
                return;

            for (int y = 0; y < 144; y++)
            {
                for (int x = 0; x < 160; x++)
                {
                    byte r, g, b;
                    if (Pixels[x, y] == 0)
                    {
                        r = Palette.blankR;
                        g = Palette.blankG;
                        b = Palette.blankB;
                    }
                    else if (Pixels[x, y] == 1)
                    {
                        r = Palette.lightR;
                        g = Palette.lightG;
                        b = Palette.lightB;
                    }
                    else if (Pixels[x, y] == 2)
                    {
                        r = Palette.darkR;
                        g = Palette.darkG;
                        b = Palette.darkB;
                    }
                    else
                    {
                        r = Palette.solidR;
                        g = Palette.solidG;
                        b = Palette.solidB;
                    }
                    var rect = new SDL_Rect { x = x * Scale, y = y * Scale, w = Scale, h = Scale };
                    SDL_FillRect(Surface, ref rect, SDL_MapRGBA(surf.format, r, g, b, 255));
                }
            }
            SDL_UpdateWindowSurface(Window);
        }

        public void Terminate()
        {
            running = false;
        }

        void CleanupSDL()
        {
            SDL_FreeSurface(Surface);
            SDL_DestroyWindow(Window);
            SDL_Quit();
        }
    }
}
