using System;
using System.Runtime.InteropServices;
using System.Threading;
using static SDL2.SDL;

namespace LameBoy.Graphics
{
    public class SDLRuntime
    {
        GPU gpu;
        public IntPtr Window { get; private set; }
        public IntPtr Surface { get; private set; }
        public IntPtr Handle {
            get
            {
                SDL_SysWMinfo wminfo = new SDL_SysWMinfo { };
                SDL_GetWindowWMInfo(Window, ref wminfo);

                return wminfo.info.win.window;
            }
        }
        public IntPtr Renderer;
        public byte[,] pixels;
        public int scale = 5;
        public bool CPUexecuting = false;

        public SDLRuntime(GPU gpu)
        {
            this.gpu = gpu;
        }

        public void Initialize()
        {
            int success = SDL_Init(SDL_INIT_EVERYTHING);
            if (success < 0)
                throw new SDLException();

            Window = SDL_CreateWindow("LameBoy", SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, 800, 720, SDL_WindowFlags.SDL_WINDOW_BORDERLESS);
            if (Window == null)
                throw new SDLException();

            Surface = SDL_GetWindowSurface(Window);
            Renderer = SDL_GetRenderer(Window);
        }

        public void SetPixels(byte[,] source)
        {
            pixels = source;
        }

        public void Render()
        {
            while(CPUexecuting){ }
            while (gpu.drawing) { }

            SDL_Surface surf = (SDL_Surface)Marshal.PtrToStructure(Surface, typeof(SDL_Surface));

            if (pixels == null)
                return;

            for (int y = 0; y < 144; y++)
            {
                for(int x = 0; x < 160; x++)
                {
                    byte r, g, b;
                    if (pixels[x, y] == 0)
                    {
                        r = Palette.blankR;
                        g = Palette.blankG;
                        b = Palette.blankB;
                    }
                    else if (pixels[x, y] == 1)
                    {
                        r = Palette.lightR;
                        g = Palette.lightG;
                        b = Palette.lightB;
                    }
                    else if (pixels[x, y] == 2)
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
                    var rect = new SDL_Rect { x = x * scale, y = y * scale, w = scale, h = scale };
                    SDL_FillRect(Surface, ref rect, SDL_MapRGBA(surf.format, r, g, b, 255));
                }
                gpu.UpdateYCounter((byte) y);
            }
            //VBlank Lines
            for(byte y = 143; y < 155; y++)
            {
                gpu.UpdateYCounter(y);
            }
            SDL_UpdateWindowSurface(Window);
        }

        public void Destroy()
        {
            SDL_FreeSurface(Surface);
            SDL_DestroyWindow(Window);
            SDL_Quit();
        }
    }
}
