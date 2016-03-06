using System;
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

        public unsafe void Render()
        {
            while(CPUexecuting){ }
            SDL_Surface* surfPtr = (SDL_Surface*) Surface.ToPointer();
            SDL_Surface surf = *surfPtr;

            if (pixels == null)
                return;

            for (int y = 0; y < 144; y++)
            {
                for(int x = 0; x < 160; x++)
                {
                    byte color;
                    if (pixels[x, y] == 0)
                        color = 255;
                    else if (pixels[x, y] == 1)
                        color = 196;
                    else if (pixels[x, y] == 2)
                        color = 127;
                    else
                        color = 0;
                    var rect = new SDL_Rect { x = x * scale, y = y * scale, w = scale, h = scale };
                    SDL_FillRect(Surface, ref rect, SDL_MapRGBA(surf.format, color, color, color, 255));
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
